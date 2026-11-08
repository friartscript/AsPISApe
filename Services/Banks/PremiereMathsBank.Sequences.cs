using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateSequencesQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateArithmeticSequenceTermQuestion(),
			1 => GenerateGeometricSequenceTermQuestion(),
			2 => GenerateSumOfIntegersQuestion(),
			_ => GenerateGeometricLimitQuestion()
		};
	}

	private ExerciseQuestion GenerateArithmeticSequenceTermQuestion()
	{
		var u0 = _random.Next(2, 9);
		var r = _random.Next(3, 7);
		var n = _random.Next(10, 25);
		var un = u0 + (n * r);

		var correct = un.ToString();
		var wrong1 = (u0 + ((n - 1) * r)).ToString();
		var wrong2 = (u0 * (n + r)).ToString();
		var wrong3 = (un + r).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-ARIT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-02",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Soit (u_n) la suite arithmétique de premier terme u_0 = {u0} et de raison r = {r}. Quelle est la valeur de u_{{{n}}} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Terme général d'une suite arithmétique : u_n = u_0 + n * r.",
			HintLevel2 = $"Calculez {u0} + {n} * {r}.",
			ExplanationText = $"u_{{{n}}} = {u0} + {n} * {r} = {un}."
		};
	}

	private ExerciseQuestion GenerateGeometricSequenceTermQuestion()
	{
		var v0 = _random.Next(2, 5);
		var q = _random.Next(2, 4);
		var n = _random.Next(3, 6);
		var vn = v0 * (int)Math.Pow(q, n);

		var correct = vn.ToString();
		var wrong1 = (v0 * (int)Math.Pow(q, n - 1)).ToString();
		var wrong2 = (v0 + (n * q)).ToString();
		var wrong3 = (vn * q).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-GEOM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-02",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Soit (v_n) la suite géométrique de premier terme v_0 = {v0} et de raison q = {q}. Quelle est la valeur de v_{{{n}}} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Terme général d'une suite géométrique : v_n = v_0 * q^n.",
			HintLevel2 = $"{q}^{n} = {(int)Math.Pow(q, n)}, puis multipliez par {v0}.",
			ExplanationText = $"v_{{{n}}} = {v0} * {q}^{n} = {vn}."
		};
	}

	private ExerciseQuestion GenerateSumOfIntegersQuestion()
	{
		var n = _random.Next(20, 50) * 2;
		var sum = n * (n + 1) / 2;

		var correct = sum.ToString();
		var wrong1 = (n * n / 2).ToString();
		var wrong2 = ((n + 1) * (n + 2) / 2).ToString();
		var wrong3 = (sum + n).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-SUMI-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-02",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Calculez la somme des entiers de 1 jusqu'à {n} : S = 1 + 2 + ... + {n}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de la somme des premiers entiers : S = n(n + 1) / 2.",
			HintLevel2 = $"Calculez {n} * {n + 1} / 2.",
			ExplanationText = $"S = {n} * {n + 1} / 2 = {sum}."
		};
	}

	private ExerciseQuestion GenerateGeometricLimitQuestion()
	{
		var frac = _random.Next(2, 6);
		var correct = "La suite converge vers 0";
		var wrong1 = "La suite diverge vers +∞";
		var wrong2 = "La suite converge vers 1";
		var wrong3 = "La suite n'a pas de limite car elle oscille";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-LIM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-02",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Quel est le comportement à l'infini de la suite géométrique u_n = (1 / {frac})^n ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Si la raison q vérifie -1 < q < 1, alors lim q^n = 0.",
			HintLevel2 = $"Ici q = 1/{frac} est strictement compris entre 0 et 1.",
			ExplanationText = $"Comme |1/{frac}| < 1, la suite converge vers 0."
		};
	}
}
