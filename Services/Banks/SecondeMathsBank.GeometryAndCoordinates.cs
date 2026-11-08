using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateGeometryAndCoordinatesQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateSegmentMidpointQuestion(),
			1 => GeneratePointDistanceQuestion(),
			_ => GenerateTriangleTypeCoordinateQuestion()
		};
	}

	private ExerciseQuestion GenerateSegmentMidpointQuestion()
	{
		var xA = _random.Next(-4, 4) * 2;
		var yA = _random.Next(-4, 4) * 2;
		var xB = _random.Next(-4, 4) * 2;
		var yB = _random.Next(-4, 4) * 2;

		var xM = (xA + xB) / 2;
		var yM = (yA + yB) / 2;

		var correct = $"M({xM} ; {yM})";
		var wrong1 = $"M({xA + xB} ; {yA + yB})";
		var wrong2 = $"M({xM + 1} ; {yM})";
		var wrong3 = $"M({(xA - xB) / 2} ; {(yA - yB) / 2})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-MID-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-05",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Dans un repère, quelles sont les coordonnées du milieu M du segment [AB] avec A({xA} ; {yA}) et B({xB} ; {yB}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule des coordonnées du milieu : xM = (xA + xB) / 2 et yM = (yA + yB) / 2.",
			HintLevel2 = $"Faites la moyenne des abscisses ({xA} + {xB})/2 et celle des ordonnées ({yA} + {yB})/2.",
			ExplanationText = $"xM = ({xA}+{xB})/2 = {xM} et yM = ({yA}+{yB})/2 = {yM}."
		};
	}

	private ExerciseQuestion GeneratePointDistanceQuestion()
	{
		var triples = new (int dx, int dy, int dist)[]
		{
			(3, 4, 5),
			(6, 8, 10),
			(5, 12, 13),
			(8, 15, 17)
		};
		var pick = triples[_random.Next(triples.Length)];
		var xA = _random.Next(-3, 3);
		var yA = _random.Next(-3, 3);
		var xB = xA + pick.dx;
		var yB = yA + pick.dy;

		var correct = $"{pick.dist}";
		var wrong1 = $"{pick.dist + 1}";
		var wrong2 = $"{pick.dx + pick.dy}";
		var wrong3 = $"{pick.dist - 1}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-DST-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-05",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Dans un repère orthonormé, calculez la distance AB pour A({xA} ; {yA}) et B({xB} ; {yB}).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de la distance : AB = √((xB - xA)² + (yB - yA)²).",
			HintLevel2 = $"(xB - xA)² = {pick.dx}² = {pick.dx * pick.dx} et (yB - yA)² = {pick.dy}² = {pick.dy * pick.dy}.",
			ExplanationText = $"AB = √({pick.dx * pick.dx} + {pick.dy * pick.dy}) = √{pick.dist * pick.dist} = {pick.dist}."
		};
	}

	private ExerciseQuestion GenerateTriangleTypeCoordinateQuestion()
	{
		var correct = "Le triangle est rectangle";
		var wrong1 = "Le triangle est équilatéral";
		var wrong2 = "Le triangle est obtusangle sans angle droit";
		var wrong3 = "Les points sont alignés";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-GEO-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-05",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = "Dans un repère orthonormé, on a AB² = 25, BC² = 144 et AC² = 169. Que peut-on affirmer sur le triangle ABC ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez la réciproque du théorème de Pythagore.",
			HintLevel2 = "Comparez 25 + 144 avec 169.",
			ExplanationText = "Comme 25 + 144 = 169, ABC est rectangle en B."
		};
	}
}
