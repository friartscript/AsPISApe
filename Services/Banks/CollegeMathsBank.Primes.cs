using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GeneratePrimeNumbersAndFactors()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateIdentifyPrimeQuestion(),
			1 => CreatePrimeFactorizationQuestion(),
			2 => CreateNonPrimeIdentificationQuestion(),
			_ => CreatePisaBusSynchronizationQuestion()
		};
	}

	private ExerciseQuestion CreateIdentifyPrimeQuestion()
	{
		var primes = new[] { 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
		var nonPrimes = new[] { 21, 27, 33, 35, 39, 45, 49, 51, 55, 57, 63, 65, 77, 81, 85, 87, 91, 93, 95 };

		var prime = primes[_random.Next(primes.Length)];
		var np1 = nonPrimes[_random.Next(nonPrimes.Length)];
		var np2 = nonPrimes[_random.Next(nonPrimes.Length)];
		while (np2 == np1) np2 = nonPrimes[_random.Next(nonPrimes.Length)];
		var np3 = nonPrimes[_random.Next(nonPrimes.Length)];
		while (np3 == np1 || np3 == np2) np3 = nonPrimes[_random.Next(nonPrimes.Length)];

		var choices = Shuffle(prime.ToString(), np1.ToString(), np2.ToString(), np3.ToString(), out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S3-{Guid.NewGuid():N}",
			SubjectId = "maths_col_nombres_premiers",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = "Lequel de ces nombres est un nombre premier ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un nombre premier n'admet exactement que deux diviseurs distincts : 1 et lui-même.",
			HintLevel2 = "Éliminez les nombres divisibles par 3 (somme des chiffres) ou par 5.",
			ExplanationText = $"{prime} n'a pas d'autre diviseur que 1 et {prime}."
		};
	}

	private ExerciseQuestion CreatePrimeFactorizationQuestion()
	{
		var pool = new[]
		{
			(60, "2² × 3 × 5", "2 × 3² × 5", "4 × 15", "2³ × 5"),
			(84, "2² × 3 × 7", "2 × 3² × 7", "4 × 21", "2³ × 3"),
			(72, "2³ × 3²", "2² × 3³", "8 × 9", "2⁴ × 3"),
			(90, "2 × 3² × 5", "2² × 3 × 5", "9 × 10", "2 × 3 × 15")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S3-{Guid.NewGuid():N}",
			SubjectId = "maths_col_nombres_premiers",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Quelle est la décomposition en produit de facteurs premiers de {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez successivement par les plus petits nombres premiers (2, 3, 5, 7...).",
			HintLevel2 = "Tous les facteurs doivent être strictement premiers (4 et 9 ne sont pas premiers).",
			ExplanationText = $"La décomposition exacte de {item.Item1} est {item.Item2}."
		};
	}

	private ExerciseQuestion CreateNonPrimeIdentificationQuestion()
	{
		var pool = new[]
		{
			(91, "91 (divisible par 7)", "41", "61", "71", "7 × 13 = 91"),
			(51, "51 (divisible par 3)", "31", "41", "61", "5 + 1 = 6, multiple de 3"),
			(49, "49 (divisible par 7)", "29", "59", "79", "7 × 7 = 49")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S3-{Guid.NewGuid():N}",
			SubjectId = "maths_col_nombres_premiers",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = "Lequel de ces nombres N'EST PAS un nombre premier ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Cherchez le nombre qui possède au moins un diviseur autre que 1 et lui-même.",
			HintLevel2 = item.Item6,
			ExplanationText = $"{item.Item2} n'est pas premier car {item.Item6}."
		};
	}

	private ExerciseQuestion CreatePisaBusSynchronizationQuestion()
	{
		var busA = 12;
		var busB = 18;
		var ppcm = 36;

		var correct = $"{ppcm} minutes";
		var w1 = $"{busA + busB} minutes";
		var w2 = $"{ppcm / 2} minutes";
		var w3 = $"{ppcm * 2} minutes";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S3-{Guid.NewGuid():N}",
			SubjectId = "maths_col_nombres_premiers",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"À une gare, la ligne A part toutes les {busA} min et la ligne B toutes les {busB} min. Elles partent ensemble à 8h00. Dans combien de temps repartiront-elles ensemble ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Il faut trouver le plus petit multiple commun (PPCM) de 12 et 18.",
			HintLevel2 = "Multiples de 12 : 12, 24, 36... Multiples de 18 : 18, 36...",
			ExplanationText = $"Le premier multiple commun à 12 et 18 est {ppcm} minutes."
		};
	}
}

