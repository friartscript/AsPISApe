using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateAlgebraAndEquationsQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateRemarkableIdentityQuestion(),
			1 => GenerateFactorizationSquareDifferenceQuestion(),
			2 => GenerateProductNullEquationQuestion(),
			_ => GenerateQuotientNullEquationQuestion()
		};
	}

	private ExerciseQuestion GenerateRemarkableIdentityQuestion()
	{
		var a = _random.Next(2, 5);
		var b = _random.Next(2, 7);
		var aSq = a * a;
		var bSq = b * b;
		var twoAb = 2 * a * b;

		var correct = $"{aSq}x² - {twoAb}x + {bSq}";
		var wrong1 = $"{aSq}x² - {bSq}";
		var wrong2 = $"{aSq}x² + {twoAb}x + {bSq}";
		var wrong3 = $"{a}x² - {twoAb}x + {bSq}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-IDR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-04",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Développez et réduisez l'expression : ({a}x - {b})².",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deuxième identité remarquable : (u - v)² = u² - 2uv + v².",
			HintLevel2 = $"u = {a}x donc u² = {aSq}x², 2uv = 2 * {a}x * {b} = {twoAb}x, v² = {bSq}.",
			ExplanationText = $"({a}x - {b})² = {aSq}x² - {twoAb}x + {bSq}."
		};
	}

	private ExerciseQuestion GenerateFactorizationSquareDifferenceQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(2, 9);
		var aSq = a * a;
		var bSq = b * b;

		var correct = $"({a}x - {b})({a}x + {b})";
		var wrong1 = $"({a}x - {b})²";
		var wrong2 = $"({aSq}x - {bSq})({aSq}x + {bSq})";
		var wrong3 = $"({a}x + {b})²";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-FAC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-04",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Factorisez l'expression algébrique : {aSq}x² - {bSq}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Troisième identité remarquable : u² - v² = (u - v)(u + v).",
			HintLevel2 = $"{aSq}x² = ({a}x)² et {bSq} = {b}².",
			ExplanationText = $"u² - v² = (u - v)(u + v) donne ({a}x - {b})({a}x + {b})."
		};
	}

	private ExerciseQuestion GenerateProductNullEquationQuestion()
	{
		var p = _random.Next(2, 8);
		var q = _random.Next(1, 9);

		var correct = $"S = {{{-p} ; {q}}}";
		var wrong1 = $"S = {{{p} ; {-q}}}";
		var wrong2 = $"S = {{{p * q}}}";
		var wrong3 = $"S = {{{-p - q}}}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-EPN-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-04",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Résolvez dans R l'équation produit nul : (x + {p})(x - {q}) = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un produit de facteurs est nul si et seulement si l'un au moins des facteurs est nul.",
			HintLevel2 = $"x + {p} = 0 donne x = -{p}, et x - {q} = 0 donne x = {q}.",
			ExplanationText = $"Les solutions sont x = -{p} ou x = {q}."
		};
	}

	private ExerciseQuestion GenerateQuotientNullEquationQuestion()
	{
		var numSol = _random.Next(1, 6);
		var denomForbidden = _random.Next(7, 12);

		var correct = $"S = {{{numSol}}} (avec x ≠ {denomForbidden})";
		var wrong1 = $"S = {{{numSol} ; {denomForbidden}}}";
		var wrong2 = $"S = {{{-numSol}}}";
		var wrong3 = "S = ∅";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-EQN-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-04",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Résolvez l'équation quotient : (x - {numSol}) / (x - {denomForbidden}) = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un quotient A/B est nul si et seulement si son numérateur A = 0 et son dénominateur B ≠ 0.",
			HintLevel2 = $"Le numérateur s'annule en {numSol} et la valeur interdite est {denomForbidden}.",
			ExplanationText = $"Numérateur nul en {numSol} et dénominateur non nul."
		};
	}
}
