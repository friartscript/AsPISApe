using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateProportionsAndPercentagesQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateSubpopulationProportionQuestion(),
			1 => GenerateMultiplierCoefficientQuestion(),
			2 => GenerateSuccessiveEvolutionsQuestion(),
			_ => GenerateReciprocalEvolutionQuestion()
		};
	}

	private ExerciseQuestion GenerateSubpopulationProportionQuestion()
	{
		var p1 = 60;
		var p2 = 40;
		var res = (p1 * p2) / 100;

		var correct = $"{res} %";
		var wrong1 = $"{p1 + p2} %";
		var wrong2 = $"{p1 - p2} %";
		var wrong3 = "50 %";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-PRP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-11",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Dans un lycée, {p1} % des élèves sont demi-pensionnaires, et parmi eux, {p2} % sont en classe de Seconde. Quelle est la proportion globale de Secondes demi-pensionnaires dans le lycée ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de la proportion de proportion : p = p1 * p2.",
			HintLevel2 = $"Calculez 0,{p1} * 0,{p2} = {res / 100.0:0.00}.",
			ExplanationText = $"p = {p1}% * {p2}% = {res}%."
		};
	}

	private ExerciseQuestion GenerateMultiplierCoefficientQuestion()
	{
		var t = _random.Next(5, 30);
		var cm = 1.0 + (t / 100.0);

		var correct = $"{cm:0.00}";
		var wrong1 = $"{1 + t}";
		var wrong2 = $"{t / 100.0:0.00}";
		var wrong3 = $"{1.0 - (t / 100.0):0.00}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-CM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-11",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quel est le coefficient multiplicateur associé à une hausse de prix de {t} % ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour une hausse de t %, le coefficient multiplicateur est CM = 1 + t / 100.",
			HintLevel2 = $"CM = 1 + {t}/100 = 1 + {t / 100.0:0.00}.",
			ExplanationText = $"CM = 1 + {t}/100 = {cm:0.00}."
		};
	}

	private ExerciseQuestion GenerateSuccessiveEvolutionsQuestion()
	{
		var rates = new (int t1, int t2, double globalPct, string w1, string w2, string w3)[]
		{
			(10, 20, 32.0, "30 %", "200 %", "28 %"),
			(20, -10, 8.0, "10 %", "12 %", "-2 %"),
			(50, -50, -25.0, "0 %", "-100 %", "25 %"),
			(20, 20, 44.0, "40 %", "400 %", "36 %")
		};
		var pick = rates[_random.Next(rates.Length)];
		var correct = pick.globalPct >= 0 ? $"+{pick.globalPct} %" : $"{pick.globalPct} %";

		var choices = Shuffle(correct, pick.w1, pick.w2, pick.w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-SUC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-11",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Un article subit une évolution de {(pick.t1 >= 0 ? "+" + pick.t1 : pick.t1.ToString())} % suivie d'une évolution de {(pick.t2 >= 0 ? "+" + pick.t2 : pick.t2.ToString())} %. Quelle est l'évolution globale ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "On ne doit jamais additionner les pourcentages ! On multiplie les coefficients multiplicateurs.",
			HintLevel2 = "CM_global = CM1 * CM2, puis Taux = (CM_global - 1) * 100.",
			ExplanationText = $"Les évolutions successives se multiplient : CM_global donne {correct}."
		};
	}

	private ExerciseQuestion GenerateReciprocalEvolutionQuestion()
	{
		var pairs = new (int up, int down, string w1, string w2, string w3)[]
		{
			(25, -20, "-25 %", "-15 %", "+20 %"),
			(100, -50, "-100 %", "-25 %", "-75 %")
		};
		var pick = pairs[_random.Next(pairs.Length)];
		var correct = $"{pick.down} %";

		var choices = Shuffle(correct, pick.w1, pick.w2, pick.w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-REC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-11",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Le prix d'un smartphone augmente de {pick.up} %. Quel pourcentage de baisse doit-il subir pour revenir exactement à son prix initial ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'évolution réciproque a pour coefficient multiplicateur CM' = 1 / CM.",
			HintLevel2 = $"Pour CM = 1 + {pick.up}/100, calculez 1 / CM puis convertissez en taux.",
			ExplanationText = $"1 / (1 + {pick.up}/100) donne un taux réciproque de {correct}."
		};
	}
}
