using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
}

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateLogarithmQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateLogProductRuleQuestion(),
			1 => GenerateLogPowerRuleQuestion(),
			2 => GenerateLogDerivativeCompositeQuestion(),
			_ => GenerateLogGrowthComparisonQuestion()
		};
	}

	private ExerciseQuestion GenerateLogProductRuleQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(3, 7);
		var prod = a * b;

		var correct = $"ln({a}) + ln({b})";
		var wrong1 = $"ln({a}) * ln({b})";
		var wrong2 = $"ln({a + b})";
		var wrong3 = $"ln({a}) - ln({b})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-LN1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-06",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Développez sous la forme d'une somme de logarithmes : ln({prod}) sachant que {prod} = {a} * {b}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété fondamentale du logarithme népérien : ln(u * v) = ln(u) + ln(v).",
			HintLevel2 = $"Le logarithme transforme un produit en une somme de logarithmes.",
			ExplanationText = $"ln({prod}) = ln({a} * {b}) = ln({a}) + ln({b})."
		};
	}

	private ExerciseQuestion GenerateLogPowerRuleQuestion()
	{
		var pwr = _random.Next(3, 8);
		var baseVal = _random.Next(2, 6);

		var correct = $"{pwr} ln({baseVal})";
		var wrong1 = $"(ln({baseVal}))^{pwr}";
		var wrong2 = $"ln({baseVal * pwr})";
		var wrong3 = $"ln({baseVal}) / {pwr}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-LN2-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-06",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Simplifiez l'expression : ln({baseVal}^{pwr}).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règle de la puissance : ln(a^n) = n * ln(a) pour tout a > 0.",
			HintLevel2 = $"L'exposant {pwr} sort devant sous forme de coefficient multiplicateur.",
			ExplanationText = $"ln({baseVal}^{pwr}) = {pwr} ln({baseVal})."
		};
	}

	private ExerciseQuestion GenerateLogDerivativeCompositeQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(1, 8);

		var correct = $"{a} / ({a}x + {b})";
		var wrong1 = $"1 / ({a}x + {b})";
		var wrong2 = $"{a} / x";
		var wrong3 = $"ln({a}) / ({a}x + {b})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-LND-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-06",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Quelle est la dérivée de la fonction f(x) = ln({a}x + {b}) sur son domaine de validité ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de dérivation de ln(u) : (ln(u))' = u' / u.",
			HintLevel2 = $"u(x) = {a}x + {b} donc u'(x) = {a}.",
			ExplanationText = $"(ln({a}x + {b}))' = u'/u = {correct}."
		};
	}

	private ExerciseQuestion GenerateLogGrowthComparisonQuestion()
	{
		var correct = "0";
		var wrong1 = "+∞";
		var wrong2 = "1";
		var wrong3 = "-∞";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-LNCMP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-06",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelle est la limite de croissance comparée : lim (x -> +∞) [ln(x) / x] ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "En +∞, la fonction puissance x l'emporte toujours sur la fonction logarithme ln(x).",
			HintLevel2 = "Le dénominateur grandit infiniment plus vite que le numérateur.",
			ExplanationText = "Par croissance comparée en +∞, lim [ln(x) / x] = 0."
		};
	}
}

