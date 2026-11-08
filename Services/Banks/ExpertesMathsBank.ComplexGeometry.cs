using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	public ExerciseQuestion GenerateComplexGeometryQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateComplexModulusQuestion(),
			1 => GenerateExponentialFormQuestion(),
			_ => GenerateDeMoivreFormulaQuestion()
		};
	}

	private ExerciseQuestion GenerateComplexModulusQuestion()
	{
		var pairs = new (int a, int b, int mod)[]
		{
			(3, 4, 5),
			(6, 8, 10),
			(5, 12, 13),
			(8, 15, 17)
		};
		var pick = pairs[_random.Next(pairs.Length)];

		var correct = pick.mod.ToString();
		var wrong1 = (pick.a + pick.b).ToString();
		var wrong2 = (pick.mod * pick.mod).ToString();
		var wrong3 = (pick.mod + 1).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-MOD-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-02",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Calculez le module |z| du nombre complexe z = {pick.a} + {pick.b}i.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule du module : |a + ib| = √(a² + b²).",
			HintLevel2 = $"√({pick.a}² + {pick.b}²) = √({pick.a * pick.a} + {pick.b * pick.b}).",
			ExplanationText = $"|z| = √({pick.a * pick.a} + {pick.b * pick.b}) = {pick.mod}."
		};
	}

	private ExerciseQuestion GenerateExponentialFormQuestion()
	{
		var correct = "z = e^(iπ/2)";
		var wrong1 = "z = e^(iπ)";
		var wrong2 = "z = e^(i*0)";
		var wrong3 = "z = e^(iπ/4)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-EXPF-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-02",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Quelle est la forme exponentielle r * e^(iθ) de l'unité imaginaire z = i ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le module de i est 1 et son argument sur le cercle trigonométrique est π/2.",
			HintLevel2 = "r = 1 et θ = π/2 donc z = 1 * e^(iπ/2).",
			ExplanationText = "i a pour module 1 et pour argument π/2, soit e^(iπ/2)."
		};
	}

	private ExerciseQuestion GenerateDeMoivreFormulaQuestion()
	{
		var n = _random.Next(2, 6);
		var correct = $"cos({n}θ) + i sin({n}θ)";
		var wrong1 = $"cos^n(θ) + i sin^n(θ)";
		var wrong2 = $"{n} cos(θ) + {n}i sin(θ)";
		var wrong3 = $"cos(θ^{n}) + i sin(θ^{n})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-MOIV-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-02",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"D'après la formule de Moivre, que vaut l'expression (cos θ + i sin θ)^{n} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La formule de Moivre traduit que (e^(iθ))^n = e^(inθ).",
			HintLevel2 = "L'exposant n devient le coefficient multiplicateur de l'angle à l'intérieur du cosinus et du sinus.",
			ExplanationText = $"Formule de Moivre : (cos θ + i sin θ)^{n} = {correct}."
		};
	}
}

