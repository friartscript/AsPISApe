using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateTrigFunctionsQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateTrigDerivativesQuestion(),
			1 => GenerateComposedTrigDerivativeQuestion(),
			_ => GenerateCosineEquationGeneralSolutionQuestion()
		};
	}

	private ExerciseQuestion GenerateTrigDerivativesQuestion()
	{
		var correct = "(cos x)' = -sin x et (sin x)' = cos x";
		var wrong1 = "(cos x)' = sin x et (sin x)' = -cos x";
		var wrong2 = "(cos x)' = -cos x et (sin x)' = -sin x";
		var wrong3 = "(cos x)' = tan x et (sin x)' = 1 / cos x";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-TRGD-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-03",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelles sont les dérivées respectives des fonctions cosinus et sinus sur R ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention au signe moins qui apparaît lors de la dérivation du cosinus.",
			HintLevel2 = "La dérivée de cos est l'opposé de sin, celle de sin est cos.",
			ExplanationText = "(cos x)' = -sin x et (sin x)' = cos x."
		};
	}

	private ExerciseQuestion GenerateComposedTrigDerivativeQuestion()
	{
		var w = _random.Next(2, 6);
		var correct = $"-{w} sin({w}x)";
		var wrong1 = $"{w} cos({w}x)";
		var wrong2 = $"-sin({w}x)";
		var wrong3 = $"-{w * w} cos({w}x)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-CMPTRG-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-03",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Quelle est la dérivée de la fonction f(x) = cos({w}x) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de dérivation composée : (cos(ax + b))' = -a * sin(ax + b).",
			HintLevel2 = $"Ici a = {w}, la dérivée fait sortir le facteur -{w}.",
			ExplanationText = $"(cos({w}x))' = -{w} sin({w}x)."
		};
	}

	private ExerciseQuestion GenerateCosineEquationGeneralSolutionQuestion()
	{
		var correct = "x = a + 2kπ ou x = -a + 2kπ (avec k ∈ Z)";
		var wrong1 = "x = a + kπ (avec k ∈ Z)";
		var wrong2 = "x = a + 2kπ ou x = π - a + 2kπ (avec k ∈ Z)";
		var wrong3 = "x = a uniquement";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-EQTRG-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-03",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Dans R, quel est l'ensemble des solutions de l'équation trigonométrique cos(x) = cos(a) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux angles ont le même cosinus s'ils sont égaux ou opposés modulo 2π.",
			HintLevel2 = "cos(-x) = cos(x), les deux familles de solutions sont a + 2kπ et -a + 2kπ.",
			ExplanationText = "cos(x) = cos(a) équivaut à x = a + 2kπ ou x = -a + 2kπ (k ∈ Z)."
		};
	}
}

