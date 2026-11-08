using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateProbabilitiesAndSamplingQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateComplementaryProbabilityQuestion(),
			1 => GeneratePoincareFormulaQuestion(),
			2 => GenerateIncompatibleEventsQuestion(),
			_ => GenerateSamplingFluctuationIntervalQuestion()
		};
	}

	private ExerciseQuestion GenerateComplementaryProbabilityQuestion()
	{
		var pInt = _random.Next(15, 85);
		var pA = pInt / 100.0;
		var pNotA = (100 - pInt) / 100.0;

		var correct = $"{pNotA:0.00}";
		var wrong1 = $"{1.0 + pA:0.00}";
		var wrong2 = $"{pA / 2.0:0.00}";
		var wrong3 = $"{pInt} %";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-CMP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-13",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Soit A un événement de probabilité P(A) = {pA:0.00}. Quelle est la probabilité de son événement contraire noté Ā ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété fondamentale de l'événement contraire : P(Ā) = 1 - P(A).",
			HintLevel2 = $"Calculez 1 - {pA:0.00}.",
			ExplanationText = $"P(Ā) = 1 - P(A) = 1 - {pA:0.00} = {correct}."
		};
	}

	private ExerciseQuestion GeneratePoincareFormulaQuestion()
	{
		var pA = 0.5;
		var pB = 0.4;
		var pInter = 0.2;
		var pUnion = pA + pB - pInter;

		var correct = $"{pUnion:0.0}";
		var wrong1 = $"{(pA + pB):0.0}";
		var wrong2 = $"{(pA * pB):0.0}";
		var wrong3 = $"{(pUnion - 0.1):0.0}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-PNC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-13",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Soit deux événements A et B tels que P(A) = {pA:0.0}, P(B) = {pB:0.0} et P(A ∩ B) = {pInter:0.0}. Calculez P(A ∪ B).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de la réunion : P(A ∪ B) = P(A) + P(B) - P(A ∩ B).",
			HintLevel2 = $"P(A ∪ B) = {pA:0.0} + {pB:0.0} - {pInter:0.0}.",
			ExplanationText = $"P(A ∪ B) = {pA:0.0} + {pB:0.0} - {pInter:0.0} = {correct}."
		};
	}

	private ExerciseQuestion GenerateIncompatibleEventsQuestion()
	{
		var correct = "P(A ∩ B) = 0 et P(A ∪ B) = P(A) + P(B)";
		var wrong1 = "P(A ∩ B) = P(A) * P(B)";
		var wrong2 = "P(A) + P(B) = 1";
		var wrong3 = "A et B se réalisent toujours en même temps";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-INC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-13",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = "Que signifie que deux événements A et B sont dits disjoints (ou incompatibles) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux événements incompatibles ne peuvent pas se réaliser simultanément : A ∩ B = ∅.",
			HintLevel2 = "Leur intersection est vide donc P(A ∩ B) = 0.",
			ExplanationText = "Incompatibles signifie qu'ils n'ont aucune issue en commun : P(A ∩ B) = 0."
		};
	}

	private ExerciseQuestion GenerateSamplingFluctuationIntervalQuestion()
	{
		var n = 100;
		var p = 0.4;
		var margin = 1.0 / Math.Sqrt(n);
		var min = p - margin;
		var max = p + margin;

		var correct = $"[{min:0.0} ; {max:0.0}]";
		var wrong1 = $"[{min - 0.1:0.0} ; {max + 0.1:0.0}]";
		var wrong2 = $"[{p - 0.05:0.00} ; {p + 0.05:0.00}]";
		var wrong3 = "[0 ; 1]";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-SMP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-13",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Dans une population, la proportion d'un caractère est p = {p:0.0}. Quel est l'intervalle de fluctuation au seuil de 95 % pour un échantillon de taille n = {n} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de Seconde : If = [p - 1/√n ; p + 1/√n] lorsque n ≥ 30, np ≥ 5 et n(1-p) ≥ 5.",
			HintLevel2 = $"1/√{n} = 1/10 = 0,1. Calculez [{p:0.0} - 0,1 ; {p:0.0} + 0,1].",
			ExplanationText = $"If = [{p:0.0} - 0,1 ; {p:0.0} + 0,1] = {correct}."
		};
	}
}
