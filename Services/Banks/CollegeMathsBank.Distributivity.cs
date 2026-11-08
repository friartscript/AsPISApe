using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateSingleDistributivity()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateSingleDistributivityExpandQuestion(),
			1 => CreateSingleDistributivityWithNegativesQuestion(),
			2 => CreateMentalDistributivityQuestion(),
			_ => CreatePisaGroupDiscountDistributivityQuestion()
		};
	}

	public ExerciseQuestion GenerateExpansionAndReduction()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateReduceLinearExpressionQuestion(),
			1 => CreateRemoveParenthesesWithMinusQuestion(),
			2 => CreateReduceQuadraticExpressionQuestion(),
			_ => CreatePisaGeometryPerimeterAlgebraicQuestion()
		};
	}

	private ExerciseQuestion CreateSingleDistributivityExpandQuestion()
	{
		var pool = new[]
		{
			("4(x + 3)", "4x + 12", "4x + 3", "7x", "12x"),
			("5(2x + 7)", "10x + 35", "10x + 7", "7x + 35", "45x"),
			("3(4x - 5)", "12x - 15", "12x - 5", "7x - 15", "-3x")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S22-{Guid.NewGuid():N}",
			SubjectId = "maths_col_distributivite_simple",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Développez l'expression : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez la formule k(a + b) = k × a + k × b.",
			HintLevel2 = "Distribuez le facteur devant la parenthèse à chacun des termes intérieurs.",
			ExplanationText = $"{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreateSingleDistributivityWithNegativesQuestion()
	{
		var pool = new[]
		{
			("-3(2x - 4)", "-6x + 12", "-6x - 12", "6x - 12", "-6x - 4"),
			("-2(5 - 3x)", "-10 + 6x", "-10 - 6x", "10 - 6x", "-10 - 3x"),
			("-4(x + 5)", "-4x - 20", "-4x + 20", "4x - 20", "-4x + 5")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S22-{Guid.NewGuid():N}",
			SubjectId = "maths_col_distributivite_simple",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Développez en appliquant la règle des signes : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention au facteur négatif : multiplier par un nombre négatif change les signes intérieurs.",
			HintLevel2 = "Moins par moins donne plus, moins par plus donne moins.",
			ExplanationText = $"{item.Item1} développé donne {item.Item2}."
		};
	}

	private ExerciseQuestion CreateMentalDistributivityQuestion()
	{
		var pool = new[]
		{
			("24 × 101", 2424, "24 × (100 + 1) = 2400 + 24"),
			("15 × 99", 1485, "15 × (100 - 1) = 1500 - 15"),
			("35 × 11", 385, "35 × (10 + 1) = 350 + 35")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item2.ToString();
		var w1 = (item.Item2 + 10).ToString();
		var w2 = (item.Item2 - 20).ToString();
		var w3 = (item.Item2 + 100).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S22-{Guid.NewGuid():N}",
			SubjectId = "maths_col_distributivite_simple",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"En utilisant la distributivité pour le calcul mental, calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = item.Item3,
			HintLevel2 = "Décomposez le nombre proche de 100 ou 10 en somme ou différence.",
			ExplanationText = $"{item.Item1} = {item.Item3} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaGroupDiscountDistributivityQuestion()
	{
		var pool = new[]
		{
			(6, 15, 2, 78),
			(4, 25, 3, 88),
			(5, 12, 1, 55)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item4} €";
		var w1 = $"{item.Item4 + 12} €";
		var w2 = $"{item.Item1 * item.Item2} €";
		var w3 = $"{item.Item4 - 8} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S22-{Guid.NewGuid():N}",
			SubjectId = "maths_col_distributivite_simple",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Un groupe de {item.Item1} personnes achète des entrées à {item.Item2} € avec une remise de {item.Item3} € par billet ({item.Item1} × ({item.Item2} - {item.Item3})). Quel est le prix total ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez la formule : {item.Item1} × {item.Item2} - {item.Item1} × {item.Item3}.",
			HintLevel2 = $"Calculez {item.Item1 * item.Item2} - {item.Item1 * item.Item3}.",
			ExplanationText = $"Le coût total est de {item.Item4} €."
		};
	}

	private ExerciseQuestion CreateReduceLinearExpressionQuestion()
	{
		var pool = new[]
		{
			("7x + 4 - 3x + 8", "4x + 12", "10x + 12", "4x + 4", "16x"),
			("5x - 9 - 2x + 4", "3x - 5", "7x - 5", "3x - 13", "-2x"),
			("8 + 6x - 3 - 4x", "2x + 5", "10x + 5", "2x + 11", "7x")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S23-{Guid.NewGuid():N}",
			SubjectId = "maths_col_developpement_reduction",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Réduisez l'expression littérale : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Regroupez les termes en x ensemble et les constantes numériques ensemble.",
			HintLevel2 = "Attention aux signes qui précèdent chaque terme.",
			ExplanationText = $"Après réduction des termes semblables : {item.Item2}."
		};
	}

	private ExerciseQuestion CreateRemoveParenthesesWithMinusQuestion()
	{
		var pool = new[]
		{
			("5x - (3x - 7)", "2x + 7", "2x - 7", "8x + 7", "8x - 7"),
			("4 - (2x + 9)", "-2x - 5", "-2x + 13", "2x - 5", "-2x + 5"),
			("3x - (5 - 4x)", "7x - 5", "-x - 5", "7x + 5", "-x + 5")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S23-{Guid.NewGuid():N}",
			SubjectId = "maths_col_developpement_reduction",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Supprimez les parenthèses et réduisez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un signe « - » devant une parenthèse inverse tous les signes à l'intérieur.",
			HintLevel2 = "-(a - b) = -a + b.",
			ExplanationText = $"Après suppression des parenthèses et réduction : {item.Item2}."
		};
	}

	private ExerciseQuestion CreateReduceQuadraticExpressionQuestion()
	{
		var pool = new[]
		{
			("3x² + 5x - x² + 2x", "2x² + 7x", "4x² + 7x", "2x² + 3x", "9x³"),
			("4x² - 6x + 3x² + 2x", "7x² - 4x", "7x² - 8x", "x² - 4x", "3x²"),
			("2x² + 4 - 5x² + 8", "-3x² + 12", "3x² + 12", "-3x² + 4", "-7x² + 12")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S23-{Guid.NewGuid():N}",
			SubjectId = "maths_col_developpement_reduction",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Réduisez l'expression polynomiale : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "On ne peut additionner que des termes de même degré (les x² avec les x², les x avec les x).",
			HintLevel2 = "Ne confondez pas x² et x.",
			ExplanationText = $"L'expression réduite exacte est {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaGeometryPerimeterAlgebraicQuestion()
	{
		var pool = new[]
		{
			("un rectangle de longueur (2x + 3) et largeur (x + 1)", "6x + 8", "3x + 4", "2x² + 5x + 3", "6x + 4"),
			("un triangle équilatéral de côté (3x + 2)", "9x + 6", "6x + 4", "9x² + 4", "3x + 6"),
			("un carré de côté (2x + 5)", "8x + 20", "4x + 10", "4x² + 25", "8x + 5")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S23-{Guid.NewGuid():N}",
			SubjectId = "maths_col_developpement_reduction",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Exprimez en fonction de x le périmètre de la figure suivante : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le périmètre est la somme de toutes les longueurs des côtés.",
			HintLevel2 = "Développez et réduisez la somme algébrique obtenue.",
			ExplanationText = $"Le périmètre réduit vaut {item.Item2}."
		};
	}
}

