using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateTriangleInequalityQuestion()
	{
		var cases = new[]
		{
			(3, 4, 8, "Non, car 3 + 4 = 7 < 8 (inégalité triangulaire non respectée)", "Oui, car il y a 3 longueurs positives", "Oui, c'est un triangle quelconque", "Oui, c'est un triangle obtusangle"),
			(5, 6, 9, "Oui, car 5 + 6 = 11 > 9 (la somme des deux plus petits dépasse le plus grand)", "Non, car 5 + 6 ne fait pas 9", "Non, les côtés sont trop longs", "Oui, seulement s'il est rectangle"),
			(2, 5, 7, "Non, car 2 + 5 = 7 (les points sont alignés, triangle aplati)", "Oui, c'est un triangle scalène", "Oui, avec un angle droit", "Non, car 7 est un nombre premier")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item4, item.Item5, item.Item6, item.Item7, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-INEQTRI-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-070",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Peut-on construire un triangle dont les côtés mesurent {item.Item1} cm, {item.Item2} cm et {item.Item3} cm ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Dans tout triangle non aplati, la longueur du plus grand côté doit être strictement inférieure à la somme des deux autres côtés.",
			HintLevel2 = $"Compare le plus grand côté ({item.Item3}) avec la somme des deux autres ({item.Item1} + {item.Item2}).",
			ExplanationText = item.Item4
		};
	}

	public ExerciseQuestion GenerateTriangleAnglesSumQuestion()
	{
		var a1 = _random.Next(35, 75);
		var a2 = _random.Next(35, 140 - a1);
		var a3 = 180 - a1 - a2;
		var correct = $"{a3}°";
		var wrong1 = $"{a3 + 10}°";
		var wrong2 = $"{180 - a1}°";
		var wrong3 = $"{90 - a1}°";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-ANGSUM-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-089",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Dans un triangle ABC, on a Â = {a1}° et B̂ = {a2}°. Quelle est la mesure du troisième angle Ĉ ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La somme des mesures des trois angles d'un triangle est toujours égale à 180°.",
			HintLevel2 = $"Calcule 180° - ({a1}° + {a2}°).",
			ExplanationText = $"Ĉ = 180° - ({a1}° + {a2}°) = 180° - {a1 + a2}° = {a3}°."
		};
	}

	public ExerciseQuestion GenerateSimilarTrianglesQuestion()
	{
		var ratio = _random.Next(2, 5);
		var side1 = _random.Next(3, 7);
		var side2 = side1 * ratio;
		var otherSmall = _random.Next(4, 8);
		var otherLarge = otherSmall * ratio;

		var correct = $"{otherLarge} cm";
		var wrong1 = $"{otherSmall + ratio} cm";
		var wrong2 = $"{otherLarge + 2} cm";
		var wrong3 = $"{otherSmall * 2} cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-SIMIL-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-075",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Deux triangles ABC et DEF sont semblables. Deux côtés homologues mesurent AB = {side1} cm et DE = {side2} cm. Si AC = {otherSmall} cm, quelle est la longueur du côté homologue DF ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les longueurs des côtés homologues de triangles semblables sont proportionnelles. Calcule le coefficient d'agrandissement.",
			HintLevel2 = $"Le coefficient k vaut {side2} / {side1} = {ratio}. Multiplie {otherSmall} par {ratio}.",
			ExplanationText = $"Rapport k = {side2} / {side1} = {ratio}. Donc DF = {otherSmall} × {ratio} = {otherLarge} cm."
		};
	}

	public ExerciseQuestion GenerateIsoscelesTriangleAnglesQuestion()
	{
		var vertexAngle = _random.Next(20, 50) * 2;
		var baseAngle = (180 - vertexAngle) / 2;
		var correct = $"{baseAngle}°";
		var wrong1 = $"{180 - vertexAngle}°";
		var wrong2 = $"{vertexAngle}°";
		var wrong3 = $"{90 - vertexAngle / 2}°";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-ISOCEL-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-071",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Un triangle isocèle a son angle au sommet principal mesurant {vertexAngle}°. Quelle est la mesure de chacun des deux angles à sa base ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Dans un triangle isocèle, les deux angles à la base ont la même mesure. La somme des 3 angles vaut 180°.",
			HintLevel2 = $"Calcule (180° - {vertexAngle}°) / 2.",
			ExplanationText = $"Angles à la base = (180° - {vertexAngle}°) / 2 = {180 - vertexAngle}° / 2 = {baseAngle}°."
		};
	}
}

