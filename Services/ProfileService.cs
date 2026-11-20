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

	public async Task<UserProfile?> RecordSessionResultAsync(int score, int correctCount, int totalQuestions, int elapsedSeconds, double maxCombo, int hintsUsed)
	{
		if (_profile == null) GetProfile();
		if (_profile == null) return null;

		_profile.Points += Math.Max(0, score);
		UpdateStreak();
		UpdatePalierProgress(score, correctCount, totalQuestions, hintsUsed);
		CheckAndAwardBadges(correctCount, totalQuestions, elapsedSeconds, maxCombo, hintsUsed);

		var json = JsonSerializer.Serialize(_profile);
		await File.WriteAllTextAsync(ProfileFilePath, json);
		return _profile;
	}

	private void UpdateStreak()
	{
		if (_profile == null) return;
		var today = DateTime.UtcNow.Date;
		if (!_profile.LastSessionDateUtc.HasValue)
		{
			_profile.StreakDays = 1;
		}
		else
		{
			var lastDate = _profile.LastSessionDateUtc.Value.Date;
			if (lastDate == today.AddDays(-1))
			{
				_profile.StreakDays++;
			}
			else if (lastDate < today.AddDays(-1))
			{
				_profile.StreakDays = 1;
			}
		}
		_profile.LastSessionDateUtc = DateTime.UtcNow;
	}

	private void UpdatePalierProgress(int score, int correctCount, int totalQuestions, int hintsUsed)
	{
		if (_profile == null) return;
		var baseGain = correctCount * 20;
		if (hintsUsed > 0)
		{
			baseGain = Math.Max(correctCount * 10, baseGain - (hintsUsed * 7));
		}
		if (correctCount == totalQuestions && totalQuestions > 0)
		{
			baseGain += 50;
		}

		_profile.TargetPalierXp = 300;
		_profile.CurrentPalierXp += baseGain;

		while (_profile.CurrentPalierXp >= _profile.TargetPalierXp && _profile.Palier < 5)
		{
			_profile.CurrentPalierXp -= _profile.TargetPalierXp;
			_profile.Palier++;
		}

		if (_profile.Palier >= 5 && _profile.CurrentPalierXp >= _profile.TargetPalierXp)
		{
			_profile.CurrentPalierXp = _profile.TargetPalierXp;
			_profile.Stars = 3;
		}
		else
		{
			_profile.Stars = Math.Clamp((_profile.CurrentPalierXp / 100) + 1, 1, 3);
		}
	}

	private void CheckAndAwardBadges(int correctCount, int totalQuestions, int elapsedSeconds, double maxCombo, int hintsUsed)
	{
		if (_profile == null) return;
		_profile.Badges ??= new List<string>();

		if (correctCount == totalQuestions && totalQuestions >= 5)
			AwardBadge("Grand Chelem ♠");
		if (elapsedSeconds <= 45 && correctCount >= 4)
			AwardBadge("Éclair ⚡");
		if (correctCount == totalQuestions && hintsUsed == 0 && totalQuestions >= 5)
			AwardBadge("Sans Filet 🎯");
		if (_profile.StreakDays >= 7)
			AwardBadge("Flamme Ardente 🔥");
		if (_profile.Palier >= 3)
			AwardBadge("Couronne Lycéenne 👑");
		if (_profile.Palier >= 5 && _profile.Stars >= 3)
			AwardBadge("Légende d'As 🏆");
	}

	private void AwardBadge(string badgeName)
	{
		if (_profile != null && !_profile.Badges.Contains(badgeName))
		{
			_profile.Badges.Add(badgeName);
		}
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
