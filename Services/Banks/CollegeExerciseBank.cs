using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class CollegeExerciseBank
{
	private readonly Random _random = new();
	private readonly CollegeMathsBank _mathsBank = new();

	public ExerciseQuestion GenerateQuestion(string discipline, int slot)
	{
		return discipline switch
		{
			"Maths" => GenerateMathQuestion(slot),
			"Francais" => GenerateFrenchQuestion(slot),
			"Mixte" => GeneratePisaMixQuestion(slot),
			_ => _random.Next(2) == 0 ? GenerateMathQuestion(slot) : GenerateFrenchQuestion(slot)
		};
	}

	public IReadOnlyList<ExerciseQuestion> GetBaseQuestions()
	{
		var list = new List<ExerciseQuestion>();
		for (var slot = 1; slot <= 5; slot++)
		{
			list.Add(GenerateMathQuestion(slot));
			list.Add(GenerateFrenchQuestion(slot));
			list.Add(GeneratePisaMixQuestion(slot));
		}
		return list;
	}

	private ExerciseQuestion GenerateMathQuestion(int slot)
	{
		return slot switch
		{
			1 => _mathsBank.GenerateEuclideanDivision(),
			2 => _mathsBank.GenerateMultiplesAndDivisors(),
			3 => _mathsBank.GeneratePrimeNumbersAndFactors(),
			4 => CreatePercentageQuestion(),
			_ => CreatePythagorasQuestion()
		};
	}

	private ExerciseQuestion GenerateFrenchQuestion(int slot)
	{
		return slot switch
		{
			1 => CreateGrammarClassQuestion(),
			2 => CreateHomophonesQuestion(),
			3 => CreateSubjectVerbAgreementQuestion(),
			4 => CreateVerbConjugationQuestion(),
			_ => CreateGrammarFunctionQuestion()
		};
	}

	private ExerciseQuestion CreateEuclideanDivisionQuestion()
	{
		var divisor = _random.Next(6, 13);
		var quotient = _random.Next(5, 16);
		var remainder = _random.Next(1, divisor);
		var dividend = (divisor * quotient) + remainder;

		var correct = remainder.ToString();
		var wrong1 = (remainder + 1).ToString();
		var wrong2 = quotient.ToString();
		var wrong3 = (divisor - 1).ToString();

		var choices = ShuffleChoices(correct, wrong1, wrong2, wrong3, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans la division euclidienne de {dividend} par {divisor}, quel est le reste ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Dividende = (Diviseur × Quotient) + Reste, avec Reste < Diviseur.",
			HintLevel2 = $"Le quotient est {quotient}. Calculez {dividend} - ({divisor} × {quotient}).",
			ExplanationText = $"{dividend} = {divisor} × {quotient} + {remainder}. Le reste est {remainder}."
		};
	}

	private ExerciseQuestion CreateFractionsQuestion()
	{
		var den = _random.Next(3, 9);
		var num1 = _random.Next(1, 5);
		var num2 = _random.Next(1, 5);
		var sumNum = num1 + num2;

		var correct = $"{sumNum}/{den}";
		var wrong1 = $"{sumNum}/{den * 2}";
		var wrong2 = $"{num1 * num2}/{den}";
		var wrong3 = $"{sumNum + 1}/{den}";

		var choices = ShuffleChoices(correct, wrong1, wrong2, wrong3, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_addition",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {num1}/{den} + {num2}/{den}",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Pour additionner des fractions de même dénominateur, on additionne les numérateurs.",
			HintLevel2 = $"Le dénominateur reste {den}. Additionnez simplement {num1} + {num2}.",
			ExplanationText = $"On garde le dénominateur {den} et on additionne {num1} + {num2} = {sumNum}."
		};
	}

	private ExerciseQuestion CreateRelativeNumbersQuestion()
	{
		var a = _random.Next(-9, -2);
		var b = _random.Next(3, 10);
		var result = a + b;

		var correct = result.ToString();
		var wrong1 = (a - b).ToString();
		var wrong2 = (Math.Abs(a) + b).ToString();
		var wrong3 = (-result).ToString();

		var choices = ShuffleChoices(correct, wrong1, wrong2, wrong3, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_addition",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : ({a}) + ({b})",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "On prend le signe du nombre qui a la plus grande distance à zéro.",
			HintLevel2 = $"La différence entre {b} et {Math.Abs(a)} donne le résultat.",
			ExplanationText = $"({a}) + ({b}) = {result}."
		};
	}

	private ExerciseQuestion CreatePercentageQuestion()
	{
		var price = _random.Next(2, 9) * 10;
		var percent = 20;
		var discount = (price * percent) / 100;
		var finalPrice = price - discount;

		var correct = $"{finalPrice} €";
		var wrong1 = $"{finalPrice - 5} €";
		var wrong2 = $"{price - percent} €";
		var wrong3 = $"{finalPrice + 4} €";

		var choices = ShuffleChoices(correct, wrong1, wrong2, wrong3, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-{Guid.NewGuid():N}",
			SubjectId = "maths_col_pourcentages",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Un vêtement à {price} € bénéficie d'une remise de 20 %. Quel est son prix final ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Calculer 20 % revient à multiplier par 0,20 puis soustraire la remise.",
			HintLevel2 = $"La remise est de {discount} €. Soustrayez {discount} € à {price} €.",
			ExplanationText = $"Remise = {price} × 0,20 = {discount} €. Prix final = {finalPrice} €."
		};
	}

	private ExerciseQuestion CreatePythagorasQuestion()
	{
		var triplets = new[] { (3, 4, 5), (6, 8, 10), (5, 12, 13) };
		var pick = triplets[_random.Next(triplets.Length)];

		var correct = $"{pick.Item3} cm";
		var wrong1 = $"{pick.Item1 + pick.Item2} cm";
		var wrong2 = $"{pick.Item3 + 2} cm";
		var wrong3 = $"{pick.Item3 - 1} cm";

		var choices = ShuffleChoices(correct, wrong1, wrong2, wrong3, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-{Guid.NewGuid():N}",
			SubjectId = "maths_col_pythagore",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Dans un triangle rectangle, les côtés de l'angle droit mesurent {pick.Item1} cm et {pick.Item2} cm. Que vaut l'hypoténuse ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Théorème de Pythagore : Hypoténuse² = Côté1² + Côté2².",
			HintLevel2 = $"{pick.Item1}² + {pick.Item2}² = {pick.Item1 * pick.Item1} + {pick.Item2 * pick.Item2} = {pick.Item3 * pick.Item3}.",
			ExplanationText = $"L'hypoténuse vaut la racine carrée de {pick.Item3 * pick.Item3}, soit {pick.Item3} cm."
		};
	}

	private ExerciseQuestion CreateGrammarClassQuestion()
	{
		var pool = new[]
		{
			("rapidement", "Un adverbe", "Un adjectif qualificatif", "Un verbe", "Un nom commun"),
			("magnifique", "Un adjectif qualificatif", "Un adverbe", "Un pronom", "Une préposition"),
			("pendant", "Une préposition", "Un adverbe", "Une conjonction", "Un nom commun"),
			("ils", "Un pronom personnel", "Un déterminant", "Un nom", "Un adjectif")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = ShuffleChoices(item.Item2, item.Item3, item.Item4, item.Item5, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-{Guid.NewGuid():N}",
			SubjectId = "francais_col_classes_mots",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est la classe grammaticale du mot « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Pensez au rôle du mot dans la phrase (qualifie un nom, modifie un verbe, etc.).",
			HintLevel2 = $"Le mot « {item.Item1} » est invariable ou désigne une catégorie précise.",
			ExplanationText = $"« {item.Item1} » est {item.Item2.ToLowerInvariant()}."
		};
	}

	private ExerciseQuestion CreateHomophonesQuestion()
	{
		var pool = new[]
		{
			("Il ___ parti ce matin à l'aube.", "est", "et", "es", "ai", "On peut remplacer par « était »."),
			("Lucas ___ Maxime jouent au football.", "et", "est", "es", "ai", "On peut remplacer par « et puis »."),
			("Elle a oublié ___ cahier de cours.", "son", "sont", "s'ont", "sommes", "On peut remplacer par « mon ».")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = ShuffleChoices(item.Item2, item.Item3, item.Item4, item.Item5, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-{Guid.NewGuid():N}",
			SubjectId = "francais_col_homophones",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Complétez la phrase : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = item.Item6,
			HintLevel2 = $"Testez la substitution à l'oral avec l'imparfait.",
			ExplanationText = $"La bonne graphie est « {item.Item2} »."
		};
	}

	private ExerciseQuestion CreateSubjectVerbAgreementQuestion()
	{
		var pool = new[]
		{
			("Les vagues de l'océan (frapper) ___ la falaise.", "frappent", "frappe", "frappes", "frappant", "Le sujet est « Les vagues » (pluriel)."),
			("Le chant des oiseaux nous (réveiller) ___ tôt.", "réveille", "réveillent", "réveilles", "réveillant", "Le sujet est « Le chant » (singulier)."),
			("La liste des fournitures (être) ___ prête.", "est", "sont", "es", "étant", "Le sujet est « La liste » (singulier).")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = ShuffleChoices(item.Item2, item.Item3, item.Item4, item.Item5, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-{Guid.NewGuid():N}",
			SubjectId = "francais_col_accord_sujet_verbe",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quel est l'accord correct du verbe : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Identifiez précisément le noyau du groupe sujet (ignorez le complément du nom).",
			HintLevel2 = item.Item6,
			ExplanationText = $"Le verbe s'accorde avec le noyau du sujet : « {item.Item2} »."
		};
	}

	private ExerciseQuestion CreateVerbConjugationQuestion()
	{
		var pool = new[]
		{
			("Soudain, la porte s'___ (ouvrir, passé simple).", "ouvrit", "ouvrait", "ouvra", "ouvrira"),
			("Tous les soirs, il ___ (lire, imparfait) un conte.", "lisait", "lut", "lira", "liserait"),
			("Si j'avais le temps, je ___ (venir, conditionnel présent).", "viendrais", "viendrait", "venais", "viendrai")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = ShuffleChoices(item.Item2, item.Item3, item.Item4, item.Item5, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-{Guid.NewGuid():N}",
			SubjectId = "francais_col_conjugaison",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Complétez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Faites attention à la valeur temporelle (action soudaine vs habitude).",
			HintLevel2 = $"La terminaison attendue correspond à la 3e personne du singulier.",
			ExplanationText = $"La forme correcte est « {item.Item2} »."
		};
	}

	private ExerciseQuestion CreateGrammarFunctionQuestion()
	{
		var pool = new[]
		{
			("Élodie offre un bouquet à sa grand-mère.", "à sa grand-mère", "Complément d'objet indirect (COI)", "Complément d'objet direct (COD)", "Sujet", "Attribut du sujet"),
			("Le vieux professeur paraît fatigué.", "fatigué", "Attribut du sujet", "Complément d'objet direct (COD)", "Épithète", "Complément circonstanciel"),
			("Lucas range sa chambre avec soin.", "sa chambre", "Complément d'objet direct (COD)", "Complément d'objet indirect (COI)", "Sujet", "Attribut")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = ShuffleChoices(item.Item3, item.Item4, item.Item5, item.Item6, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-{Guid.NewGuid():N}",
			SubjectId = "francais_col_fonctions",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Dans la phrase « {item.Item1} », quelle est la fonction du groupe « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Posez la question : qui/quoi ? ou à qui/à quoi ? après le verbe.",
			HintLevel2 = $"Ce groupe complète directement ou indirectement le verbe de la proposition.",
			ExplanationText = $"« {item.Item2} » a pour fonction : {item.Item3}."
		};
	}

	private ExerciseQuestion GeneratePisaMixQuestion(int slot)
	{
		var capacity = _random.Next(3, 7) * 10;
		var used = capacity / 2;
		var remaining = capacity - used;

		var correct = $"{remaining} L";
		var wrong1 = $"{capacity + used} L";
		var wrong2 = $"{remaining - 5} L";
		var wrong3 = $"{used + 5} L";

		var choices = ShuffleChoices(correct, wrong1, wrong2, wrong3, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-PISA-COL-{Guid.NewGuid():N}",
			SubjectId = "pisa_col_lecture_calcul",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Un réservoir d'eau de pluie de {capacity} L est rempli à moitié. On en prélève la moitié du contenu. Combien de litres d'eau reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Calculez d'abord la moitié du réservoir, puis enlevez la quantité prélevée.",
			HintLevel2 = $"À moitié plein = {used} L. On retire la moitié de {used} L, soit {used / 2} L.",
			ExplanationText = $"Moitié = {used} L. Moitié prélevée = {used / 2} L. Il reste {used - (used / 2)} L."
		};
	}

	private List<string> ShuffleChoices(string correct, string w1, string w2, string w3, out int correctIndex)
	{
		var list = new List<string> { correct, w1, w2, w3 };
		var n = list.Count;
		while (n > 1)
		{
			n--;
			var k = _random.Next(n + 1);
			(list[k], list[n]) = (list[n], list[k]);
		}
		correctIndex = list.IndexOf(correct);
		return list;
	}
}
