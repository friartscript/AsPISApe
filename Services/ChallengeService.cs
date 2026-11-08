namespace AsPISApe.Services;

public class ChallengeService : IChallengeService
{
	public string GenerateChallengeCode(int correctCount, int totalSeconds, int palier)
	{
		var safeSec = Math.Clamp(totalSeconds, 1, 999);
		var seed = (palier * 10000) + (correctCount * 1000) + safeSec;
		var hex = seed.ToString("X4");
		return $"PISA-{hex}";
	}

	public string GenerateShareMessage(string username, int correctCount, int totalQuestions, int totalSeconds, string challengeCode)
	{
		var m = totalSeconds / 60;
		var s = totalSeconds % 60;
		var timeStr = $"{m:D2}:{s:D2}";
		var name = string.IsNullOrWhiteSpace(username) ? "Un élève" : username.Trim();

		return $"♠ AsPISApe — Défi PISA\n" +
		       $"{name} a validé {correctCount}/{totalQuestions} en {timeStr} !\n" +
		       $"Peux-tu faire mieux ?\n" +
		       $"Code Défi : {challengeCode}\n" +
		       $"L'app qui te fait devenir un as du PISA ♠";
	}
}
