using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateConvexityQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateConvexitySecondDerivativeQuestion(),
			1 => GenerateInflectionPointConditionQuestion(),
			_ => GenerateCompositeDerivativeFormulaQuestion()
		};
	}

	private ExerciseQuestion GenerateConvexitySecondDerivativeQuestion()
	{
		var correct = "f est convexe sur I";
		var wrong1 = "f est concave sur I";
		var wrong2 = "f est strictement décroissante sur I";
		var wrong3 = "f admet obligatoirement un maximum local";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-CVX1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-05",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Soit f deux fois dérivable sur un intervalle I. Si pour tout x de I, f''(x) ≥ 0, que peut-on affirmer sur f ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le signe de la dérivée seconde f'' détermine la convexité de la fonction.",
			HintLevel2 = "Une dérivée seconde positive signifie que f' est croissante et que f est convexe.",
			ExplanationText = "f''(x) ≥ 0 sur I implique que la fonction f est convexe sur I."
		};
	}

	private ExerciseQuestion GenerateInflectionPointConditionQuestion()
	{
		var correct = "f''(x) s'annule en changeant de signe";
		var wrong1 = "f'(x) = 0 sans changement de signe";
		var wrong2 = "f(x) = 0 et f'(x) = 0";
		var wrong3 = "f''(x) reste strictement positive";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-INFL-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-05",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "À quelle condition sur la dérivée seconde f'' la courbe de f admet-elle un point d'inflexion ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un point d'inflexion est le point où la courbe traverse sa tangente, changeant de concavité.",
			HintLevel2 = "La dérivée seconde doit obligatoirement s'annuler ET changer de signe.",
			ExplanationText = "Un point d'inflexion apparaît quand f'' s'annule en changeant de signe."
		};
	}

	private ExerciseQuestion GenerateCompositeDerivativeFormulaQuestion()
	{
		var correct = "(v o u)' = u' * (v' o u)";
		var wrong1 = "(v o u)' = v' * u'";
		var wrong2 = "(v o u)' = v'(u') * u";
		var wrong3 = "(v o u)' = (v' o u') / u";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-COMPD-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-05",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelle est la formule générale de dérivation d'une fonction composée v o u ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La règle de la chaîne (chain rule) multiplie la dérivée de la fonction intérieure par celle de l'extérieure.",
			HintLevel2 = "(v(u(x)))' = u'(x) * v'(u(x)).",
			ExplanationText = "La dérivée d'une composée est donnée par (v o u)' = u' * (v' o u)."
		};
	}
}

