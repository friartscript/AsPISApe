using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateDerivationBasicsQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateTangentEquationQuestion(),
			1 => GeneratePowerDerivativeQuestion(),
			2 => GenerateProductDerivativeRuleQuestion(),
			_ => GenerateQuotientDerivativeRuleQuestion()
		};
	}

	private ExerciseQuestion GenerateTangentEquationQuestion()
	{
		var a = _random.Next(1, 4);
		var fa = a * a;
		var fPrimeA = 2 * a;
		var p = fa - (fPrimeA * a);

		var pStr = p < 0 ? $"- {-p}" : $"+ {p}";
		var correct = $"y = {fPrimeA}x {pStr}";
		var wrong1 = $"y = {fPrimeA}x + {fa}";
		var wrong2 = $"y = {fa}x + {fPrimeA}";
		var wrong3 = $"y = {a}x + {fa}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-TNG-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-04",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Soit f(x) = x². Déterminez l'équation de la tangente à la courbe de f au point d'abscisse a = {a}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Équation de la tangente : y = f'(a)(x - a) + f(a).",
			HintLevel2 = $"f({a}) = {fa} et f'({a}) = 2 * {a} = {fPrimeA}. Développez {fPrimeA}(x - {a}) + {fa}.",
			ExplanationText = $"y = {fPrimeA}(x - {a}) + {fa} = {correct}."
		};
	}

	private ExerciseQuestion GeneratePowerDerivativeQuestion()
	{
		var n = _random.Next(3, 7);
		var c = _random.Next(2, 6);
		var coeff = c * n;
		var pwr = n - 1;

		var correct = $"{coeff}x^{pwr}";
		var wrong1 = $"{c}x^{pwr}";
		var wrong2 = $"{coeff}x^{n}";
		var wrong3 = $"{c * (n + 1)}x^{n + 1}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-DRV-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-04",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Quelle est la fonction dérivée de f(x) = {c}x^{n} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règle de dérivation d'une puissance : (x^n)' = n * x^(n - 1).",
			HintLevel2 = $"Multipliez le coefficient {c} par l'exposant {n} et abaissez l'exposant de 1.",
			ExplanationText = $"({c}x^{n})' = {c} * {n} * x^{pwr} = {correct}."
		};
	}

	private ExerciseQuestion GenerateProductDerivativeRuleQuestion()
	{
		var correct = "(uv)' = u'v + uv'";
		var wrong1 = "(uv)' = u' * v'";
		var wrong2 = "(uv)' = u'v - uv'";
		var wrong3 = "(uv)' = (u' + v') / 2";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-PRDD-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-04",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Quelle est la formule de dérivation d'un produit de deux fonctions u et v dérivables ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La dérivée d'un produit n'est PAS le produit des dérivées !",
			HintLevel2 = "Chaque facteur est dérivé à son tour puis multiplié par l'autre facteur non dérivé.",
			ExplanationText = "Formule de Leibniz pour le produit : (uv)' = u'v + uv'."
		};
	}

	private ExerciseQuestion GenerateQuotientDerivativeRuleQuestion()
	{
		var correct = "(u / v)' = (u'v - uv') / v²";
		var wrong1 = "(u / v)' = u' / v'";
		var wrong2 = "(u / v)' = (u'v + uv') / v²";
		var wrong3 = "(u / v)' = (uv' - u'v) / v";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-QTD-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-04",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Quelle est la formule de dérivation d'un quotient u / v (pour v(x) ≠ 0) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le numérateur contient un signe moins et le dénominateur est mis au carré.",
			HintLevel2 = "Attention à l'ordre au numérateur : u'v - uv'.",
			ExplanationText = "Formule du quotient : (u/v)' = (u'v - uv') / v²."
		};
	}
}
