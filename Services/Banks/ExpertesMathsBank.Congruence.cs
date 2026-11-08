using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	public ExerciseQuestion GenerateCongruenceQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateCongruencePowerQuestion(),
			1 => GenerateEuclideanRemainderQuestion(),
			_ => GenerateCongruenceDefinitionQuestion()
		};
	}

	private ExerciseQuestion GenerateCongruencePowerQuestion()
	{
		var mod = _random.Next(5, 8);
		var baseVal = mod - 1;
		var pwr = _random.Next(10, 30) * 2;

		var correct = "1";
		var wrong1 = $"{baseVal}";
		var wrong2 = "0";
		var wrong3 = "-1";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-CNGP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-03",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Quel est le reste de la division euclidienne de {baseVal}^{pwr} par {mod} (calcul modulo {mod}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = $"Remarquez que {baseVal} ≡ -1 [ {mod} ].",
			HintLevel2 = $"Comme l'exposant {pwr} est un entier pair, (-1)^{pwr} = 1.",
			ExplanationText = $"{baseVal} ≡ -1 [{mod}] et comme l'exposant est pair, le reste est 1."
		};
	}

	private ExerciseQuestion GenerateEuclideanRemainderQuestion()
	{
		var b = _random.Next(6, 12);
		var q = _random.Next(5, 10);
		var r = _random.Next(1, b);
		var a = (b * q) + r;

		var correct = r.ToString();
		var wrong1 = q.ToString();
		var wrong2 = (r + 1).ToString();
		var wrong3 = (b - r).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-EUC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-03",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Dans la division euclidienne de {a} par {b}, quel est le reste r sachant que {a} = {b} * {q} + {r} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Par unicité de la division euclidienne, le reste doit vérifier strictement 0 ≤ r < b.",
			HintLevel2 = $"{r} est strictement inférieur au diviseur {b}.",
			ExplanationText = $"Le reste de la division euclidienne est {r} car 0 ≤ {r} < {b}."
		};
	}

	private ExerciseQuestion GenerateCongruenceDefinitionQuestion()
	{
		var correct = "n divise la différence a - b";
		var wrong1 = "n divise la somme a + b";
		var wrong2 = "a et b sont obligatoirement égaux";
		var wrong3 = "a divise b modulo n";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-DEFCNG-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-03",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Par définition, que signifie la notation a ≡ b [n] pour un entier n ≥ 2 ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux nombres sont congrus modulo n s'ils ont le même reste par n.",
			HintLevel2 = "Leur différence est un multiple de n, c'est-à-dire que n divise a - b.",
			ExplanationText = "a ≡ b [n] signifie exactement que n divise la différence a - b."
		};
	}
}

