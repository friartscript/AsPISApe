using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateScaleQuestion()
	{
		var scaleDenom = new[] { 100, 200, 500, 1000, 25000 }[_random.Next(5)];
		var mapCm = _random.Next(2, 8);
		var realCm = mapCm * scaleDenom;
		var realMeters = realCm / 100.0;
		var correct = realMeters >= 1000 ? $"{realMeters / 1000.0} km" : $"{realMeters} m";
		var wrong1 = $"{realMeters * 10} m";
		var wrong2 = $"{mapCm * 10} m";
		var wrong3 = $"{realMeters / 10} m";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-ECH-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-048",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Sur une carte à l'échelle 1 / {scaleDenom}, un sentier mesure {mapCm} cm. Quelle est sa longueur réelle sur le terrain ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une échelle 1 / n signifie que 1 cm sur la carte représente n cm dans la réalité.",
			HintLevel2 = $"{mapCm} cm × {scaleDenom} = {realCm} cm. Convertis en mètres ou kilomètres.",
			ExplanationText = $"Longueur réelle = {mapCm} × {scaleDenom} cm = {realMeters} m ({correct})."
		};
	}

	public ExerciseQuestion GenerateScalingFactorQuestion()
	{
		var k = _random.Next(2, 5);
		var initialArea = _random.Next(4, 15);
		var newArea = initialArea * k * k;
		var correct = $"{newArea} cm²";
		var wrong1 = $"{initialArea * k} cm²";
		var wrong2 = $"{initialArea * 2 * k} cm²";
		var wrong3 = $"{newArea + initialArea} cm²";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-AGR-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-049",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Une figure d'aire {initialArea} cm² subit un agrandissement de rapport k = {k}. Quelle est l'aire de la figure agrandie ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Lors d'un agrandissement de rapport k, les longueurs sont multipliées par k et les aires sont multipliées par k².",
			HintLevel2 = $"k² = {k}² = {k * k}. Multiplie {initialArea} par {k * k}.",
			ExplanationText = $"Aire = {initialArea} × {k}² = {initialArea} × {k * k} = {newArea} cm²."
		};
	}

	public ExerciseQuestion GenerateAverageSpeedConversionQuestion()
	{
		var speeds = new[]
		{
			(36, 10),
			(54, 15),
			(72, 20),
			(90, 25),
			(108, 30)
		};
		var item = speeds[_random.Next(speeds.Length)];
		var correct = $"{item.Item2} m/s";
		var wrong1 = $"{item.Item2 * 2} m/s";
		var wrong2 = $"{item.Item1 / 2} m/s";
		var wrong3 = $"{item.Item2 - 5} m/s";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-VITCONV-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-050",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Une voiture roule à {item.Item1} km/h. Quelle est sa vitesse exprimée en mètres par seconde (m/s) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour passer de km/h à m/s, divise la vitesse par 3,6 (car 1 km = 1000 m et 1 h = 3600 s).",
			HintLevel2 = $"Calcule {item.Item1} / 3,6.",
			ExplanationText = $"{item.Item1} km/h / 3,6 = {item.Item2} m/s."
		};
	}

	public ExerciseQuestion GeneratePercentMultiplierQuestion()
	{
		var cases = new[]
		{
			("une hausse de 20 %", "1,20", "0,20", "1,02", "1,80"),
			("une baisse de 15 %", "0,85", "0,15", "1,15", "0,70"),
			("une hausse de 5 %", "1,05", "1,50", "0,05", "0,95"),
			("une baisse de 30 %", "0,70", "0,30", "1,30", "0,60")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-COEFM-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-047",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Quel est le coefficient multiplicateur associé à {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour une hausse de t %, CM = 1 + (t/100). Pour une baisse de t %, CM = 1 - (t/100).",
			HintLevel2 = $"Applique la formule avec la valeur indiquée.",
			ExplanationText = $"Le coefficient multiplicateur associé est {item.Item2}."
		};
	}
}

