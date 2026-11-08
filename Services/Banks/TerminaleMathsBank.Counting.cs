using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
}

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateCountingQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateCombinationCalculationQuestion(),
			1 => GeneratePermutationsQuestion(),
			_ => GeneratePascalFormulaQuestion()
		};
	}

	private ExerciseQuestion GenerateCombinationCalculationQuestion()
	{
		var pairs = new (int n, int k, int res, int w1, int w2, int w3)[]
		{
			(5, 2, 10, 20, 15, 5),
			(6, 2, 15, 30, 12, 20),
			(5, 3, 10, 15, 25, 60),
			(4, 2, 6, 12, 8, 4),
			(7, 2, 21, 42, 14, 28)
		};
		var pick = pairs[_random.Next(pairs.Length)];

		var choices = Shuffle(pick.res.ToString(), pick.w1.ToString(), pick.w2.ToString(), pick.w3.ToString(), out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-CMB1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-11",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Combien de sous-ensembles de {pick.k} éléments peut-on former à partir d'un ensemble de {pick.n} éléments (calcul de ({pick.n} parmi {pick.k})) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule des combinaisons : (n parmi k) = n! / (k! * (n - k)!).",
			HintLevel2 = $"({pick.n} parmi 2) = {pick.n} * {pick.n - 1} / 2.",
			ExplanationText = $"({pick.n} parmi {pick.k}) = {pick.res} combinaisons."
		};
	}

	private ExerciseQuestion GeneratePermutationsQuestion()
	{
		var n = _random.Next(3, 6);
		var fact = 1;
		for (var i = 1; i <= n; i++)
		{
			fact *= i;
		}

		var correct = fact.ToString();
		var wrong1 = (fact * 2).ToString();
		var wrong2 = (n * n).ToString();
		var wrong3 = (fact / 2).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-PRM1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-11",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"De combien de manières différentes peut-on ranger {n} livres distincts sur une étagère (calcul de {n}!) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le nombre de permutations de n éléments distincts est n! (factorielle n).",
			HintLevel2 = $"Multipliez les entiers de 1 jusqu'à {n}.",
			ExplanationText = $"{n}! = {fact} permutations possibles."
		};
	}

	private ExerciseQuestion GeneratePascalFormulaQuestion()
	{
		var correct = "(n parmi k) = (n-1 parmi k-1) + (n-1 parmi k)";
		var wrong1 = "(n parmi k) = (n-1 parmi k) * (n-1 parmi k-1)";
		var wrong2 = "(n parmi k) = (n parmi k-1) + (n-1 parmi k)";
		var wrong3 = "(n parmi k) = (n+1 parmi k+1) - (n parmi k)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-PSCL-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-11",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelle est la relation de récurrence de la formule de Pascal utilisée dans le triangle de Pascal ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Chaque terme est la somme des deux termes situés juste au-dessus dans la ligne précédente n-1.",
			HintLevel2 = "La ligne précédente n-1 combine k-1 et k.",
			ExplanationText = "Formule de Pascal : (n parmi k) = (n-1 parmi k-1) + (n-1 parmi k)."
		};
	}
}

