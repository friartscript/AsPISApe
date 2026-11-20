using AsPISApe.Models;

namespace AsPISApe.Services;

public interface IProfileService
{
	UserProfile? GetProfile();
	bool HasProfile();
	Task<bool> SaveProfileAsync(string name, string sourceImagePath, double scale = 1.0, double panX = 0.0, double panY = 0.0);
	Task AddPointsAsync(long points);
	Task<UserProfile?> RecordSessionResultAsync(int score, int correctCount, int totalQuestions, int elapsedSeconds, double maxCombo, int hintsUsed);
	string FormatPoints(long points);
	bool IsValidUsername(string? name);
}
