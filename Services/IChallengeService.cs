namespace AsPISApe.Services;

public interface IChallengeService
{
	string GenerateShareMessage(string username, int correctCount, int totalQuestions, int totalSeconds, int palier = 1, double maxCombo = 1.0);
}
