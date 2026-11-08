namespace AsPISApe.Models;

public class QuestionAttempt
{
	public string QuestionId { get; set; } = string.Empty;
	public int SelectedChoiceIndex { get; set; } = -1;
	public bool IsCorrect { get; set; }
	public bool UsedHintLevel1 { get; set; }
	public bool UsedHintLevel2 { get; set; }
	public int EarnedPoints { get; set; }
}

public class SessionRun
{
	public string Id { get; set; } = Guid.NewGuid().ToString("N");
	public DateTime StartedAt { get; set; } = DateTime.UtcNow;
	public int TotalSeconds { get; set; }
	public int TotalScore { get; set; }
	public int CorrectAnswersCount { get; set; }
	public double MaxComboMultiplier { get; set; } = 1.0;
	public List<QuestionAttempt> Attempts { get; set; } = [];
}
