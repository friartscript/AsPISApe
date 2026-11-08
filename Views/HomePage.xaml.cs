using AsPISApe.Services;

namespace AsPISApe.Views;

public partial class HomePage : ContentPage
{
	private readonly INavigationService _navigationService;
	private readonly ISoundService _soundService;
	private readonly IProfileService _profileService;
	private readonly ISessionGenerator _sessionGenerator;
	private readonly IAntiSecheService _antiSecheService;
	private string? _selectedTempPhotoPath;
	private double _currentScale = 1.0;
	private double _currentPanX;
	private double _currentPanY;
	private double _panStartX;
	private double _panStartY;
	private CancellationTokenSource? _pulseCts;
	private readonly Random _animRandom = new();
	private DateTime _lastHoverTime = DateTime.MinValue;

	public HomePage(
		INavigationService navigationService,
		ISoundService soundService,
		IProfileService profileService,
		ISessionGenerator? sessionGenerator = null,
		IAntiSecheService? antiSecheService = null)
	{
		InitializeComponent();
		_navigationService = navigationService;
		_soundService = soundService;
		_profileService = profileService;
		_sessionGenerator = sessionGenerator ?? new SessionGenerator(new ExerciseBankService());
		_antiSecheService = antiSecheService ?? new AntiSecheService();
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);

		_pulseCts?.Cancel();
		_pulseCts?.Dispose();
		_pulseCts = new CancellationTokenSource();
		StartPulseAnimation(_pulseCts.Token);

		if (!_profileService.HasProfile())
		{
			ConfigureModalForCreation();
			ProfileModalOverlay.Opacity = 1;
			ProfileModalOverlay.IsVisible = true;
			return;
		}

