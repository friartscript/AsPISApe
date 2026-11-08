using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestionByChapter(int chapterNumber)
	{
		return chapterNumber switch
		{
			1 => GenerateComplexAlgebraQuestion(),
			2 => GenerateComplexGeometryQuestion(),
			3 => GenerateCongruenceQuestion(),
			4 => GenerateBezoutGaussQuestion(),
			5 => GeneratePrimesFermatQuestion(),
			6 => GenerateMatricesGraphsQuestion(),
			7 => GenerateMarkovChainsQuestion(),
			_ => GenerateComplexAlgebraQuestion()
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

