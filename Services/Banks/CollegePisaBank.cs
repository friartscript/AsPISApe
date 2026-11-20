using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class CollegePisaBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestion(int slot)
	{
		return slot switch
		{
			1 => GenerateRainTankEnigma(),
			2 => GenerateTheoremDefinitionQuestion(),
			3 => GenerateSuccessiveDiscountsEnigma(),
			4 => GenerateMathTrapQuestion(),
			_ => _random.Next(2) == 0 ? GenerateAverageSpeedEnigma() : GenerateWorkersInverseProportionEnigma()
		};
	}

	private ExerciseQuestion GenerateRainTankEnigma()
	{
		var capacity = _random.Next(3, 7) * 20;
		var used = capacity / 2;
		var drained = used / 2;
		var remaining = capacity - drained;

		var correct = $"{remaining} L";
		var w1 = $"{used} L";
		var w2 = $"{capacity - used} L";
		var w3 = $"{remaining - 10} L";

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-TANK-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_reservoir",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Une cuve de {capacity} L est pleine. On vide la moitié de sa moitié. Combien de litres reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La moitié de la moitié équivaut à un quart de la capacité totale.",
			HintLevel2 = $"Un quart de {capacity} L vaut {drained} L. On soustrait : {capacity} - {drained}.",
			ExplanationText = $"Un quart ({drained} L) est vidé, il reste {remaining} L dans la cuve."
		};
	}

	private ExerciseQuestion GenerateTheoremDefinitionQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GeneratePythagoreDefinition(),
			1 => GeneratePrimeNumberDefinition(),
			_ => GenerateThalesCondition()
		};
	}

	private ExerciseQuestion GeneratePythagoreDefinition()
	{
		var correct = "Le triangle doit obligatoirement posséder un angle droit (rectangle).";
		var w1 = "Le triangle doit obligatoirement avoir deux côtés de même longueur.";
		var w2 = "Le triangle doit obligatoirement être inscrit dans un cercle de diamètre quelconque.";
		var w3 = "La somme des trois angles doit être strictement supérieure à 180°.";

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-TH-PYTH-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_pythagore_theorie",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = "Quelle condition fondamentale est indispensable pour appliquer le théorème de Pythagore : a² + b² = c² ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Ce théorème s'applique uniquement aux triangles possédant une forme d'angle spécifique.",
			HintLevel2 = "Cherchez la propriété liée à la perpendicularité de deux côtés.",
			ExplanationText = "Le théorème de Pythagore s'applique uniquement dans un triangle rectangle."
		};
	}

	private ExerciseQuestion GeneratePrimeNumberDefinition()
	{
		var correct = "Un nombre entier qui admet exactement deux diviseurs distincts : 1 et lui-même.";
		var w1 = "Un nombre entier qui se termine toujours par 1, 3, 7 ou 9.";
		var w2 = "Tout nombre impair positif supérieur ou égal à 1.";
		var w3 = "Un nombre qui ne peut être divisé par aucun nombre pair.";

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-TH-PRIME-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_nombre_premier_def",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = "Quelle est la définition mathématique exacte d'un nombre premier ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention au cas particulier de 1 : a-t-il deux diviseurs distincts ?",
			HintLevel2 = "Un nombre premier a exactement deux diviseurs : 1 et le nombre lui-même.",
			ExplanationText = "Un nombre premier admet exactement deux diviseurs distincts : 1 et lui-même."
		};
	}

	private ExerciseQuestion GenerateThalesCondition()
	{
		var correct = "Deux droites sécantes coupées par deux droites parallèles.";
		var w1 = "Deux droites perpendiculaires coupées par une diagonale.";
		var w2 = "Trois points alignés formant un angle obtus.";
		var w3 = "Un cercle circonscrit à un triangle isocèle.";

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-TH-THALES-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_thales_theorie",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = "Dans quelle configuration géométrique peut-on appliquer le théorème de Thalès ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pensez aux alignements de points et à la condition de parallélisme.",
			HintLevel2 = "Deux droites sécantes doivent être coupées par deux droites strictement parallèles.",
			ExplanationText = "Thalès exige deux droites sécantes coupées par deux parallèles."
		};
	}

	private ExerciseQuestion GenerateSuccessiveDiscountsEnigma()
	{
		var initial = 100;
		var r1 = 20;
		var r2 = 20;
		var afterFirst = initial * (100 - r1) / 100;
		var finalPrice = afterFirst * (100 - r2) / 100;
		var totalDiscountPercent = initial - finalPrice;

		var correct = $"{finalPrice} € (soit {totalDiscountPercent} % de réduction)";
		var w1 = $"60 € (soit 40 % de réduction)";
		var w2 = $"70 € (soit 30 % de réduction)";
		var w3 = $"80 € (soit 20 % de réduction)";

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-SOLDES-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_soldes_piege",
			Discipline = "Mixte",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 30,
			QuestionText = $"Un manteau à 100 € est soldé à -{r1} %, puis bénéficie d'une remise supplémentaire de -{r2} % à la caisse. Quel est son prix final ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention au piège : on ne peut jamais additionner les pourcentages de remises successives !",
			HintLevel2 = $"Après -20 %, le manteau coûte {afterFirst} €. La seconde remise de -20 % s'applique sur {afterFirst} €.",
			ExplanationText = $"100 € - 20 % = 80 €. Puis 80 € - 20 % = 64 € (remise réelle de 36 %)."
		};
	}

	private ExerciseQuestion GenerateMathTrapQuestion()
	{
		var n = _random.Next(3, 7);
		var correct = (-n * n).ToString();
		var w1 = (n * n).ToString();
		var w2 = (2 * n).ToString();
		var w3 = (-2 * n).ToString();

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-TRAP-POW-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_puissances_piege",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 30,
			QuestionText = $"Quel est le résultat exact du calcul : -{n}² ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Regardez bien : le signe moins est-il à l'intérieur de parenthèses ou non ?",
			HintLevel2 = $"En l'absence de parenthèses, le carré ne porte que sur {n}. Le calcul est -( {n} × {n} ).",
			ExplanationText = $"Sans parenthèses, le carré ne s'applique qu'au nombre : -{n}² = -({n*n}) = {-n*n}."
		};
	}

	private ExerciseQuestion GenerateAverageSpeedEnigma()
	{
		var correct = "48 km/h";
		var w1 = "50 km/h";
		var w2 = "52 km/h";
		var w3 = "45 km/h";

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-SPEED-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_vitesse_moyenne",
			Discipline = "Mixte",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 50,
			QuestionText = "Un cycliste parcourt un trajet à 60 km/h à l'aller, et revient par la même route à 40 km/h au retour. Quelle est sa vitesse moyenne sur l'ensemble du parcours ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Piège classique : la vitesse moyenne n'est PAS la moyenne des deux vitesses !",
			HintLevel2 = "Vitesse moyenne = Distance totale divisée par Temps total. Le retour dure plus longtemps que l'aller.",
			ExplanationText = "Pour 120 km aller-retour : 1h aller + 1h30 retour = 2h30. 120 / 2,5 = 48 km/h."
		};
	}

	private ExerciseQuestion GenerateWorkersInverseProportionEnigma()
	{
		var workers1 = 3;
		var days1 = 6;
		var workers2 = 6;
		var days2 = (workers1 * days1) / workers2;

		var correct = $"{days2} jours";
		var w1 = "12 jours";
		var w2 = "9 jours";
		var w3 = "4 jours";

		var choices = ShuffleChoices(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-PISA-WORKERS-{_random.Next(1000, 9999)}",
			SubjectId = "pisa_col_proportion_inverse",
			Discipline = "Mixte",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 50,
			QuestionText = $"{workers1} ouvriers réalisent un chantier en {days1} jours. En supposant qu'ils travaillent tous au même rythme, combien de jours mettront {workers2} ouvriers pour faire le même travail ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Plus il y a d'ouvriers sur le chantier, moins de temps il faudra : c'est une proportion inverse.",
			HintLevel2 = "Le travail total représente 3 × 6 = 18 journées de travail. Divisez 18 par 6 ouvriers.",
			ExplanationText = "Travail total = 18 jours-ouvrier. Avec 6 ouvriers : 18 / 6 = 3 jours."
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
