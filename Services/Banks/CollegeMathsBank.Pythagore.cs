using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GeneratePythagorasHypotenuseQuestion()
	{
		var triplets = new[]
		{
			(3, 4, 5),
			(6, 8, 10),
			(5, 12, 13),
			(9, 12, 15),
			(8, 15, 17)
		};
		var item = triplets[_random.Next(triplets.Length)];
		var correct = $"{item.Item3} cm";
		var wrong1 = $"{item.Item1 + item.Item2} cm";
		var wrong2 = $"{item.Item3 + 2} cm";
		var wrong3 = $"{item.Item1 * 2} cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PYTHYP-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-076",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Dans un triangle ABC rectangle en A, on a AB = {item.Item1} cm et AC = {item.Item2} cm. Quelle est la longueur de l'hypoténuse BC selon le théorème de Pythagore ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "D'après le théorème de Pythagore : BC² = AB² + AC². Calcule la somme des carrés puis prends la racine carrée.",
			HintLevel2 = $"{item.Item1}² + {item.Item2}² = {item.Item1 * item.Item1} + {item.Item2 * item.Item2} = {item.Item3 * item.Item3}. √{item.Item3 * item.Item3} = {item.Item3}.",
			ExplanationText = $"BC² = {item.Item1}² + {item.Item2}² = {item.Item3 * item.Item3}, donc BC = √{item.Item3 * item.Item3} = {item.Item3} cm."
		};
	}

	public ExerciseQuestion GeneratePythagorasLegQuestion()
	{
		var triplets = new[]
		{
			(3, 4, 5),
			(6, 8, 10),
			(5, 12, 13),
			(9, 12, 15),
			(8, 15, 17)
		};
		var item = triplets[_random.Next(triplets.Length)];
		var correct = $"{item.Item1} cm";
		var wrong1 = $"{item.Item3 - item.Item2} cm";
		var wrong2 = $"{item.Item1 + 1} cm";
		var wrong3 = $"{item.Item2 / 2} cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PYTLEG-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-076",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Dans un triangle EFG rectangle en E, on a l'hypoténuse FG = {item.Item3} cm et le côté EG = {item.Item2} cm. Quelle est la longueur du côté EF ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour trouver un côté de l'angle droit, soustrais le carré du côté connu au carré de l'hypoténuse : EF² = FG² - EG².",
			HintLevel2 = $"{item.Item3}² - {item.Item2}² = {item.Item3 * item.Item3} - {item.Item2 * item.Item2} = {item.Item1 * item.Item1}.",
			ExplanationText = $"EF² = {item.Item3}² - {item.Item2}² = {item.Item1 * item.Item1}, donc EF = √{item.Item1 * item.Item1} = {item.Item1} cm."
		};
	}

	public ExerciseQuestion GeneratePythagorasConverseQuestion()
	{
		var cases = new[]
		{
			(6, 8, 10, "Oui, rectangle en A (car 10² = 6² + 8² = 100)", "Non, 10² ≠ 6² + 8²", "Oui, rectangle en B", "Non, triangle isocèle"),
			(5, 7, 9, "Non, car 9² = 81 ≠ 5² + 7² = 74", "Oui, rectangle car 9 est impair", "Oui, rectangle en A", "Non, car 5 + 7 < 9"),
			(5, 12, 13, "Oui, rectangle en A (car 13² = 5² + 12² = 169)", "Non, car 13 est premier", "Oui, rectangle en C", "Non, car 5² + 12² = 144")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item4, item.Item5, item.Item6, item.Item7, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PYTREC-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-077",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Un triangle ABC a pour côtés AB = {item.Item1} cm, AC = {item.Item2} cm et BC = {item.Item3} cm. Est-il rectangle d'après la réciproque du théorème de Pythagore ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calcule séparément le carré du plus grand côté d'une part, et la somme des carrés des deux autres côtés d'autre part. Compare les résultats.",
			HintLevel2 = $"Plus grand côté au carré = {item.Item3}² = {item.Item3 * item.Item3}. Somme des deux autres = {item.Item1}² + {item.Item2}² = {item.Item1 * item.Item1 + item.Item2 * item.Item2}.",
			ExplanationText = item.Item4
		};
	}

	public ExerciseQuestion GeneratePythagorasRealContextQuestion()
	{
		var wallH = 12;
		var groundDist = 5;
		var ladderL = 13;
		var correct = $"{ladderL} m";
		var wrong1 = $"{wallH + groundDist} m";
		var wrong2 = $"{ladderL + 2} m";
		var wrong3 = "15 m";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PYTCTX-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-076",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Une échelle est posée contre un mur vertical. Le bas de l'échelle est à {groundDist} m du mur et le haut atteint une fenêtre située à {wallH} m de hauteur. Quelle est la longueur de l'échelle ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le mur vertical et le sol horizontal forment un angle droit. L'échelle correspond à l'hypoténuse d'un triangle rectangle.",
			HintLevel2 = $"L² = {groundDist}² + {wallH}² = {groundDist * groundDist} + {wallH * wallH} = {ladderL * ladderL}.",
			ExplanationText = $"L² = {groundDist}² + {wallH}² = {ladderL * ladderL}, donc Longueur = √{ladderL * ladderL} = {ladderL} m."
		};
	}
}

