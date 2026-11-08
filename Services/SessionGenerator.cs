using AsPISApe.Models;

namespace AsPISApe.Services;

public class SessionGenerator : ISessionGenerator
{
	private readonly IExerciseBankService _exerciseBank;

	public SessionGenerator(IExerciseBankService exerciseBank)
	{
		_exerciseBank = exerciseBank;
	}

	public IReadOnlyList<ExerciseQuestion> GenerateCrescendoSession(int palier)
	{
		var questions = new List<ExerciseQuestion>(5)
		{
			_exerciseBank.GenerateQuestion(palier, "Francais", 1),
			_exerciseBank.GenerateQuestion(palier, "Maths", 2),
			_exerciseBank.GenerateQuestion(palier, "Mixte", 3),
			_exerciseBank.GenerateQuestion(palier, "Maths", 4),
			_exerciseBank.GenerateQuestion(palier, "Mixte", 5)
		};

		return questions;
	}
}
