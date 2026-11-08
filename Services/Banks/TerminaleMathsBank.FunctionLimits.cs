using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateFunctionLimitsQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateRationalFunctionLimitAtInfinityQuestion(),
			1 => GenerateVerticalAsymptoteQuestion(),
			_ => GenerateIndeterminateFormsQuestion()
		};
	}

	private ExerciseQuestion GenerateRationalFunctionLimitAtInfinityQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(2, 6);
		var gcd = Math.Max(1, a == b ? a : 1);
		var num = a / gcd;
		var den = b / gcd;

		var correct = den == 1 ? num.ToString() : $"{num} / {den}";
		var wrong1 = "+∞";
		var wrong2 = "0";
		var wrong3 = "-∞";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-RATL-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-02",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Calculez la limite en +∞ de la fonction rationnelle f(x) = ({a}x² + 5x - 1) / ({b}x² - 3).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "En l'infini, la limite d'une fonction rationnelle est égale au quotient de ses termes de plus haut degré.",
			HintLevel2 = $"Simplifiez ({a}x²) / ({b}x²) = {a} / {b}.",
			ExplanationText = $"La limite est égale au rapport des monômes dominants : {correct}."
		};
	}

	private ExerciseQuestion GenerateVerticalAsymptoteQuestion()
	{
		var a = _random.Next(1, 6);
		var correct = $"La droite verticale d'équation x = {a}";
		var wrong1 = $"La droite horizontale d'équation y = {a}";
		var wrong2 = "La droite oblique y = x";
		var wrong3 = "La courbe ne possède aucune asymptote";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-ASYM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-02",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Sachant que lim (x -> {a}) f(x) = +∞, quelle asymptote la courbe de f admet-elle ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Quand la limite en une valeur finie est infinie, l'asymptote est verticale.",
			HintLevel2 = $"L'équation de l'asymptote verticale est de la forme x = {a}.",
			ExplanationText = $"lim en {a} valant +∞, la droite x = {a} est asymptote verticale."
		};
	}

	private ExerciseQuestion GenerateIndeterminateFormsQuestion()
	{
		var correct = "« +∞ - ∞ », « 0 / 0 », « ∞ / ∞ » et « 0 * ∞ »";
		var wrong1 = "« +∞ + ∞ », « 0 / ∞ » et « ∞ * ∞ »";
		var wrong2 = "« 1 / 0 », « +∞ * +∞ » et « 0 / 1 »";
		var wrong3 = "« 0 + ∞ », « ∞ - 0 » et « 0 * 0 »";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-INDT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-02",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelles sont les 4 formes indéterminées classiques (FI) en calcul de limites ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les formes indéterminées nécessitent une factorisation, quantité conjuguée ou taux d'accroissement.",
			HintLevel2 = "L'addition de deux infinis de même signe n'est jamais indéterminée.",
			ExplanationText = "Les 4 formes indéterminées sont +∞-∞, 0/0, ∞/∞ et 0*∞."
		};
	}
}

