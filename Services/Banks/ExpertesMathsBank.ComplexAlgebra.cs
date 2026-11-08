using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	public ExerciseQuestion GenerateComplexAlgebraQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateComplexProductQuestion(),
			1 => GenerateComplexConjugateQuestion(),
			_ => GenerateNegativeDiscriminantQuadraticQuestion()
		};
	}

	private ExerciseQuestion GenerateComplexProductQuestion()
	{
		var a = _random.Next(2, 5);
		var b = _random.Next(2, 5);
		var realPart = (a * a) - (b * b);
		var imagPart = 2 * a * b;

		var correct = $"{realPart} + {imagPart}i";
		var wrong1 = $"{realPart} - {imagPart}i";
		var wrong2 = $"{a * a + b * b} + {imagPart}i";
		var wrong3 = $"{a * a} + {b * b}i";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-CPX1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-01",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Développez sous forme algébrique le carré du nombre complexe z = {a} + {b}i (rappel : i² = -1).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez l'identité remarquable : (a + ib)² = a² - b² + 2abi.",
			HintLevel2 = $"{a}² - {b}² = {a * a} - {b * b} = {realPart}, et 2 * {a} * {b} = {imagPart}.",
			ExplanationText = $"( {a} + {b}i )² = {realPart} + {imagPart}i."
		};
	}

	private ExerciseQuestion GenerateComplexConjugateQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(2, 6);
		var normSq = (a * a) + (b * b);

		var correct = normSq.ToString();
		var wrong1 = ((a * a) - (b * b)).ToString();
		var wrong2 = (a + b).ToString();
		var wrong3 = $"{normSq}i";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-CNJ-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-01",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Pour z = {a} + {b}i, quelle est la valeur exacte du produit z * z̄ avec son conjugué ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété fondamentale du conjugué : z * z̄ = a² + b² (nombre réel positif).",
			HintLevel2 = $"Calculez {a}² + {b}² = {a * a} + {b * b}.",
			ExplanationText = $"z * z̄ = a² + b² = {normSq}."
		};
	}

	private ExerciseQuestion GenerateNegativeDiscriminantQuadraticQuestion()
	{
		var w = _random.Next(2, 5);
		var wSq = w * w;

		var correct = $"S = {{-{w}i ; {w}i}}";
		var wrong1 = $"S = {{{w} ; -{w}}}";
		var wrong2 = $"S = {{{wSq}i}}";
		var wrong3 = "Aucune solution dans C";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-QDTC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-01",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Résolvez dans C l'équation : z² + {wSq} = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "z² = -{wSq} = ({w}i)². Dans C, un nombre négatif admet deux racines carrées imaginaires pures.",
			HintLevel2 = $"Les solutions sont -i√{wSq} et i√{wSq}.",
			ExplanationText = $"Dans C, z² = -{wSq} admet pour solutions -{w}i et {w}i."
		};
	}
}

