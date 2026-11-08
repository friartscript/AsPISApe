namespace AsPISApe.Models;

public class UserProfile
{
	private double _avatarScale = 1.0;

	public string Name { get; set; } = string.Empty;
	public string AvatarPath { get; set; } = string.Empty;
	public long Points { get; set; }
	public int Palier { get; set; } = 1;
	public int Stars { get; set; } = 1;
	public int StreakDays { get; set; } = 1;
	public int CurrentPalierXp { get; set; } = 0;
	public int TargetPalierXp { get; set; } = 100;

	public double AvatarScale
	{
		get => _avatarScale <= 0 ? 1.0 : _avatarScale;
		set => _avatarScale = value <= 0 ? 1.0 : value;
	}
	public double AvatarPanX { get; set; }
	public double AvatarPanY { get; set; }

	public string PalierTitle => Palier switch
	{
		1 => "Valet de Trèfle ♣",
		2 => "Valet de Cœur ♥",
		3 => "Dame de Carreau ♦",
		4 => "Roi de Trèfle ♣",
		5 => "Roi de Pique ♠",
		_ => "As de Pique ♠"
	};

	public string StarsDisplay => Stars switch
	{
		3 => "★ ★ ★",
		2 => "★ ★ ☆",
		1 => "★ ☆ ☆",
		_ => "☆ ☆ ☆"
	};
}
