using AsPISApe.Models;

namespace AsPISApe.Views;

public partial class SessionPlayPage
{
	private void UpdateComboDisplay()
	{
		var mul = GetCurrentComboMultiplier();
		ComboLabel.Text = $"x{mul:F1}";
	}

	private double GetCurrentComboMultiplier() => _comboCount switch
	{
		>= 4 => 2.0,
		3 => 1.5,
		2 => 1.2,
		_ => 1.0
	};

	private void OnAntiSecheTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		if (_currentIndex >= _questions.Count) return;

		var q = _questions[_currentIndex];
		_hintLevelUsed = Math.Max(1, _hintLevelUsed);

		HintLevel1Label.Text = q.HintLevel1;
		HintLevel2Label.Text = q.HintLevel2;
		HintLevel2Card.IsVisible = _hintLevelUsed >= 2;
		UnlockLevel2Button.IsVisible = _hintLevelUsed < 2;

		AntiSecheModalOverlay.Opacity = 1;
		AntiSecheModalOverlay.IsVisible = true;
	}

	private void OnUnlockLevel2Tapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		if (_currentIndex >= _questions.Count) return;

		var q = _questions[_currentIndex];
		_hintLevelUsed = 2;

		HintLevel2Card.IsVisible = true;
		UnlockLevel2Button.IsVisible = false;

		ApplyFiftyFiftyElimination(q.CorrectChoiceIndex, q.Choices.Count);
	}

	private void ApplyFiftyFiftyElimination(int correctIndex, int count)
	{
		var toHide = _antiSecheService.GetFiftyFiftyHiddenIndices(correctIndex, count);
		foreach (var idx in toHide)
		{
			if (idx < ChoicesLayout.Children.Count && ChoicesLayout.Children[idx] is Border b)
			{
				b.Opacity = 0.25;
				b.IsEnabled = false;
			}
		}
	}

	private void OnCloseAntiSecheClicked(object? sender, EventArgs e)
	{
		_soundService.PlayClick();
		AntiSecheModalOverlay.IsVisible = false;
	}

	private void OnCloseAntiSecheTapped(object? sender, TappedEventArgs? e)
	{
		OnCloseAntiSecheClicked(sender, EventArgs.Empty);
	}
}
