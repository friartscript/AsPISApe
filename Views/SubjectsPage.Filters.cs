namespace AsPISApe.Views;

public partial class SubjectsPage
{
	private void OnResetFiltersTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		_currentDiscipline = "Tous";
		_currentLevel = "Tous";
		_currentClassLevel = "Tous";
		_currentSearchQuery = string.Empty;
		SearchEntry.Text = string.Empty;

		UpdateDisciplineTabUi();
		UpdateLevelTabUi();
		UpdateClassChipsVisibility();
		UpdateClassChipsUi();
		ApplyFilters();
	}

	private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
	{
		_currentSearchQuery = e.NewTextValue ?? string.Empty;
		ApplyFilters();
	}

	private void OnFilterDisciplineAllTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentDiscipline = "Tous";
		UpdateDisciplineTabUi();
		ApplyFilters();
	}

	private void OnFilterDisciplineMathsTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentDiscipline = "Maths";
		UpdateDisciplineTabUi();
		ApplyFilters();
	}

	private void OnFilterDisciplineFrancaisTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentDiscipline = "Francais";
		UpdateDisciplineTabUi();
		ApplyFilters();
	}

	private void UpdateDisciplineTabUi()
	{
		SetTabStyle(BtnDisciplineAll, LblDisciplineAll, _currentDiscipline == "Tous", Color.FromArgb("#6CB4EE"));
		SetTabStyle(BtnDisciplineMaths, LblDisciplineMaths, _currentDiscipline == "Maths", Color.FromArgb("#BDB2FF"));
		SetTabStyle(BtnDisciplineFrancais, LblDisciplineFrancais, _currentDiscipline == "Francais", Color.FromArgb("#FFC6A5"));
	}

	private void OnFilterLevelAllTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentLevel = "Tous";
		UpdateLevelTabUi();
		UpdateClassChipsVisibility();
		ApplyFilters();
	}

	private void OnFilterLevelCollegeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentLevel = "College";
		if (IsLyceeClass(_currentClassLevel))
		{
			_currentClassLevel = "Tous";
			UpdateClassChipsUi();
		}
		UpdateLevelTabUi();
		UpdateClassChipsVisibility();
		ApplyFilters();
	}

	private void OnFilterLevelLyceeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentLevel = "Lycee";
		if (IsCollegeClass(_currentClassLevel))
		{
			_currentClassLevel = "Tous";
			UpdateClassChipsUi();
		}
		UpdateLevelTabUi();
		UpdateClassChipsVisibility();
		ApplyFilters();
	}

	private static bool IsCollegeClass(string cls) =>
		cls is "6e" or "5e" or "4e" or "3e";

	private static bool IsLyceeClass(string cls) =>
		cls is "2de" or "1re Spé" or "Tle Spé" or "Tle Expertes";

	private void UpdateLevelTabUi()
	{
		SetTabStyle(BtnLevelAll, LblLevelAll, _currentLevel == "Tous", Color.FromArgb("#2C3445"));
		SetTabStyle(BtnLevelCollege, LblLevelCollege, _currentLevel == "College", Color.FromArgb("#82D8A7"));
		SetTabStyle(BtnLevelLycee, LblLevelLycee, _currentLevel == "Lycee", Color.FromArgb("#6CB4EE"));
	}

	private void UpdateClassChipsVisibility()
	{
		if (_currentLevel == "College")
		{
			EnsureChipClassAllIn(RowClassCollege);
			RowClassCollege.IsVisible = true;
			RowClassLycee.IsVisible = false;
			return;
		}

		if (_currentLevel == "Lycee")
		{
			EnsureChipClassAllIn(RowClassLycee);
			RowClassCollege.IsVisible = false;
			RowClassLycee.IsVisible = true;
			return;
		}

		EnsureChipClassAllIn(RowClassCollege);
		RowClassCollege.IsVisible = true;
		RowClassLycee.IsVisible = true;
	}

	private void EnsureChipClassAllIn(HorizontalStackLayout target)
	{
		if (target.Children.Contains(ChipClassAll))
		{
			return;
		}

		RowClassCollege.Children.Remove(ChipClassAll);
		RowClassLycee.Children.Remove(ChipClassAll);
		target.Children.Insert(0, ChipClassAll);
	}

	private void OnChipClassAllTapped(object? sender, TappedEventArgs e) => SelectClassChip("Tous");
	private void OnChipClass6eTapped(object? sender, TappedEventArgs e) => SelectClassChip("6e");
	private void OnChipClass5eTapped(object? sender, TappedEventArgs e) => SelectClassChip("5e");
	private void OnChipClass4eTapped(object? sender, TappedEventArgs e) => SelectClassChip("4e");
	private void OnChipClass3eTapped(object? sender, TappedEventArgs e) => SelectClassChip("3e");
	private void OnChipClass2deTapped(object? sender, TappedEventArgs e) => SelectClassChip("2de");
	private void OnChipClass1reTapped(object? sender, TappedEventArgs e) => SelectClassChip("1re Spé");
	private void OnChipClassTleSpeTapped(object? sender, TappedEventArgs e) => SelectClassChip("Tle Spé");
	private void OnChipClassTleExpTapped(object? sender, TappedEventArgs e) => SelectClassChip("Tle Expertes");

	private void SelectClassChip(string classLevel)
	{
		_soundService.PlaySelect();
		_currentClassLevel = classLevel;
		UpdateClassChipsUi();
		ApplyFilters();
	}

	private void UpdateClassChipsUi()
	{
		SetChipStyle(ChipClassAll, LblClassAll, _currentClassLevel == "Tous");
		SetChipStyle(ChipClass6e, LblClass6e, _currentClassLevel == "6e");
		SetChipStyle(ChipClass5e, LblClass5e, _currentClassLevel == "5e");
		SetChipStyle(ChipClass4e, LblClass4e, _currentClassLevel == "4e");
		SetChipStyle(ChipClass3e, LblClass3e, _currentClassLevel == "3e");
		SetChipStyle(ChipClass2de, LblClass2de, _currentClassLevel == "2de");
		SetChipStyle(ChipClass1re, LblClass1re, _currentClassLevel == "1re Spé");
		SetChipStyle(ChipClassTleSpe, LblClassTleSpe, _currentClassLevel == "Tle Spé");
		SetChipStyle(ChipClassTleExp, LblClassTleExp, _currentClassLevel == "Tle Expertes");
	}

	private static void SetTabStyle(Border border, Label label, bool isSelected, Color activeColor)
	{
		if (isSelected)
		{
			border.BackgroundColor = activeColor;
			border.StrokeThickness = 2;
			label.TextColor = activeColor.GetLuminosity() > 0.65 ? Color.FromArgb("#2C3445") : Colors.White;
			label.FontAttributes = FontAttributes.Bold;
			return;
		}

		border.BackgroundColor = Colors.White;
		border.StrokeThickness = 1.5;
		label.TextColor = Color.FromArgb("#2C3445");
		label.FontAttributes = FontAttributes.None;
	}

	private static void SetChipStyle(Border chip, Label label, bool isSelected)
	{
		chip.Stroke = Color.FromArgb("#2C3445");
		chip.StrokeThickness = 1.5;

		if (isSelected)
		{
			chip.BackgroundColor = Color.FromArgb("#2C3445");
			label.TextColor = Colors.White;
			label.FontAttributes = FontAttributes.Bold;
			return;
		}

		chip.BackgroundColor = Colors.White;
		label.TextColor = Color.FromArgb("#2C3445");
		label.FontAttributes = FontAttributes.None;
	}

	private async void OnButtonPointerEntered(object? sender, PointerEventArgs e)
	{
		_soundService.PlayHover();
		if (sender is VisualElement btn)
		{
			await btn.ScaleToAsync(1.04, 90);
		}
	}

	private async void OnButtonPointerExited(object? sender, PointerEventArgs e)
	{
		if (sender is VisualElement btn)
		{
			await btn.ScaleToAsync(1.0, 90);
		}
	}
}
