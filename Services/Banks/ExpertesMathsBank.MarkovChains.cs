using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	public ExerciseQuestion GenerateMarkovChainsQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateStochasticMatrixRowSumQuestion(),
			1 => GenerateMarkovStateIterationQuestion(),
			_ => GenerateInvariantDistributionDefinitionQuestion()
		};
	}

	private ExerciseQuestion GenerateStochasticMatrixRowSumQuestion()
	{
		var correct = "La somme des coefficients de chaque ligne est égale à 1";
		var wrong1 = "La somme des coefficients de chaque colonne est égale à 1";
		var wrong2 = "Le déterminant de la matrice est égal à 1";
		var wrong3 = "Tous les coefficients diagonaux sont nuls";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-STOC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-07",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Quelle propriété caractéristique doit obligatoirement vérifier la matrice de transition T d'une chaîne de Markov (matrice stochastique par ligne) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Chaque ligne rassemble les probabilités de transition depuis un état donné vers tous les autres états possibles.",
			HintLevel2 = "La somme de toutes les probabilités issues d'un même état doit valoir 1.",
			ExplanationText = "Chaque ligne d'une matrice de transition stochastique a une somme égale à 1."
		};
	}

	private ExerciseQuestion GenerateMarkovStateIterationQuestion()
	{
		var n = _random.Next(2, 6);
		var correct = $"P_{{{n}}} = P_0 * T^{n}";
		var wrong1 = $"P_{{{n}}} = T^{n} * P_0";
		var wrong2 = $"P_{{{n}}} = P_0 * ({n} * T)";
		var wrong3 = $"P_{{{n}}} = (P_0)^{n} * T";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-MRKIT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-07",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Soit P_0 la distribution de probabilité initiale (vecteur ligne) et T la matrice de transition d'une chaîne de Markov. Quelle est l'expression de P_{{{n}}} à l'étape {n} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "P_1 = P_0 * T, puis P_2 = P_1 * T = P_0 * T² par récurrence.",
			HintLevel2 = $"À l'étape {n}, on multiplie P_0 à droite par la matrice puissance T^{n}.",
			ExplanationText = $"La distribution à l'étape {n} est donnée par P_{{{n}}} = P_0 * T^{n}."
		};
	}

	private ExerciseQuestion GenerateInvariantDistributionDefinitionQuestion()
	{
		var correct = "π = π * T et la somme des composantes de π vaut 1";
		var wrong1 = "T * π = 0";
		var wrong2 = "π = T * π et det(T) = 0";
		var wrong3 = "π * T = I_n";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-INVMRK-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-07",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Quelle équation définit une distribution stationnaire (ou distribution invariante) notée π pour une chaîne de Markov de matrice de transition T ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une distribution stationnaire ne change plus lorsqu'on lui applique la transition T.",
			HintLevel2 = "Le vecteur ligne vérifie π = πT avec des probabilités sommant à 1.",
			ExplanationText = "La distribution invariante vérifie π = π * T avec somme(π_i) = 1."
		};
	}
}

