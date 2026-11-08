using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GeneratePythonListsQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateListComprehensionQuestion(),
			1 => GenerateListNegativeIndexingQuestion(),
			2 => GenerateListAppendLengthQuestion(),
			_ => GenerateListSumAccumulationQuestion()
		};
	}

	private ExerciseQuestion GenerateListComprehensionQuestion()
	{
		var n = _random.Next(3, 6);
		var mult = _random.Next(2, 5);

		var elements = Enumerable.Range(0, n).Select(x => x * mult).ToList();
		var correct = "[" + string.Join(", ", elements) + "]";
		var wrong1 = "[" + string.Join(", ", Enumerable.Range(1, n).Select(x => x * mult)) + "]";
		var wrong2 = "[" + string.Join(", ", Enumerable.Range(0, n)) + "]";
		var wrong3 = "[" + string.Join(", ", Enumerable.Range(0, n).Select(x => x + mult)) + "]";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-LST-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-01",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Que contient la liste L créée par cette compréhension Python ?\nL = [{mult} * x for x in range({n})]",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "range(n) génère les entiers de 0 jusqu'à n-1 inclus.",
			HintLevel2 = $"Pour x prenant les valeurs de 0 à {n - 1}, multipliez chaque x par {mult}.",
			ExplanationText = $"x varie de 0 à {n - 1}, les valeurs obtenues forment {correct}."
		};
	}

	private ExerciseQuestion GenerateListNegativeIndexingQuestion()
	{
		var vals = new List<int> { _random.Next(10, 20), _random.Next(20, 30), _random.Next(30, 40), _random.Next(40, 50), _random.Next(50, 60) };
		var listStr = "[" + string.Join(", ", vals) + "]";

		var correct = vals[^1].ToString();
		var wrong1 = vals[0].ToString();
		var wrong2 = vals[^2].ToString();
		var wrong3 = vals[1].ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-IDX-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-01",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Soit la liste Python L = {listStr}. Quelle valeur renvoie l'instruction L[-1] ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "En Python, un indice négatif commence le décompte depuis la fin de la liste.",
			HintLevel2 = "L[-1] désigne le tout dernier élément de la liste.",
			ExplanationText = $"L[-1] accède au dernier élément de la liste, soit {correct}."
		};
	}

	private ExerciseQuestion GenerateListAppendLengthQuestion()
	{
		var initCount = _random.Next(2, 5);
		var appends = _random.Next(2, 4);
		var finalCount = initCount + appends;

		var correct = finalCount.ToString();
		var wrong1 = initCount.ToString();
		var wrong2 = (finalCount + 1).ToString();
		var wrong3 = (initCount * appends).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-APP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-01",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Une liste L contient initialement {initCount} nombres. On exécute {appends} fois la méthode L.append(x). Que renvoie len(L) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La méthode .append() ajoute un élément à la fin de la liste et augmente sa taille de 1.",
			HintLevel2 = $"Taille finale = {initCount} + {appends}.",
			ExplanationText = $"Chaque .append() incrémente la longueur len(L) de 1, total {finalCount}."
		};
	}

	private ExerciseQuestion GenerateListSumAccumulationQuestion()
	{
		var a = _random.Next(2, 5);
		var b = _random.Next(3, 7);
		var c = _random.Next(4, 9);
		var sum = a + b + c;

		var correct = sum.ToString();
		var wrong1 = (sum - a).ToString();
		var wrong2 = (sum + b).ToString();
		var wrong3 = "3";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-SUM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-01",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Que vaut la variable s après l'exécution de ce code ?\ns = 0\nfor x in [{a}, {b}, {c}]:\n    s = s + x",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La boucle for parcourt successivement chaque élément de la liste.",
			HintLevel2 = $"Additionnez {a} + {b} + {c}.",
			ExplanationText = $"La somme cumulée des éléments est {sum}."
		};
	}
}
