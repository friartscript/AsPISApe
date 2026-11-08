using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateRelativeNumbersGraduationAndCoordinates()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateAxisAbscissaQuestion(),
			1 => CreateDistanceToZeroQuestion(),
			2 => CreateCartesianCoordinatesQuestion(),
			_ => CreatePisaAltitudeDifferenceQuestion()
		};
	}

	public ExerciseQuestion GenerateRelativeNumbersComparison()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateCompareTwoNegativesQuestion(),
			1 => CreateFindSmallestRelativeQuestion(),
			2 => CreateNegativeIntegerBoundQuestion(),
			_ => CreatePisaColdestTemperatureQuestion()
		};
	}

	private ExerciseQuestion CreateAxisAbscissaQuestion()
	{
		var dist = _random.Next(2, 9);
		var correct = (-dist).ToString();
		var w1 = dist.ToString();
		var w2 = (-dist - 1).ToString();
		var w3 = (-dist + 2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Sur une droite graduée d'origine O, le point A est situé à {dist} unités à gauche de O. Quelle est son abscisse ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les points situés à gauche de l'origine ont une abscisse négative.",
			HintLevel2 = $"Le point est à gauche donc son signe est négatif : -{dist}.",
			ExplanationText = $"L'abscisse d'un point à gauche de l'origine est négative : {correct}."
		};
	}

	private ExerciseQuestion CreateDistanceToZeroQuestion()
	{
		var val = _random.Next(3, 15);
		var correct = val.ToString();
		var w1 = (-val).ToString();
		var w2 = (val * 2).ToString();
		var w3 = "0";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est la distance à zéro du nombre relatif -{val} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La distance à zéro est toujours un nombre positif (valeur absolue).",
			HintLevel2 = "Supprimez simplement le signe négatif pour obtenir la distance.",
			ExplanationText = $"La distance à zéro de -{val} est le nombre positif {correct}."
		};
	}

	private ExerciseQuestion CreateCartesianCoordinatesQuestion()
	{
		var x = _random.Next(-6, -1);
		var y = _random.Next(2, 8);
		var correct = y.ToString();
		var w1 = x.ToString();
		var w2 = (-y).ToString();
		var w3 = (x + y).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans un repère, le point M a pour coordonnées ({x} ; {y}). Quelle est son ordonnée ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les coordonnées se lisent dans l'ordre alphabétique : (abscisse x ; ordonnée y).",
			HintLevel2 = "L'ordonnée est le deuxième nombre entre parenthèses.",
			ExplanationText = $"Dans ({x} ; {y}), {x} est l'abscisse et {y} est l'ordonnée."
		};
	}

	private ExerciseQuestion CreatePisaAltitudeDifferenceQuestion()
	{
		var altPos = _random.Next(12, 35) * 10;
		var altNeg = _random.Next(4, 15) * 10;
		var diff = altPos + altNeg;
		var correct = $"{diff} m";
		var w1 = $"{altPos - altNeg} m";
		var w2 = $"{diff + 20} m";
		var w3 = $"{altPos} m";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Un village est situé à +{altPos} m d'altitude et une vallée sous-marine à -{altNeg} m. Quel est l'écart d'altitude ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La différence d'altitude se calcule par : Altitude haute - Altitude basse.",
			HintLevel2 = $"Calculez (+{altPos}) - (-{altNeg}) = {altPos} + {altNeg}.",
			ExplanationText = $"Écart = {altPos} - (-{altNeg}) = {diff} m."
		};
	}

	private ExerciseQuestion CreateCompareTwoNegativesQuestion()
	{
		var a = _random.Next(8, 20);
		var b = _random.Next(2, 7);
		var correct = $"-{b}";
		var w1 = $"-{a}";
		var w2 = "Ils sont égaux";
		var w3 = $"-{a + b}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quel est le plus grand nombre entre -{a} et -{b} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Entre deux nombres négatifs, le plus grand est celui qui a la plus petite distance à zéro.",
			HintLevel2 = $"-{b} est plus proche de 0 que -{a}.",
			ExplanationText = $"-{b} est supérieur à -{a} car sa distance à zéro est inférieure."
		};
	}

	private ExerciseQuestion CreateFindSmallestRelativeQuestion()
	{
		var pool = new[]
		{
			(-18, -12, 3, -4),
			(-25, -9, 0, -17),
			(-31, -15, -8, 2),
			(-14, -6, 5, -9)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item1.ToString();
		var w1 = item.Item2.ToString();
		var w2 = item.Item3.ToString();
		var w3 = item.Item4.ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quel est le plus petit nombre parmi : {item.Item1}, {item.Item2}, {item.Item3}, {item.Item4} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le plus petit nombre est celui qui est situé le plus à gauche sur la droite graduée.",
			HintLevel2 = "Recherchez le nombre négatif ayant la plus grande distance à zéro.",
			ExplanationText = $"{item.Item1} a la plus grande distance à zéro parmi les négatifs."
		};
	}

	private ExerciseQuestion CreateNegativeIntegerBoundQuestion()
	{
		var intPart = _random.Next(3, 9);
		var dec = _random.Next(1, 9);
		var val = $"{intPart},{dec}";
		var correct = (-intPart - 1).ToString();
		var w1 = (-intPart).ToString();
		var w2 = (intPart).ToString();
		var w3 = (-intPart + 1).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quel entier relatif se trouve immédiatement inférieur à -{val} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un nombre inférieur se situe plus à gauche sur la droite graduée.",
			HintLevel2 = $"On a : {-intPart - 1} < -{val} < {-intPart}.",
			ExplanationText = $"L'entier immédiatement inférieur à -{val} est {correct}."
		};
	}

	private ExerciseQuestion CreatePisaColdestTemperatureQuestion()
	{
		var pool = new[]
		{
			("-14,5 °C", "-8,2 °C", "-3,0 °C", "1,5 °C"),
			("-21,3 °C", "-17,0 °C", "-9,5 °C", "0 °C"),
			("-16,8 °C", "-12,4 °C", "-4,1 °C", "2,3 °C")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item1, item.Item2, item.Item3, item.Item4, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = "D'après les relevés météo, quelle température est la plus froide ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La température la plus froide correspond au minimum algébrique.",
			HintLevel2 = "C'est la valeur négative la plus éloignée de zéro.",
			ExplanationText = $"{item.Item1} est la température la plus basse enregistrée."
		};
	}
}

