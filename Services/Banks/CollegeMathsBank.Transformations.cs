using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateTransformationDefinitionQuestion()
	{
		var transformations = new[]
		{
			("un glissement en ligne droite défini par une direction, un sens et une distance", "la translation", "la rotation", "la symétrie axiale", "l'homothétie"),
			("un demi-tour complet de 180° autour d'un point fixe", "la symétrie centrale", "la symétrie axiale", "la translation", "la perspective"),
			("un pliage ou effet miroir par rapport à une droite", "la symétrie axiale", "la rotation", "la translation", "l'homothétie"),
			("un pivotement autour d'un centre selon un angle et un sens donnés", "la rotation", "la translation", "l'homothétie", "la symétrie centrale")
		};
		var item = transformations[_random.Next(transformations.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TRFDEF-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-100",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Quelle transformation géométrique correspond à : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Associe la description géométrique au bon vocabulaire des transformations du plan.",
			HintLevel2 = $"Il s'agit de {item.Item2}.",
			ExplanationText = $"Cette transformation est {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateHomothetyQuestion()
	{
		var k = _random.Next(2, 5);
		var initialLength = _random.Next(3, 8);
		var newLength = initialLength * k;
		var correct = $"{newLength} cm";
		var wrong1 = $"{initialLength + k} cm";
		var wrong2 = $"{newLength + 2} cm";
		var wrong3 = $"{initialLength * 2} cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-HOMOTH-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-102",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Un segment [AB] mesure {initialLength} cm. Par une homothétie de rapport k = {k}, quelle est la longueur du segment image [A'B'] ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une homothétie de rapport k multiplie toutes les longueurs par |k|.",
			HintLevel2 = $"Multiplie la longueur de départ ({initialLength}) par le rapport ({k}).",
			ExplanationText = $"Longueur image = {initialLength} × {k} = {newLength} cm."
		};
	}

	public ExerciseQuestion GenerateRotationClockwiseQuestion()
	{
		var angles = new[]
		{
			("90° dans le sens horaire", "quart de tour vers la droite", "quart de tour vers la gauche", "demi-tour inversé", "tour complet"),
			("180°", "demi-tour (équivalent à une symétrie centrale)", "quart de tour droit", "trois quarts de tour", "retour au point de départ"),
			("90° dans le sens anti-horaire (trigonométrique)", "quart de tour vers la gauche", "quart de tour vers la droite", "demi-tour", "tour complet")
		};
		var item = angles[_random.Next(angles.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-ROTANG-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-101",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Dans le plan, une rotation d'angle {item.Item1} correspond géométriquement à un :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Visualise les aiguilles d'une montre pour le sens horaire et le sens trigonométrique inverse.",
			HintLevel2 = $"Une rotation de {item.Item1} correspond à un {item.Item2}.",
			ExplanationText = $"Une rotation de {item.Item1} équivaut à un {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateTransformationConservationQuestion()
	{
		var correct = "Les longueurs, les angles, les aires et l'alignement";
		var wrong1 = "Uniquement la couleur et le style";
		var wrong2 = "Seulement le périmètre, mais pas les angles";
		var wrong3 = "La position absolue des points dans le repère";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-CONSERV-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-103",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = "Que conservent les isométries du plan (symétries axiales, centrales, translations et rotations) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les isométries conservent toutes les mesures géométriques fondamentales.",
			HintLevel2 = "Une figure transformée par symétrie ou translation est superposable à la figure initiale.",
			ExplanationText = "Les isométries conservent les longueurs, les angles, les aires et l'alignement."
		};
	}
}

