using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateCoordinateGeometryQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateNormalVectorQuestion(),
			1 => GenerateCircleEquationFromCenterRadiusQuestion(),
			_ => GenerateCircleCenterRadiusIdentificationQuestion()
		};
	}

	private ExerciseQuestion GenerateNormalVectorQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(2, 6);
		var c = _random.Next(-9, 9);

		var correct = $"n({a} ; {b})";
		var wrong1 = $"n({-b} ; {a})";
		var wrong2 = $"n({b} ; {a})";
		var wrong3 = $"n({-a} ; {-b})";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-NRM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-09",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Donnez un vecteur normal à la droite (d) d'équation cartésienne : {a}x + {b}y + {c} = 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour une droite d'équation ax + by + c = 0, un vecteur normal est directement n(a ; b).",
			HintLevel2 = $"Les coefficients devant x et y sont respectivement a = {a} et b = {b}.",
			ExplanationText = $"Un vecteur normal canonique est n(a ; b) = n({a} ; {b})."
		};
	}

	private ExerciseQuestion GenerateCircleEquationFromCenterRadiusQuestion()
	{
		var x0 = _random.Next(1, 5);
		var y0 = _random.Next(1, 5);
		var r = _random.Next(2, 6);
		var rSq = r * r;

		var correct = $"(x - {x0})² + (y - {y0})² = {rSq}";
		var wrong1 = $"(x + {x0})² + (y + {y0})² = {rSq}";
		var wrong2 = $"(x - {x0})² + (y - {y0})² = {r}";
		var wrong3 = $"(x - {x0}) + (y - {y0}) = {rSq}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-CIR1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-09",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Quelle est l'équation cartésienne du cercle C de centre Ω({x0} ; {y0}) et de rayon R = {r} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Équation cartésienne du cercle : (x - x0)² + (y - y0)² = R².",
			HintLevel2 = $"Remplacez x0 par {x0}, y0 par {y0} et calculez R² = {r}² = {rSq}.",
			ExplanationText = $"L'équation du cercle est (x - {x0})² + (y - {y0})² = {rSq}."
		};
	}

	private ExerciseQuestion GenerateCircleCenterRadiusIdentificationQuestion()
	{
		var x0 = _random.Next(2, 6);
		var y0 = _random.Next(2, 6);
		var r = _random.Next(2, 5);
		var rSq = r * r;

		var correct = $"Centre Ω({x0} ; {-y0}) et rayon R = {r}";
		var wrong1 = $"Centre Ω({-x0} ; {y0}) et rayon R = {r}";
		var wrong2 = $"Centre Ω({x0} ; {-y0}) et rayon R = {rSq}";
		var wrong3 = $"Centre Ω({-x0} ; {-y0}) et rayon R = {r}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-CIR2-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-09",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Déterminez le centre et le rayon du cercle d'équation : (x - {x0})² + (y + {y0})² = {rSq}.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Comparez avec la forme (x - a)² + (y - b)² = R².",
			HintLevel2 = $"a = {x0}, b = -{y0} et le rayon est R = √{rSq} = {r}.",
			ExplanationText = $"Le centre est Ω({x0} ; -{y0}) et le rayon R = √{rSq} = {r}."
		};
	}
}
