using AsPISApe.Models;
using AsPISApe.Services;

namespace AsPISApe.Views;

public partial class SubjectsPage : ContentPage
{
	private readonly INavigationService _navigationService;
	private readonly ISoundService _soundService;
	private readonly ISubjectService _subjectService;

	private string _currentDiscipline = "Tous";
	private string _currentLevel = "Tous";
	private string _currentClassLevel = "Tous";
	private string _currentSearchQuery = string.Empty;

	public SubjectsPage(INavigationService navigationService, ISoundService soundService, ISubjectService subjectService)
	{
		InitializeComponent();
		_navigationService = navigationService;
		_soundService = soundService;
		_subjectService = subjectService;
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);
		ApplyFilters();
	}

	private void ApplyFilters()
	{
		var filtered = _subjectService.FilterSubjects(
			_currentDiscipline,
			_currentLevel,
			_currentClassLevel,
			_currentSearchQuery
		);

		SubjectsCollectionView.ItemsSource = filtered;

		var total = filtered.Count;
		SubjectCountLabel.Text = total switch
		{
			0 => "Aucun sujet trouvé",
			1 => "1 sujet disponible",
			_ => $"{total} sujets disponibles"
		};

		EmptyStateView.IsVisible = total == 0;
		SubjectsCollectionView.IsVisible = total > 0;
	}

	private async void OnBackTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		if (sender is VisualElement btn)
		{
			await btn.ScaleToAsync(0.92, 70);
			await btn.ScaleToAsync(1.0, 90);
		}
		await _navigationService.NavigateBackAsync();
	}

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
		UpdateClassChipsUi();
		ApplyFilters();
	}

	private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
	{
		_currentSearchQuery = e.NewTextValue ?? string.Empty;
		ApplyFilters();
	}

	// -------------------------------------------------------------------------
	// Filtres Discipline (Matière)
	// -------------------------------------------------------------------------
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

	// -------------------------------------------------------------------------
	// Filtres Cycle (Collège / Lycée)
	// -------------------------------------------------------------------------
	private void OnFilterLevelAllTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentLevel = "Tous";
		UpdateLevelTabUi();
		ApplyFilters();
	}

	private void OnFilterLevelCollegeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentLevel = "College";
		UpdateLevelTabUi();
		ApplyFilters();
	}

	private void OnFilterLevelLyceeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlaySelect();
		_currentLevel = "Lycee";
		UpdateLevelTabUi();
		ApplyFilters();
	}

	private void UpdateLevelTabUi()
	{
		SetTabStyle(BtnLevelAll, LblLevelAll, _currentLevel == "Tous", Color.FromArgb("#2C3445"));
		SetTabStyle(BtnLevelCollege, LblLevelCollege, _currentLevel == "College", Color.FromArgb("#82D8A7"));
		SetTabStyle(BtnLevelLycee, LblLevelLycee, _currentLevel == "Lycee", Color.FromArgb("#6CB4EE"));
	}

	// -------------------------------------------------------------------------
	// Filtres Sous-classes / Années (6e, 5e, 4e, 3e, 2de, 1re, Tle)
	// -------------------------------------------------------------------------
	private void OnClassChipTapped(object? sender, TappedEventArgs e)
	{
		if (e.Parameter is string targetClass)
		{
			_soundService.PlaySelect();
			_currentClassLevel = targetClass;
			UpdateClassChipsUi();
			ApplyFilters();
		}
	}

	private void UpdateClassChipsUi()
	{
		SetChipStyle(ChipClassAll, _currentClassLevel == "Tous");
		SetChipStyle(ChipClass6e, _currentClassLevel == "6e");
		SetChipStyle(ChipClass5e, _currentClassLevel == "5e");
		SetChipStyle(ChipClass4e, _currentClassLevel == "4e");
		SetChipStyle(ChipClass3e, _currentClassLevel == "3e");
		SetChipStyle(ChipClass2de, _currentClassLevel == "2de");
		SetChipStyle(ChipClass1re, _currentClassLevel == "1re Spé");
		SetChipStyle(ChipClassTleSpe, _currentClassLevel == "Tle Spé");
		SetChipStyle(ChipClassTleExp, _currentClassLevel == "Tle Expertes");
	}

	private static void SetTabStyle(Border border, Label label, bool isSelected, Color activeColor)
	{
		if (isSelected)
		{
			border.BackgroundColor = activeColor;
			border.StrokeThickness = 2;
			label.TextColor = activeColor.GetLuminosity() > 0.65 ? Color.FromArgb("#2C3445") : Colors.White;
			label.FontAttributes = FontAttributes.Bold;
		}
		else
		{
			border.BackgroundColor = Colors.White;
			border.StrokeThickness = 1.5;
			label.TextColor = Color.FromArgb("#2C3445");
			label.FontAttributes = FontAttributes.None;
		}
	}

	private static void SetChipStyle(Border chip, bool isSelected)
	{
		if (isSelected)
		{
			chip.BackgroundColor = Color.FromArgb("#2C3445");
			if (chip.Content is Label lbl)
			{
				lbl.TextColor = Colors.White;
				lbl.FontAttributes = FontAttributes.Bold;
			}
		}
		else
		{
			chip.BackgroundColor = Colors.White;
			if (chip.Content is Label lbl)
			{
				lbl.TextColor = Color.FromArgb("#2C3445");
				lbl.FontAttributes = FontAttributes.None;
			}
		}
	}

	private async void OnSubjectCardTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		if (sender is VisualElement card)
		{
			await card.ScaleToAsync(0.97, 60);
			await card.ScaleToAsync(1.0, 80);
		}
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
