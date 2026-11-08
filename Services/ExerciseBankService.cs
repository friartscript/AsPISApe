using AsPISApe.Models;
using AsPISApe.Services.Banks;

namespace AsPISApe.Services;

public class ExerciseBankService : IExerciseBankService
{
	private readonly CollegeExerciseBank _collegeBank = new();

	public IReadOnlyList<ExerciseQuestion> GetQuestionsByPalier(int palier)
	{
		return _collegeBank.GetBaseQuestions();
	}

	public IReadOnlyList<ExerciseQuestion> GetQuestions(int palier, string discipline)
	{
		var all = GetQuestionsByPalier(palier);
		if (string.Equals(discipline, "Tous", StringComparison.OrdinalIgnoreCase))
		{
			return all;
		}
		return all.Where(q => string.Equals(q.Discipline, discipline, StringComparison.OrdinalIgnoreCase)).ToList();
	}

	public ExerciseQuestion GenerateQuestion(int palier, string discipline, int targetDifficultySlot)
	{
		var slot = Math.Clamp(targetDifficultySlot, 1, 5);
		return _collegeBank.GenerateQuestion(discipline, slot);
	}
}
