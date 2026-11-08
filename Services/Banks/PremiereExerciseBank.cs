using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class PremiereExerciseBank
{
	private readonly Random _random = new();
	private readonly PremiereMathsBank _mathsBank = new();

	public ExerciseQuestion GenerateQuestion(string discipline, int slot)
	{
		return slot switch
		{
			1 => _mathsBank.GenerateQuestionByChapter(_random.Next(1, 3)),
			2 => _mathsBank.GenerateQuestionByChapter(_random.Next(3, 5)),
			3 => _mathsBank.GenerateQuestionByChapter(_random.Next(5, 7)),
			4 => _mathsBank.GenerateQuestionByChapter(_random.Next(7, 9)),
			_ => _mathsBank.GenerateQuestionByChapter(_random.Next(9, 12))
		};
	}

	public IReadOnlyList<ExerciseQuestion> GetBaseQuestions()
	{
		var list = new List<ExerciseQuestion>();
		for (var chapter = 1; chapter <= 11; chapter++)
		{
			list.Add(_mathsBank.GenerateQuestionByChapter(chapter));
		}
		return list;
	}
}
