using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestionByChapter(int chapterNumber)
	{
		return chapterNumber switch
		{
			1 => GenerateAlgorithmChapterQuestion(),
			2 => GenerateNumbersAndCalculusQuestion(),
			3 => GenerateIntervalsAndInequalitiesQuestion(),
			4 => GenerateAlgebraAndEquationsQuestion(),
			5 => GenerateGeometryAndCoordinatesQuestion(),
			6 => GenerateVectorsQuestion(),
			7 => GenerateLinesAndSystemsQuestion(),
			8 => GenerateFunctionsBasicsQuestion(),
			9 => GenerateVariationsAndExtremaQuestion(),
			10 => GenerateSignAndInequalitiesQuestion(),
			11 => GenerateProportionsAndPercentagesQuestion(),
			12 => GenerateStatisticsQuestion(),
			13 => GenerateProbabilitiesAndSamplingQuestion(),
			_ => GenerateNumbersAndCalculusQuestion()
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
