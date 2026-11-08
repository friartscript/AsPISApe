using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateSpaceDotProductQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateSpaceDotProductCalculationQuestion(),
			1 => GeneratePlaneCartesianEquationQuestion(),
			_ => GenerateLinePlaneOrthogonalityQuestion()
		};
	}

	private ExerciseQuestion GenerateSpaceDotProductCalculationQuestion()
	{
		var x1 = _random.Next(-3, 4);
		var y1 = _random.Next(-3, 4);
		var z1 = _random.Next(-3, 4);
		var x2 = _random.Next(-3, 4);
		var y2 = _random.Next(-3, 4);
		var z2 = _random.Next(-3, 4);

		var dot = (x1 * x2) + (y1 * y2) + (z1 * z2);

		var correct = dot.ToString();
		var wrong1 = (dot + 2).ToString();
		var wrong2 = ((x1 * x2) - (y1 * y2) + (z1 * z2)).ToString();
		var wrong3 = ((x1 + x2) * (y1 + y2) * (z1 + z2)).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-SDOT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-10",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Dans un repère orthonormé de l'espace, calculez le produit scalaire u · v avec u({x1} ; {y1} ; {z1}) et v({x2} ; {y2} ; {z2}).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule analytique dans l'espace : u · v = xx' + yy' + zz'.",
			HintLevel2 = $"Calculez ({x1} * {x2}) + ({y1} * {y2}) + ({z1} * {z2}).",
			ExplanationText = $"u · v = {x1}*{x2} + {y1}*{y2} + {z1}*{z2} = {dot}."
		};
	}

	private ExerciseQuestion GeneratePlaneCartesianEquationQuestion()
	{
		var a = _random.Next(1, 4);
		var b = _random.Next(1, 4);
		var c = _random.Next(1, 4);
		var d = _random.Next(-6, 7);

		var correct = $"n({a} ; {b} ; {c})";
		var wrong1 = $"n({-b} ; {a} ; {c})";
		var wrong2 = $"n({a} ; {b} ; {d})";
		var wrong3 = $"n({-a} ; {-b} ; {-c})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-PLNE-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-10",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Donnez un vecteur normal au plan (P) d'équation cartésienne : {a}x + {b}y + {c}z + {d} = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour un plan d'équation ax + by + cz + d = 0, un vecteur normal est directement n(a ; b ; c).",
			HintLevel2 = "Prenez les coefficients respectifs devant x, y et z.",
			ExplanationText = $"Un vecteur normal canonique est n(a ; b ; c) = n({a} ; {b} ; {c})."
		};
	}

	private ExerciseQuestion GenerateLinePlaneOrthogonalityQuestion()
	{
		var correct = "Le vecteur directeur de (d) est colinéaire au vecteur normal de (P)";
		var wrong1 = "Le vecteur directeur de (d) est orthogonal au vecteur normal de (P)";
		var wrong2 = "La droite (d) est entièrement contenue dans le plan (P)";
		var wrong3 = "La droite et le plan ont une infinité de points communs";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-ORTLP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-10",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "À quelle condition géométrique une droite (d) est-elle orthogonale à un plan (P) de l'espace ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un plan est dirigé par son vecteur normal orthogonal au plan.",
			HintLevel2 = "La droite orthogonale au plan doit suivre la même direction que la normale au plan.",
			ExplanationText = "(d) ⊥ (P) ssi le vecteur directeur de (d) est colinéaire à la normale de (P)."
		};
	}
}

