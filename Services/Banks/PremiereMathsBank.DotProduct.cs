using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateDotProductQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateAnalyticalDotProductQuestion(),
			1 => GenerateOrthogonalityCriterionQuestion(),
			2 => GenerateGeometricDotProductQuestion(),
			_ => GenerateAlKashiQuestion()
		};
	}

	private ExerciseQuestion GenerateAnalyticalDotProductQuestion()
	{
		var ux = _random.Next(-4, 5);
		var uy = _random.Next(-4, 5);
		var vx = _random.Next(-4, 5);
		var vy = _random.Next(-4, 5);
		var dot = (ux * vx) + (uy * vy);

		var correct = dot.ToString();
		var wrong1 = ((ux * vy) - (uy * vx)).ToString();
		var wrong2 = (dot + 2).ToString();
		var wrong3 = ((ux + vx) * (uy + vy)).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-DOT1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-08",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Dans un repère orthonormé, calculez le produit scalaire u · v avec u({ux} ; {uy}) et v({vx} ; {vy}).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Expression analytique du produit scalaire : u · v = xx' + yy'.",
			HintLevel2 = $"Calculez ({ux} * {vx}) + ({uy} * {vy}).",
			ExplanationText = $"u · v = {ux} * {vx} + {uy} * {vy} = {dot}."
		};
	}

	private ExerciseQuestion GenerateOrthogonalityCriterionQuestion()
	{
		var ux = _random.Next(1, 5);
		var uy = _random.Next(1, 5);
		var vx = uy;
		var vy = -ux;

		var correct = "Orthogonaux car u · v = 0";
		var wrong1 = "Colinéaires car det(u, v) = 0";
		var wrong2 = "De même sens et de même norme";
		var wrong3 = "Opposés";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-ORT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-08",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Soit u({ux} ; {uy}) et v({vx} ; {vy}). Quelle est la position géométrique relative de ces deux vecteurs non nuls ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calculez le produit scalaire u · v = xx' + yy'.",
			HintLevel2 = $"{ux} * {vx} + {uy} * ({vy}) = {ux * vx} - {uy * ux} = 0.",
			ExplanationText = $"Le produit scalaire est nul, donc les vecteurs sont orthogonaux."
		};
	}

	private ExerciseQuestion GenerateGeometricDotProductQuestion()
	{
		var normU = _random.Next(3, 7);
		var normV = 4;
		var dot = normU * normV / 2;

		var correct = dot.ToString();
		var wrong1 = (normU * normV).ToString();
		var wrong2 = (normU + normV).ToString();
		var wrong3 = (dot * 2).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-DOTG-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-08",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Calculez le produit scalaire u · v sachant que ||u|| = {normU}, ||v|| = {normV} et que l'angle entre eux mesure π / 3 rad (cos(π/3) = 1/2).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule géométrique du produit scalaire : u · v = ||u|| * ||v|| * cos(θ).",
			HintLevel2 = $"Calculez {normU} * {normV} * 0,5.",
			ExplanationText = $"u · v = {normU} * {normV} * (1/2) = {dot}."
		};
	}

	private ExerciseQuestion GenerateAlKashiQuestion()
	{
		var correct = "BC² = AB² + AC² - 2 * AB * AC * cos(Â)";
		var wrong1 = "BC² = AB² + AC² + 2 * AB * AC * cos(Â)";
		var wrong2 = "BC² = AB² + AC²";
		var wrong3 = "BC = AB + AC - cos(Â)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-KSH-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-08",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Dans un triangle ABC quelconque, quelle est la formule du théorème d'Al-Kashi pour le côté opposé BC ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le théorème d'Al-Kashi généralise le théorème de Pythagore à tous les triangles.",
			HintLevel2 = "Le terme correctif retranche le double produit par le cosinus de l'angle opposé.",
			ExplanationText = "Formule d'Al-Kashi : BC² = AB² + AC² - 2*AB*AC*cos(Â)."
		};
	}
}
