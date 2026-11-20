using AsPISApe.Models;
using Microsoft.Maui.Controls.Shapes;

namespace AsPISApe.Views;

public partial class SessionPlayPage
{
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

		var badge = CreateChoiceBadge(letter);
		Grid.SetColumn(badge, 0);
		grid.Children.Add(badge);

		var label = CreateChoiceLabel(text);
		Grid.SetColumn(label, 1);
		grid.Children.Add(label);

		border.Content = grid;

		var tap = new TapGestureRecognizer();
		tap.Tapped += (s, e) => OnChoiceTapped(index, border);
		border.GestureRecognizers.Add(tap);

		return border;
	}

	private static Border CreateChoiceBadge(string letter)
	{
		return new Border
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
	}

	private static Label CreateChoiceLabel(string text)
	{
		return new Label
		{
			Text = text,
			FontSize = 13,
			FontAttributes = FontAttributes.Bold,
			TextColor = Color.FromArgb("#2C3445"),
			VerticalOptions = LayoutOptions.Center,
			LineBreakMode = LineBreakMode.TailTruncation
		};
	}

	private void HighlightCorrectAnswer(int correctIndex)
	{
		if (correctIndex < ChoicesLayout.Children.Count &&
			ChoicesLayout.Children[correctIndex] is Border correctBorder)
		{
			correctBorder.BackgroundColor = Color.FromArgb("#82D8A7");
		}
	}
}
