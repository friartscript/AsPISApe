using AsPISApe.Models;
using AsPISApe.Services;

namespace AsPISApe.Views;

public partial class SessionSummaryPage : ContentPage
{
	private readonly INavigationService _navigationService;
	private readonly ISoundService _soundService;
	private readonly IProfileService _profileService;
	private readonly ISessionGenerator _sessionGenerator;
	private readonly IAntiSecheService _antiSecheService;
	private readonly IChallengeService _challengeService;

	private readonly int _correctCount;
	private readonly int _totalQuestions;
	private readonly int _score;
	private readonly int _elapsedSeconds;
	private readonly double _maxCombo;
	private readonly int _hintsUsed;

	public SessionSummaryPage(
		INavigationService navigationService,
		ISoundService soundService,
		IProfileService profileService,
		ISessionGenerator sessionGenerator,
		IAntiSecheService antiSecheService,
		int correctCount,
		int totalQuestions,
		int score,
		int elapsedSeconds,
		double maxCombo,
		IChallengeService? challengeService = null,
		int hintsUsed = 0)
	{
		InitializeComponent();
		_navigationService = navigationService;
		_soundService = soundService;
		_profileService = profileService;
		_sessionGenerator = sessionGenerator;
		_antiSecheService = antiSecheService;
		_challengeService = challengeService ?? new ChallengeService();

		_correctCount = correctCount;
		_totalQuestions = totalQuestions;
		_score = score;
		_elapsedSeconds = elapsedSeconds;
		_maxCombo = maxCombo;
		_hintsUsed = hintsUsed;

		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);

		ApplySummaryData();
		_ = SaveScoreAndSoundAsync();
	}

	private void ApplySummaryData()
	{
		SummaryScoreLabel.Text = $"{_correctCount} / {_totalQuestions}";
		SummaryTimeLabel.Text = FormatSeconds(_elapsedSeconds);
		SummaryComboLabel.Text = $"x{_maxCombo:F1} 🔥";
		SummaryXpLabel.Text = $"+{_score} XP";

		ConfigureCelebrationHeader();
		ConfigurePalierProgress();
	}

	private void ConfigureCelebrationHeader()
	{
		if (_correctCount == _totalQuestions)
		{
			CrownBadgeLabel.Text = "♠";
			CelebrationTitleLabel.Text = "Grand Chelem PISA !";
			CelebrationSubtitleLabel.Text = "Performance parfaite ! Tu es sur la voie des As.";
			return;
		}

		if (_correctCount >= 3)
		{
			CrownBadgeLabel.Text = "👑";
			CelebrationTitleLabel.Text = "Session Réussie !";
			CelebrationSubtitleLabel.Text = "Belle maîtrise des notions. Continue sur cette lancée !";
			return;
		}

		CrownBadgeLabel.Text = "🎯";
		CelebrationTitleLabel.Text = "Entraînement Terminé";
		CelebrationSubtitleLabel.Text = "Chaque essai renforce tes compétences PISA.";
	}

	private void ConfigurePalierProgress(UserProfile? profile = null)
	{
		profile ??= _profileService.GetProfile();
		var palier = profile?.Palier ?? 1;
		var stars = profile?.StarsDisplay ?? "★ ☆ ☆";
		var currentXp = profile?.CurrentPalierXp ?? 0;
		var targetXp = profile?.TargetPalierXp ?? 300;

		SummaryPalierLabel.Text = $"Palier {palier} : {currentXp} / {targetXp} XP";
		SummaryStarsLabel.Text = stars;

		var ratio = Math.Clamp((double)currentXp / Math.Max(1, targetXp), 0.08, 1.0);
		SummaryProgressBar.WidthRequest = Math.Max(12, 180 * ratio);
	}

	private static string FormatSeconds(int totalSec)
	{
		var m = totalSec / 60;
		var s = totalSec % 60;
		return $"{m:D2}:{s:D2}";
	}

	private async Task SaveScoreAndSoundAsync()
	{
		_soundService.PlaySuccess();
		var updated = await _profileService.RecordSessionResultAsync(
			_score,
			_correctCount,
			_totalQuestions,
			_elapsedSeconds,
			_maxCombo,
			_hintsUsed
		);

		if (updated != null)
		{
			ConfigurePalierProgress(updated);
		}
	}

	private async void OnReplayTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await _navigationService.NavigateToAsync(new SessionPlayPage(
			_navigationService,
			_soundService,
			_profileService,
			_sessionGenerator,
			_antiSecheService
		));
	}

	private async void OnShareTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		var profile = _profileService.GetProfile();
		var name = profile?.Name ?? "Élève";
		var palier = profile?.Palier ?? 1;

		var msg = _challengeService.GenerateShareMessage(name, _correctCount, _totalQuestions, _elapsedSeconds, palier, _maxCombo);

		await Share.Default.RequestAsync(new ShareTextRequest
		{
			Text = msg,
			Title = "Défi d'As — AsPISApe"
		});
	}

	private async void OnHomeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await _navigationService.NavigateBackAsync();
	}
}
