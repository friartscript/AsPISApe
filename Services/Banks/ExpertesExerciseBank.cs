using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class ExpertesExerciseBank
{
	private readonly Random _random = new();
	private readonly ExpertesMathsBank _mathsBank = new();

	public ExerciseQuestion GenerateQuestion(string discipline, int slot)
	{
		return slot switch
		{
			1 => _mathsBank.GenerateQuestionByChapter(_random.Next(1, 3)),
			2 => _mathsBank.GenerateQuestionByChapter(_random.Next(3, 5)),
			3 => _mathsBank.GenerateQuestionByChapter(5),
			4 => _mathsBank.GenerateQuestionByChapter(6),
			_ => _mathsBank.GenerateQuestionByChapter(7)
		};
	}

	public IReadOnlyList<ExerciseQuestion> GetBaseQuestions()
	{
		var list = new List<ExerciseQuestion>();
		for (var chapter = 1; chapter <= 7; chapter++)
		{
			list.Add(_mathsBank.GenerateQuestionByChapter(chapter));
		}
		return list;
	}
}

