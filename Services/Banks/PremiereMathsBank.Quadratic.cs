using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateQuadraticQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateDiscriminantValueQuestion(),
			1 => GenerateTwoRootsQuadraticQuestion(),
			2 => GenerateCanonicalFormQuestion(),
			_ => GenerateQuadraticSignRuleQuestion()
		};
	}

	private ExerciseQuestion GenerateDiscriminantValueQuestion()
	{
		var a = 1;
		var b = _random.Next(2, 6) * 2;
		var c = _random.Next(1, 8);
		var delta = (b * b) - (4 * a * c);

		var correct = delta.ToString();
		var wrong1 = ((b * b) + (4 * a * c)).ToString();
		var wrong2 = (b * b).ToString();
		var wrong3 = (delta + 4).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-DIS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-03",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Calculez le discriminant Δ du trinôme du second degré : P(x) = x² + {b}x + {c}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule du discriminant : Δ = b² - 4ac.",
			HintLevel2 = $"Δ = {b}² - 4 * 1 * {c} = {b * b} - {4 * c}.",
			ExplanationText = $"Δ = b² - 4ac = {b * b} - {4 * c} = {delta}."
		};
	}

	private ExerciseQuestion GenerateTwoRootsQuadraticQuestion()
	{
		var r1 = _random.Next(1, 4);
		var r2 = r1 + _random.Next(1, 4);
		var b = -(r1 + r2);
		var c = r1 * r2;

		var bStr = b < 0 ? $"- {-b}x" : $"+ {b}x";
		var correct = $"S = {{{r1} ; {r2}}}";
		var wrong1 = $"S = {{{-r1} ; {-r2}}}";
		var wrong2 = $"S = {{{r1 + r2}}}";
		var wrong3 = $"S = {{{r1 * r2}}}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-ROT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-03",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Résolvez dans R l'équation du second degré : x² {bStr} + {c} = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Cherchez deux nombres dont la somme est -b et le produit est c.",
			HintLevel2 = $"{r1} + {r2} = {-b} et {r1} * {r2} = {c}.",
			ExplanationText = $"L'équation admet pour solutions x = {r1} et x = {r2}."
		};
	}

	private ExerciseQuestion GenerateCanonicalFormQuestion()
	{
		var alpha = _random.Next(1, 5);
		var beta = _random.Next(1, 7);
		var b = -2 * alpha;
		var c = (alpha * alpha) + beta;

		var correct = $"(x - {alpha})² + {beta}";
		var wrong1 = $"(x + {alpha})² + {beta}";
		var wrong2 = $"(x - {alpha})² - {beta}";
		var wrong3 = $"(x - {alpha * 2})² + {c}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-CAN-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-03",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Quelle est la forme canonique du trinôme f(x) = x² - {2 * alpha}x + {c} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Forme canonique : a(x - α)² + β avec α = -b / (2a).",
			HintLevel2 = $"α = {2 * alpha} / 2 = {alpha}, et β = f({alpha}) = {alpha}² - {2 * alpha * alpha} + {c} = {beta}.",
			ExplanationText = $"f(x) s'écrit sous forme canonique (x - {alpha})² + {beta}."
		};
	}

	private ExerciseQuestion GenerateQuadraticSignRuleQuestion()
	{
		var correct = "Du signe de a à l'extérieur des racines et du signe de -a entre les racines";
		var wrong1 = "Toujours du signe de a sur tout R";
		var wrong2 = "Toujours positif quelle que soit la valeur de a";
		var wrong3 = "Du signe de -a à l'extérieur des racines";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-SGNQ-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-03",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Lorsque le discriminant Δ est strictement positif, quel est le signe du trinôme ax² + bx + c ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règle du signe du trinôme : regardez le signe du coefficient dominant a.",
			HintLevel2 = "Le trinôme prend le signe opposé de a uniquement strictement entre ses deux racines.",
			ExplanationText = "Un trinôme est du signe de a à l'extérieur de ses racines."
		};
	}
}
