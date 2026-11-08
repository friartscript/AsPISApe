using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateBasicProbabilityQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateDiceProbabilityQuestion(),
			1 => GenerateUrnProbabilityQuestion(),
			_ => GenerateCardsProbabilityQuestion()
		};
	}

	public ExerciseQuestion GenerateComplementaryProbabilityQuestion()
	{
		var redBalls = _random.Next(3, 7);
		var totalBalls = _random.Next(8, 15);
		var nonRed = totalBalls - redBalls;
		var correct = $"{nonRed} / {totalBalls}";
		var wrong1 = $"{redBalls} / {totalBalls}";
		var wrong2 = $"{nonRed} / {redBalls}";
		var wrong3 = "1 / 2";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-COMPL-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-041",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Une urne contient {totalBalls} boules indiscernables au toucher, dont {redBalls} rouges. On tire une boule au hasard. Quelle est la probabilité de NE PAS tirer une boule rouge ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La probabilité de l'événement contraire est égale à 1 - P(événement), ou au nombre d'issues non rouges divisé par le total.",
			HintLevel2 = $"Il y a {totalBalls} - {redBalls} = {nonRed} boules qui ne sont pas rouges sur un total de {totalBalls}.",
			ExplanationText = $"P(non rouge) = 1 - ({redBalls} / {totalBalls}) = {nonRed} / {totalBalls}."
		};
	}

	private ExerciseQuestion GenerateDiceProbabilityQuestion()
	{
		var cases = new[]
		{
			("obtenir un nombre pair avec un dé à 6 faces", "3 / 6 (ou 1 / 2)", "2 / 6", "4 / 6", "1 / 6", "3 issues favorables (2, 4, 6) sur 6"),
			("obtenir un nombre supérieur ou égal à 5 avec un dé à 6 faces", "2 / 6 (ou 1 / 3)", "1 / 6", "3 / 6", "5 / 6", "2 issues favorables (5, 6) sur 6"),
			("obtenir un multiple de 3 avec un dé à 6 faces", "2 / 6 (ou 1 / 3)", "3 / 6", "1 / 6", "4 / 6", "2 issues favorables (3, 6) sur 6"),
			("obtenir le chiffre 6 avec un dé équilibré à 6 faces", "1 / 6", "6 / 6", "1 / 2", "1 / 3", "1 seule issue favorable sur 6")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PROBDICE-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-040",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Quelle est la probabilité d'{item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "En situation d'équiprobabilité, la probabilité est égale au nombre d'issues favorables divisé par le nombre total d'issues.",
			HintLevel2 = item.Item6,
			ExplanationText = $"Probabilité = Issues favorables / Total = {item.Item2}."
		};
	}

	private ExerciseQuestion GenerateUrnProbabilityQuestion()
	{
		var green = _random.Next(2, 6);
		var blue = _random.Next(3, 7);
		var yellow = _random.Next(1, 5);
		var total = green + blue + yellow;
		var correct = $"{blue} / {total}";
		var wrong1 = $"{green} / {total}";
		var wrong2 = $"{blue} / {green + yellow}";
		var wrong3 = "1 / 3";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PROBURN-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-040",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Un sac contient {green} billes vertes, {blue} billes bleues et {yellow} billes jaunes. On tire une bille au hasard. Quelle est la probabilité qu'elle soit bleue ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calcule d'abord le nombre total de billes dans le sac, puis divise le nombre de billes bleues par ce total.",
			HintLevel2 = $"Total des billes : {green} + {blue} + {yellow} = {total}. Billes bleues = {blue}.",
			ExplanationText = $"P(bleue) = {blue} / ({green} + {blue} + {yellow}) = {blue} / {total}."
		};
	}

	private ExerciseQuestion GenerateCardsProbabilityQuestion()
	{
		var correct = "13 / 52 (ou 1 / 4)";
		var wrong1 = "4 / 52";
		var wrong2 = "1 / 52";
		var wrong3 = "1 / 2";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PROBCARD-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-041",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = "Dans un jeu standard de 52 cartes bien mélangées, quelle est la probabilité de tirer une carte de pique (♠) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un jeu de 52 cartes contient 4 couleurs équitablement réparties (Pique, Cœur, Carreau, Trèfle).",
			HintLevel2 = "Il y a 13 piques dans le paquet de 52 cartes. 13 / 52 se simplifie en 1 / 4.",
			ExplanationText = "P(Pique) = 13 / 52 = 1 / 4 (25 % de chance)."
		};
	}
}

