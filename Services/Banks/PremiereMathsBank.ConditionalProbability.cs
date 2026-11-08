using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateConditionalProbabilityQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateConditionalDefinitionQuestion(),
			1 => GenerateTotalProbabilityLawQuestion(),
			_ => GenerateIndependenceCriterionQuestion()
		};
	}

	private ExerciseQuestion GenerateConditionalDefinitionQuestion()
	{
		var pB = 0.4;
		var pInter = 0.12;
		var pCond = pInter / pB;

		var correct = $"{pCond:0.00}";
		var wrong1 = $"{(pB * pInter):0.00}";
		var wrong2 = $"{(pB + pInter):0.00}";
		var wrong3 = $"{(pB - pInter):0.00}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-PRBC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-10",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Sachant que P(B) = {pB:0.0} et P(A ∩ B) = {pInter:0.00}, quelle est la probabilité conditionnelle P_B(A) (probabilité de A sachant B) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de la probabilité conditionnelle : P_B(A) = P(A ∩ B) / P(B).",
			HintLevel2 = $"Divisez {pInter:0.00} par {pB:0.0}.",
			ExplanationText = $"P_B(A) = P(A ∩ B) / P(B) = {pInter:0.00} / {pB:0.0} = {correct}."
		};
	}

	private ExerciseQuestion GenerateTotalProbabilityLawQuestion()
	{
		var pB = 0.6;
		var pNotB = 0.4;
		var pA_given_B = 0.1;
		var pA_given_NotB = 0.2;
		var pA = (pB * pA_given_B) + (pNotB * pA_given_NotB);

		var correct = $"{pA:0.00}";
		var wrong1 = $"{(pA + 0.05):0.00}";
		var wrong2 = $"{(pB * pNotB):0.00}";
		var wrong3 = "0,50";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-TOTP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-10",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Un arbre pondéré donne P(B) = {pB:0.0}, P_B(A) = {pA_given_B:0.0} et P_B̄(A) = {pA_given_NotB:0.0}. Calculez P(A) par la formule des probabilités totales.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule des probabilités totales : P(A) = P(B) * P_B(A) + P(B̄) * P_B̄(A).",
			HintLevel2 = $"P(B̄) = 1 - {pB:0.0} = {pNotB:0.0}. Calculez ({pB:0.0} * {pA_given_B:0.0}) + ({pNotB:0.0} * {pA_given_NotB:0.0}).",
			ExplanationText = $"P(A) = {pB:0.0}*{pA_given_B:0.0} + {pNotB:0.0}*{pA_given_NotB:0.0} = {correct}."
		};
	}

	private ExerciseQuestion GenerateIndependenceCriterionQuestion()
	{
		var correct = "P(A ∩ B) = P(A) * P(B)";
		var wrong1 = "P(A ∩ B) = 0";
		var wrong2 = "P(A ∪ B) = P(A) + P(B)";
		var wrong3 = "P(A) + P(B) = 1";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-INDP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-10",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "À quelle condition nécessaire et suffisante deux événements A et B sont-ils dits indépendants ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux événements sont indépendants si la réalisation de l'un n'influence pas celle de l'autre.",
			HintLevel2 = "La probabilité de l'intersection est égale au produit des probabilités.",
			ExplanationText = "L'indépendance de A et B équivaut à P(A ∩ B) = P(A) * P(B)."
		};
	}
}
