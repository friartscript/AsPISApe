using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateDifferentialEquationsQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateHomogeneousDiffEqQuestion(),
			1 => GenerateAffineDiffEqQuestion(),
			_ => GeneratePrimitiveFormulaQuestion()
		};
	}

	private ExerciseQuestion GenerateHomogeneousDiffEqQuestion()
	{
		var a = _random.Next(2, 6);
		var correct = $"y(t) = C * e^{{{a}t}} (avec C ∈ R)";
		var wrong1 = $"y(t) = C * e^{{-{a}t}} (avec C ∈ R)";
		var wrong2 = $"y(t) = {a}t + C (avec C ∈ R)";
		var wrong3 = $"y(t) = C * t^{a} (avec C ∈ R)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-DIFE1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-07",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Quelles sont les solutions générales sur R de l'équation différentielle linéaire : y' = {a}y ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les solutions de l'équation y' = ay sont de la forme y(t) = C * e^(at).",
			HintLevel2 = $"Ici a = {a}, l'exposant de l'exponentielle est donc {a}t.",
			ExplanationText = $"Les solutions de y' = {a}y sont les fonctions y(t) = C * e^{{{a}t}}."
		};
	}

	private ExerciseQuestion GenerateAffineDiffEqQuestion()
	{
		var a = _random.Next(2, 5);
		var b = a * _random.Next(2, 5);
		var particuliere = b / a;

		var correct = $"y(t) = C * e^{{-{a}t}} + {particuliere}";
		var wrong1 = $"y(t) = C * e^{{{a}t}} + {particuliere}";
		var wrong2 = $"y(t) = C * e^{{-{a}t}} - {b}";
		var wrong3 = $"y(t) = {particuliere}t + C";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-DIFE2-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-07",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Résolvez sur R l'équation différentielle : y' + {a}y = {b}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Forme y' = ay + b. La solution générale est y(t) = C*e^(at) - b/a.",
			HintLevel2 = $"y' = -{a}y + {b}. La constante particulière constante est {b} / {a} = {particuliere}.",
			ExplanationText = $"Solution générale : y(t) = C * e^{{-{a}t}} + {particuliere}."
		};
	}

	private ExerciseQuestion GeneratePrimitiveFormulaQuestion()
	{
		var n = _random.Next(2, 6);
		var nextN = n + 1;

		var correct = $"F(x) = (1 / {nextN}) x^{nextN} + C";
		var wrong1 = $"F(x) = {n} x^{n - 1} + C";
		var wrong2 = $"F(x) = x^{nextN} + C";
		var wrong3 = $"F(x) = (1 / {n}) x^{nextN} + C";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-PRMT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-07",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Quelle est la forme générale des primitives sur R de la fonction f(x) = x^{n} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La primitive d'une puissance x^n est (1 / (n + 1)) * x^(n + 1) + C.",
			HintLevel2 = $"Augmentez l'exposant de 1 pour obtenir {nextN} et divisez par ce même nombre.",
			ExplanationText = $"Une primitive de x^{n} est F(x) = (1/{nextN}) x^{nextN} + C."
		};
	}
}

