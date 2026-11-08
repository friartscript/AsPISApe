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
		IChallengeService? challengeService = null)
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

	private void ConfigurePalierProgress()
	{
		var profile = _profileService.GetProfile();
		var palier = profile?.Palier ?? 1;
		var stars = profile?.StarsDisplay ?? "★ ☆ ☆";

		SummaryPalierLabel.Text = $"Progression Palier {palier}";
		SummaryStarsLabel.Text = stars;
		SummaryProgressBar.WidthRequest = 100;
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
		if (_score > 0)
		{
			await _profileService.AddPointsAsync(_score);
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

		var code = _challengeService.GenerateChallengeCode(_correctCount, _elapsedSeconds, palier);
		var msg = _challengeService.GenerateShareMessage(name, _correctCount, _totalQuestions, _elapsedSeconds, code);

		await Share.Default.RequestAsync(new ShareTextRequest
		{
			Text = msg,
			Title = "Défi PISA — AsPISApe"
		});
	}

	private async void OnHomeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await _navigationService.NavigateBackAsync();
	}
}
