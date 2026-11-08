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
			47 => GeneratePercentMultiplierQuestion(),
			48 => GenerateScaleQuestion(),
			49 => GenerateScalingFactorQuestion(),
			50 => GenerateAverageSpeedConversionQuestion(),
			51 => GenerateFunctionImageQuestion(),
			52 => GenerateFunctionAntecedentQuestion(),
			53 => GenerateLinearVsAffineQuestion(),
			54 => GenerateFunctionImageQuestion(),
			55 => GenerateSlopeFromPointsQuestion(),
			56 => GenerateCirclePerimeterQuestion(),
			57 => GenerateCirclePerimeterQuestion(),
			58 => GenerateTrapezoidAreaQuestion(),
			59 => GenerateTrapezoidAreaQuestion(),
			60 => GenerateTrapezoidAreaQuestion(),
			61 => GenerateTimeConversionQuestion(),
			62 => GeneratePavedVolumeQuestion(),
			63 => _random.Next(2) == 0 ? GeneratePavedVolumeQuestion() : GenerateCylinderVolumeQuestion(),
			64 => GenerateConeVolumeQuestion(),
			65 => GenerateConeVolumeQuestion(),
			66 => GenerateTriangleInequalityQuestion(),
			67 => GenerateTriangleInequalityQuestion(),
			68 => GenerateTriangleAnglesSumQuestion(),
			69 => GenerateTriangleAnglesSumQuestion(),
			70 => GenerateTriangleInequalityQuestion(),
			71 => GenerateIsoscelesTriangleAnglesQuestion(),
			72 => GenerateTriangleAnglesSumQuestion(),
			73 => GenerateSimilarTrianglesQuestion(),
			74 => GenerateSimilarTrianglesQuestion(),
			75 => GenerateSimilarTrianglesQuestion(),
			76 => _random.Next(3) switch { 0 => GeneratePythagorasHypotenuseQuestion(), 1 => GeneratePythagorasLegQuestion(), _ => GeneratePythagorasRealContextQuestion() },
			77 => GeneratePythagorasConverseQuestion(),
			78 => _random.Next(3) switch { 0 => GenerateThalesDirectTriangleQuestion(), 1 => GenerateThalesButterflyQuestion(), _ => GenerateThalesPisaShadowQuestion() },
			79 => GenerateThalesConverseQuestion(),
			80 => GenerateParallelogramPropertiesQuestion(),
			81 => GenerateParallelogramPropertiesQuestion(),
			82 => GenerateParallelogramPropertiesQuestion(),
			83 => GenerateParallelogramPropertiesQuestion(),
			84 => GenerateParallelogramPropertiesQuestion(),
			85 => GenerateSupplementaryAnglesQuestion(),
			86 => GenerateSupplementaryAnglesQuestion(),
			87 => GenerateOppositeAnglesQuestion(),
			88 => GenerateAlternateInteriorAnglesQuestion(),
			89 => GenerateTriangleAnglesSumQuestion(),
			90 => GenerateTrigFormulaQuestion(),
			91 => _random.Next(2) == 0 ? GenerateTrigCosineLengthQuestion() : GenerateTrigTangentHeightQuestion(),
			92 => GenerateTrigAngleDeterminationQuestion(),
			93 => GenerateTrigFormulaQuestion(),
			94 => GenerateTrigCosineLengthQuestion(),
			95 => GenerateTrigTangentHeightQuestion(),
			96 => GenerateTrigAngleDeterminationQuestion(),
			97 => GenerateTransformationDefinitionQuestion(),
			98 => GenerateTransformationDefinitionQuestion(),
			99 => GenerateTransformationConservationQuestion(),
			100 => GenerateTransformationDefinitionQuestion(),
			101 => GenerateRotationClockwiseQuestion(),
			102 => GenerateHomothetyQuestion(),
			103 => GenerateTransformationConservationQuestion(),
			104 => GenerateCubeNetFacesQuestion(),
			105 => GenerateCubeNetFacesQuestion(),
			106 => GenerateCubeNetFacesQuestion(),
			107 => GenerateSolidSectionQuestion(),
			108 => GenerateSolidSectionQuestion(),
			109 => GenerateSolidSectionQuestion(),
			110 => GenerateSolidSectionQuestion(),
			111 => _random.Next(2) == 0 ? Generate3DCoordinatesQuestion() : GenerateSphereCoordinatesQuestion(),
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
