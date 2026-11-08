using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateVectorsQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateVectorCoordinatesQuestion(),
			1 => GenerateChaslesRelationQuestion(),
			2 => GenerateVectorCollinearityQuestion(),
			_ => GenerateVectorLinearCombinationQuestion()
		};
	}

	private ExerciseQuestion GenerateVectorCoordinatesQuestion()
	{
		var xA = _random.Next(-5, 5);
		var yA = _random.Next(-5, 5);
		var xB = _random.Next(-5, 5);
		var yB = _random.Next(-5, 5);

		var vx = xB - xA;
		var vy = yB - yA;

		var correct = $"({vx} ; {vy})";
		var wrong1 = $"({xA + xB} ; {yA + yB})";
		var wrong2 = $"({xA - xB} ; {yA - yB})";
		var wrong3 = $"({vy} ; {vx})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-VEC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-06",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quelles sont les coordonnées du vecteur AB avec A({xA} ; {yA}) et B({xB} ; {yB}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule des coordonnées d'un vecteur : AB(xB - xA ; yB - yA).",
			HintLevel2 = $"Calculez {xB} - ({xA}) et {yB} - ({yA}).",
			ExplanationText = $"AB a pour coordonnées ({xB} - {xA} ; {yB} - {yA}) = {correct}."
		};
	}

	private ExerciseQuestion GenerateChaslesRelationQuestion()
	{
		var pts = new[] { ("A", "B", "C", "AC"), ("M", "N", "P", "MP"), ("R", "S", "T", "RT"), ("E", "F", "G", "EG") };
		var p = pts[_random.Next(pts.Length)];

		var correct = $"{p.Item4}";
		var wrong1 = $"{p.Item1}{p.Item2}";
		var wrong2 = $"{p.Item2}{p.Item3}";
		var wrong3 = "0 (vecteur nul)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-CHS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-06",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Simplifiez la somme vectorielle selon la relation de Chasles : {p.Item1}{p.Item2} + {p.Item2}{p.Item3}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Relation de Chasles : pour tous points A, B, C, on a AB + BC = AC.",
			HintLevel2 = $"L'extrémité du premier vecteur coïncide avec l'origine du second.",
			ExplanationText = $"Par la relation de Chasles : {p.Item1}{p.Item2} + {p.Item2}{p.Item3} = {p.Item4}."
		};
	}

	private ExerciseQuestion GenerateVectorCollinearityQuestion()
	{
		var ux = _random.Next(1, 4);
		var uy = _random.Next(2, 5);
		var k = _random.Next(2, 5);
		var vx = ux * k;
		var vy = uy * k;

		var correct = "Colinéaires car det(u, v) = 0";
		var wrong1 = "Non colinéaires car det(u, v) ≠ 0";
		var wrong2 = "Orthogonaux";
		var wrong3 = "Opposés de même norme";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-COL-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-06",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Les vecteurs u({ux} ; {uy}) et v({vx} ; {vy}) sont-ils colinéaires ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux vecteurs u(x; y) et v(x'; y') sont colinéaires ssi xy' - yx' = 0.",
			HintLevel2 = $"{ux} * {vy} - {uy} * {vx} = {ux * vy} - {uy * vx} = 0.",
			ExplanationText = $"Le déterminant vaut 0, donc les vecteurs sont colinéaires."
		};
	}

	private ExerciseQuestion GenerateVectorLinearCombinationQuestion()
	{
		var u1 = _random.Next(1, 4);
		var u2 = _random.Next(-3, 3);
		var v1 = _random.Next(-3, 3);
		var v2 = _random.Next(1, 4);
		var k = 2;

		var rx = (k * u1) + v1;
		var ry = (k * u2) + v2;

		var correct = $"({rx} ; {ry})";
		var wrong1 = $"({(k * u1)} ; {(k * u2)})";
		var wrong2 = $"({u1 + v1} ; {u2 + v2})";
		var wrong3 = $"({rx + 1} ; {ry - 1})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-CMB-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-06",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Soit u({u1} ; {u2}) et v({v1} ; {v2}). Calculez les coordonnées de w = 2u + v.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multipliez les coordonnées de u par 2 puis ajoutez celles de v.",
			HintLevel2 = $"w = (2 * {u1} + {v1} ; 2 * {u2} + {v2}).",
			ExplanationText = $"2u + v = (2*{u1}+{v1} ; 2*{u2}+{v2}) = {correct}."
		};
	}
}
