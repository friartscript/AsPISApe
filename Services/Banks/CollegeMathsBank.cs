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
			4 => GenerateDecimalAdditionSubtraction(),
			5 => GenerateDecimalMultiplication(),
			6 => GenerateDecimalDivisionByInteger(),
			7 => GenerateRelativeNumbersGraduationAndCoordinates(),
			8 => GenerateRelativeNumbersComparison(),
			9 => GenerateRelativeNumbersAdditionSubtraction(),
			10 => GenerateRelativeNumbersSeries(),
			11 => GenerateRelativeNumbersMultiplicationDivision(),
			12 => GenerateCalculationPriorities(),
			13 => GenerateFractionBasics(),
			14 => GenerateFractionEquality(),
			15 => GenerateFractionSimplification(),
			16 => GenerateFractionAdditionSubtraction(),
			17 => GenerateFractionMultiplicationDivision(),
			18 => GeneratePowersBasics(),
			19 => GenerateScientificNotation(),
			_ => GenerateEuclideanDivision()
		};
	}

	public ExerciseQuestion GenerateFractionBasics()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateFractionVocabularyQuestion(),
			1 => CreateFractionOfQuantityQuestion(),
			2 => CreateFractionQuotientQuestion(),
			_ => CreatePisaPizzaSharingQuestion()
		};
	}

	public ExerciseQuestion GenerateFractionEquality()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateEqualFractionsMultiplierQuestion(),
			1 => CreateMissingFractionNumeratorQuestion(),
			2 => CreateCrossProductEqualityQuestion(),
			_ => CreatePisaEqualDosageQuestion()
		};
	}

	public ExerciseQuestion GenerateFractionSimplification()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateIrreducibleFractionQuestion(),
			1 => CreateDivideByCommonFactorQuestion(),
			2 => CreateRecognizeIrreducibleQuestion(),
			_ => CreatePisaSimplifiedProportionQuestion()
		};
	}

	public ExerciseQuestion GenerateFractionAdditionSubtraction()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateSameDenominatorAdditionQuestion(),
			1 => CreateSameDenominatorSubtractionQuestion(),
			2 => CreateMultipleDenominatorAdditionQuestion(),
			_ => CreatePisaPaintTankFractionQuestion()
		};
	}

	public ExerciseQuestion GenerateFractionMultiplicationDivision()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateFractionMultiplicationQuestion(),
			1 => CreateFractionByIntegerMultiplicationQuestion(),
			2 => CreateFractionDivisionQuestion(),
			_ => CreatePisaRecipePortionQuestion()
		};
	}

	public ExerciseQuestion GeneratePowersBasics()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreatePowerSquareCubeQuestion(),
			1 => CreateNegativePowerOfTenQuestion(),
			2 => CreatePowerSignRulesQuestion(),
			_ => CreatePisaDigitalStorageQuestion()
		};
	}

	public ExerciseQuestion GenerateScientificNotation()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateNumberToScientificNotationQuestion(),
			1 => CreateScientificNotationToDecimalQuestion(),
			2 => CreatePowerOfTenProductRuleQuestion(),
			_ => CreatePisaAstronomyDistanceQuestion()
		};
	}

	public ExerciseQuestion GenerateRelativeNumbersGraduationAndCoordinates()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateAxisAbscissaQuestion(),
			1 => CreateDistanceToZeroQuestion(),
			2 => CreateCartesianCoordinatesQuestion(),
			_ => CreatePisaAltitudeDifferenceQuestion()
		};
	}

	public ExerciseQuestion GenerateRelativeNumbersComparison()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateCompareTwoNegativesQuestion(),
			1 => CreateFindSmallestRelativeQuestion(),
			2 => CreateNegativeIntegerBoundQuestion(),
			_ => CreatePisaColdestTemperatureQuestion()
		};
	}

	public ExerciseQuestion GenerateRelativeNumbersAdditionSubtraction()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateAddTwoNegativesQuestion(),
			1 => CreateAddOppositeSignsQuestion(),
			2 => CreateSubtractRelativeQuestion(),
			_ => CreatePisaBankBalanceQuestion()
		};
	}

	public ExerciseQuestion GenerateRelativeNumbersSeries()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateThreeTermsRelativeSeriesQuestion(),
			1 => CreateGroupPositivesAndNegativesQuestion(),
			2 => CreateSimplifiedParenthesesQuestion(),
			_ => CreatePisaDailyBalanceQuestion()
		};
	}

	public ExerciseQuestion GenerateRelativeNumbersMultiplicationDivision()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateMultiplyTwoNegativesQuestion(),
			1 => CreateMultiplyOppositeSignsQuestion(),
			2 => CreateDivideRelativesQuestion(),
			_ => CreatePisaDailyVariationQuestion()
		};
	}

	public ExerciseQuestion GenerateCalculationPriorities()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreatePriorityMultiplicationOverAdditionQuestion(),
			1 => CreatePriorityParenthesesQuestion(),
			2 => CreatePriorityDivisionAndSubtractionQuestion(),
			_ => CreatePisaInvoicingPriorityQuestion()
		};
	}

	public ExerciseQuestion GenerateDecimalAdditionSubtraction()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateDecimalAdditionQuestion(),
			1 => CreateDecimalSubtractionQuestion(),
			2 => CreateMissingDecimalTermQuestion(),
			_ => CreatePisaChangeReturnQuestion()
		};
	}

	public ExerciseQuestion GenerateDecimalMultiplication()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateDecimalPowerOfTenMultiplicationQuestion(),
			1 => CreateDecimalByIntegerMultiplicationQuestion(),
			2 => CreateTwoDecimalsMultiplicationQuestion(),
			_ => CreatePisaAreaOrWeightMultiplicationQuestion()
		};
	}

	public ExerciseQuestion GenerateDecimalDivisionByInteger()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateExactDecimalDivisionQuestion(),
			1 => CreateDecimalPowerOfTenDivisionQuestion(),
			2 => CreateIntegerDivisionToDecimalQuestion(),
			_ => CreatePisaBillSharingQuestion()
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

	private ExerciseQuestion CreateDecimalAdditionQuestion()
	{
		var centsA = _random.Next(120, 650) * 5;
		var centsB = _random.Next(50, 400) * 5;
		var valA = centsA / 100m;
		var valB = centsB / 100m;
		var sum = valA + valB;

		var correct = $"{sum:F2}".Replace('.', ',');
		var w1 = $"{sum + 1m:F2}".Replace('.', ',');
		var w2 = $"{sum - 0.10m:F2}".Replace('.', ',');
		var w3 = $"{sum + 0.05m:F2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {valA:F2}".Replace('.', ',') + $" + {valB:F2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Alignez les virgules verticalement avant d'additionner les chiffres de même rang.",
			HintLevel2 = $"Additionnez d'abord les centièmes, puis les dixièmes et les unités.",
			ExplanationText = $"{valA:F2} + {valB:F2} = {sum:F2}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateDecimalSubtractionQuestion()
	{
		var centsA = _random.Next(400, 950) * 5;
		var centsB = _random.Next(100, 350) * 5;
		var valA = centsA / 100m;
		var valB = centsB / 100m;
		var diff = valA - valB;

		var correct = $"{diff:F2}".Replace('.', ',');
		var w1 = $"{diff + 1m:F2}".Replace('.', ',');
		var w2 = $"{diff - 0.10m:F2}".Replace('.', ',');
		var w3 = $"{diff + 0.20m:F2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {valA:F2}".Replace('.', ',') + $" - {valB:F2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Alignez les virgules et complétez éventuellement avec un zéro.",
			HintLevel2 = $"Retirez {valB:F2} à {valA:F2} en tenant compte des retenues.".Replace('.', ','),
			ExplanationText = $"{valA:F2} - {valB:F2} = {diff:F2}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateMissingDecimalTermQuestion()
	{
		var centsA = _random.Next(100, 500) * 5;
		var centsMissing = _random.Next(100, 400) * 5;
		var valA = centsA / 100m;
		var valMissing = centsMissing / 100m;
		var sum = valA + valMissing;

		var correct = $"{valMissing:F2}".Replace('.', ',');
		var w1 = $"{valMissing + 1m:F2}".Replace('.', ',');
		var w2 = $"{valMissing - 0.10m:F2}".Replace('.', ',');
		var w3 = $"{sum + valA:F2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Trouvez le nombre manquant : {valA:F2}".Replace('.', ',') + $" + ? = {sum:F2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour trouver un terme manquant dans une addition, effectuez une soustraction.",
			HintLevel2 = $"Calculez {sum:F2} - {valA:F2}.".Replace('.', ','),
			ExplanationText = $"Le terme manquant vaut {sum:F2} - {valA:F2} = {valMissing:F2}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreatePisaChangeReturnQuestion()
	{
		var prices = new[] { 13.40m, 17.65m, 24.80m, 32.50m, 41.25m };
		var price = prices[_random.Next(prices.Length)];
		var bill = price < 20m ? 20m : 50m;
		var change = bill - price;

		var correct = $"{change:F2} €".Replace('.', ',');
		var w1 = $"{change + 1m:F2} €".Replace('.', ',');
		var w2 = $"{change - 0.50m:F2} €".Replace('.', ',');
		var w3 = $"{bill - price + 0.20m:F2} €".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Un achat coûte {price:F2} €. Le client paie avec un billet de {bill:F0} €. Combien lui rend-on ?".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La monnaie rendue correspond à la différence entre le billet donné et le montant dû.",
			HintLevel2 = $"Calculez {bill:F0} - {price:F2}.".Replace('.', ','),
			ExplanationText = $"On lui rend {bill:F0} - {price:F2} = {change:F2} €.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateDecimalPowerOfTenMultiplicationQuestion()
	{
		var factors = new[] { 10, 100, 1000 };
		var factor = factors[_random.Next(factors.Length)];
		var decimals = new[] { 3.45m, 0.78m, 12.6m, 4.09m, 0.05m };
		var val = decimals[_random.Next(decimals.Length)];
		var prod = val * factor;

		var correct = $"{prod:G29}".Replace('.', ',');
		var w1 = $"{prod * 10:G29}".Replace('.', ',');
		var w2 = $"{prod / 10:G29}".Replace('.', ',');
		var w3 = $"{val + factor:G29}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {val}".Replace('.', ',') + $" × {factor}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multiplier par 10, 100 ou 1000 revient à décaler la virgule vers la droite.",
			HintLevel2 = $"Déplacez la virgule de {factor.ToString().Length - 1} rang(s) vers la droite.",
			ExplanationText = $"{val} × {factor} = {prod}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateDecimalByIntegerMultiplicationQuestion()
	{
		var pool = new[]
		{
			(2.5m, 4, 10m),
			(3.25m, 4, 13m),
			(1.75m, 3, 5.25m),
			(4.5m, 6, 27m),
			(6.2m, 5, 31m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m}".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.5m}".Replace('.', ',');
		var w3 = $"{item.Item1 * (item.Item2 + 1)}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {item.Item1}".Replace('.', ',') + $" × {item.Item2}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multipliez sans tenir compte de la virgule, puis replacez la virgule au résultat.",
			HintLevel2 = $"Le résultat comporte le même nombre de décimales que {item.Item1}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} × {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateTwoDecimalsMultiplicationQuestion()
	{
		var pool = new[]
		{
			(1.5m, 0.4m, 0.6m),
			(2.5m, 1.2m, 3.0m),
			(0.8m, 0.5m, 0.4m),
			(1.2m, 0.3m, 0.36m),
			(0.7m, 0.6m, 0.42m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 * 10m}".Replace('.', ',');
		var w2 = $"{item.Item3 / 10m}".Replace('.', ',');
		var w3 = $"{item.Item1 + item.Item2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1}".Replace('.', ',') + $" × {item.Item2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le nombre de décimales du produit est la somme des décimales des deux facteurs.",
			HintLevel2 = $"Multipliez les entiers puis placez la virgule avec le bon nombre de chiffres après.",
			ExplanationText = $"{item.Item1} × {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreatePisaAreaOrWeightMultiplicationQuestion()
	{
		var pool = new[]
		{
			(2.5m, 2.40m, 6.00m, "kg de pommes", "€ le kg"),
			(3.2m, 1.50m, 4.80m, "mètres de tissu", "€ le mètre"),
			(4.5m, 2.00m, 9.00m, "kg d'oranges", "€ le kg")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3:F2} €".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m:F2} €".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.60m:F2} €".Replace('.', ',');
		var w3 = $"{item.Item1 + item.Item2:F2} €".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"On achète {item.Item1} {item.Item4} à {item.Item2:F2} {item.Item5}. Quel est le montant total ?".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Montant total = Quantité × Prix unitaire.",
			HintLevel2 = $"Multipliez {item.Item1} par {item.Item2:F2}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} × {item.Item2:F2} = {item.Item3:F2} €.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateExactDecimalDivisionQuestion()
	{
		var pool = new[]
		{
			(34.5m, 5, 6.9m),
			(48.6m, 6, 8.1m),
			(25.6m, 4, 6.4m),
			(14.8m, 4, 3.7m),
			(63.9m, 9, 7.1m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m}".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.2m}".Replace('.', ',');
		var w3 = $"{item.Item3 * 10m}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez le quotient exact : {item.Item1}".Replace('.', ',') + $" ÷ {item.Item2}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Placez la virgule au quotient dès que vous descendez le chiffre des dixièmes.",
			HintLevel2 = $"{item.Item2} × {item.Item3} = {item.Item1}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} ÷ {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateDecimalPowerOfTenDivisionQuestion()
	{
		var factors = new[] { 10, 100 };
		var factor = factors[_random.Next(factors.Length)];
		var pool = new[] { 45.8m, 127.4m, 8.9m, 63.2m };
		var val = pool[_random.Next(pool.Length)];
		var quot = val / factor;

		var correct = $"{quot:G29}".Replace('.', ',');
		var w1 = $"{quot * 10m:G29}".Replace('.', ',');
		var w2 = $"{quot / 10m:G29}".Replace('.', ',');
		var w3 = $"{val * factor:G29}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {val}".Replace('.', ',') + $" ÷ {factor}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Diviser par 10 ou 100 revient à décaler la virgule vers la gauche.",
			HintLevel2 = $"Déplacez la virgule de {factor.ToString().Length - 1} rang(s) vers la gauche.",
			ExplanationText = $"{val} ÷ {factor} = {quot}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateIntegerDivisionToDecimalQuestion()
	{
		var pool = new[]
		{
			(15, 4, 3.75m),
			(27, 5, 5.4m),
			(39, 6, 6.5m),
			(18, 4, 4.5m),
			(7, 2, 3.5m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m}".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.25m}".Replace('.', ',');
		var w3 = $"{item.Item1 - item.Item2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez l'écriture décimale exacte de {item.Item1} ÷ {item.Item2}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Poursuivez la division au-delà des unités en ajoutant des zéros aux dixièmes.",
			HintLevel2 = $"{item.Item2} × {item.Item3} = {item.Item1}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} ÷ {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreatePisaBillSharingQuestion()
	{
		var pool = new[]
		{
			(68.40m, 4, 17.10m),
			(45.50m, 5, 9.10m),
			(75.60m, 3, 25.20m),
			(52.80m, 4, 13.20m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3:F2} €".Replace('.', ',');
		var w1 = $"{item.Item3 + 2m:F2} €".Replace('.', ',');
		var w2 = $"{item.Item3 - 1m:F2} €".Replace('.', ',');
		var w3 = $"{item.Item1 / (item.Item2 + 1):F2} €".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Une addition de restaurant de {item.Item1:F2} € est partagée équitablement entre {item.Item2} amis. Combien paie chacun ?".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez le montant total par le nombre de personnes.",
			HintLevel2 = $"Calculez {item.Item1:F2} ÷ {item.Item2}.".Replace('.', ','),
			ExplanationText = $"Chacun paie {item.Item1:F2} ÷ {item.Item2} = {item.Item3:F2} €.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateAxisAbscissaQuestion()
	{
		var dist = _random.Next(2, 9);
		var correct = (-dist).ToString();
		var w1 = dist.ToString();
		var w2 = (-dist - 1).ToString();
		var w3 = (-dist + 2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Sur une droite graduée d'origine O, le point A est situé à {dist} unités à gauche de O. Quelle est son abscisse ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les points situés à gauche de l'origine ont une abscisse négative.",
			HintLevel2 = $"Le point est à gauche donc son signe est négatif : -{dist}.",
			ExplanationText = $"L'abscisse d'un point à gauche de l'origine est négative : {correct}."
		};
	}

	private ExerciseQuestion CreateDistanceToZeroQuestion()
	{
		var val = _random.Next(3, 15);
		var correct = val.ToString();
		var w1 = (-val).ToString();
		var w2 = (val * 2).ToString();
		var w3 = "0";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est la distance à zéro du nombre relatif -{val} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La distance à zéro est toujours un nombre positif (valeur absolue).",
			HintLevel2 = "Supprimez simplement le signe négatif pour obtenir la distance.",
			ExplanationText = $"La distance à zéro de -{val} est le nombre positif {correct}."
		};
	}

	private ExerciseQuestion CreateCartesianCoordinatesQuestion()
	{
		var x = _random.Next(-6, -1);
		var y = _random.Next(2, 8);
		var correct = y.ToString();
		var w1 = x.ToString();
		var w2 = (-y).ToString();
		var w3 = (x + y).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans un repère, le point M a pour coordonnées ({x} ; {y}). Quelle est son ordonnée ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les coordonnées se lisent dans l'ordre alphabétique : (abscisse x ; ordonnée y).",
			HintLevel2 = "L'ordonnée est le deuxième nombre entre parenthèses.",
			ExplanationText = $"Dans ({x} ; {y}), {x} est l'abscisse et {y} est l'ordonnée."
		};
	}

	private ExerciseQuestion CreatePisaAltitudeDifferenceQuestion()
	{
		var altPos = _random.Next(12, 35) * 10;
		var altNeg = _random.Next(4, 15) * 10;
		var diff = altPos + altNeg;
		var correct = $"{diff} m";
		var w1 = $"{altPos - altNeg} m";
		var w2 = $"{diff + 20} m";
		var w3 = $"{altPos} m";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S7-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_reperage",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Un village est situé à +{altPos} m d'altitude et une vallée sous-marine à -{altNeg} m. Quel est l'écart d'altitude ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La différence d'altitude se calcule par : Altitude haute - Altitude basse.",
			HintLevel2 = $"Calculez (+{altPos}) - (-{altNeg}) = {altPos} + {altNeg}.",
			ExplanationText = $"Écart = {altPos} - (-{altNeg}) = {diff} m."
		};
	}

	private ExerciseQuestion CreateCompareTwoNegativesQuestion()
	{
		var a = _random.Next(8, 20);
		var b = _random.Next(2, 7);
		var correct = $"-{b}";
		var w1 = $"-{a}";
		var w2 = "Ils sont égaux";
		var w3 = $"-{a + b}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quel est le plus grand nombre entre -{a} et -{b} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Entre deux nombres négatifs, le plus grand est celui qui a la plus petite distance à zéro.",
			HintLevel2 = $"-{b} est plus proche de 0 que -{a}.",
			ExplanationText = $"-{b} est supérieur à -{a} car sa distance à zéro est inférieure."
		};
	}

	private ExerciseQuestion CreateFindSmallestRelativeQuestion()
	{
		var pool = new[]
		{
			(-18, -12, 3, -4),
			(-25, -9, 0, -17),
			(-31, -15, -8, 2),
			(-14, -6, 5, -9)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item1.ToString();
		var w1 = item.Item2.ToString();
		var w2 = item.Item3.ToString();
		var w3 = item.Item4.ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quel est le plus petit nombre parmi : {item.Item1}, {item.Item2}, {item.Item3}, {item.Item4} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le plus petit nombre est celui qui est situé le plus à gauche sur la droite graduée.",
			HintLevel2 = $"Recherchez le nombre négatif ayant la plus grande distance à zéro.",
			ExplanationText = $"{item.Item1} a la plus grande distance à zéro parmi les négatifs."
		};
	}

	private ExerciseQuestion CreateNegativeIntegerBoundQuestion()
	{
		var intPart = _random.Next(3, 9);
		var dec = _random.Next(1, 9);
		var val = $"{intPart},{dec}";
		var correct = (-intPart - 1).ToString();
		var w1 = (-intPart).ToString();
		var w2 = (intPart).ToString();
		var w3 = (-intPart + 1).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quel entier relatif se trouve immédiatement inférieur à -{val} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un nombre inférieur se situe plus à gauche sur la droite graduée.",
			HintLevel2 = $"On a : {-intPart - 1} < -{val} < {-intPart}.",
			ExplanationText = $"L'entier immédiatement inférieur à -{val} est {correct}."
		};
	}

	private ExerciseQuestion CreatePisaColdestTemperatureQuestion()
	{
		var pool = new[]
		{
			("-14,5 °C", "-8,2 °C", "-3,0 °C", "1,5 °C"),
			("-21,3 °C", "-17,0 °C", "-9,5 °C", "0 °C"),
			("-16,8 °C", "-12,4 °C", "-4,1 °C", "2,3 °C")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item1, item.Item2, item.Item3, item.Item4, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S8-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_comparaison",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = "D'après les relevés météo, quelle température est la plus froide ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La température la plus froide correspond au minimum algébrique.",
			HintLevel2 = "C'est la valeur négative la plus éloignée de zéro.",
			ExplanationText = $"{item.Item1} est la température la plus basse enregistrée."
		};
	}

	private ExerciseQuestion CreateAddTwoNegativesQuestion()
	{
		var a = _random.Next(4, 12);
		var b = _random.Next(3, 9);
		var sum = -(a + b);
		var correct = sum.ToString();
		var w1 = (a + b).ToString();
		var w2 = (a - b).ToString();
		var w3 = (b - a).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : (-{a}) + (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour additionner deux nombres négatifs, on garde le signe - et on additionne les distances à zéro.",
			HintLevel2 = $"Gardez le signe négatif et calculez {a} + {b}.",
			ExplanationText = $"(-{a}) + (-{b}) = -({a} + {b}) = {sum}."
		};
	}

	private ExerciseQuestion CreateAddOppositeSignsQuestion()
	{
		var a = _random.Next(6, 15);
		var b = _random.Next(2, a);
		var sum = -a + b;
		var correct = sum.ToString();
		var w1 = (-sum).ToString();
		var w2 = (-(a + b)).ToString();
		var w3 = (a + b).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : (-{a}) + (+{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "On prend le signe du nombre qui a la plus grande distance à zéro et on soustrait les distances.",
			HintLevel2 = $"{a} > {b}, donc le résultat est négatif : -({a} - {b}).",
			ExplanationText = $"(-{a}) + (+{b}) = -({a} - {b}) = {sum}."
		};
	}

	private ExerciseQuestion CreateSubtractRelativeQuestion()
	{
		var a = _random.Next(3, 10);
		var b = _random.Next(5, 12);
		var diff = a - (-b);
		var correct = diff.ToString();
		var w1 = (a - b).ToString();
		var w2 = (-diff).ToString();
		var w3 = (b - a).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : (+{a}) - (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Soustraire un nombre relatif revient à ajouter son opposé.",
			HintLevel2 = $"(+{a}) - (-{b}) = {a} + {b}.",
			ExplanationText = $"Soustraire (-{b}) revient à ajouter {b} : {a} + {b} = {diff}."
		};
	}

	private ExerciseQuestion CreatePisaBankBalanceQuestion()
	{
		var initial = _random.Next(3, 9) * 10;
		var deposit = _random.Next(10, 25) * 10;
		var finalBalance = -initial + deposit;
		var correct = $"+{finalBalance} €";
		var w1 = $"{finalBalance - 50} €";
		var w2 = $"-{initial + deposit} €";
		var w3 = $"+{deposit} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Un compte en banque affiche un solde débiteur de -{initial} €. Un virement de {deposit} € arrive. Quel est le nouveau solde ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionnez le montant reçu au solde initial : Solde = (-initial) + virement.",
			HintLevel2 = $"Calculez (-{initial}) + {deposit} = {deposit} - {initial}.",
			ExplanationText = $"Nouveau solde = -{initial} + {deposit} = +{finalBalance} €."
		};
	}

	private ExerciseQuestion CreateThreeTermsRelativeSeriesQuestion()
	{
		var pool = new[]
		{
			(-5, 8, -3, 0),
			(-7, 12, -4, 1),
			(-9, 5, -6, -10),
			(14, -8, -10, -4)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4.ToString();
		var w1 = (item.Item4 + 2).ToString();
		var w2 = (-item.Item4).ToString();
		var w3 = (item.Item4 - 4).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : ({item.Item1}) + (+{item.Item2}) + ({item.Item3})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Effectuez les calculs de gauche à droite ou regroupez les nombres de même signe.",
			HintLevel2 = $"({item.Item1} + {item.Item3}) = {item.Item1 + item.Item3}, puis ajoutez {item.Item2}.",
			ExplanationText = $"La somme de cette suite vaut {item.Item4}."
		};
	}

	private ExerciseQuestion CreateGroupPositivesAndNegativesQuestion()
	{
		var pool = new[]
		{
			("12 - 7 + 8 - 5", "8", "12", "4", "-2"),
			("15 - 9 - 6 + 10", "10", "14", "6", "-4"),
			("20 - 14 + 5 - 3", "8", "12", "5", "2")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Simplifiez et calculez l'expression : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionnez ensemble les termes positifs, puis ensemble les termes négatifs.",
			HintLevel2 = "Faites ensuite la différence entre les deux sommes obtenues.",
			ExplanationText = $"Le résultat de {item.Item1} est égal à {item.Item2}."
		};
	}

	private ExerciseQuestion CreateSimplifiedParenthesesQuestion()
	{
		var pool = new[]
		{
			("-(-8) + (-3) - (+5)", "0", "16", "-10", "6"),
			("-(+12) - (-7) + (+4)", "-1", "23", "-15", "5"),
			("-(-6) - (-4) - (+10)", "0", "20", "-12", "-8")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Supprimez les parenthèses et calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Rappel : -(-a) = +a et -(+a) = -a.",
			HintLevel2 = "Réécrivez sans parenthèses avant d'effectuer les additions et soustractions.",
			ExplanationText = $"Après simplification, le résultat est {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaDailyBalanceQuestion()
	{
		var pool = new[]
		{
			(120, 45, 80, 50, 105),
			(150, 70, 90, 60, 110),
			(200, 85, 50, 45, 120)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item5} €";
		var w1 = $"{item.Item5 + 30} €";
		var w2 = $"{item.Item5 - 20} €";
		var w3 = $"{item.Item1 - item.Item2} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S10-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_suites",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Bilan sur 4 jours : gain de {item.Item1} €, perte de {item.Item2} €, gain de {item.Item3} €, perte de {item.Item4} €. Quel est le solde net ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Solde net = (Total des gains) - (Total des pertes).",
			HintLevel2 = $"Gains : {item.Item1} + {item.Item3} = {item.Item1 + item.Item3} €. Pertes : {item.Item2} + {item.Item4} = {item.Item2 + item.Item4} €.",
			ExplanationText = $"Solde net = ({item.Item1 + item.Item3}) - ({item.Item2 + item.Item4}) = {item.Item5} €."
		};
	}

	private ExerciseQuestion CreateMultiplyTwoNegativesQuestion()
	{
		var a = _random.Next(4, 10);
		var b = _random.Next(3, 9);
		var prod = a * b;
		var correct = prod.ToString();
		var w1 = (-prod).ToString();
		var w2 = (a + b).ToString();
		var w3 = (-(a + b)).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : (-{a}) × (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règle des signes : le produit de deux nombres de même signe est toujours positif.",
			HintLevel2 = $"Moins par moins donne plus : +({a} × {b}).",
			ExplanationText = $"Le produit de deux négatifs est positif : {correct}."
		};
	}

	private ExerciseQuestion CreateMultiplyOppositeSignsQuestion()
	{
		var a = _random.Next(4, 9);
		var b = _random.Next(3, 8);
		var prod = -(a * b);
		var correct = prod.ToString();
		var w1 = (-prod).ToString();
		var w2 = (a - b).ToString();
		var w3 = (b - a).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : (-{a}) × (+{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règle des signes : le produit de deux nombres de signes contraires est toujours négatif.",
			HintLevel2 = $"Moins par plus donne moins : -({a} × {b}).",
			ExplanationText = $"Le produit de signes contraires est négatif : {correct}."
		};
	}

	private ExerciseQuestion CreateDivideRelativesQuestion()
	{
		var b = _random.Next(3, 8);
		var q = _random.Next(4, 10);
		var a = -(b * q);
		var correct = q.ToString();
		var w1 = (-q).ToString();
		var w2 = (q + 2).ToString();
		var w3 = (a + b).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez le quotient : ({a}) ÷ (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le quotient de deux nombres de même signe est positif.",
			HintLevel2 = $"Divisez les distances à zéro : {Math.Abs(a)} ÷ {b}.",
			ExplanationText = $"({a}) ÷ (-{b}) = {q}."
		};
	}

	private ExerciseQuestion CreatePisaDailyVariationQuestion()
	{
		var drop = _random.Next(2, 6);
		var days = _random.Next(4, 8);
		var total = -(drop * days);
		var correct = $"{total} cm";
		var w1 = $"{Math.Abs(total)} cm";
		var w2 = $"{total - 5} cm";
		var w3 = $"-{drop + days} cm";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S11-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_produits_quotients",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Le niveau d'un lac baisse régulièrement de {drop} cm par jour pendant {days} jours consécutifs. Quelle est la variation totale ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une baisse correspond à un nombre relatif négatif : Variation = (-baisse) × jours.",
			HintLevel2 = $"Calculez (-{drop}) × {days}.",
			ExplanationText = $"La variation totale est (-{drop}) × {days} = {total} cm."
		};
	}

	private ExerciseQuestion CreatePriorityMultiplicationOverAdditionQuestion()
	{
		var pool = new[]
		{
			("5 + 3 × (-4)", "-7", "-32", "17", "-2"),
			("12 - 2 × (-5)", "22", "-50", "2", "-8"),
			("8 + (-4) × 3", "-4", "12", "-36", "4"),
			("15 - 3 × 6", "-3", "72", "-21", "3")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"En respectant les priorités opératoires, calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La multiplication est toujours prioritaire sur l'addition et la soustraction.",
			HintLevel2 = "Effectuez d'abord le produit avant d'additionner ou soustraire.",
			ExplanationText = $"En appliquant la priorité de la multiplication, on trouve {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePriorityParenthesesQuestion()
	{
		var pool = new[]
		{
			("(-2) × (7 - 12)", "10", "-10", "-26", "5"),
			("3 × (4 - 9)", "-15", "15", "-21", "-3"),
			("(-4) × (2 - 8)", "24", "-24", "0", "-16"),
			("5 × (-3 - 4)", "-35", "35", "-11", "-7")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les calculs entre parenthèses sont strictement prioritaires.",
			HintLevel2 = "Calculez d'abord la parenthèse, puis multipliez le résultat.",
			ExplanationText = $"Après calcul de la parenthèse et multiplication : {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePriorityDivisionAndSubtractionQuestion()
	{
		var pool = new[]
		{
			("20 - 15 ÷ (-3)", "25", "15", "-5", "3"),
			("18 + (-24) ÷ 6", "14", "-7", "22", "-1"),
			("30 - (-16) ÷ (-4)", "26", "34", "-4", "10"),
			("10 + 20 ÷ (-5)", "6", "-6", "-2", "14")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La division est prioritaire sur l'addition et la soustraction.",
			HintLevel2 = "Effectuez d'abord le quotient avec la règle des signes.",
			ExplanationText = $"En effectuant la division en premier, on obtient {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaInvoicingPriorityQuestion()
	{
		var pool = new[]
		{
			(4, 15, 3, 5, 45),
			(5, 12, 2, 8, 44),
			(3, 20, 4, 6, 36)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item5} €";
		var w1 = $"{item.Item5 + 10} €";
		var w2 = $"{item.Item5 - 8} €";
		var w3 = $"{item.Item1 * item.Item2} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Un groupe achète {item.Item1} billets à {item.Item2} € et bénéficie d'un bon de réduction de {item.Item3} × {item.Item4} €. Quel est le montant final ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Montant = ({item.Item1} × {item.Item2}) - ({item.Item3} × {item.Item4}).",
			HintLevel2 = $"Calculez {item.Item1 * item.Item2} - {item.Item3 * item.Item4}.",
			ExplanationText = $"Montant final = {item.Item1 * item.Item2} - {item.Item3 * item.Item4} = {item.Item5} €."
		};
	}

	private ExerciseQuestion CreateFractionVocabularyQuestion()
	{
		var pool = new[]
		{
			(3, 7, "3", "Le numérateur", "Le dénominateur", "Le quotient", "Le reste"),
			(5, 8, "8", "Le dénominateur", "Le numérateur", "Le facteur", "Le dividende"),
			(2, 9, "9", "Le dénominateur", "Le numérateur", "La somme", "Le produit")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item4, item.Item5, item.Item6, item.Item7, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans l'écriture fractionnaire {item.Item1}/{item.Item2}, que représente le nombre {item.Item3} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le nombre du haut est le numérateur, le nombre du bas est le dénominateur.",
			HintLevel2 = "Le dénominateur donne le nom des parts et se trouve en bas.",
			ExplanationText = $"Dans une fraction, le terme recherché est {item.Item4.ToLowerInvariant()}."
		};
	}

	private ExerciseQuestion CreateFractionOfQuantityQuestion()
	{
		var pool = new[]
		{
			(3, 4, 28, 21),
			(2, 5, 35, 14),
			(5, 6, 42, 35),
			(3, 8, 48, 18)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4.ToString();
		var w1 = (item.Item4 + 3).ToString();
		var w2 = (item.Item4 - 4).ToString();
		var w3 = (item.Item3 / item.Item2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez les {item.Item1}/{item.Item2} de {item.Item3} :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Prendre une fraction d'un nombre revient à diviser par le dénominateur puis multiplier par le numérateur.",
			HintLevel2 = $"Calculez ({item.Item3} ÷ {item.Item2}) × {item.Item1}.",
			ExplanationText = $"({item.Item3} ÷ {item.Item2}) × {item.Item1} = {item.Item4}."
		};
	}

	private ExerciseQuestion CreateFractionQuotientQuestion()
	{
		var pool = new[]
		{
			(7, 2, "3,5", "3,2", "3,7", "4"),
			(9, 4, "2,25", "2,5", "2,15", "3"),
			(3, 4, "0,75", "0,5", "0,8", "1,25")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est l'écriture décimale exacte de la fraction {item.Item1}/{item.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fraction représente le quotient exact du numérateur par le dénominateur.",
			HintLevel2 = $"Effectuez la division décimale : {item.Item1} ÷ {item.Item2}.",
			ExplanationText = $"{item.Item1}/{item.Item2} est égal à {item.Item3}."
		};
	}

	private ExerciseQuestion CreatePisaPizzaSharingQuestion()
	{
		var pool = new[]
		{
			(8, 3, "5/8", "3/8", "5/5", "1/2"),
			(12, 5, "7/12", "5/12", "7/7", "1/3"),
			(10, 4, "6/10", "4/10", "3/5", "1/2")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une tarte est découpée en {item.Item1} parts égales. On en mange {item.Item2}. Quelle fraction de la tarte reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La tarte entière correspond à la fraction {item.Item1}/{item.Item1}.",
			HintLevel2 = $"Calculez ({item.Item1} - {item.Item2}) / {item.Item1}.",
			ExplanationText = $"Il reste {item.Item1 - item.Item2}/{item.Item1} de la tarte."
		};
	}

	private ExerciseQuestion CreateEqualFractionsMultiplierQuestion()
	{
		var pool = new[]
		{
			(3, 5, 4, "12/20", "7/9", "12/15", "15/20"),
			(2, 7, 3, "6/21", "5/10", "6/14", "8/21"),
			(4, 9, 2, "8/18", "6/11", "8/9", "12/18")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item4, item.Item5, item.Item6, item.Item7, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle fraction est égale à {item.Item1}/{item.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "On obtient une fraction égale en multipliant numérateur et dénominateur par un même nombre.",
			HintLevel2 = $"Multipliez le haut et le bas par {item.Item3}.",
			ExplanationText = $"{item.Item1}/{item.Item2} = ({item.Item1} × {item.Item3})/({item.Item2} × {item.Item3}) = {item.Item4}."
		};
	}

	private ExerciseQuestion CreateMissingFractionNumeratorQuestion()
	{
		var pool = new[]
		{
			(5, 6, 24, 20),
			(3, 8, 32, 12),
			(4, 7, 35, 20),
			(2, 9, 27, 6)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4.ToString();
		var w1 = (item.Item4 + 2).ToString();
		var w2 = (item.Item4 - 3).ToString();
		var w3 = (item.Item1 * 2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Trouvez le numérateur manquant pour respecter l'égalité : {item.Item1}/{item.Item2} = ?/{item.Item3}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Repérez par quel facteur le dénominateur a été multiplié.",
			HintLevel2 = $"{item.Item2} × {item.Item3 / item.Item2} = {item.Item3}. Multipliez {item.Item1} par ce même facteur.",
			ExplanationText = $"Le facteur multiplicateur est {item.Item3 / item.Item2}, donc le numérateur vaut {item.Item4}."
		};
	}

	private ExerciseQuestion CreateCrossProductEqualityQuestion()
	{
		var pool = new[]
		{
			(6, 9, 8, 12, true),
			(4, 10, 6, 15, true),
			(5, 8, 7, 11, false),
			(3, 7, 5, 12, false)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5 ? "Oui, car 6×12 = 9×8" : "Non, les produits en croix sont différents";
		var w1 = item.Item5 ? "Non, elles n'ont pas les mêmes chiffres" : "Oui, elles sont presque égales";
		var w2 = "Impossible à déterminer";
		var w3 = "Seulement si le numérateur est supérieur";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Les fractions {item.Item1}/{item.Item2} et {item.Item3}/{item.Item4} sont-elles égales ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux fractions a/b et c/d sont égales si et seulement si a × d = b × c (produit en croix).",
			HintLevel2 = $"Calculez {item.Item1} × {item.Item4} et comparez à {item.Item2} × {item.Item3}.",
			ExplanationText = $"Les produits en croix valent {item.Item1 * item.Item4} et {item.Item2 * item.Item3}."
		};
	}

	private ExerciseQuestion CreatePisaEqualDosageQuestion()
	{
		var pool = new[]
		{
			(2, 5, 100, 40),
			(3, 4, 80, 60),
			(1, 3, 90, 30)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item4} cL";
		var w1 = $"{item.Item4 + 10} cL";
		var w2 = $"{item.Item4 - 5} cL";
		var w3 = $"{item.Item3 / 2} cL";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une recette demande une proportion de {item.Item1}/{item.Item2} de jus. Pour préparer {item.Item3} cL de boisson, quel volume de jus faut-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez la fraction au volume total ou utilisez l'égalité de fractions.",
			HintLevel2 = $"Calculez ({item.Item1} × {item.Item3}) ÷ {item.Item2}.",
			ExplanationText = $"Il faut {item.Item4} cL de jus pour respecter le dosage."
		};
	}

	private ExerciseQuestion CreateIrreducibleFractionQuestion()
	{
		var pool = new[]
		{
			(18, 24, "3/4", "6/8", "9/12", "1/2"),
			(28, 42, "2/3", "4/6", "14/21", "1/3"),
			(35, 50, "7/10", "5/10", "14/20", "3/5"),
			(45, 60, "3/4", "9/12", "15/20", "5/6")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la forme irréductible de la fraction {item.Item1}/{item.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez le numérateur et le dénominateur par leur plus grand commun diviseur (PGCD).",
			HintLevel2 = "Une fraction est irréductible si son numérateur et son dénominateur sont premiers entre eux.",
			ExplanationText = $"La forme simplifiée au maximum est {item.Item3}."
		};
	}

	private ExerciseQuestion CreateDivideByCommonFactorQuestion()
	{
		var pool = new[]
		{
			(24, 36, 12, "2/3"),
			(30, 45, 15, "2/3"),
			(40, 56, 8, "5/7"),
			(21, 49, 7, "3/7")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4;
		var w1 = "1/2";
		var w2 = "3/4";
		var w3 = "4/5";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Simplifiez la fraction {item.Item1}/{item.Item2} par {item.Item3} :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez le numérateur par {item.Item3} et le dénominateur par {item.Item3}.",
			HintLevel2 = $"{item.Item1} ÷ {item.Item3} = {item.Item1 / item.Item3} et {item.Item2} ÷ {item.Item3} = {item.Item2 / item.Item3}.",
			ExplanationText = $"{item.Item1}/{item.Item2} simplifié par {item.Item3} donne {correct}."
		};
	}

	private ExerciseQuestion CreateRecognizeIrreducibleQuestion()
	{
		var pool = new[]
		{
			("7/11", "6/9", "15/25", "14/21"),
			("5/9", "8/12", "10/15", "12/18"),
			("11/13", "9/15", "14/28", "20/30")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item1, item.Item2, item.Item3, item.Item4, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = "Parmi ces fractions, laquelle est déjà irréductible ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fraction est irréductible lorsqu'on ne peut plus simplifier par aucun entier autre que 1.",
			HintLevel2 = "Vérifiez si les deux termes n'ont aucun diviseur commun supérieur à 1.",
			ExplanationText = $"{item.Item1} est irréductible car son numérateur et son dénominateur sont premiers entre eux."
		};
	}

	private ExerciseQuestion CreatePisaSimplifiedProportionQuestion()
	{
		var pool = new[]
		{
			(16, 24, "2 élèves sur 3", "1 élève sur 2", "3 élèves sur 4", "4 élèves sur 5"),
			(15, 20, "3 élèves sur 4", "2 élèves sur 3", "1 élève sur 2", "4 élèves sur 5"),
			(12, 18, "2 élèves sur 3", "1 élève sur 3", "3 élèves sur 5", "5 élèves sur 6")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans une classe de {item.Item2} élèves, {item.Item1} pratiquent une activité sportive. Sous forme simplifiée, quelle est cette proportion ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Écrivez la fraction {item.Item1}/{item.Item2} puis simplifiez-la au maximum.",
			HintLevel2 = $"Divisez le haut et le bas par leur plus grand diviseur commun.",
			ExplanationText = $"La proportion simplifiée correspond à {item.Item3}."
		};
	}

	private ExerciseQuestion CreateSameDenominatorAdditionQuestion()
	{
		var den = _random.Next(5, 12);
		var n1 = _random.Next(1, 4);
		var n2 = _random.Next(1, 4);
		var sum = n1 + n2;
		var correct = $"{sum}/{den}";
		var w1 = $"{sum}/{den * 2}";
		var w2 = $"{n1 * n2}/{den}";
		var w3 = $"{sum + 1}/{den}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {n1}/{den} + {n2}/{den}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour additionner deux fractions de même dénominateur, on additionne les numérateurs.",
			HintLevel2 = $"Le dénominateur reste {den}. Calculez {n1} + {n2}.",
			ExplanationText = $"On conserve le dénominateur {den} : {n1} + {n2} = {sum}/{den}."
		};
	}

	private ExerciseQuestion CreateSameDenominatorSubtractionQuestion()
	{
		var den = _random.Next(6, 13);
		var n1 = _random.Next(4, 8);
		var n2 = _random.Next(1, 4);
		var diff = n1 - n2;
		var correct = $"{diff}/{den}";
		var w1 = $"{diff}/0";
		var w2 = $"{n1 + n2}/{den}";
		var w3 = $"{diff}/{den * 2}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {n1}/{den} - {n2}/{den}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour soustraire deux fractions de même dénominateur, on soustrait les numérateurs.",
			HintLevel2 = $"Le dénominateur reste {den}. Calculez {n1} - {n2}.",
			ExplanationText = $"On garde le dénominateur commun {den} : {n1} - {n2} = {diff}/{den}."
		};
	}

	private ExerciseQuestion CreateMultipleDenominatorAdditionQuestion()
	{
		var pool = new[]
		{
			(1, 3, 2, 6, "4/6 = 2/3"),
			(1, 4, 3, 8, "5/8"),
			(2, 5, 3, 10, "7/10"),
			(1, 2, 1, 6, "4/6 = 2/3")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5;
		var w1 = "4/9";
		var w2 = "3/7";
		var w3 = "5/12";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1}/{item.Item2} + {item.Item3}/{item.Item4}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Mettez les fractions au même dénominateur avant d'additionner les numérateurs.",
			HintLevel2 = $"{item.Item4} est un multiple de {item.Item2}. Multipliez le haut et le bas de la première fraction.",
			ExplanationText = $"Après mise au même dénominateur, le résultat vaut {correct}."
		};
	}

	private ExerciseQuestion CreatePisaPaintTankFractionQuestion()
	{
		var pool = new[]
		{
			(1, 4, 1, 2, "1/4", "3/4", "1/8", "1/3"),
			(2, 5, 1, 5, "2/5", "3/5", "1/5", "1/2"),
			(1, 3, 1, 6, "1/2", "2/9", "1/6", "3/4")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item4, item.Item5, item.Item6, item.Item7, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Un peintre utilise {item.Item1}/{item.Item2} de son pot le matin et {item.Item3}/{item.Item2} l'après-midi. Quelle fraction du pot reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Faites la somme des fractions consommées puis soustrayez à 1.",
			HintLevel2 = $"Consommé : {item.Item1 + item.Item3}/{item.Item2}. Reste : 1 - ({item.Item1 + item.Item3}/{item.Item2}).",
			ExplanationText = $"Il reste la fraction {item.Item4} du pot de peinture."
		};
	}

	private ExerciseQuestion CreateFractionMultiplicationQuestion()
	{
		var pool = new[]
		{
			(2, 3, 4, 5, "8/15"),
			(3, 4, 1, 5, "3/20"),
			(5, 7, 2, 3, "10/21"),
			(1, 2, 3, 4, "3/8")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5;
		var w1 = $"{item.Item1 + item.Item3}/{item.Item2 + item.Item4}";
		var w2 = $"{item.Item1 * item.Item3}/{item.Item2 + item.Item4}";
		var w3 = $"{item.Item1}/{item.Item2 * item.Item4}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez le produit : ({item.Item1}/{item.Item2}) × ({item.Item3}/{item.Item4})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour multiplier deux fractions, on multiplie les numérateurs entre eux et les dénominateurs entre eux.",
			HintLevel2 = $"Calculez ({item.Item1} × {item.Item3}) / ({item.Item2} × {item.Item4}).",
			ExplanationText = $"Produit des numérateurs sur produit des dénominateurs = {correct}."
		};
	}

	private ExerciseQuestion CreateFractionByIntegerMultiplicationQuestion()
	{
		var pool = new[]
		{
			(4, 2, 7, "8/7"),
			(3, 5, 8, "15/8"),
			(5, 3, 11, "15/11"),
			(2, 4, 9, "8/9")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4;
		var w1 = $"{item.Item1 * item.Item2}/{item.Item1 * item.Item3}";
		var w2 = $"{item.Item2}/{item.Item3 * item.Item1}";
		var w3 = $"{item.Item1 + item.Item2}/{item.Item3}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1} × ({item.Item2}/{item.Item3})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multiplier un entier par une fraction revient à multiplier uniquement le numérateur par cet entier.",
			HintLevel2 = $"Calculez ({item.Item1} × {item.Item2}) / {item.Item3}.",
			ExplanationText = $"{item.Item1} × {item.Item2}/{item.Item3} = ({item.Item1} × {item.Item2})/{item.Item3} = {correct}."
		};
	}

	private ExerciseQuestion CreateFractionDivisionQuestion()
	{
		var pool = new[]
		{
			(2, 3, 5, 7, "14/15"),
			(3, 4, 2, 5, "15/8"),
			(1, 2, 3, 5, "5/6"),
			(4, 5, 3, 2, "8/15")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5;
		var w1 = $"{item.Item1 * item.Item3}/{item.Item2 * item.Item4}";
		var w2 = $"{item.Item1}/{item.Item3}";
		var w3 = "1/2";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Calculez le quotient : ({item.Item1}/{item.Item2}) ÷ ({item.Item3}/{item.Item4})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Diviser par une fraction revient à multiplier par son inverse.",
			HintLevel2 = $"Inversez la deuxième fraction : ({item.Item1}/{item.Item2}) × ({item.Item4}/{item.Item3}).",
			ExplanationText = $"On multiplie par l'inverse de la seconde fraction : {correct}."
		};
	}

	private ExerciseQuestion CreatePisaRecipePortionQuestion()
	{
		var pool = new[]
		{
			(3, 4, 1, 2, "3/8 de litre", "1/2 de litre", "3/4 de litre", "1/4 de litre"),
			(2, 3, 3, 4, "1/2 de litre", "5/7 de litre", "2/3 de litre", "1/3 de litre"),
			(4, 5, 1, 2, "2/5 de litre", "3/5 de litre", "1/5 de litre", "4/10 de litre")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Une bouteille contient {item.Item1}/{item.Item2} de litre de jus. On en consomme la moitié ({item.Item1}/{item.Item2} × 1/2). Quel volume a été bu ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Prendre la moitié d'une quantité revient à la multiplier par 1/2.",
			HintLevel2 = $"Calculez ({item.Item1} × 1) / ({item.Item2} × 2).",
			ExplanationText = $"Le volume bu correspond à {item.Item3}."
		};
	}

	private ExerciseQuestion CreatePowerSquareCubeQuestion()
	{
		var pool = new[]
		{
			(5, 3, 125, "5 × 5 × 5"),
			(4, 3, 64, "4 × 4 × 4"),
			(6, 2, 36, "6 × 6"),
			(3, 4, 81, "3 × 3 × 3 × 3")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item3.ToString();
		var w1 = (item.Item1 * item.Item2).ToString();
		var w2 = (item.Item3 + 10).ToString();
		var w3 = (item.Item3 - 8).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la valeur de {item.Item1}^{item.Item2} ({item.Item1} puissance {item.Item2}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "a^n désigne le produit de n facteurs tous égaux à a.",
			HintLevel2 = $"Calculez {item.Item4} (attention : ce n'est pas {item.Item1} × {item.Item2}).",
			ExplanationText = $"{item.Item1}^{item.Item2} = {item.Item4} = {item.Item3}."
		};
	}

	private ExerciseQuestion CreateNegativePowerOfTenQuestion()
	{
		var pool = new[]
		{
			(1, "0,1", "10⁻¹"),
			(2, "0,01", "10⁻²"),
			(3, "0,001", "10⁻³"),
			(4, "0,0001", "10⁻⁴")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item2;
		var w1 = (-item.Item1 * 10).ToString();
		var w2 = $"0,{new string('0', item.Item1)}1";
		var w3 = "1";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est l'écriture décimale de 10⁻{item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "10⁻ⁿ = 1 / 10ⁿ, le 1 se trouve au n-ième rang après la virgule.",
			HintLevel2 = $"Il y a {item.Item1} zéros au total en comptant celui avant la virgule.",
			ExplanationText = $"10⁻{item.Item1} s'écrit {correct}."
		};
	}

	private ExerciseQuestion CreatePowerSignRulesQuestion()
	{
		var pool = new[]
		{
			("(-3)²", "9", "-9", "6", "-6"),
			("(-2)³", "-8", "8", "-6", "6"),
			("-4²", "-16", "16", "-8", "8"),
			("(-5)²", "25", "-25", "10", "-10")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Si le nombre négatif est entre parenthèses, la puissance s'applique au signe moins.",
			HintLevel2 = "Un nombre négatif élevé à une puissance paire devient positif.",
			ExplanationText = $"{item.Item1} est égal à {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaDigitalStorageQuestion()
	{
		var pool = new[]
		{
			("1 kilo-octet (ko)", "10³ octets", "10⁶ octets", "10² octets", "10⁹ octets"),
			("1 méga-octet (Mo)", "10⁶ octets", "10³ octets", "10⁹ octets", "10¹² octets"),
			("1 giga-octet (Go)", "10⁹ octets", "10⁶ octets", "10¹² octets", "10³ octets")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"En informatique et selon les normes internationales, à combien d'octets équivaut {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Préfixes : kilo = 1 000 (10³), méga = 1 000 000 (10⁶), giga = 1 000 000 000 (10⁹).",
			HintLevel2 = "Comptez le nombre de groupes de 3 zéros.",
			ExplanationText = $"{item.Item1} correspond à {item.Item2}."
		};
	}

	private ExerciseQuestion CreateNumberToScientificNotationQuestion()
	{
		var pool = new[]
		{
			(45000, "4,5 × 10⁴", "45 × 10³", "0,45 × 10⁵", "4,5 × 10³"),
			(320000, "3,2 × 10⁵", "32 × 10⁴", "3,2 × 10⁶", "0,32 × 10⁶"),
			(1800, "1,8 × 10³", "18 × 10²", "1,8 × 10⁴", "0,18 × 10⁴")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Quelle est la notation scientifique du nombre {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La notation scientifique s'écrit a × 10ⁿ avec 1 ≤ a < 10.",
			HintLevel2 = "Le premier nombre ne doit comporter qu'un seul chiffre non nul avant la virgule.",
			ExplanationText = $"La notation scientifique de {item.Item1} est {item.Item2}."
		};
	}

	private ExerciseQuestion CreateScientificNotationToDecimalQuestion()
	{
		var pool = new[]
		{
			("7,2 × 10³", "7 200", "72 000", "720", "0,0072"),
			("3,05 × 10⁴", "30 500", "305 000", "3 050", "0,0305"),
			("6,4 × 10⁻²", "0,064", "0,64", "0,0064", "640")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est l'écriture décimale du nombre {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Déplacez la virgule du nombre de rangs indiqué par l'exposant.",
			HintLevel2 = "Vers la droite pour une puissance positive, vers la gauche pour une puissance négative.",
			ExplanationText = $"{item.Item1} s'écrit sous forme décimale : {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePowerOfTenProductRuleQuestion()
	{
		var pool = new[]
		{
			("10³ × 10⁴", "10⁷", "10¹²", "10¹", "10⁰"),
			("10⁵ × 10⁻²", "10³", "10⁻¹⁰", "10⁷", "10⁻⁷"),
			("10⁶ ÷ 10²", "10⁴", "10³", "10⁸", "10¹²")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Écrivez sous la forme d'une seule puissance de 10 : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règles : 10ᵃ × 10ᵇ = 10ᵃ⁺ᵇ et 10ᵃ ÷ 10ᵇ = 10ᵃ⁻ᵇ.",
			HintLevel2 = "Additionnez les exposants pour un produit, soustrayez-les pour un quotient.",
			ExplanationText = $"{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaAstronomyDistanceQuestion()
	{
		var pool = new[]
		{
			(150000000, "1,5 × 10⁸ km", "15 × 10⁷ km", "1,5 × 10⁶ km", "0,15 × 10⁹ km"),
			(384000, "3,84 × 10⁵ km", "38,4 × 10⁴ km", "3,84 × 10⁶ km", "0,384 × 10⁶ km"),
			(778000000, "7,78 × 10⁸ km", "77,8 × 10⁷ km", "7,78 × 10⁹ km", "0,778 × 10⁹ km")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"La distance Terre-Soleil moyenne est d'environ {item.Item1:#,##0} km. Quelle est sa notation scientifique exacte ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Placez la virgule après le premier chiffre non nul et comptez le nombre de rangs.",
			HintLevel2 = "La forme requise est obligatoirement comprise entre 1 et 10 multipliée par 10ⁿ.",
			ExplanationText = $"La distance scientifique s'écrit {item.Item2}."
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
