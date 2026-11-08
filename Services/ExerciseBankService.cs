using AsPISApe.Models;
using AsPISApe.Services.Banks;

namespace AsPISApe.Services;

public class ExerciseBankService : IExerciseBankService
{
	private readonly CollegeExerciseBank _collegeBank = new();
	private readonly SecondeExerciseBank _secondeBank = new();
	private readonly PremiereExerciseBank _premiereBank = new();
	private readonly TerminaleExerciseBank _terminaleBank = new();
	private readonly ExpertesExerciseBank _expertesBank = new();

	public IReadOnlyList<ExerciseQuestion> GetQuestionsByPalier(int palier)
	{
		return palier switch
		{
			5 => _expertesBank.GetBaseQuestions(),
			4 => _terminaleBank.GetBaseQuestions(),
			3 => _premiereBank.GetBaseQuestions(),
			2 => _secondeBank.GetBaseQuestions(),
			_ => _collegeBank.GetBaseQuestions()
		};
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
		return palier switch
		{
			5 => _expertesBank.GenerateQuestion(discipline, slot),
			4 => _terminaleBank.GenerateQuestion(discipline, slot),
			3 => _premiereBank.GenerateQuestion(discipline, slot),
			2 => _secondeBank.GenerateQuestion(discipline, slot),
			_ => _collegeBank.GenerateQuestion(discipline, slot)
		};
	}
}
