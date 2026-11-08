using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateRelativeNumbersSeries()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateThreeTermsRelativeSeriesQuestion(),
			1 => CreateGroupPositivesAndNegativesQuestion(),
			2 => CreateSimplifiedParenthesesQuestion(),
			_ => CreatePisaDailyBalanceQuestion()
		};
	}

	public ExerciseQuestion GenerateRelativeNumbersMultiplicationDivision()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateMultiplyTwoNegativesQuestion(),
			1 => CreateMultiplyOppositeSignsQuestion(),
			2 => CreateDivideRelativesQuestion(),
			_ => CreatePisaDailyVariationQuestion()
		};
	}

	private ExerciseQuestion CreateThreeTermsRelativeSeriesQuestion()
	{
		var pool = new[]
		{
			(-5, 8, -3, 0),
			(-7, 12, -4, 1),
			(-9, 5, -6, -10),
			(14, -8, -10, -4)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4.ToString();
		var w1 = (item.Item4 + 2).ToString();
		var w2 = (-item.Item4).ToString();
		var w3 = (item.Item4 - 4).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : ({item.Item1}) + (+{item.Item2}) + ({item.Item3})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Effectuez les calculs de gauche à droite ou regroupez les nombres de même signe.",
			HintLevel2 = $"({item.Item1} + {item.Item3}) = {item.Item1 + item.Item3}, puis ajoutez {item.Item2}.",
			ExplanationText = $"La somme de cette suite vaut {item.Item4}."
		};
	}

	private ExerciseQuestion CreateGroupPositivesAndNegativesQuestion()
	{
		var pool = new[]
		{
			("12 - 7 + 8 - 5", "8", "12", "4", "-2"),
			("15 - 9 - 6 + 10", "10", "14", "6", "-4"),
			("20 - 14 + 5 - 3", "8", "12", "5", "2")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Simplifiez et calculez l'expression : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionnez ensemble les termes positifs, puis ensemble les termes négatifs.",
			HintLevel2 = "Faites ensuite la différence entre les deux sommes obtenues.",
			ExplanationText = $"Le résultat de {item.Item1} est égal à {item.Item2}."
		};
	}

	private ExerciseQuestion CreateSimplifiedParenthesesQuestion()
	{
		var pool = new[]
		{
			("-(-8) + (-3) - (+5)", "0", "16", "-10", "6"),
			("-(+12) - (-7) + (+4)", "-1", "23", "-15", "5"),
			("-(-6) - (-4) - (+10)", "0", "20", "-12", "-8")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Supprimez les parenthèses et calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Rappel : -(-a) = +a et -(+a) = -a.",
			HintLevel2 = "Réécrivez sans parenthèses avant d'effectuer les additions et soustractions.",
			ExplanationText = $"Après simplification, le résultat est {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaDailyBalanceQuestion()
	{
		var pool = new[]
		{
			(120, 45, 80, 50, 105),
			(150, 70, 90, 60, 110),
			(200, 85, 50, 45, 120)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item5} €";
		var w1 = $"{item.Item5 + 30} €";
		var w2 = $"{item.Item5 - 20} €";
		var w3 = $"{item.Item1 - item.Item2} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Bilan sur 4 jours : gain de {item.Item1} €, perte de {item.Item2} €, gain de {item.Item3} €, perte de {item.Item4} €. Quel est le solde net ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Solde net = (Total des gains) - (Total des pertes).",
			HintLevel2 = $"Gains : {item.Item1} + {item.Item3} = {item.Item1 + item.Item3} €. Pertes : {item.Item2} + {item.Item4} = {item.Item2 + item.Item4} €.",
			ExplanationText = $"Solde net = ({item.Item1 + item.Item3}) - ({item.Item2 + item.Item4}) = {item.Item5} €."
		};
	}

	private ExerciseQuestion CreateMultiplyTwoNegativesQuestion()
	{
		var a = _random.Next(4, 10);
		var b = _random.Next(3, 9);
		var prod = a * b;
		var correct = prod.ToString();
		var w1 = (-prod).ToString();
		var w2 = (a + b).ToString();
		var w3 = (-(a + b)).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : (-{a}) × (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règle des signes : le produit de deux nombres de même signe est toujours positif.",
			HintLevel2 = $"Moins par moins donne plus : +({a} × {b}).",
			ExplanationText = $"Le produit de deux négatifs est positif : {correct}."
		};
	}

	private ExerciseQuestion CreateMultiplyOppositeSignsQuestion()
	{
		var a = _random.Next(4, 9);
		var b = _random.Next(3, 8);
		var prod = -(a * b);
		var correct = prod.ToString();
		var w1 = (-prod).ToString();
		var w2 = (a - b).ToString();
		var w3 = (b - a).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : (-{a}) × (+{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règle des signes : le produit de deux nombres de signes contraires est toujours négatif.",
			HintLevel2 = $"Moins par plus donne moins : -({a} × {b}).",
			ExplanationText = $"Le produit de signes contraires est négatif : {correct}."
		};
	}

	private ExerciseQuestion CreateDivideRelativesQuestion()
	{
		var b = _random.Next(3, 8);
		var q = _random.Next(4, 10);
		var a = -(b * q);
		var correct = q.ToString();
		var w1 = (-q).ToString();
		var w2 = (q + 2).ToString();
		var w3 = (a + b).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez le quotient : ({a}) ÷ (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le quotient de deux nombres de même signe est positif.",
			HintLevel2 = $"Divisez les distances à zéro : {Math.Abs(a)} ÷ {b}.",
			ExplanationText = $"({a}) ÷ (-{b}) = {q}."
		};
	}

	private ExerciseQuestion CreatePisaDailyVariationQuestion()
	{
		var drop = _random.Next(2, 6);
		var days = _random.Next(4, 8);
		var total = -(drop * days);
		var correct = $"{total} cm";
		var w1 = $"{Math.Abs(total)} cm";
		var w2 = $"{total - 5} cm";
		var w3 = $"-{drop + days} cm";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Le niveau d'un lac baisse régulièrement de {drop} cm par jour pendant {days} jours consécutifs. Quelle est la variation totale ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une baisse correspond à un nombre relatif négatif : Variation = (-baisse) × jours.",
			HintLevel2 = $"Calculez (-{drop}) × {days}.",
			ExplanationText = $"La variation totale est (-{drop}) × {days} = {total} cm."
		};
	}
}

