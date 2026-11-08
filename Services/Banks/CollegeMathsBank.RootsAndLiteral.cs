using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateSquareRoots()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreatePerfectSquareRootQuestion(),
			1 => CreateSquareRootFramingQuestion(),
			2 => CreateSquareRootPropertiesQuestion(),
			_ => CreatePisaSquareAreaSideQuestion()
		};
	}

	public ExerciseQuestion GenerateLiteralCalculusBasics()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateLiteralConventionsQuestion(),
			1 => CreateEvaluateExpressionQuestion(),
			2 => CreateTestEqualityQuestion(),
			_ => CreatePisaFormulaPerimeterQuestion()
		};
	}

	private ExerciseQuestion CreatePerfectSquareRootQuestion()
	{
		var pool = new[]
		{
			(49, 7),
			(64, 8),
			(81, 9),
			(121, 11),
			(144, 12),
			(169, 13)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item2.ToString();
		var w1 = (item.Item2 - 1).ToString();
		var w2 = (item.Item2 + 2).ToString();
		var w3 = (item.Item1 / 2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S20-{Guid.NewGuid():N}",
			SubjectId = "maths_col_racines_carrees",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la valeur exacte de √{item.Item1} (racine carrée de {item.Item1}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La racine carrée de a est le nombre positif dont le carré vaut a.",
			HintLevel2 = $"{item.Item2} × {item.Item2} = {item.Item1}.",
			ExplanationText = $"√{item.Item1} = {item.Item2} car {item.Item2}² = {item.Item1}."
		};
	}

	private ExerciseQuestion CreateSquareRootFramingQuestion()
	{
		var pool = new[]
		{
			(30, "5 et 6", "5² = 25 et 6² = 36"),
			(50, "7 et 8", "7² = 49 et 8² = 64"),
			(70, "8 et 9", "8² = 64 et 9² = 81"),
			(20, "4 et 5", "4² = 16 et 5² = 25")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item2;
		var w1 = "4 et 5";
		if (w1 == correct) w1 = "6 et 7";
		var w2 = "6 et 7";
		if (w2 == correct) w2 = "7 et 8";
		var w3 = "9 et 10";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S20-{Guid.NewGuid():N}",
			SubjectId = "maths_col_racines_carrees",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Entre quels entiers consécutifs se situe √{item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Encadrez le nombre par deux carrés parfaits consécutifs.",
			HintLevel2 = item.Item3,
			ExplanationText = $"√{item.Item1} est compris entre {correct} car {item.Item3}."
		};
	}

	private ExerciseQuestion CreateSquareRootPropertiesQuestion()
	{
		var pool = new[]
		{
			("√(4 × 25)", "10", "√4 × √25 = 2 × 5 = 10", "14", "20", "50"),
			("√(9 × 16)", "12", "√9 × √16 = 3 × 4 = 12", "15", "25", "72"),
			("√(36 ÷ 4)", "3", "√36 ÷ √4 = 6 ÷ 2 = 3", "6", "9", "4")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S20-{Guid.NewGuid():N}",
			SubjectId = "maths_col_racines_carrees",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété : √(a × b) = √a × √b pour tous réels positifs a et b.",
			HintLevel2 = item.Item3,
			ExplanationText = $"{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaSquareAreaSideQuestion()
	{
		var pool = new[]
		{
			(64, "8 m", "16 m", "32 m", "4 m"),
			(100, "10 m", "25 m", "50 m", "20 m"),
			(81, "9 m", "18 m", "40 m", "27 m")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S20-{Guid.NewGuid():N}",
			SubjectId = "maths_col_racines_carrees",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Un jardin carré a une surface de {item.Item1} m². Quelle est la longueur d'un de ses côtés ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'aire d'un carré est Côté² = Aire. Donc Côté = √Aire.",
			HintLevel2 = $"Calculez √{item.Item1}.",
			ExplanationText = $"Le côté mesure √{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreateLiteralConventionsQuestion()
	{
		var pool = new[]
		{
			("3 × x + 5 × y", "3x + 5y", "8xy", "15xy", "3x5y"),
			("a × b × 4", "4ab", "ab4", "4 + ab", "a4b"),
			("x × x + 2 × x", "x² + 2x", "3x²", "3x", "2x³")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S21-{Guid.NewGuid():N}",
			SubjectId = "maths_col_calcul_litteral_generalites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Selon les conventions d'écriture algébrique, comment s'écrit simplement : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le signe × est omis devant une lettre ou entre deux lettres.",
			HintLevel2 = "Le nombre s'écrit toujours devant la lettre (ex: 4a et non a4).",
			ExplanationText = $"{item.Item1} s'écrit sous forme simplifiée : {item.Item2}."
		};
	}

	private ExerciseQuestion CreateEvaluateExpressionQuestion()
	{
		var pool = new[]
		{
			(3, "4x - 5", 7),
			(5, "2x² + 3", 53),
			(4, "3(x + 2)", 18),
			(2, "5x² - 3x + 1", 15)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item3.ToString();
		var w1 = (item.Item3 + 4).ToString();
		var w2 = (item.Item3 - 3).ToString();
		var w3 = (item.Item1 * 2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S21-{Guid.NewGuid():N}",
			SubjectId = "maths_col_calcul_litteral_generalites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez la valeur de l'expression {item.Item2} pour x = {item.Item1} :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Remplacez la variable x par sa valeur numérique et respectez les priorités.",
			HintLevel2 = "Effectuez les puissances et multiplications avant les additions.",
			ExplanationText = $"Pour x = {item.Item1}, l'expression vaut {correct}."
		};
	}

	private ExerciseQuestion CreateTestEqualityQuestion()
	{
		var pool = new[]
		{
			("2x + 6 = 5x - 3", 3, true, "12 = 12"),
			("3x - 4 = x + 8", 6, true, "14 = 14"),
			("4x + 1 = 2x + 7", 2, false, "9 ≠ 11")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item3 ? "Oui, l'égalité est vérifiée" : "Non, l'égalité est fausse";
		var w1 = item.Item3 ? "Non, les deux membres sont différents" : "Oui, elle est toujours vraie";
		var w2 = "Seulement si x est négatif";
		var w3 = "Impossible à savoir";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S21-{Guid.NewGuid():N}",
			SubjectId = "maths_col_calcul_litteral_generalites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Pour x = {item.Item2}, l'égalité « {item.Item1} » est-elle vérifiée ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calculez séparément le membre de gauche et le membre de droite pour x = {item.Item2}.",
			HintLevel2 = $"Comparez les deux résultats obtenus : {item.Item4}.",
			ExplanationText = $"Pour x = {item.Item2}, on a {item.Item4} : {correct.ToLowerInvariant()}."
		};
	}

	private ExerciseQuestion CreatePisaFormulaPerimeterQuestion()
	{
		var pool = new[]
		{
			("2L + 2l", "Le périmètre d'un rectangle", "L'aire d'un rectangle", "Le volume d'un pavé", "La diagonale"),
			("c²", "L'aire d'un carré de côté c", "Le périmètre d'un carré", "Le volume d'un cube", "La hauteur"),
			("2πR", "Le périmètre (circonférence) d'un cercle", "L'aire d'un disque", "Le diamètre", "Le rayon")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S21-{Guid.NewGuid():N}",
			SubjectId = "maths_col_calcul_litteral_generalites",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Que permet de calculer la formule littérale « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Associez les variables aux dimensions de la figure géométrique usuelle.",
			HintLevel2 = "Observez s'il s'agit d'une longueur (somme) ou d'une surface (produit).",
			ExplanationText = $"La formule {item.Item1} correspond à {item.Item2.ToLowerInvariant()}."
		};
	}
}

