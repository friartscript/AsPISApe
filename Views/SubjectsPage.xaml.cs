using AsPISApe.Models;
using AsPISApe.Services;
using Microsoft.Maui.Controls.Shapes;

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

		SubjectsCardsLayout.Children.Clear();
		foreach (var subject in filtered)
		{
			SubjectsCardsLayout.Children.Add(CreateSubjectCard(subject));
		}

		var count = filtered.Count;
		SubjectCountLabel.Text = count switch
		{
			0 => "Aucun sujet trouvé",
			1 => "1 sujet disponible",
			_ => $"{count} sujets disponibles"
		};

		EmptyStateView.IsVisible = count == 0;
		SubjectsScrollView.IsVisible = count > 0;
	}

	private IView CreateSubjectCard(SubjectItem item)
	{
		var isFrancais = item.Discipline.Equals("Francais", StringComparison.OrdinalIgnoreCase);
		var disciplineName = isFrancais ? "📖 Français" : "📐 Maths";

		var card = new Border
		{
			BackgroundColor = Colors.White,
			Stroke = Color.FromArgb("#2C3445"),
			StrokeThickness = 2,
			StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(16) },
			Padding = new Thickness(14, 12)
		};

		var tapGesture = new TapGestureRecognizer();
		tapGesture.Tapped += async (s, e) =>
		{
			_soundService.PlayClick();
			await card.ScaleToAsync(0.97, 60);
			await card.ScaleToAsync(1.0, 80);
		};
		card.GestureRecognizers.Add(tapGesture);

		var stack = new VerticalStackLayout { Spacing = 6 };

		var topRow = new Grid
		{
			ColumnDefinitions =
			{
				new ColumnDefinition { Width = GridLength.Auto },
				new ColumnDefinition { Width = GridLength.Star },
				new ColumnDefinition { Width = GridLength.Auto }
			},
			ColumnSpacing = 6
		};

		var disciplineLabel = new Label
		{
			Text = disciplineName,
			FontAttributes = FontAttributes.Bold,
			TextColor = Color.FromArgb("#2C3445"),
			FontSize = 11,
			VerticalOptions = LayoutOptions.Center
		};
		Grid.SetColumn(disciplineLabel, 0);
		topRow.Children.Add(disciplineLabel);

		var domainLabel = new Label
		{
			Text = $"• {item.Domain}",
			TextColor = Color.FromArgb("#64748B"),
			FontSize = 11,
			LineBreakMode = LineBreakMode.TailTruncation,
			VerticalOptions = LayoutOptions.Center
		};
		Grid.SetColumn(domainLabel, 1);
		topRow.Children.Add(domainLabel);

		var palierLabel = new Label
		{
			Text = $"PALIER {item.Palier}",
			FontAttributes = FontAttributes.Bold,
			TextColor = Color.FromArgb("#2C3445"),
			FontSize = 11,
			VerticalOptions = LayoutOptions.Center
		};
		Grid.SetColumn(palierLabel, 2);
		topRow.Children.Add(palierLabel);

		stack.Children.Add(topRow);

		stack.Children.Add(new Label
		{
			Text = item.Title,
			FontSize = 15,
			FontAttributes = FontAttributes.Bold,
			FontFamily = "OpenSansSemibold",
			TextColor = Color.FromArgb("#2C3445")
		});

		stack.Children.Add(new Label
		{
			Text = item.Details,
			FontSize = 12,
			TextColor = Color.FromArgb("#475569")
		});

		var bottomRow = new HorizontalStackLayout { Spacing = 6 };

		var classBadge = new Border
		{
			BackgroundColor = Color.FromArgb("#F1F5F9"),
			Stroke = Color.FromArgb("#CBD5E1"),
			StrokeThickness = 1,
			StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(8) },
			Padding = new Thickness(8, 2),
			Content = new Label
			{
				Text = item.ClassLevel,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.FromArgb("#2C3445"),
				FontSize = 11
			}
		};
		bottomRow.Children.Add(classBadge);

		stack.Children.Add(bottomRow);

		card.Content = stack;
		return card;
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
}
