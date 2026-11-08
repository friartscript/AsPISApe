using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateDoubleDistributivityAndIdentities()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateDoubleDistributivityQuestion(),
			1 => CreateFirstRemarkableIdentityQuestion(),
			2 => CreateSecondOrThirdIdentityQuestion(),
			_ => CreatePisaAreaExtensionAlgebraicQuestion()
		};
	}

	public ExerciseQuestion GenerateFactorization()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateCommonFactorIntegerQuestion(),
			1 => CreateCommonFactorVariableQuestion(),
			2 => CreateFactorRemarkableDifferenceOfSquaresQuestion(),
			_ => CreatePisaFactorizedCostCalculationQuestion()
		};
	}

	private ExerciseQuestion CreateDoubleDistributivityQuestion()
	{
		var pool = new[]
		{
			("(x + 2)(x + 5)", "x² + 7x + 10", "x² + 10x + 7", "x² + 7x + 7", "2x + 7"),
			("(2x + 3)(x + 4)", "2x² + 11x + 12", "2x² + 7x + 12", "2x² + 11x + 7", "3x + 7"),
			("(x - 3)(x + 4)", "x² + x - 12", "x² - x - 12", "x² + 7x - 12", "x² - 12")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S24-{Guid.NewGuid():N}",
			SubjectId = "maths_col_double_distributivite",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Développez et réduisez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez la double distributivité : (a + b)(c + d) = ac + ad + bc + bd.",
			HintLevel2 = "Multipliez chaque terme de la 1ère parenthèse par chaque terme de la 2nde.",
			ExplanationText = $"{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreateFirstRemarkableIdentityQuestion()
	{
		var pool = new[]
		{
			("(x + 3)²", "x² + 6x + 9", "x² + 9", "x² + 3x + 9", "2x + 6"),
			("(2x + 5)²", "4x² + 20x + 25", "4x² + 25", "4x² + 10x + 25", "2x² + 20x + 25"),
			("(x + 7)²", "x² + 14x + 49", "x² + 49", "x² + 7x + 49", "2x + 14")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S24-{Guid.NewGuid():N}",
			SubjectId = "maths_col_double_distributivite",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Développez à l'aide d'une identité remarquable : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Première identité remarquable : (a + b)² = a² + 2ab + b².",
			HintLevel2 = "N'oubliez pas le double produit central (2 × a × b).",
			ExplanationText = $"{item.Item1} développé donne {item.Item2}."
		};
	}

	private ExerciseQuestion CreateSecondOrThirdIdentityQuestion()
	{
		var pool = new[]
		{
			("(x - 4)²", "x² - 8x + 16", "x² - 16", "x² + 8x + 16", "x² - 8x - 16"),
			("(x - 5)(x + 5)", "x² - 25", "x² + 25", "x² - 10x - 25", "2x - 25"),
			("(3x - 2)(3x + 2)", "9x² - 4", "9x² + 4", "6x² - 4", "9x² - 12x - 4")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S24-{Guid.NewGuid():N}",
			SubjectId = "maths_col_double_distributivite",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Développez l'expression : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Identités : (a - b)² = a² - 2ab + b² et (a - b)(a + b) = a² - b².",
			HintLevel2 = "Pour (a - b)(a + b), les doubles produits s'annulent.",
			ExplanationText = $"{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaAreaExtensionAlgebraicQuestion()
	{
		var pool = new[]
		{
			(3, 2, "x² + 5x + 6", "x² + 6", "2x + 5"),
			(4, 1, "x² + 5x + 4", "x² + 4", "2x + 5"),
			(5, 2, "x² + 7x + 10", "x² + 10", "2x + 7")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item3;
		var w1 = item.Item4;
		var w2 = item.Item5;
		var w3 = "x² + 15";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S24-{Guid.NewGuid():N}",
			SubjectId = "maths_col_double_distributivite",
			Discipline = "Mixte",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Un terrain carré de côté x est agrandi de {item.Item1} m d'un côté et de {item.Item2} m de l'autre ((x + {item.Item1})(x + {item.Item2})). Quelle est sa nouvelle aire ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Nouvelle aire = (x + {item.Item1}) × (x + {item.Item2}). Développez ce produit.",
			HintLevel2 = "x² + {item.Item2}x + {item.Item1}x + ({item.Item1} × {item.Item2}).",
			ExplanationText = $"L'aire développée est {correct}."
		};
	}

	private ExerciseQuestion CreateCommonFactorIntegerQuestion()
	{
		var pool = new[]
		{
			("6x + 15", "3(2x + 5)", "3(2x + 15)", "6(x + 2)", "x(6 + 15)"),
			("12x - 8", "4(3x - 2)", "4(3x - 8)", "2(6x - 2)", "8(x - 1)"),
			("14x + 21", "7(2x + 3)", "7(2x + 21)", "14(x + 1)", "21(x + 1)")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S25-{Guid.NewGuid():N}",
			SubjectId = "maths_col_factorisation",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Factorisez l'expression en trouvant le plus grand facteur commun numérique : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Trouvez le plus grand commun diviseur (PGCD) des coefficients numériques.",
			HintLevel2 = "Écrivez ce nombre devant la parenthèse et divisez chaque terme par ce nombre.",
			ExplanationText = $"{item.Item1} factorisé donne {item.Item2}."
		};
	}

	private ExerciseQuestion CreateCommonFactorVariableQuestion()
	{
		var pool = new[]
		{
			("x² + 5x", "x(x + 5)", "x(x + 1)", "5(x² + 1)", "(x + 5)²"),
			("3x² - 7x", "x(3x - 7)", "3x(x - 7)", "x(3x + 7)", "7x(3x - 1)"),
			("2x² + 6x", "2x(x + 3)", "2(x² + 3x)", "x(2x + 6)", "6x(x + 1)")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S25-{Guid.NewGuid():N}",
			SubjectId = "maths_col_factorisation",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Factorisez l'expression par la variable x : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Mettez x (ou le multiple de x) en facteur devant la parenthèse.",
			HintLevel2 = "Rappel : x² = x × x.",
			ExplanationText = $"{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreateFactorRemarkableDifferenceOfSquaresQuestion()
	{
		var pool = new[]
		{
			("x² - 16", "(x - 4)(x + 4)", "(x - 4)²", "(x - 8)(x + 8)", "(x - 16)(x + 1)"),
			("x² - 49", "(x - 7)(x + 7)", "(x - 7)²", "(x + 7)²", "(x - 49)(x + 1)"),
			("4x² - 25", "(2x - 5)(2x + 5)", "(2x - 5)²", "(4x - 5)(4x + 5)", "(2x + 25)(2x - 1)")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S25-{Guid.NewGuid():N}",
			SubjectId = "maths_col_factorisation",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Factorisez à l'aide d'une identité remarquable : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Reconnaissez la forme a² - b² = (a - b)(a + b).",
			HintLevel2 = "Identifiez les racines carrées de chaque terme.",
			ExplanationText = $"{item.Item1} factorisé donne {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaFactorizedCostCalculationQuestion()
	{
		var pool = new[]
		{
			(17, 35, 65, 1700),
			(24, 48, 52, 2400),
			(13, 120, 80, 2600)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item4} €";
		var w1 = $"{item.Item4 + 200} €";
		var w2 = $"{item.Item4 - 150} €";
		var w3 = $"{item.Item1 * 100} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S25-{Guid.NewGuid():N}",
			SubjectId = "maths_col_factorisation",
			Discipline = "Mixte",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Un artisan calcule son devis : {item.Item1} × {item.Item2} + {item.Item1} × {item.Item3}. En factorisant par {item.Item1}, quel montant obtient-il rapidement ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Factorisez : {item.Item1} × ({item.Item2} + {item.Item3}).",
			HintLevel2 = $"{item.Item2} + {item.Item3} = {item.Item2 + item.Item3}. Multipliez par {item.Item1}.",
			ExplanationText = $"{item.Item1} × ({item.Item2} + {item.Item3}) = {item.Item4} €."
		};
	}
}

