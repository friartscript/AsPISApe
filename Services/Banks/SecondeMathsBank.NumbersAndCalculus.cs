using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateNumbersAndCalculusQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateNumberSetsQuestion(),
			1 => GeneratePowerRulesQuestion(),
			2 => GenerateSquareRootSimplificationQuestion(),
			_ => GeneratePrimeDecompositionQuestion()
		};
	}

	private ExerciseQuestion GenerateNumberSetsQuestion()
	{
		var items = new (string Num, string Set, string Wrong1, string Wrong2, string Wrong3)[]
		{
			("-7", "Z (Entiers relatifs)", "N (Entiers naturels)", "D uniquement", "Q \\ D"),
			("1/4", "D (Nombres décimaux)", "Z (Entiers relatifs)", "N (Entiers naturels)", "R \\ Q (Irrationnels)"),
			("1/3", "Q (Rationnels non décimaux)", "D (Nombres décimaux)", "Z (Entiers relatifs)", "N (Entiers naturels)"),
			("√2", "R \\ Q (Irrationnels)", "Q (Nombres rationnels)", "D (Nombres décimaux)", "Z (Entiers relatifs)"),
			("π", "R \\ Q (Irrationnels)", "Q (Rationnels)", "D (Décimaux)", "Z (Relatifs)")
		};
		var pick = items[_random.Next(items.Length)];

		var choices = Shuffle(pick.Set, pick.Wrong1, pick.Wrong2, pick.Wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-SET-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-02",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quel est le plus petit ensemble de nombres auquel appartient le nombre {pick.Num} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Rappelez-vous l'inclusion : N ⊂ Z ⊂ D ⊂ Q ⊂ R.",
			HintLevel2 = $"Vérifiez si l'écriture décimale de {pick.Num} s'arrête ou est infinie non périodique.",
			ExplanationText = $"{pick.Num} appartient au plus petit ensemble {pick.Set}."
		};
	}

	private ExerciseQuestion GeneratePowerRulesQuestion()
	{
		var a = _random.Next(2, 6);
		var p1 = _random.Next(2, 6);
		var p2 = _random.Next(2, 5);
		var pSum = p1 + p2;

		var correct = $"{a}^{pSum}";
		var wrong1 = $"{a}^{p1 * p2}";
		var wrong2 = $"{a * a}^{pSum}";
		var wrong3 = $"{a}^{pSum + 1}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-POW-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-02",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Simplifiez l'expression sous la forme d'une seule puissance : {a}^{p1} * {a}^{p2}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété des puissances : a^n * a^m = a^(n+m).",
			HintLevel2 = $"Additionnez les exposants : {p1} + {p2}.",
			ExplanationText = $"a^n * a^m = a^(n+m), donc {a}^{p1} * {a}^{p2} = {a}^{pSum}."
		};
	}

	private ExerciseQuestion GenerateSquareRootSimplificationQuestion()
	{
		var squares = new (int a, int k, int num)[]
		{
			(2, 2, 8),
			(2, 3, 12),
			(3, 2, 18),
			(2, 5, 20),
			(3, 3, 27),
			(4, 2, 32),
			(5, 2, 50),
			(6, 2, 72)
		};
		var pick = squares[_random.Next(squares.Length)];
		var correct = $"{pick.a}√{pick.k}";
		var wrong1 = $"{pick.k}√{pick.a}";
		var wrong2 = $"{pick.a * pick.k}√2";
		var wrong3 = $"{pick.a + pick.k}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-SQR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-02",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Écrivez √{pick.num} sous la forme a√b avec b le plus petit entier possible.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Décomposez le nombre sous le radical en un produit contenant un carré parfait.",
			HintLevel2 = $"{pick.num} = {pick.a * pick.a} * {pick.k}, et √({pick.a * pick.a}) = {pick.a}.",
			ExplanationText = $"√{pick.num} = √({pick.a * pick.a} * {pick.k}) = {correct}."
		};
	}

	private ExerciseQuestion GeneratePrimeDecompositionQuestion()
	{
		var primes = new (int n, string factors, string w1, string w2, string w3)[]
		{
			(60, "2² * 3 * 5", "2 * 3² * 5", "4 * 15", "2³ * 5"),
			(72, "2³ * 3²", "2² * 3³", "8 * 9", "2⁴ * 3"),
			(84, "2² * 3 * 7", "2 * 3² * 7", "4 * 21", "2³ * 7"),
			(90, "2 * 3² * 5", "2² * 3 * 5", "9 * 10", "3³ * 5")
		};
		var pick = primes[_random.Next(primes.Length)];

		var choices = Shuffle(pick.factors, pick.w1, pick.w2, pick.w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-PRM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-02",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quelle est la décomposition en facteurs premiers du nombre {pick.n} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez successivement par les nombres premiers : 2, 3, 5, 7...",
			HintLevel2 = "Tous les facteurs de la décomposition doivent être strictement premiers.",
			ExplanationText = $"La décomposition exacte en produit de nombres premiers est {pick.factors}."
		};
	}
}
