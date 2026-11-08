using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class CollegeMathsBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestionBySubject(int subjectNumber)
	{
		return subjectNumber switch
		{
			1 => GenerateEuclideanDivision(),
			2 => GenerateMultiplesAndDivisors(),
			3 => GeneratePrimeNumbersAndFactors(),
			_ => GenerateEuclideanDivision()
		};
	}

	public ExerciseQuestion GenerateEuclideanDivision()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateFindRemainderQuestion(),
			1 => CreateFindQuotientQuestion(),
			2 => CreateFindDividendQuestion(),
			_ => CreatePisaPackagingQuestion()
		};
	}

	public ExerciseQuestion GenerateMultiplesAndDivisors()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateDivisibilityByThreeOrNineQuestion(),
			1 => CreateDivisibilityByTwoFiveTenQuestion(),
			2 => CreateCommonDivisorQuestion(),
			_ => CreatePisaGroupingQuestion()
		};
	}

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

	private ExerciseQuestion CreateFindRemainderQuestion()
	{
		var divisor = _random.Next(6, 15);
		var quotient = _random.Next(8, 25);
		var remainder = _random.Next(1, divisor);
		var dividend = (divisor * quotient) + remainder;

		var correct = remainder.ToString();
		var w1 = (remainder + 1).ToString();
		var w2 = quotient.ToString();
		var w3 = (divisor - 1).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans la division euclidienne de {dividend} par {divisor}, quel est le reste ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Dividende = (Diviseur × Quotient) + Reste, avec 0 ≤ Reste < Diviseur.",
			HintLevel2 = $"{dividend} = ({divisor} × {quotient}) + Reste. Soustrayez {divisor * quotient} à {dividend}.",
			ExplanationText = $"{dividend} = {divisor} × {quotient} + {remainder}. Le reste est {remainder}."
		};
	}

	private ExerciseQuestion CreateFindQuotientQuestion()
	{
		var divisor = _random.Next(5, 12);
		var quotient = _random.Next(10, 30);
		var remainder = _random.Next(1, divisor);
		var dividend = (divisor * quotient) + remainder;

		var correct = quotient.ToString();
		var w1 = (quotient - 1).ToString();
		var w2 = (quotient + 2).ToString();
		var w3 = remainder.ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans la division euclidienne de {dividend} par {divisor}, quel est le quotient entier ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le quotient est le plus grand nombre de fois que le diviseur rentre dans le dividende.",
			HintLevel2 = $"{divisor} × {quotient} = {divisor * quotient} ≤ {dividend}.",
			ExplanationText = $"{dividend} = {divisor} × {quotient} + {remainder}. Le quotient est {quotient}."
		};
	}

	private ExerciseQuestion CreateFindDividendQuestion()
	{
		var divisor = _random.Next(7, 14);
		var quotient = _random.Next(6, 18);
		var remainder = _random.Next(1, divisor);
		var dividend = (divisor * quotient) + remainder;

		var correct = dividend.ToString();
		var w1 = (divisor * quotient).ToString();
		var w2 = (dividend + divisor).ToString();
		var w3 = (dividend - remainder).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une division euclidienne a pour diviseur {divisor}, pour quotient {quotient} et pour reste {remainder}. Quel est le dividende ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez l'égalité fondamentale : Dividende = Diviseur × Quotient + Reste.",
			HintLevel2 = $"Calculez ({divisor} × {quotient}) puis ajoutez {remainder}.",
			ExplanationText = $"Dividende = ({divisor} × {quotient}) + {remainder} = {dividend}."
		};
	}

	private ExerciseQuestion CreatePisaPackagingQuestion()
	{
		var boxCapacity = _random.Next(6, 13);
		var boxes = _random.Next(12, 35);
		var leftover = _random.Next(1, boxCapacity);
		var totalItems = (boxCapacity * boxes) + leftover;

		var correct = $"{boxes} boîtes pleines et {leftover} restant(s)";
		var w1 = $"{boxes + 1} boîtes pleines";
		var w2 = $"{boxes - 1} boîtes pleines et {leftover + 2} restant(s)";
		var w3 = $"{boxes} boîtes pleines et {boxCapacity} restant(s)";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Un artisan emballe {totalItems} sablés dans des boîtes de {boxCapacity}. Combien de boîtes pleines remplit-il et combien en reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Effectuez la division euclidienne du nombre total de sablés par la contenance d'une boîte.",
			HintLevel2 = $"{totalItems} = {boxCapacity} × {boxes} + {leftover}.",
			ExplanationText = $"Il remplit {boxes} boîtes et il reste {leftover} sablés non emballés."
		};
	}

	private ExerciseQuestion CreateDivisibilityByThreeOrNineQuestion()
	{
		var useNine = _random.Next(2) == 0;
		var divisorTarget = useNine ? 9 : 3;

		var validNumbers = useNine
			? new[] { 144, 207, 315, 432, 513, 621, 738, 801, 918 }
			: new[] { 114, 213, 312, 423, 516, 624, 711, 804, 912 };

		var correctNum = validNumbers[_random.Next(validNumbers.Length)];
		var w1 = correctNum + 1;
		var w2 = correctNum + 2;
		var w3 = correctNum - 1;
		var choices = Shuffle(correctNum.ToString(), w1.ToString(), w2.ToString(), w3.ToString(), out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Parmi ces nombres, lequel est divisible par {divisorTarget} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = $"Un nombre est divisible par {divisorTarget} si la somme de ses chiffres est un multiple de {divisorTarget}.",
			HintLevel2 = $"Additionnez les chiffres de chaque proposition.",
			ExplanationText = $"La somme des chiffres de {correctNum} est un multiple de {divisorTarget}."
		};
	}

	private ExerciseQuestion CreateDivisibilityByTwoFiveTenQuestion()
	{
		var lastDigits = new[] { 0, 5 };
		var ending = lastDigits[_random.Next(lastDigits.Length)];
		var baseVal = _random.Next(20, 95) * 10;
		var correctNum = baseVal + ending;

		var w1 = baseVal + 3;
		var w2 = baseVal + 7;
		var w3 = baseVal + 1;
		var choices = Shuffle(correctNum.ToString(), w1.ToString(), w2.ToString(), w3.ToString(), out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = "Quel nombre est un multiple de 5 ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un nombre est multiple de 5 si son chiffre des unités est 0 ou 5.",
			HintLevel2 = "Observez le tout dernier chiffre de chaque proposition.",
			ExplanationText = $"{correctNum} se termine par {ending}, il est donc divisible par 5."
		};
	}

	private ExerciseQuestion CreateCommonDivisorQuestion()
	{
		var pairs = new[]
		{
			(24, 36, 12, 8, 5, 7),
			(30, 45, 15, 10, 8, 4),
			(42, 70, 14, 12, 9, 6),
			(36, 60, 12, 18, 8, 5)
		};
		var p = pairs[_random.Next(pairs.Length)];
		var choices = Shuffle(p.Item3.ToString(), p.Item4.ToString(), p.Item5.ToString(), p.Item6.ToString(), out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quel est le plus grand commun diviseur (PGCD) de {p.Item1} et {p.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Cherchez le plus grand nombre qui divise à la fois les deux entiers sans reste.",
			HintLevel2 = $"{p.Item1} = {p.Item3} × {p.Item1 / p.Item3} et {p.Item2} = {p.Item3} × {p.Item2 / p.Item3}.",
			ExplanationText = $"Le plus grand diviseur commun à {p.Item1} et {p.Item2} est {p.Item3}."
		};
	}

	private ExerciseQuestion CreatePisaGroupingQuestion()
	{
		var groups = _random.Next(4, 9);
		var pensPerGroup = _random.Next(5, 12);
		var total = groups * pensPerGroup;

		var correct = $"{pensPerGroup} stylos";
		var w1 = $"{pensPerGroup + 2} stylos";
		var w2 = $"{pensPerGroup - 1} stylos";
		var w3 = $"{pensPerGroup + 4} stylos";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une association répartit équitablement {total} stylos dans {groups} trousses identiques sans qu'il n'en reste. Combien de stylos contient chaque trousse ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Puisqu'il n'y a pas de reste, le nombre cherché est le diviseur exact de la division.",
			HintLevel2 = $"Calculez {total} ÷ {groups}.",
			ExplanationText = $"{total} ÷ {groups} = {pensPerGroup} stylos par trousse."
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
			HintLevel2 = $"Éliminez les nombres divisibles par 3 (somme des chiffres) ou par 5.",
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

	private List<string> Shuffle(string c, string w1, string w2, string w3, out int correctIndex)
	{
		var list = new List<string> { c, w1, w2, w3 };
		var n = list.Count;
		while (n > 1)
		{
			n--;
			var k = _random.Next(n + 1);
			(list[k], list[n]) = (list[n], list[k]);
		}
		correctIndex = list.IndexOf(c);
		return list;
	}
}
