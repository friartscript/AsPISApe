using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateFunctionImageQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(1, 8);
		var x = _random.Next(2, 6);
		var image = (a * x) + b;
		var correct = image.ToString();
		var wrong1 = (image - a).ToString();
		var wrong2 = (image + b).ToString();
		var wrong3 = (a + x + b).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-FNCIMG-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-051",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Soit la fonction affine f définie par f(x) = {a}x + {b}. Quelle est l'image de {x} par f ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour calculer l'image d'un nombre par une fonction, remplace la variable x par ce nombre dans la formule.",
			HintLevel2 = $"Calcule {a} × {x} + {b}.",
			ExplanationText = $"f({x}) = {a}×{x} + {b} = {a * x} + {b} = {image}."
		};
	}

	public ExerciseQuestion GenerateFunctionAntecedentQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(1, 8);
		var ant = _random.Next(2, 7);
		var image = (a * ant) + b;
		var correct = $"x = {ant}";
		var wrong1 = $"x = {ant + 2}";
		var wrong2 = $"x = {image}";
		var wrong3 = $"x = {ant - 1}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-FNCANT-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-051",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Soit f(x) = {a}x + {b}. Quel est l'antécédent de {image} par f ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Chercher l'antécédent revient à résoudre l'équation f(x) = image, c'est-à-dire ax + b = image.",
			HintLevel2 = $"{a}x + {b} = {image} donne {a}x = {image - b}. Divise par {a}.",
			ExplanationText = $"{a}x = {image} - {b} = {image - b}, donc x = {image - b} / {a} = {ant}."
		};
	}

	public ExerciseQuestion GenerateLinearVsAffineQuestion()
	{
		var a = _random.Next(2, 7);
		var b = _random.Next(2, 9);
		var cases = new[]
		{
			($"f(x) = {a}x", "Linéaire (et affine particulière)", "Affine non linéaire", "Constante", "Ni linéaire ni affine", "passe par l'origine O(0; 0)"),
			($"g(x) = {a}x + {b}", "Affine non linéaire", "Linéaire", "Quadratique", "Inverse", "a une ordonnée à l'origine non nulle b"),
			($"h(x) = {b}", "Constante (affine avec a = 0)", "Linéaire de pente non nulle", "Puissance", "Trigonométrique", "droite horizontale")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TYPFNC-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-053",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Quelle est la nature de la fonction : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fonction linéaire s'écrit f(x) = ax (droite passant par l'origine). Une fonction affine s'écrit ax + b.",
			HintLevel2 = item.Item6,
			ExplanationText = $"{item.Item1} est une fonction {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateSlopeFromPointsQuestion()
	{
		var a = _random.Next(2, 5);
		var x1 = _random.Next(1, 3);
		var x2 = x1 + _random.Next(2, 4);
		var b = _random.Next(1, 5);
		var y1 = (a * x1) + b;
		var y2 = (a * x2) + b;

		var correct = a.ToString();
		var wrong1 = (a + 1).ToString();
		var wrong2 = ((y2 - y1) * 2).ToString();
		var wrong3 = b.ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-SLOPE-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-055",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"La droite représentative d'une fonction affine passe par les points A({x1} ; {y1}) et B({x2} ; {y2}). Quel est son coefficient directeur ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La formule du coefficient directeur est a = (yB - yA) / (xB - xA).",
			HintLevel2 = $"a = ({y2} - {y1}) / ({x2} - {x1}) = {y2 - y1} / {x2 - x1}.",
			ExplanationText = $"a = ({y2} - {y1}) / ({x2} - {x1}) = {y2 - y1} / {x2 - x1} = {a}."
		};
	}
}

