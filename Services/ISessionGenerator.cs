using AsPISApe.Models;

namespace AsPISApe.Services;

public interface ISessionGenerator
{
	IReadOnlyList<ExerciseQuestion> GenerateCrescendoSession(int palier);
}
