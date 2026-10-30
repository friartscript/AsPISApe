namespace AsPISApe.Models;

public class SubjectItem
{
	public string Id { get; set; } = string.Empty;
	public string Title { get; set; } = string.Empty;
	public string Discipline { get; set; } = "Maths"; // "Maths" ou "Francais"
	public string Level { get; set; } = "College";    // "College" ou "Lycee"
	public string ClassLevel { get; set; } = string.Empty; // "6e-3e", "2de", "1re Spé", "Tle Spé", "Tle Expertes"
	public int Palier { get; set; } = 1;
	public string Domain { get; set; } = string.Empty;
	public string Details { get; set; } = string.Empty;
	public string ReferencePage { get; set; } = string.Empty;

	// Propriétés d'aide à l'affichage UI
	public string DisciplineIcon => Discipline == "Francais" ? "📖" : "📐";
	public string DisciplineName => Discipline == "Francais" ? "Français" : "Maths";
	public Color DisciplineColor => Discipline == "Francais" ? Color.FromArgb("#FFC6A5") : Color.FromArgb("#BDB2FF");
	public Color DisciplineBorderColor => Discipline == "Francais" ? Color.FromArgb("#E8A580") : Color.FromArgb("#9A8CF2");
	public string PalierBadge => $"PALIER {Palier}";
	public string LevelBadge => Level == "College" ? "Collège" : "Lycée";
}
