using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	public ExerciseQuestion GenerateMatricesGraphsQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateMatrixProductCommutativityQuestion(),
			1 => GenerateAdjacencyMatrixPathLengthQuestion(),
			_ => GenerateMatrixInverse2x2Question()
		};
	}

	private ExerciseQuestion GenerateMatrixProductCommutativityQuestion()
	{
		var correct = "Le produit matriciel n'est généralement pas commutatif : A * B ≠ B * A";
		var wrong1 = "Le produit matriciel est toujours commutatif : A * B = B * A";
		var wrong2 = "Le produit matriciel n'est défini que pour des matrices diagonales";
		var wrong3 = "A * B donne toujours la matrice nulle";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-MTRP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-06",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Quelle propriété fondamentale distingue la multiplication des matrices carrées de dimension n ≥ 2 par rapport aux nombres réels ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'ordre des facteurs dans un produit matriciel est capital.",
			HintLevel2 = "En général, inverser l'ordre des matrices produit un résultat différent.",
			ExplanationText = "Le produit matriciel n'est pas commutatif : A * B ≠ B * A en général."
		};
	}

	private ExerciseQuestion GenerateAdjacencyMatrixPathLengthQuestion()
	{
		var k = _random.Next(2, 6);
		var correct = $"Le nombre de chaînes de longueur {k} reliant le sommet i au sommet j";
		var wrong1 = $"La distance minimale entre le sommet i et le sommet j";
		var wrong2 = $"Le degré du sommet i multiplié par {k}";
		var wrong3 = "La probabilité de transition en une étape";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-ADJC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-06",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Soit M la matrice d'adjacence d'un graphe. Que représente le coefficient situé à la ligne i et colonne j de la matrice puissance M^{k} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le produit successif de la matrice d'adjacence dénombre les chemins pas à pas.",
			HintLevel2 = $"La puissance {k} correspond exactement à des chaînes de {k} arêtes.",
			ExplanationText = $"Le coefficient (M^{k})_ij dénombre les chaînes de longueur {k} entre i et j."
		};
	}

	private ExerciseQuestion GenerateMatrixInverse2x2Question()
	{
		var correct = "det(A) = ad - bc ≠ 0";
		var wrong1 = "det(A) = ad + bc = 0";
		var wrong2 = "a + d = 0";
		var wrong3 = "b = c = 0";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-INV2-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-06",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "À quelle condition nécessaire et suffisante une matrice carrée 2x2 A = [[a, b], [c, d]] est-elle inversible ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une matrice est inversible si et seulement si son déterminant est non nul.",
			HintLevel2 = "Le déterminant d'une matrice 2x2 est égal au produit croisé ad - bc.",
			ExplanationText = "Une matrice 2x2 est inversible ssi son déterminant ad - bc est non nul."
		};
	}
}

