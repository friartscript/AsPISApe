namespace AsPISApe.Services;

public interface IChallengeService
{
	string GenerateChallengeCode(int correctCount, int totalSeconds, int palier);
	string GenerateShareMessage(string username, int correctCount, int totalQuestions, int totalSeconds, string challengeCode);
}
