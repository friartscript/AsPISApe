using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class SecondeExerciseBank
{
	private readonly Random _random = new();
	private readonly SecondeMathsBank _mathsBank = new();

	public ExerciseQuestion GenerateQuestion(string discipline, int slot)
	{
		return slot switch
		{
			1 => _mathsBank.GenerateQuestionByChapter(_random.Next(1, 4)),
			2 => _mathsBank.GenerateQuestionByChapter(_random.Next(4, 7)),
			3 => _mathsBank.GenerateQuestionByChapter(_random.Next(7, 10)),
			4 => _mathsBank.GenerateQuestionByChapter(_random.Next(10, 12)),
			_ => _mathsBank.GenerateQuestionByChapter(_random.Next(12, 14))
		};
	}

	public IReadOnlyList<ExerciseQuestion> GetBaseQuestions()
	{
		var list = new List<ExerciseQuestion>();
		for (var chapter = 1; chapter <= 13; chapter++)
		{
			list.Add(_mathsBank.GenerateQuestionByChapter(chapter));
		}
		return list;
	}
}
