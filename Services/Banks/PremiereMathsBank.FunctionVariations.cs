using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateFunctionVariationsQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateDerivativeSignMonotonicityQuestion(),
			1 => GenerateHorizontalTangentConditionQuestion(),
			_ => GenerateCubicLocalExtremumQuestion()
		};
	}

	private ExerciseQuestion GenerateDerivativeSignMonotonicityQuestion()
	{
		var correct = "f est strictement croissante sur I";
		var wrong1 = "f est strictement décroissante sur I";
		var wrong2 = "f est constante sur I";
		var wrong3 = "f s'annule obligatoirement sur I";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-VARL-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-05",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Soit f une fonction dérivable sur un intervalle I. Si pour tout x de I, f'(x) > 0, que peut-on affirmer ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le théorème fondamental relie le signe de la dérivée aux variations de la fonction.",
			HintLevel2 = "Une dérivée strictement positive indique un taux d'accroissement positif.",
			ExplanationText = "Si f'(x) > 0 sur I, alors f est strictement croissante sur I."
		};
	}

	private ExerciseQuestion GenerateHorizontalTangentConditionQuestion()
	{
		var x0 = _random.Next(-3, 4);
		var correct = $"f'({x0}) = 0";
		var wrong1 = $"f({x0}) = 0";
		var wrong2 = $"f'({x0}) = 1";
		var wrong3 = $"f'({x0}) = -1";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-HOR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-05",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"À quelle condition la courbe d'une fonction f admet-elle une tangente horizontale au point d'abscisse x = {x0} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La pente de la tangente en x0 est donnée par le nombre dérivé f'(x0).",
			HintLevel2 = "Une droite horizontale a une pente (coefficient directeur) égale à 0.",
			ExplanationText = $"Une tangente est horizontale si et seulement si sa pente f'({x0}) = 0."
		};
	}

	private ExerciseQuestion GenerateCubicLocalExtremumQuestion()
	{
		var a = _random.Next(1, 4);
		var correct = $"En x = -{a} et x = {a}";
		var wrong1 = $"En x = 0 uniquement";
		var wrong2 = $"En x = {a * a}";
		var wrong3 = "La fonction n'admet aucun extremum local";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-EXTR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-05",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Pour f(x) = x³ - {3 * a * a}x, en quelles abscisses la dérivée s'annule-t-elle avec changement de signe ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calculez la dérivée f'(x) = 3x² - 3a² puis factorisez.",
			HintLevel2 = $"3(x² - {a * a}) = 0 donne x² = {a * a}, d'où deux racines opposées.",
			ExplanationText = $"f'(x) = 3(x - {a})(x + {a}) s'annule et change de signe en -{a} et {a}."
		};
	}
}
