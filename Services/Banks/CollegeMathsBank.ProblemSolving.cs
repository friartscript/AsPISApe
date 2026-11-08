using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateProblemModeling()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateAgeProblem(),
			1 => GenerateShoppingProblem(),
			_ => GenerateConsecutiveSumProblem()
		};
	}

	public ExerciseQuestion GenerateLiteralProof()
	{
		var variant = _random.Next(2);
		return variant switch
		{
			0 => GenerateConsecutiveIntegersProof(),
			_ => GenerateEvenNumberSquareProof()
		};
	}

	private ExerciseQuestion GenerateAgeProblem()
	{
		var childAge = _random.Next(8, 14);
		var parentLead = _random.Next(24, 32);
		var sum = (2 * childAge) + parentLead;
		var correct = $"{childAge} ans";
		var wrong1 = $"{childAge + 3} ans";
		var wrong2 = $"{childAge - 2} ans";
		var wrong3 = $"{sum / 2} ans";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PB1-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-029",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Une mère a {parentLead} ans de plus que sa fille. À elles deux, elles ont {sum} ans. Quel est l'âge de la fille ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pose x l'âge de la fille. La mère a alors (x + écart). Écris la somme égale au total.",
			HintLevel2 = $"L'équation est x + (x + {parentLead}) = {sum}, soit 2x + {parentLead} = {sum}.",
			ExplanationText = $"2x = {sum - parentLead} donc x = {(sum - parentLead) / 2} ans."
		};
	}

	private ExerciseQuestion GenerateShoppingProblem()
	{
		var bookPrice = _random.Next(5, 12);
		var nbBooks = _random.Next(3, 6);
		var penPrice = _random.Next(2, 5);
		var total = (nbBooks * bookPrice) + penPrice;
		var correct = $"{bookPrice} €";
		var wrong1 = $"{bookPrice + 2} €";
		var wrong2 = $"{bookPrice - 1} €";
		var wrong3 = $"{(total - penPrice) / 2} €";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PB2-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-029",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Léa achète {nbBooks} romans identiques et un stylo à {penPrice} €. Elle paie {total} € au total. Quel est le prix d'un roman ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pose x le prix d'un roman. Traduis les achats en équation avec le prix total.",
			HintLevel2 = $"{nbBooks}x + {penPrice} = {total}. Soustrais {penPrice} puis divise par {nbBooks}.",
			ExplanationText = $"{nbBooks}x = {total - penPrice} donc x = {bookPrice} €."
		};
	}

	private ExerciseQuestion GenerateConsecutiveSumProblem()
	{
		var n = _random.Next(10, 30);
		var sum = (3 * n) + 3;
		var correct = $"{n}, {n + 1} et {n + 2}";
		var wrong1 = $"{n - 1}, {n} et {n + 1}";
		var wrong2 = $"{n + 1}, {n + 2} et {n + 3}";
		var wrong3 = $"{sum / 3 - 2}, {sum / 3} et {sum / 3 + 2}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PB3-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-029",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"La somme de trois nombres entiers consécutifs est égale à {sum}. Quels sont ces trois nombres ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Trois entiers consécutifs s'écrivent n, (n + 1) et (n + 2).",
			HintLevel2 = $"Leur somme vaut n + n + 1 + n + 2 = 3n + 3 = {sum}.",
			ExplanationText = $"3n = {sum - 3} donc n = {n}. Les nombres sont {n}, {n + 1} et {n + 2}."
		};
	}

	private ExerciseQuestion GenerateConsecutiveIntegersProof()
	{
		var correct = "2n + 1 (toujours impair)";
		var wrong1 = "2n (toujours pair)";
		var wrong2 = "n² (toujours un carré)";
		var wrong3 = "3n (toujours multiple de 3)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PRF1-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-031",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = "Si n est un nombre entier, comment s'exprime la somme de n et de l'entier suivant (n + 1) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calcule littéralement n + (n + 1) en réduisant les termes semblables.",
			HintLevel2 = "n + n + 1 = 2n + 1. Or 2n est pair, donc 2n + 1 est impair.",
			ExplanationText = "n + (n + 1) = 2n + 1, ce qui prouve que la somme de 2 entiers consécutifs est toujours impaire."
		};
	}

	private ExerciseQuestion GenerateEvenNumberSquareProof()
	{
		var correct = "4k² (qui est multiple de 4, donc pair)";
		var wrong1 = "2k² (qui est impair si k est impair)";
		var wrong2 = "4k + 1 (qui est impair)";
		var wrong3 = "k² (dont la parité est inconnue)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PRF2-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-031",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = "Un nombre pair s'écrit 2k (où k est un entier). Que vaut son carré (2k)² ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Applique la règle des puissances sur un produit : (ab)² = a² × b².",
			HintLevel2 = "(2k)² = 2² × k² = 4k².",
			ExplanationText = "(2k)² = 4k² = 2 × (2k²), ce qui démontre que le carré d'un nombre pair est toujours pair."
		};
	}
}

