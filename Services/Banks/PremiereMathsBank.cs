using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestionByChapter(int chapterNumber)
	{
		return chapterNumber switch
		{
			1 => GeneratePythonListsQuestion(),
			2 => GenerateSequencesQuestion(),
			3 => GenerateQuadraticQuestion(),
			4 => GenerateDerivationBasicsQuestion(),
			5 => GenerateFunctionVariationsQuestion(),
			6 => GenerateExponentialQuestion(),
			7 => GenerateTrigonometryQuestion(),
			8 => GenerateDotProductQuestion(),
			9 => GenerateCoordinateGeometryQuestion(),
			10 => GenerateConditionalProbabilityQuestion(),
			11 => GenerateRandomVariablesQuestion(),
			_ => GenerateQuadraticQuestion()
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
