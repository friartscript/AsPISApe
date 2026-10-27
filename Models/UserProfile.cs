namespace AsPISApe.Models;

public class UserProfile
{
	private double _avatarScale = 1.0;

	public string Name { get; set; } = string.Empty;
	public string AvatarPath { get; set; } = string.Empty;
	public long Points { get; set; }
	public double AvatarScale
	{
		get => _avatarScale <= 0 ? 1.0 : _avatarScale;
		set => _avatarScale = value <= 0 ? 1.0 : value;
	}
	public double AvatarPanX { get; set; }
	public double AvatarPanY { get; set; }
}
