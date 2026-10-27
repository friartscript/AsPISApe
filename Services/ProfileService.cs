using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using AsPISApe.Models;

namespace AsPISApe.Services;

public class ProfileService : IProfileService
{
	private static readonly string ProfileFilePath = Path.Combine(FileSystem.AppDataDirectory, "profile.json");
	private static readonly string AvatarFilePath = Path.Combine(FileSystem.AppDataDirectory, "avatar_user.png");
	private UserProfile? _profile;

	public UserProfile? GetProfile()
	{
		if (_profile != null) return _profile;
		if (!File.Exists(ProfileFilePath)) return null;

		try
		{
			var json = File.ReadAllText(ProfileFilePath);
			_profile = JsonSerializer.Deserialize<UserProfile>(json);
			return _profile;
		}
		catch
		{
			return null;
		}
	}

	public bool HasProfile()
	{
		var profile = GetProfile();
		return profile != null && !string.IsNullOrWhiteSpace(profile.Name);
	}

	public async Task<bool> SaveProfileAsync(string name, string sourceImagePath, double scale = 1.0, double panX = 0.0, double panY = 0.0)
	{
		if (!IsValidUsername(name) || !File.Exists(sourceImagePath)) return false;

		try
		{
			var isSameFile = string.Equals(
				Path.GetFullPath(sourceImagePath),
				Path.GetFullPath(AvatarFilePath),
				StringComparison.OrdinalIgnoreCase);

			if (!isSameFile)
			{
				var imageBytes = await File.ReadAllBytesAsync(sourceImagePath);
				await File.WriteAllBytesAsync(AvatarFilePath, imageBytes);
			}

			_profile ??= new UserProfile();
			_profile.Name = name.Trim();
			_profile.AvatarPath = AvatarFilePath;
			_profile.AvatarScale = scale;
			_profile.AvatarPanX = panX;
			_profile.AvatarPanY = panY;

			var json = JsonSerializer.Serialize(_profile);
			await File.WriteAllTextAsync(ProfileFilePath, json);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public async Task AddPointsAsync(long points)
	{
		if (_profile == null) GetProfile();
		if (_profile == null) return;

		_profile.Points += points;
		var json = JsonSerializer.Serialize(_profile);
		await File.WriteAllTextAsync(ProfileFilePath, json);
	}

	public string FormatPoints(long points)
	{
		return points.ToString("N0", CultureInfo.GetCultureInfo("fr-FR"))
			.Replace('\u00A0', ' ')
			.Replace('\u202F', ' ');
	}

	public bool IsValidUsername(string? name)
	{
		if (string.IsNullOrWhiteSpace(name)) return false;
		var trimmed = name.Trim();
		if (trimmed.Length < 3 || trimmed.Length > 24) return false;
		if (trimmed.Contains('<') || trimmed.Contains('>')) return false;
		return Regex.IsMatch(trimmed, @"^[a-zA-Z0-9À-ÿ_\- ]+$");
	}
}
