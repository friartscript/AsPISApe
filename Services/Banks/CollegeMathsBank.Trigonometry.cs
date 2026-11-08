using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateTrigFormulaQuestion()
	{
		var cases = new[]
		{
			("cosinus d'un angle aigu", "Côté adjacent / Hypoténuse (CAH)", "Côté opposé / Hypoténuse (SOH)", "Côté opposé / Côté adjacent (TOA)", "Hypoténuse / Côté adjacent"),
			("sinus d'un angle aigu", "Côté opposé / Hypoténuse (SOH)", "Côté adjacent / Hypoténuse (CAH)", "Côté opposé / Côté adjacent (TOA)", "Hypoténuse / Côté opposé"),
			("tangente d'un angle aigu", "Côté opposé / Côté adjacent (TOA)", "Côté adjacent / Hypoténuse (CAH)", "Côté opposé / Hypoténuse (SOH)", "Hypoténuse / Côté opposé")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TRIGFORM-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-090",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Dans un triangle rectangle, quelle est la définition exacte du {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Utilise le moyen mnémotechnique universel : CAH - SOH - TOA.",
			HintLevel2 = $"Pour le {item.Item1.Split(' ')[0]} : {item.Item2.Split(' ')[0]}.",
			ExplanationText = $"Règle CAHSOHTOA : {item.Item1} = {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateTrigCosineLengthQuestion()
	{
		var angles = new[]
		{
			(60, 0.5, 10, 5),
			(60, 0.5, 16, 8),
			(60, 0.5, 20, 10),
			(60, 0.5, 12, 6)
		};
		var item = angles[_random.Next(angles.Length)];
		var correct = $"{item.Item4} cm";
		var wrong1 = $"{item.Item3 / 4} cm";
		var wrong2 = $"{item.Item4 + 3} cm";
		var wrong3 = $"{item.Item3 - 2} cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TRIGCOS-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-091",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Dans un triangle ABC rectangle en B, l'hypoténuse AC mesure {item.Item3} cm et l'angle Â mesure {item.Item1}° (on sait que cos({item.Item1}°) = {item.Item2}). Quelle est la longueur du côté adjacent AB ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "cos(Â) = Côté adjacent / Hypoténuse = AB / AC, donc AB = AC × cos(Â).",
			HintLevel2 = $"AB = {item.Item3} × {item.Item2}.",
			ExplanationText = $"AB = AC × cos({item.Item1}°) = {item.Item3} × {item.Item2} = {item.Item4} cm."
		};
	}

	public ExerciseQuestion GenerateTrigTangentHeightQuestion()
	{
		var distances = new[] { 10, 20, 30, 40, 50 };
		var dist = distances[_random.Next(distances.Length)];
		var h = dist;
		var correct = $"{h} m";
		var wrong1 = $"{h * 2} m";
		var wrong2 = $"{h / 2} m";
		var wrong3 = $"{dist + 15} m";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TRIGTAN-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-091",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Un géomètre se tient à {dist} m d'une tour verticale sur un sol horizontal. Il vise le sommet avec un angle d'élévation de 45° (sachant que tan(45°) = 1). Quelle est la hauteur de la tour ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "tan(angle) = Côté opposé (hauteur) / Côté adjacent (distance au sol). Hauteur = distance × tan(angle).",
			HintLevel2 = $"Hauteur = {dist} × tan(45°) = {dist} × 1.",
			ExplanationText = $"Hauteur = {dist} × tan(45°) = {dist} × 1 = {h} m."
		};
	}

	public ExerciseQuestion GenerateTrigAngleDeterminationQuestion()
	{
		var cases = new[]
		{
			(5, 10, 60, "cos(Â) = 5/10 = 0,5 donc Â = 60°"),
			(8, 16, 60, "cos(Â) = 8/16 = 0,5 donc Â = 60°"),
			(7, 7, 45, "tan(Â) = 7/7 = 1 donc Â = 45°")
		};
		var item = cases[_random.Next(cases.Length)];
		var correct = $"{item.Item3}°";
		var wrong1 = $"{item.Item3 + 15}°";
		var wrong2 = $"{90 - item.Item3 / 2}°";
		var wrong3 = "30°";
		if (item.Item3 == 45) wrong3 = "60°";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TRIGANG-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-092",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Dans un triangle rectangle ABC en B, on a AB = {item.Item1} cm et AC = {item.Item2} cm. Quelle est la mesure de l'angle Â sachant que le rapport vaut 0,5 ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calcule le cosinus de l'angle : cos(Â) = AB / AC, puis utilise la valeur remarquable connue.",
			HintLevel2 = item.Item4,
			ExplanationText = item.Item4
		};
	}
}

