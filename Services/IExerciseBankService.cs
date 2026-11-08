using AsPISApe.Models;

namespace AsPISApe.Services;

public interface IExerciseBankService
{
	IReadOnlyList<ExerciseQuestion> GetQuestionsByPalier(int palier);
	IReadOnlyList<ExerciseQuestion> GetQuestions(int palier, string discipline);
	ExerciseQuestion GenerateQuestion(int palier, string discipline, int targetDifficultySlot);
}
