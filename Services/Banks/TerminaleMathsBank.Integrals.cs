using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateIntegralsQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateDefiniteIntegralCalculationQuestion(),
			1 => GenerateAverageValueOfFunctionQuestion(),
			_ => GenerateIntegrationByPartsFormulaQuestion()
		};
	}

	private ExerciseQuestion GenerateDefiniteIntegralCalculationQuestion()
	{
		var b = _random.Next(2, 5);
		var integralVal = (b * b * b) / 3.0;

		var correct = $"{b * b * b} / 3";
		var wrong1 = $"{b * b} / 2";
		var wrong2 = $"{b * b * b}";
		var wrong3 = $"{(b * b * b) - 1} / 3";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-INT1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-08",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Calculez l'intégrale définie I = ∫[0 à {b}] x² dx.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une primitive de x² est F(x) = (1/3) x³. Calculez F(b) - F(0).",
			HintLevel2 = $"F({b}) - F(0) = ({b}³ / 3) - 0 = {b * b * b} / 3.",
			ExplanationText = $"∫[0 à {b}] x² dx = [{b}³ / 3] - 0 = {correct}."
		};
	}

	private ExerciseQuestion GenerateAverageValueOfFunctionQuestion()
	{
		var a = 0;
		var b = _random.Next(2, 6);
		var correct = $"μ = (1 / ({b} - {a})) * ∫[{a} à {b}] f(t) dt";
		var wrong1 = $"μ = ∫[{a} à {b}] f(t) dt";
		var wrong2 = $"μ = (f({a}) + f({b})) / 2";
		var wrong3 = $"μ = ({b} - {a}) * ∫[{a} à {b}] f(t) dt";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-INTM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-08",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Quelle est la formule de la valeur moyenne μ d'une fonction continue f sur l'intervalle [{a} ; {b}] ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La valeur moyenne est l'intégrale divisée par la longueur de l'intervalle.",
			HintLevel2 = "La longueur de l'intervalle [a ; b] est b - a.",
			ExplanationText = "La valeur moyenne est μ = (1 / (b - a)) * ∫[a à b] f(t) dt."
		};
	}

	private ExerciseQuestion GenerateIntegrationByPartsFormulaQuestion()
	{
		var correct = "∫[a à b] u'(x)v(x) dx = [u(x)v(x)][a à b] - ∫[a à b] u(x)v'(x) dx";
		var wrong1 = "∫[a à b] u'(x)v(x) dx = [u(x)v(x)][a à b] + ∫[a à b] u(x)v'(x) dx";
		var wrong2 = "∫[a à b] u'(x)v(x) dx = [u'(x)v'(x)][a à b]";
		var wrong3 = "∫[a à b] u'(x)v(x) dx = (∫ u' dx) * (∫ v dx)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-INTIPP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-08",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelle est la formule générale d'intégration par parties (IPP) pour deux fonctions u et v de classe C¹ ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'intégration par parties découle de la dérivation d'un produit (uv)' = u'v + uv'.",
			HintLevel2 = "Le terme intégral après le crochet comporte un signe moins.",
			ExplanationText = "Formule IPP : ∫ u'v = [uv] - ∫ uv'."
		};
	}
}

