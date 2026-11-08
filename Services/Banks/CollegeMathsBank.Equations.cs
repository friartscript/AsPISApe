using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateFirstDegreeEquation()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateSimpleLinearEquation(),
			1 => GenerateTwoStepsLinearEquation(),
			_ => GenerateBalanceLinearEquation()
		};
	}

	public ExerciseQuestion GenerateProductEquation()
	{
		var variant = _random.Next(2);
		return variant switch
		{
			0 => GenerateSimpleProductEquation(),
			_ => GenerateAffineProductEquation()
		};
	}

	private ExerciseQuestion GenerateSimpleLinearEquation()
	{
		var a = _random.Next(2, 8);
		var x = _random.Next(2, 9);
		var b = a * x;
		var correct = $"x = {x}";
		var wrong1 = $"x = {x + 1}";
		var wrong2 = $"x = {b - a}";
		var wrong3 = $"x = {b + a}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-EQ1-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-027",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Résous l'équation : {a}x = {b}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour isoler x lorsqu'il est multiplié par un nombre, divise les deux côtés par ce nombre.",
			HintLevel2 = $"Divise {b} par {a}.",
			ExplanationText = $"x = {b} / {a} = {x}."
		};
	}

	private ExerciseQuestion GenerateTwoStepsLinearEquation()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(3, 10);
		var x = _random.Next(2, 7);
		var c = (a * x) + b;
		var correct = $"x = {x}";
		var wrong1 = $"x = {x + 2}";
		var wrong2 = $"x = {(c + b) / a}";
		var wrong3 = $"x = {c - b}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-EQ2-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-027",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Résous l'équation : {a}x + {b} = {c}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Soustrait d'abord le terme constant des deux membres, puis divise par le coefficient de x.",
			HintLevel2 = $"{a}x = {c} - {b} = {c - b}. Divise ensuite par {a}.",
			ExplanationText = $"{a}x = {c - b} donc x = {c - b} / {a} = {x}."
		};
	}

	private ExerciseQuestion GenerateBalanceLinearEquation()
	{
		var a = _random.Next(4, 8);
		var c = _random.Next(2, a);
		var diff = a - c;
		var x = _random.Next(2, 6);
		var d = _random.Next(1, 9);
		var b = d - (diff * x);
		var bSign = b >= 0 ? $"+ {b}" : $"- {Math.Abs(b)}";

		var correct = $"x = {x}";
		var wrong1 = $"x = {x + 1}";
		var wrong2 = $"x = {-x}";
		var wrong3 = $"x = {x + 3}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-EQ3-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-027",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Résous l'équation : {a}x {bSign} = {c}x + {d}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Regroupe tous les termes en x à gauche et les nombres constants à droite.",
			HintLevel2 = $"({a} - {c})x = {diff}x = {d - b}. Divise {d - b} par {diff}.",
			ExplanationText = $"{diff}x = {d - b} donc x = {x}."
		};
	}

	private ExerciseQuestion GenerateSimpleProductEquation()
	{
		var a = _random.Next(2, 8);
		var b = _random.Next(2, 8);
		while (b == a) b = _random.Next(2, 8);

		var correct = $"x = {a} ou x = {-b}";
		var wrong1 = $"x = {-a} ou x = {b}";
		var wrong2 = $"x = {a} ou x = {b}";
		var wrong3 = $"x = {a * b}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PROD1-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-028",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Quelles sont les solutions de l'équation produit nul (x - {a})(x + {b}) = 0 ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un produit de facteurs est nul si et seulement si au moins un des facteurs est nul.",
			HintLevel2 = "Résous séparément x - a = 0 et x + b = 0.",
			ExplanationText = $"x - {a} = 0 donne x = {a}, et x + {b} = 0 donne x = {-b}."
		};
	}

	private ExerciseQuestion GenerateAffineProductEquation()
	{
		var a = _random.Next(2, 4);
		var sol1 = _random.Next(2, 6);
		var c = a * sol1;
		var sol2 = _random.Next(2, 6);

		var correct = $"x = {-sol1} ou x = {sol2}";
		var wrong1 = $"x = {sol1} ou x = {-sol2}";
		var wrong2 = $"x = {-sol1} seulement";
		var wrong3 = $"x = {sol2} seulement";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PROD2-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-028",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Résous l'équation : ({a}x + {c})(x - {sol2}) = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un produit est nul si l'un au moins des facteurs est égal à 0.",
			HintLevel2 = $"{a}x + {c} = 0 donne {a}x = {-c}. Le deuxième facteur donne x = {sol2}.",
			ExplanationText = $"{a}x = {-c} donc x = {-sol1}, et x - {sol2} = 0 donne x = {sol2}."
		};
	}
}

