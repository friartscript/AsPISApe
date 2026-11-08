using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	public ExerciseQuestion GeneratePrimesFermatQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateFermatLittleTheoremQuestion(),
			1 => GenerateDivisorsCountQuestion(),
			_ => GenerateInfinitudeOfPrimesQuestion()
		};
	}

	private ExerciseQuestion GenerateFermatLittleTheoremQuestion()
	{
		var correct = "a^(p - 1) ≡ 1 [p]";
		var wrong1 = "a^p ≡ 1 [p]";
		var wrong2 = "a^(p - 1) ≡ 0 [p]";
		var wrong3 = "a^p ≡ p [a]";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-FRMT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-05",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Soit p un nombre premier et a un entier non divisible par p. Que stipule le Petit Théorème de Fermat ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le théorème établit une congruence modulo p avec l'exposant p - 1.",
			HintLevel2 = "La puissance p - 1 est toujours congrue à 1 modulo p.",
			ExplanationText = "Petit théorème de Fermat : si p ne divise pas a, a^(p - 1) ≡ 1 [p]."
		};
	}

	private ExerciseQuestion GenerateDivisorsCountQuestion()
	{
		var primes = new (int n, string decomp, int count, int w1, int w2, int w3)[]
		{
			(72, "2³ * 3²", 12, 6, 8, 24),
			(60, "2² * 3¹ * 5¹", 12, 6, 10, 15),
			(100, "2² * 5²", 9, 4, 8, 12),
			(48, "2⁴ * 3¹", 10, 5, 8, 16)
		};
		var pick = primes[_random.Next(primes.Length)];

		var choices = Shuffle(pick.count.ToString(), pick.w1.ToString(), pick.w2.ToString(), pick.w3.ToString(), out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-DIVC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-05",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Combien de diviseurs positifs possède le nombre {pick.n} dont la décomposition est {pick.decomp} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule du nombre de diviseurs : produit des (exposant + 1) de chaque facteur premier.",
			HintLevel2 = "Pour p1^a * p2^b, le nombre de diviseurs est (a + 1) * (b + 1).",
			ExplanationText = $"Le nombre total de diviseurs positifs est {pick.count}."
		};
	}

	private ExerciseQuestion GenerateInfinitudeOfPrimesQuestion()
	{
		var correct = "Euclide par l'absurde en considérant N = p1*p2*...*pk + 1";
		var wrong1 = "Pythagore par construction géométrique de triangles";
		var wrong2 = "Descartes par coordonnées cartésiennes";
		var wrong3 = "Newton par calcul infinitésimal";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-INFPR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-05",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Quel mathématicien de l'Antiquité a démontré pour la première fois l'infinité des nombres premiers à l'aide d'un raisonnement par l'absurde célèbre ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Cette preuve fondatrice figure dans le Livre IX des Éléments.",
			HintLevel2 = "Il suppose une liste finie de nombres premiers et construit leur produit plus un.",
			ExplanationText = "Euclide a prouvé l'infinité des nombres premiers dans ses Éléments."
		};
	}
}

