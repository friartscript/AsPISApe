namespace AsPISApe.Models;

public class ExerciseQuestion
{
	public string Id { get; set; } = string.Empty;
	public string SubjectId { get; set; } = string.Empty;
	public string Discipline { get; set; } = "Maths";
	public string ClassLevel { get; set; } = "6e";
	public int Palier { get; set; } = 1;
	public string QuestionText { get; set; } = string.Empty;
	public List<string> Choices { get; set; } = [];
	public int CorrectChoiceIndex { get; set; }
	public string HintLevel1 { get; set; } = string.Empty;
	public string HintLevel2 { get; set; } = string.Empty;
	public string ExplanationText { get; set; } = string.Empty;
	public int BasePoints { get; set; } = 10;
}
