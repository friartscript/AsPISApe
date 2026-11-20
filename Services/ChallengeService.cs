namespace AsPISApe.Services;

public class ChallengeService : IChallengeService
{
	public string GenerateShareMessage(string username, int correctCount, int totalQuestions, int totalSeconds, int palier = 1, double maxCombo = 1.0)
	{
		var m = totalSeconds / 60;
		var s = totalSeconds % 60;
		var timeStr = $"{m:D2}:{s:D2}";
		var name = string.IsNullOrWhiteSpace(username) ? "Un élève" : username.Trim();
		var palierLabel = GetPalierLabel(palier);

		return $"♠ AsPISApe — Performance d'As ♠\n" +
		       $"{name} a validé {correctCount}/{totalQuestions} en {timeStr} (Combo x{maxCombo:F1} 🔥) au Palier {palierLabel} !\n" +
		       $"Peux-tu faire mieux ?\n" +
		       $"L'app qui te fait devenir un as du PISA ♠";
	}

	private static string GetPalierLabel(int palier) => palier switch
	{
		1 => "Collège",
		2 => "Seconde",
		3 => "Première Spé",
		4 => "Terminale Spé",
		5 => "Maths Expertes",
		_ => $"Palier {palier}"
	};
}
