using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateLinesAndSystemsQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateLineDirectorVectorQuestion(),
			1 => GenerateReducedLineEquationQuestion(),
			2 => GenerateParallelLinesConditionQuestion(),
			_ => GenerateLinearSystemQuestion()
		};
	}

	private ExerciseQuestion GenerateLineDirectorVectorQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(2, 6);
		var c = _random.Next(-9, 9);

		var correct = $"u({-b} ; {a})";
		var wrong1 = $"u({a} ; {b})";
		var wrong2 = $"u({b} ; {-a})";
		var wrong3 = $"u({-a} ; {-b})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-DIR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-07",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Donnez un vecteur directeur de la droite (d) d'équation : {a}x + {b}y + {c} = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour une droite d'équation ax + by + c = 0, un vecteur directeur est u(-b ; a).",
			HintLevel2 = $"Ici a = {a} et b = {b}, donc -b = {-b} et a = {a}.",
			ExplanationText = $"Un vecteur directeur canonique est u(-b ; a) = u({-b} ; {a})."
		};
	}

	private ExerciseQuestion GenerateReducedLineEquationQuestion()
	{
		var m = _random.Next(2, 5);
		var p = _random.Next(1, 6);
		var xA = 1;
		var yA = m + p;

		var correct = $"y = {m}x + {p}";
		var wrong1 = $"y = {p}x + {m}";
		var wrong2 = $"y = -{m}x + {p}";
		var wrong3 = $"y = {m}x - {p}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-RED-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-07",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quelle est l'équation réduite de la droite de coefficient directeur {m} passant par le point A(0 ; {p}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'équation réduite est de la forme y = mx + p où p est l'ordonnée à l'origine.",
			HintLevel2 = $"Le coefficient directeur est m = {m} et l'ordonnée à l'origine en x=0 est p = {p}.",
			ExplanationText = $"L'équation réduite est y = {m}x + {p}."
		};
	}

	private ExerciseQuestion GenerateParallelLinesConditionQuestion()
	{
		var m = _random.Next(2, 6);
		var p1 = _random.Next(1, 5);
		var p2 = p1 + 3;

		var correct = "Parallèles et strictement disjointes";
		var wrong1 = "Sécantes en un point unique";
		var wrong2 = "Confondues";
		var wrong3 = "Perpendiculaires";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-PAR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-07",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quelle est la position relative des droites (d1) : y = {m}x + {p1} et (d2) : y = {m}x + {p2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Comparez les coefficients directeurs et les ordonnées à l'origine.",
			HintLevel2 = $"Elles ont le même coefficient directeur {m} mais des ordonnées à l'origine différentes.",
			ExplanationText = $"Même pente et ordonnées distinctes : les droites sont strictement parallèles."
		};
	}

	private ExerciseQuestion GenerateLinearSystemQuestion()
	{
		var x = _random.Next(1, 5);
		var y = _random.Next(1, 5);

		var c1 = x + y;
		var c2 = (2 * x) - y;

		var correct = $"(x ; y) = ({x} ; {y})";
		var wrong1 = $"(x ; y) = ({y} ; {x})";
		var wrong2 = $"(x ; y) = ({x + 1} ; {y - 1})";
		var wrong3 = $"(x ; y) = ({-x} ; {-y})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-SYS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-07",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Résolvez le système linéaire de deux équations à deux inconnues :\n{{ x + y = {c1}\n{{ 2x - y = {c2}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionnez les deux lignes pour éliminer y par combinaison linéaire.",
			HintLevel2 = $"(x + y) + (2x - y) = 3x = {c1 + c2}, ce qui donne x = {x}.",
			ExplanationText = $"L'addition donne 3x = {c1 + c2} donc x = {x}, puis y = {y}."
		};
	}
}
