using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateBinomialLawQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateBinomialProbabilityFormulaQuestion(),
			1 => GenerateBinomialExpectationQuestion(),
			_ => GenerateBinomialVarianceQuestion()
		};
	}

	private ExerciseQuestion GenerateBinomialProbabilityFormulaQuestion()
	{
		var correct = "P(X = k) = (n parmi k) * p^k * (1 - p)^(n - k)";
		var wrong1 = "P(X = k) = p^k * (1 - p)^(n - k)";
		var wrong2 = "P(X = k) = (n parmi k) * p^(n - k)";
		var wrong3 = "P(X = k) = (n * p)^k";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-BNM1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-12",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Soit X une variable aléatoire suivant la loi binomiale B(n, p). Quelle est la formule de P(X = k) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La formule compte le nombre de chemins à k succès dans l'arbre : (n parmi k).",
			HintLevel2 = "Chaque chemin a une probabilité égale à p^k * (1-p)^(n-k).",
			ExplanationText = "Loi binomiale : P(X = k) = (n parmi k) * p^k * (1 - p)^(n - k)."
		};
	}

	private ExerciseQuestion GenerateBinomialExpectationQuestion()
	{
		var n = _random.Next(10, 50) * 2;
		var p = 0.5;
		var eX = (int)(n * p);

		var correct = eX.ToString();
		var wrong1 = n.ToString();
		var wrong2 = (eX / 2).ToString();
		var wrong3 = (eX + 5).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-BNME-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-12",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Une variable aléatoire X suit la loi binomiale B({n} ; 0,5). Quelle est son espérance mathématique E(X) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour une loi binomiale B(n, p), l'espérance est donnée par la formule simple E(X) = n * p.",
			HintLevel2 = $"Calculez {n} * 0,5.",
			ExplanationText = $"E(X) = n * p = {n} * 0,5 = {eX}."
		};
	}

	private ExerciseQuestion GenerateBinomialVarianceQuestion()
	{
		var correct = "V(X) = n * p * (1 - p)";
		var wrong1 = "V(X) = n * p";
		var wrong2 = "V(X) = n² * p²";
		var wrong3 = "V(X) = √(n * p)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-BNMV-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-12",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelle est la variance V(X) d'une variable aléatoire X suivant une loi binomiale B(n, p) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La variance d'une somme de n variables de Bernoulli indépendantes est n fois la variance de Bernoulli.",
			HintLevel2 = "La variance d'une épreuve de Bernoulli de paramètre p est p(1-p).",
			ExplanationText = "Pour une loi binomiale, V(X) = n * p * (1 - p)."
		};
	}
}

