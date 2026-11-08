using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateConcentrationQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateBienaymeTchebychevQuestion(),
			1 => GenerateEmpiricalMeanVarianceQuestion(),
			_ => GenerateLawOfLargeNumbersQuestion()
		};
	}

	private ExerciseQuestion GenerateBienaymeTchebychevQuestion()
	{
		var correct = "P(|X - E(X)| ≥ δ) ≤ V(X) / δ²";
		var wrong1 = "P(|X - E(X)| ≥ δ) ≤ V(X) / δ";
		var wrong2 = "P(|X - E(X)| ≥ δ) ≥ V(X) / δ²";
		var wrong3 = "P(|X - E(X)| ≥ δ) ≤ σ(X) / δ";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-TCHB-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-13",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelle est l'expression de l'inégalité de Bienaymé-Tchebychev pour une variable aléatoire X admettant une variance V(X) et pour tout δ > 0 ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'inégalité majore la probabilité que X s'éloigne de son espérance par un quotient faisant intervenir δ².",
			HintLevel2 = "Le numérateur est la variance V(X) et le dénominateur est δ².",
			ExplanationText = "Inégalité de Bienaymé-Tchebychev : P(|X - E(X)| ≥ δ) ≤ V(X) / δ²."
		};
	}

	private ExerciseQuestion GenerateEmpiricalMeanVarianceQuestion()
	{
		var correct = "V(M_n) = σ² / n";
		var wrong1 = "V(M_n) = n * σ²";
		var wrong2 = "V(M_n) = σ / √n";
		var wrong3 = "V(M_n) = σ²";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-VARMN-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-13",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Soit M_n la moyenne empirique d'un échantillon de n variables aléatoires indépendantes et de même variance σ². Quelle est la variance de M_n ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "V(M_n) = V((1/n) * somme X_i) = (1/n²) * somme V(X_i).",
			HintLevel2 = "(1/n²) * (n * σ²) = σ² / n.",
			ExplanationText = "La variance de la moyenne d'un échantillon est divisée par n : V(M_n) = σ² / n."
		};
	}

	private ExerciseQuestion GenerateLawOfLargeNumbersQuestion()
	{
		var correct = "Pour tout δ > 0, lim (n -> +∞) P(|M_n - μ| ≥ δ) = 0";
		var wrong1 = "Pour tout n, M_n est exactement égale à μ";
		var wrong2 = "La variance de M_n tend vers +∞";
		var wrong3 = "L'espérance de M_n diminue lorsque la taille n augmente";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-LGN-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-13",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Que stipule la loi faible des grands nombres pour la moyenne empirique M_n d'un échantillon lorsque la taille n tend vers l'infini ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Quand la taille de l'échantillon devient très grande, la moyenne observée se concentre autour de l'espérance théorique.",
			HintLevel2 = "La probabilité que la moyenne s'écarte de μ tend vers 0.",
			ExplanationText = "La loi des grands nombres assure la convergence en probabilité de M_n vers μ."
		};
	}
}