		ProfileModalOverlay.IsVisible = false;
		UpdateHeaderWithProfile();
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		_pulseCts?.Cancel();
		_pulseCts?.Dispose();
		_pulseCts = null;
	}

	private void UpdateHeaderWithProfile()
	{
		var profile = _profileService.GetProfile();
		if (profile == null) return;

		HeaderUsernameLabel.Text = profile.Name;
		HeaderPointsLabel.Text = $"{_profileService.FormatPoints(profile.Points)} pts";
		HeaderStreakLabel.Text = Math.Max(1, profile.StreakDays).ToString();
		HeaderTitleLabel.Text = profile.PalierTitle;
		HeaderPalierLabel.Text = $"PALIER {profile.Palier}";
		HeaderStarsLabel.Text = profile.StarsDisplay;
		HeaderPalierBadge.BackgroundColor = GetPalierColor(profile.Palier);

		var currentXp = Math.Max(0, profile.CurrentPalierXp);
		var targetXp = Math.Max(1, profile.TargetPalierXp);
		HeaderXpLabel.Text = $"{currentXp} / {targetXp} XP";

		var progressRatio = Math.Clamp((double)currentXp / targetXp, 0.08, 1.0);
		HeaderXpProgressBar.WidthRequest = Math.Max(10, 130 * progressRatio);

		if (!string.IsNullOrEmpty(profile.AvatarPath) && File.Exists(profile.AvatarPath))
		{
			HeaderAvatarImage.Source = LoadImageNoLock(profile.AvatarPath);
			HeaderAvatarImage.Scale = Math.Max(1.0, profile.AvatarScale);
			HeaderAvatarImage.TranslationX = profile.AvatarPanX * (44.0 / 94.0);
			HeaderAvatarImage.TranslationY = profile.AvatarPanY * (44.0 / 94.0);
		}
	}

	private static Color GetPalierColor(int palier) => palier switch
	{
		1 => Color.FromArgb("#BDB2FF"),
		2 => Color.FromArgb("#FFC6A5"),
		3 => Color.FromArgb("#6CB4EE"),
		4 => Color.FromArgb("#82D8A7"),
		5 => Color.FromArgb("#FCE38A"),
		_ => Color.FromArgb("#E2E8F0")
	};

	private void StartPulseAnimation(CancellationToken token)
	{
		_ = IdleBreathLoopAsync(token);
		_ = RandomAnimationLoopAsync(token);
	}

	private async Task IdleBreathLoopAsync(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				await Task.WhenAll(
					AceButton.ScaleToAsync(1.04, 1400, Easing.SinInOut),
					AceButtonHalo.ScaleToAsync(1.12, 1400, Easing.SinInOut),
					AceButtonHalo.FadeToAsync(0.45, 1400, Easing.SinInOut)
				);

				if (token.IsCancellationRequested) break;

				await Task.WhenAll(
					AceButton.ScaleToAsync(1.0, 1400, Easing.SinInOut),
					AceButtonHalo.ScaleToAsync(1.0, 1400, Easing.SinInOut),
					AceButtonHalo.FadeToAsync(0.25, 1400, Easing.SinInOut)
				);

				if (token.IsCancellationRequested) break;
				await Task.Delay(200, token);
			}
			catch (TaskCanceledException) { break; }
			catch { break; }
		}
	}

	private async Task RandomAnimationLoopAsync(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				var delayMs = _animRandom.Next(2500, 25001);
				await Task.Delay(delayMs, token);
				if (token.IsCancellationRequested) break;

				var animIndex = _animRandom.Next(5);
				await RunRandomAnimation(animIndex, token);
			}
			catch (TaskCanceledException) { break; }
			catch { break; }
		}
	}

	private Task RunRandomAnimation(int index, CancellationToken token)
	{
		return index switch
		{
			0 => AnimateElasticBounce(token),
			1 => AnimateCardWiggle(token),
			2 => AnimateHaloFlash(token),
			3 => AnimateSpadeShiver(token),
			4 => AnimateQuickSpin(token),
			_ => Task.CompletedTask
		};
	}

	private async Task AnimateElasticBounce(CancellationToken token)
	{
		if (token.IsCancellationRequested) return;
		await AceButton.ScaleToAsync(0.88, 120, Easing.CubicOut);
		if (token.IsCancellationRequested) return;
		await AceButton.ScaleToAsync(1.12, 180, Easing.BounceOut);
		if (token.IsCancellationRequested) return;
		await AceButton.ScaleToAsync(0.97, 100, Easing.CubicIn);
		if (token.IsCancellationRequested) return;
		await AceButton.ScaleToAsync(1.0, 140, Easing.SpringOut);
	}

	private async Task AnimateCardWiggle(CancellationToken token)
	{
		if (token.IsCancellationRequested) return;
		await AceButton.RotateToAsync(4, 80, Easing.CubicOut);
		if (token.IsCancellationRequested) return;
		await AceButton.RotateToAsync(-4, 80, Easing.CubicOut);
		if (token.IsCancellationRequested) return;
		await AceButton.RotateToAsync(2.5, 70, Easing.CubicOut);
		if (token.IsCancellationRequested) return;
		await AceButton.RotateToAsync(-1.5, 60, Easing.CubicOut);
		if (token.IsCancellationRequested) return;
		await AceButton.RotateToAsync(0, 80, Easing.SpringOut);
	}

	private async Task AnimateHaloFlash(CancellationToken token)
	{
		if (token.IsCancellationRequested) return;
		await Task.WhenAll(
			AceButtonHalo.ScaleToAsync(1.45, 250, Easing.CubicOut),
			AceButtonHalo.FadeToAsync(0.75, 250, Easing.CubicOut)
		);
		if (token.IsCancellationRequested) return;
		await Task.WhenAll(
			AceButtonHalo.ScaleToAsync(1.0, 500, Easing.CubicIn),
			AceButtonHalo.FadeToAsync(0.25, 500, Easing.CubicIn)
		);
	}

	private async Task AnimateSpadeShiver(CancellationToken token)
	{
		for (var i = 0; i < 6; i++)
		{
			if (token.IsCancellationRequested) return;
			var offsetX = (i % 2 == 0) ? 2.5 : -2.5;
			await AceButton.TranslateToAsync(offsetX, 0, 40, Easing.Linear);
		}
		if (token.IsCancellationRequested) return;
		await AceButton.TranslateToAsync(0, 0, 60, Easing.SpringOut);
	}

	private async Task AnimateQuickSpin(CancellationToken token)
	{
		if (token.IsCancellationRequested) return;
		AceButton.RotationY = 0;
		await AceButton.RotateYToAsync(360, 600, Easing.CubicInOut);
		AceButton.RotationY = 0;
	}

	private async void OnAceButtonTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await AceButton.ScaleToAsync(0.91, 75, Easing.CubicOut);
		await AceButton.ScaleToAsync(1.0, 95, Easing.CubicIn);
		await _navigationService.NavigateToAsync(new SessionPlayPage(
			_navigationService,
			_soundService,
			_profileService,
			_sessionGenerator,
			_antiSecheService
		));
	}

	private void OnAceButtonPointerEntered(object? sender, PointerEventArgs e)
	{
		var now = DateTime.UtcNow;
		if ((now - _lastHoverTime).TotalMilliseconds > 400)
		{
			_lastHoverTime = now;
			_soundService.PlayHover();
		}
	}

	private void OnAceButtonPointerExited(object? sender, PointerEventArgs e)
	{
	}

	private async void OnButtonPointerEntered(object? sender, PointerEventArgs e)
	{
		_soundService.PlayHover();
		if (sender is VisualElement btn)
		{
			await btn.ScaleToAsync(1.025, 100);
		}
	}

	private async void OnButtonPointerExited(object? sender, PointerEventArgs e)
	{
		if (sender is VisualElement btn)
		{
			await btn.ScaleToAsync(1.0, 100);
		}
	}
}
