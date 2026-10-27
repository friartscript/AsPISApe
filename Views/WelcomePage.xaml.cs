using AsPISApe.Services;

namespace AsPISApe.Views;

public partial class WelcomePage : ContentPage
{
	private static readonly string[] ParticlesPool =
	{
		"♠", "As", "PISA",
		"Au", "Eau", "Œ", "Du", "Da", "Des", "Le", "La", "Les",
		"Ou", "Et", "On", "Ai", "En", "Un", "Par", "Car", "Si",
		"Que", "Qui", "Dans", "Pour", "Sur", "Avec", "Sans", "Bien", "Mots", "Lire",
		"E=mc²", "f(x)", "a²+b²", "πr²", "∫dx", "x→∞", "cos(θ)",
		"√Δ", "∑n", "lim x", "λ", "3.14", "x²", "Δ", "π", "∞", "≠", "≤", "≥", "±", "ln(x)", "eˣ"
	};

	private static readonly Color[] PastelColors =
	{
		Color.FromArgb("#6CB4EE"),
		Color.FromArgb("#82D8A7"),
		Color.FromArgb("#FF8DA1"),
		Color.FromArgb("#FFC6A5"),
		Color.FromArgb("#FCE38A"),
		Color.FromArgb("#BDB2FF"),
		Color.FromArgb("#98D8AA"),
		Color.FromArgb("#A0C4FF")
	};

	private readonly INavigationService _navigationService;
	private readonly ISoundService _soundService;
	private readonly IProfileService _profileService;
	private CancellationTokenSource? _animationCts;
	private int _particleCounter;
	private bool _hasAnimatedEntrance;
	private bool _rainStarted;

	public WelcomePage(INavigationService navigationService, ISoundService soundService, IProfileService profileService)
	{
		InitializeComponent();
		_navigationService = navigationService;
		_soundService = soundService;
		_profileService = profileService;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		_animationCts = new CancellationTokenSource();
		_rainStarted = false;

		if (BackgroundCanvas.Width > 0 && BackgroundCanvas.Height > 0)
		{
			_rainStarted = true;
			StartRainAnimation(_animationCts.Token);
		}
		else
		{
			BackgroundCanvas.SizeChanged += OnCanvasSizeChanged;
		}

		if (!_hasAnimatedEntrance)
		{
			_hasAnimatedEntrance = true;
			await PlayEntranceAnimationsAsync();
		}
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		BackgroundCanvas.SizeChanged -= OnCanvasSizeChanged;
		_animationCts?.Cancel();
		_animationCts?.Dispose();
		_animationCts = null;
		_rainStarted = false;
		BackgroundCanvas.Children.Clear();
	}

	private void OnCanvasSizeChanged(object? sender, EventArgs e)
	{
		if (!_rainStarted && BackgroundCanvas.Width > 0 && BackgroundCanvas.Height > 0 && _animationCts != null)
		{
			_rainStarted = true;
			BackgroundCanvas.SizeChanged -= OnCanvasSizeChanged;
			StartRainAnimation(_animationCts.Token);
		}
	}

	private async Task PlayEntranceAnimationsAsync()
	{
		MascotContainer.Scale = 0.2;
		TitleContainer.TranslationY = -35;
		TitleContainer.Opacity = 0;

		await Task.WhenAll(
			MascotContainer.ScaleToAsync(1.12, 320, Easing.SpringOut),
			TitleContainer.FadeToAsync(1, 260),
			TitleContainer.TranslateToAsync(0, 0, 320, Easing.CubicOut)
		);

		await MascotContainer.ScaleToAsync(1.0, 130);
		await MascotContainer.RotateToAsync(6, 80);
		await MascotContainer.RotateToAsync(-6, 80);
		await MascotContainer.RotateToAsync(0, 80);
	}

	private void StartRainAnimation(CancellationToken token)
	{
		BackgroundCanvas.Children.Clear();
		for (var i = 0; i < 20; i++)
		{
			SpawnParticle(true, token);
		}
	}

	private void SpawnParticle(bool isInitial, CancellationToken token)
	{
		if (token.IsCancellationRequested) return;

		var label = CreateRandomParticleLabel();
		AbsoluteLayout.SetLayoutBounds(label, new Rect(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
		BackgroundCanvas.Children.Add(label);

		var width = BackgroundCanvas.Width > 0 ? BackgroundCanvas.Width : 390;
		var height = BackgroundCanvas.Height > 0 ? BackgroundCanvas.Height : 800;

		var startX = Random.Shared.NextDouble() * (width - 60) + 15;
		var startY = isInitial ? Random.Shared.NextDouble() * height - 30 : -40;
		var totalY = height + 40 - startY;

		var speed = Random.Shared.Next(35, 65);
		var duration = (uint)Math.Max(3000, (totalY / speed) * 1000);

		var frequency = Random.Shared.NextDouble() * 1.5 + 1.0;
		var phase = Random.Shared.NextDouble() * Math.PI * 2;
		var amplitude = Random.Shared.NextDouble() * 25.0 + 15.0;
		var drift = Random.Shared.NextDouble() * 60.0 - 30.0;

		AnimateParticle(label, startX, startY, totalY, drift, frequency, phase, amplitude, duration, token);
	}

	private void AnimateParticle(Label label, double startX, double startY, double totalY, double drift, double frequency, double phase, double amplitude, uint duration, CancellationToken token)
	{
		label.TranslationX = startX;
		label.TranslationY = startY;

		var animId = $"P_{Interlocked.Increment(ref _particleCounter)}";
		var anim = new Animation(progress =>
		{
			if (token.IsCancellationRequested) return;
			var currentY = startY + progress * totalY;
			var sway = Math.Sin(progress * Math.PI * 2 * frequency + phase) * amplitude;
			var currentX = startX + (progress * drift) + sway;
			label.TranslationY = currentY;
			label.TranslationX = currentX;
			label.Rotation = Math.Sin(progress * Math.PI * 2 * frequency + phase) * 12;
		});

		anim.Commit(label, animId, rate: 16, length: duration, easing: Easing.Linear, finished: (val, cancelled) =>
		{
			BackgroundCanvas.Children.Remove(label);
			if (!cancelled && !token.IsCancellationRequested)
			{
				SpawnParticle(false, token);
			}
		});
	}

	private Label CreateRandomParticleLabel()
	{
		var text = ParticlesPool[Random.Shared.Next(ParticlesPool.Length)];
		var color = PastelColors[Random.Shared.Next(PastelColors.Length)];
		var fontSize = Random.Shared.Next(13, 22);
		var opacity = Random.Shared.NextDouble() * 0.28 + 0.18;
		var isBold = Random.Shared.Next(0, 2) == 1;

		return new Label
		{
			Text = text,
			TextColor = color,
			FontSize = fontSize,
			FontAttributes = isBold ? FontAttributes.Bold : FontAttributes.None,
			Opacity = opacity,
			InputTransparent = true,
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Start
		};
	}

	private async void OnStartButtonPointerEntered(object? sender, PointerEventArgs e)
	{
		_soundService.PlayHover();
		await StartButton.ScaleToAsync(1.025, 100);
	}

	private async void OnStartButtonPointerExited(object? sender, PointerEventArgs e)
	{
		await StartButton.ScaleToAsync(1.0, 100);
	}

	private async void OnStartButtonTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await StartButton.ScaleToAsync(0.96, 70);
		await StartButton.ScaleToAsync(1.0, 90);
		await _navigationService.NavigateToAsync(new HomePage(_navigationService, _soundService, _profileService));
	}
}
