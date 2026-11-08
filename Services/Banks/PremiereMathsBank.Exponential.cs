using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateExponentialQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateExponentialProductRuleQuestion(),
			1 => GenerateExponentialQuotientRuleQuestion(),
			2 => GenerateExponentialPositivityQuestion(),
			_ => GenerateExponentialEquationQuestion()
		};
	}

	private ExerciseQuestion GenerateExponentialProductRuleQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(2, 6);
		var sum = a + b;

		var correct = $"e^{{{sum}x}}";
		var wrong1 = $"e^{{{a * b}x²}}";
		var wrong2 = $"e^{{{sum}x²}}";
		var wrong3 = $"2e^{{{sum}x}}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-EXP1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-06",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Simplifiez l'expression sous la forme d'une seule exponentielle : e^{{{a}x}} * e^{{{b}x}}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété fondamentale de l'exponentielle : e^u * e^v = e^(u + v).",
			HintLevel2 = $"Additionnez les exposants : {a}x + {b}x.",
			ExplanationText = $"e^u * e^v = e^(u + v) donne e^{{{a}x + {b}x}} = {correct}."
		};
	}

	private ExerciseQuestion GenerateExponentialQuotientRuleQuestion()
	{
		var a = _random.Next(5, 9);
		var b = _random.Next(2, 5);
		var diff = a - b;

		var correct = $"e^{{{diff}x}}";
		var wrong1 = $"e^{{{a + b}x}}";
		var wrong2 = $"e^{{{a / b}x}}";
		var wrong3 = $"e^{{{-diff}x}}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-EXP2-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-06",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Simplifiez le quotient d'exponentielles : e^{{{a}x}} / e^{{{b}x}}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété du quotient : e^u / e^v = e^(u - v).",
			HintLevel2 = $"Soustrayez les exposants : {a}x - {b}x.",
			ExplanationText = $"e^u / e^v = e^(u - v) donne e^{{{diff}x}}."
		};
	}

	private ExerciseQuestion GenerateExponentialPositivityQuestion()
	{
		var correct = "Pour tout réel x, e^x > 0";
		var wrong1 = "e^x > 0 uniquement si x > 0";
		var wrong2 = "e^x peut être négatif si x est négatif";
		var wrong3 = "e^x s'annule en x = 0";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-EXPP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-06",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Quelle affirmation caractérise le signe de la fonction exponentielle sur R ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La courbe de la fonction exponentielle est strictement au-dessus de l'axe des abscisses.",
			HintLevel2 = "La fonction exponentielle ne s'annule jamais et ne prend que des valeurs strictement positives.",
			ExplanationText = "La fonction exponentielle est strictement positive sur R entier."
		};
	}

	private ExerciseQuestion GenerateExponentialEquationQuestion()
	{
		var a = _random.Next(2, 5);
		var b = _random.Next(1, 8);
		var target = (a * 2) + b;

		var correct = "x = 2";
		var wrong1 = "x = 0";
		var wrong2 = "x = 1";
		var wrong3 = $"x = {target}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-EXPE-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-06",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Résolvez dans R l'équation : e^({a}x + {b}) = e^{target}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Par stricte croissance, e^u = e^v équivaut à u = v.",
			HintLevel2 = $"Égalisez les exposants : {a}x + {b} = {target}, puis isolez x.",
			ExplanationText = $"{a}x + {b} = {target} donne {a}x = {target - b} d'où x = 2."
		};
	}
}
