using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateIntervalsAndInequalitiesQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateIntersectionIntervalsQuestion(),
			1 => GenerateUnionIntervalsQuestion(),
			2 => GenerateAbsoluteValueDistanceQuestion(),
			_ => GenerateInequalityOperationsQuestion()
		};
	}

	private ExerciseQuestion GenerateIntersectionIntervalsQuestion()
	{
		var a = _random.Next(-5, 0);
		var b = _random.Next(2, 6);
		var c = _random.Next(0, 3);
		var d = _random.Next(7, 12);

		var correct = $"[{c} ; {b}]";
		var wrong1 = $"[{a} ; {d}]";
		var wrong2 = $"[{a} ; {c}]";
		var wrong3 = "∅";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-INT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-03",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Déterminez l'intersection des intervalles I = [{a} ; {b}] et J = [{c} ; {d}] : I ∩ J.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'intersection I ∩ J rassemble les réels appartenant à la fois à I et à J.",
			HintLevel2 = $"Le plus grand début est {c} et la plus petite fin est {b}.",
			ExplanationText = $"Les éléments communs vont de {c} à {b}, soit [{c} ; {b}]."
		};
	}

	private ExerciseQuestion GenerateUnionIntervalsQuestion()
	{
		var a = _random.Next(-4, 0);
		var b = _random.Next(1, 4);
		var c = _random.Next(2, 5);
		var d = _random.Next(6, 10);

		var correct = $"[{a} ; {d}]";
		var wrong1 = $"[{c} ; {b}]";
		var wrong2 = $"[{a} ; {c}]";
		var wrong3 = $"[{b} ; {d}]";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-UNI-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-03",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Soit I = [{a} ; {c}] et J = [{b} ; {d}]. Déterminez la réunion I ∪ J.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La réunion I ∪ J rassemble les éléments qui appartiennent à I, à J ou aux deux.",
			HintLevel2 = $"Comme {b} < {c}, les deux intervalles se chevauchent de {a} à {d}.",
			ExplanationText = $"L'union continue des deux intervalles forme [{a} ; {d}]."
		};
	}

	private ExerciseQuestion GenerateAbsoluteValueDistanceQuestion()
	{
		var center = _random.Next(1, 7);
		var radius = _random.Next(2, 5);
		var min = center - radius;
		var max = center + radius;

		var correct = $"x ∈ [{min} ; {max}]";
		var wrong1 = $"x ∈ [{min - 1} ; {max + 1}]";
		var wrong2 = $"x ∈ [{-radius} ; {radius}]";
		var wrong3 = $"x ∈ ]-∞ ; {min}] ∪ [{max} ; +∞[";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-ABS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-03",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Résolvez dans R l'inéquation : |x - {center}| ≤ {radius}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "|x - a| ≤ r représente l'ensemble des réels x à une distance au plus r de a.",
			HintLevel2 = $"L'intervalle centré en {center} et de rayon {radius} est [{center}-{radius} ; {center}+{radius}].",
			ExplanationText = $"|x - {center}| ≤ {radius} équivaut à x ∈ [{min} ; {max}]."
		};
	}

	private ExerciseQuestion GenerateInequalityOperationsQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(5, 12);
		var k = _random.Next(2, 5);

		var correct = $"-{k}x > -{k * b}";
		var wrong1 = $"-{k}x < -{k * b}";
		var wrong2 = $"-{k}x < -{b}";
		var wrong3 = $"x < -{b}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-INQ-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-03",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Sachant que x < {b}, que peut-on affirmer en multipliant par -{k} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multiplier ou diviser les deux membres d'une inégalité par un nombre strictement négatif change son sens.",
			HintLevel2 = $"Le signe '<' devient '>' et {b} * (-{k}) = -{k * b}.",
			ExplanationText = $"Multiplier par un négatif inverse le sens de l'inégalité."
		};
	}
}
