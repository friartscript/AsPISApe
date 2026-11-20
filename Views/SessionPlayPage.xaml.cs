using AsPISApe.Models;
using AsPISApe.Services;
using Microsoft.Maui.Controls.Shapes;

namespace AsPISApe.Views;

public partial class SessionPlayPage : ContentPage
{
	private readonly INavigationService _navigationService;
	private readonly ISoundService _soundService;
	private readonly IProfileService _profileService;
	private readonly ISessionGenerator _sessionGenerator;
	private readonly IAntiSecheService _antiSecheService;

	private IReadOnlyList<ExerciseQuestion> _questions = [];
	private int _currentIndex;
	private int _totalScore;
	private int _correctCount;
	private int _comboCount;
	private double _maxComboMultiplier = 1.0;
	private int _hintLevelUsed;
	private int _totalHintsUsed;
	private int _elapsedSeconds;
	private bool _isAnswerLocked;
	private CancellationTokenSource? _timerCts;

	public SessionPlayPage(
		INavigationService navigationService,
		ISoundService soundService,
		IProfileService profileService,
		ISessionGenerator sessionGenerator,
		IAntiSecheService antiSecheService)
	{
		InitializeComponent();
		_navigationService = navigationService;
		_soundService = soundService;
		_profileService = profileService;
		_sessionGenerator = sessionGenerator;
		_antiSecheService = antiSecheService;
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);

		var profile = _profileService.GetProfile();
		var palier = profile?.Palier ?? 1;

		_questions = _sessionGenerator.GenerateCrescendoSession(palier);
		_currentIndex = 0;
		_totalScore = 0;
		_correctCount = 0;
		_comboCount = 0;
		_maxComboMultiplier = 1.0;
		_totalHintsUsed = 0;
		_elapsedSeconds = 0;

		StartTimer();
		DisplayCurrentQuestion();
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		StopTimer();
	}

	private void StartTimer()
	{
		StopTimer();
		_timerCts = new CancellationTokenSource();
		_ = TimerLoopAsync(_timerCts.Token);
	}

	private void StopTimer()
	{
		_timerCts?.Cancel();
		_timerCts?.Dispose();
		_timerCts = null;
	}

	private async Task TimerLoopAsync(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				await Task.Delay(1000, token);
				if (token.IsCancellationRequested) break;
				_elapsedSeconds++;
				UpdateTimerDisplay();
			}
			catch { break; }
		}
	}

	private void UpdateTimerDisplay()
	{
		var remaining = Math.Max(0, 90 - _elapsedSeconds);
		var minutes = remaining / 60;
		var seconds = remaining % 60;
		TimerLabel.Text = $"⏱️ {minutes:D2}:{seconds:D2}";
	}

	private void DisplayCurrentQuestion()
	{
		if (_currentIndex >= _questions.Count)
		{
			_ = FinishSessionAsync();
			return;
		}

		_isAnswerLocked = false;
		_hintLevelUsed = 0;

		var q = _questions[_currentIndex];
		QuestionProgressLabel.Text = $"Question {_currentIndex + 1}/5";
		ProgressBarFill.WidthRequest = Math.Max(10, 160 * ((_currentIndex + 1) / 5.0));

		ApplyDisciplineStyle(q.Discipline);
		ClassLevelLabel.Text = q.ClassLevel;
		QuestionTextLabel.Text = q.QuestionText;
		ExplanationBox.IsVisible = false;

		BuildChoices(q);
	}

	private async void OnChoiceTapped(int selectedIndex, Border selectedBorder)
	{
		if (_isAnswerLocked || _currentIndex >= _questions.Count) return;
		_isAnswerLocked = true;

		var q = _questions[_currentIndex];
		var isCorrect = selectedIndex == q.CorrectChoiceIndex;

		if (isCorrect)
		{
			await HandleCorrectAnswerAsync(selectedBorder, q);
		}
		else
		{
			await HandleWrongAnswerAsync(selectedBorder, q);
		}

		await Task.Delay(1400);
		_currentIndex++;
		DisplayCurrentQuestion();
	}

	private async Task HandleCorrectAnswerAsync(Border border, ExerciseQuestion q)
	{
		_soundService.PlaySuccess();
		border.BackgroundColor = Color.FromArgb("#82D8A7");
		await border.ScaleToAsync(1.03, 80);
		await border.ScaleToAsync(1.0, 80);

		_correctCount++;
		_comboCount++;
		var multiplier = GetCurrentComboMultiplier();
		if (multiplier > _maxComboMultiplier)
		{
			_maxComboMultiplier = multiplier;
		}
		UpdateComboDisplay();

		var earned = _antiSecheService.CalculateEarnedPoints(q.BasePoints, _hintLevelUsed);
		_totalScore += (int)Math.Round(earned * multiplier);

		ShowExplanation(q.ExplanationText, true);
	}

	private async Task HandleWrongAnswerAsync(Border border, ExerciseQuestion q)
	{
		_soundService.PlayError();
		border.BackgroundColor = Color.FromArgb("#FFC6A5");
		await border.TranslateToAsync(-4, 0, 40);
		await border.TranslateToAsync(4, 0, 40);
		await border.TranslateToAsync(0, 0, 40);

		_comboCount = 0;
		UpdateComboDisplay();

		HighlightCorrectAnswer(q.CorrectChoiceIndex);
		ShowExplanation(q.ExplanationText, false);
	}

	private void ShowExplanation(string text, bool isSuccess)
	{
		if (string.IsNullOrWhiteSpace(text)) return;
		ExplanationBox.BackgroundColor = isSuccess
			? Color.FromArgb("#DCFCE7")
			: Color.FromArgb("#FFE8D6");
		ExplanationBox.Stroke = isSuccess
			? Color.FromArgb("#82D8A7")
			: Color.FromArgb("#FFC6A5");
		ExplanationLabel.TextColor = isSuccess
			? Color.FromArgb("#166534")
			: Color.FromArgb("#9A3412");
		ExplanationLabel.Text = (isSuccess ? "✓ " : "✕ ") + text;
		ExplanationBox.IsVisible = true;
	}

	private async void OnAbandonTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		StopTimer();
		await _navigationService.NavigateBackAsync();
	}

	private async Task FinishSessionAsync()
	{
		StopTimer();
		await _navigationService.NavigateToAsync(new SessionSummaryPage(
			_navigationService,
			_soundService,
			_profileService,
			_sessionGenerator,
			_antiSecheService,
			_correctCount,
			_questions.Count,
			_totalScore,
			_elapsedSeconds,
			_maxComboMultiplier,
			null,
			_totalHintsUsed
		));
	}
}
