using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class TerminaleExerciseBank
{
	private readonly Random _random = new();
	private readonly TerminaleMathsBank _mathsBank = new();

	public ExerciseQuestion GenerateQuestion(string discipline, int slot)
	{
		return slot switch
		{
			1 => _mathsBank.GenerateQuestionByChapter(_random.Next(1, 4)),
			2 => _mathsBank.GenerateQuestionByChapter(_random.Next(4, 6)),
			3 => _mathsBank.GenerateQuestionByChapter(_random.Next(6, 8)),
			4 => _mathsBank.GenerateQuestionByChapter(_random.Next(8, 11)),
			_ => _mathsBank.GenerateQuestionByChapter(_random.Next(11, 14))
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

