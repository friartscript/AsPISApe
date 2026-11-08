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
	private int _hintLevelUsed;
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

	private void ApplyDisciplineStyle(string discipline)
	{
		var isMaths = string.Equals(discipline, "Maths", StringComparison.OrdinalIgnoreCase);
		var isFrench = string.Equals(discipline, "Francais", StringComparison.OrdinalIgnoreCase);

		DisciplineBadge.BackgroundColor = isMaths
			? Color.FromArgb("#BDB2FF")
			: (isFrench ? Color.FromArgb("#FFC6A5") : Color.FromArgb("#6CB4EE"));

		DisciplineLabel.Text = isMaths
			? "📐 Maths"
			: (isFrench ? "📖 Français" : "♠ PISA Mixte");
	}

	private void BuildChoices(ExerciseQuestion q)
	{
		ChoicesLayout.Children.Clear();
		for (var i = 0; i < q.Choices.Count; i++)
		{
			var choiceIndex = i;
			var choiceText = q.Choices[i];
			ChoicesLayout.Children.Add(CreateChoiceButton(choiceIndex, choiceText));
		}
	}

	private Border CreateChoiceButton(int index, string text)
	{
		var letters = new[] { "A", "B", "C", "D" };
		var letter = index < letters.Length ? letters[index] : (index + 1).ToString();

		var border = new Border
		{
			BackgroundColor = Colors.White,
			Stroke = Color.FromArgb("#2C3445"),
			StrokeThickness = 2,
			StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(16) },
			Padding = new Thickness(12, 10),
			HeightRequest = 52
		};

		var grid = new Grid
		{
			ColumnDefinitions = new ColumnDefinitionCollection
			{
				new(GridLength.Auto),
				new(GridLength.Star)
			},
			ColumnSpacing = 10,
			VerticalOptions = LayoutOptions.Center
		};

		var badge = new Border
		{
			WidthRequest = 28,
			HeightRequest = 28,
			StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(14) },
			Stroke = Color.FromArgb("#2C3445"),
			StrokeThickness = 1.2,
			BackgroundColor = Color.FromArgb("#F1F5F9"),
			Content = new Label
			{
				Text = letter,
				FontSize = 12,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.FromArgb("#2C3445"),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			}
		};
		Grid.SetColumn(badge, 0);
		grid.Children.Add(badge);

		var label = new Label
		{
			Text = text,
			FontSize = 13,
			FontAttributes = FontAttributes.Bold,
			TextColor = Color.FromArgb("#2C3445"),
			VerticalOptions = LayoutOptions.Center,
			LineBreakMode = LineBreakMode.TailTruncation
		};
		Grid.SetColumn(label, 1);
		grid.Children.Add(label);

		border.Content = grid;

		var tap = new TapGestureRecognizer();
		tap.Tapped += (s, e) => OnChoiceTapped(index, border);
		border.GestureRecognizers.Add(tap);

		return border;
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

		await Task.Delay(900);
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
		UpdateComboDisplay();

		var earned = _antiSecheService.CalculateEarnedPoints(q.BasePoints, _hintLevelUsed);
		var multiplier = GetCurrentComboMultiplier();
		_totalScore += (int)Math.Round(earned * multiplier);
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
		ShowExplanation(q.ExplanationText);
	}

	private void HighlightCorrectAnswer(int correctIndex)
	{
		if (correctIndex < ChoicesLayout.Children.Count &&
			ChoicesLayout.Children[correctIndex] is Border correctBorder)
		{
			correctBorder.BackgroundColor = Color.FromArgb("#82D8A7");
		}
	}

	private void ShowExplanation(string text)
	{
		if (string.IsNullOrWhiteSpace(text)) return;
		ExplanationLabel.Text = text;
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
		var maxCombo = GetCurrentComboMultiplier();
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
			maxCombo
		));
	}
}
