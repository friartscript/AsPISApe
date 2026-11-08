using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
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
			20 => GenerateSquareRoots(),
			21 => GenerateLiteralCalculusBasics(),
			22 => GenerateSingleDistributivity(),
			23 => GenerateExpansionAndReduction(),
			24 => GenerateDoubleDistributivityAndIdentities(),
			25 => GenerateFactorization(),
			26 => GenerateFormulasAndCalculus(),
			27 => GenerateFirstDegreeEquation(),
			28 => GenerateProductEquation(),
			29 => GenerateProblemModeling(),
			30 => GenerateFormulaUsage(),
			31 => GenerateLiteralProof(),
			32 => GenerateAlgorithmQuestion(),
			33 => GenerateVariableQuestion(),
			34 => GenerateGeometricTraceQuestion(),
			35 => GenerateFrequencyQuestion(),
			36 => GenerateFrequencyQuestion(),
			37 => GenerateRangeQuestion(),
			38 => GenerateMeanQuestion(),
			39 => GenerateMedianQuestion(),
			40 => GenerateBasicProbabilityQuestion(),
			41 => GenerateComplementaryProbabilityQuestion(),
			42 => GenerateBasicProbabilityQuestion(),
			43 => GenerateFourthProportionalQuestion(),
			44 => GenerateFourthProportionalQuestion(),
			45 => GenerateRatioQuestion(),
			46 => _random.Next(2) == 0 ? GeneratePercentageDiscountQuestion() : GeneratePercentageIncreaseQuestion(),
			_ => GenerateEuclideanDivision()
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
