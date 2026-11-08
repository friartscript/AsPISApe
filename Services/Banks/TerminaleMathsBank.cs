using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestionByChapter(int chapterNumber)
	{
		return chapterNumber switch
		{
			1 => GenerateRecurrenceQuestion(),
			2 => GenerateFunctionLimitsQuestion(),
			3 => GenerateTrigFunctionsQuestion(),
			4 => GenerateContinuityQuestion(),
			5 => GenerateConvexityQuestion(),
			6 => GenerateLogarithmQuestion(),
			7 => GenerateDifferentialEquationsQuestion(),
			8 => GenerateIntegralsQuestion(),
			9 => GenerateSpaceGeometryQuestion(),
			10 => GenerateSpaceDotProductQuestion(),
			11 => GenerateCountingQuestion(),
			12 => GenerateBinomialLawQuestion(),
			13 => GenerateConcentrationQuestion(),
			_ => GenerateRecurrenceQuestion()
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

