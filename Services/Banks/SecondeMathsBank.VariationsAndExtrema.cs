using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateVariationsAndExtremaQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateFunctionMonotonicityDefinitionQuestion(),
			1 => GenerateDecreasingImageBoundingQuestion(),
			_ => GenerateGlobalExtremumQuestion()
		};
	}

	private ExerciseQuestion GenerateFunctionMonotonicityDefinitionQuestion()
	{
		var correct = "Conserve l'ordre : pour a ≤ b, f(a) ≤ f(b)";
		var wrong1 = "Inverse l'ordre : pour a ≤ b, f(a) ≥ f(b)";
		var wrong2 = "Prend toujours des valeurs positives";
		var wrong3 = "Possède une courbe qui descend de gauche à droite";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-VAR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-09",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = "Par définition, que signifie qu'une fonction f est strictement croissante sur un intervalle I ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fonction croissante conserve l'ordre des éléments.",
			HintLevel2 = "Si a < b alors leurs images sont rangées dans le même sens : f(a) < f(b).",
			ExplanationText = "Une fonction croissante conserve l'ordre : si a ≤ b alors f(a) ≤ f(b)."
		};
	}

	private ExerciseQuestion GenerateDecreasingImageBoundingQuestion()
	{
		var minX = _random.Next(1, 4);
		var maxX = minX + _random.Next(2, 5);
		var imgMaxX = _random.Next(-5, 0);
		var imgMinX = imgMaxX + _random.Next(6, 12);

		var correct = $"[{imgMaxX} ; {imgMinX}]";
		var wrong1 = $"[{imgMinX} ; {imgMaxX}]";
		var wrong2 = $"[{minX} ; {maxX}]";
		var wrong3 = $"[-{imgMinX} ; {imgMinX}]";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-BND-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-09",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Une fonction f est strictement décroissante sur [{minX} ; {maxX}]. Si f({minX}) = {imgMinX} et f({maxX}) = {imgMaxX}, quel est l'encadrement de f(x) pour x ∈ [{minX} ; {maxX}] ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fonction décroissante inverse l'ordre des bornes de l'intervalle.",
			HintLevel2 = $"Le minimum de f(x) est f({maxX}) = {imgMaxX} et le maximum est f({minX}) = {imgMinX}.",
			ExplanationText = $"f étant décroissante, {imgMaxX} ≤ f(x) ≤ {imgMinX}."
		};
	}

	private ExerciseQuestion GenerateGlobalExtremumQuestion()
	{
		var a = _random.Next(1, 5);
		var x0 = _random.Next(-3, 4);
		var y0 = _random.Next(1, 8);

		var correct = $"Un minimum égal à {y0}, atteint en x = {x0}";
		var wrong1 = $"Un maximum égal à {y0}, atteint en x = {x0}";
		var wrong2 = $"Un minimum égal à {-y0}, atteint en x = {-x0}";
		var wrong3 = $"Un maximum égal à {a}, atteint en x = 0";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-EXT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-09",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Soit f(x) = {a}(x - {x0})² + {y0}. Quel extremum admet cette fonction sur R ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour tout x, un carré est positif ou nul : (x - x0)² ≥ 0.",
			HintLevel2 = $"Comme {a} > 0, {a}(x - {x0})² ≥ 0, donc f(x) ≥ {y0}.",
			ExplanationText = $"Le carré s'annule en x = {x0}, fournissant le minimum global {y0}."
		};
	}
}
