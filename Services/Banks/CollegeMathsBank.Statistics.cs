using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateMeanQuestion()
	{
		var n1 = _random.Next(8, 14);
		var n2 = _random.Next(10, 16);
		var n3 = _random.Next(12, 18);
		var n4 = _random.Next(6, 16);
		var sum = n1 + n2 + n3 + n4;
		var remainder = sum % 4;
		if (remainder != 0)
		{
			n4 += (4 - remainder);
			sum = n1 + n2 + n3 + n4;
		}
		var mean = sum / 4;
		var correct = $"{mean} / 20";
		var wrong1 = $"{mean - 1} / 20";
		var wrong2 = $"{mean + 2} / 20";
		var wrong3 = $"{sum / 2} / 20";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-MEAN-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-038",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Un élève a obtenu les 4 notes suivantes : {n1}, {n2}, {n3} et {n4}. Quelle est sa moyenne ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionne toutes les valeurs de la série, puis divise la somme par le nombre total de notes.",
			HintLevel2 = $"La somme des 4 notes vaut {sum}. Divise par 4.",
			ExplanationText = $"Moyenne = ({n1} + {n2} + {n3} + {n4}) / 4 = {sum} / 4 = {mean}."
		};
	}

	public ExerciseQuestion GenerateMedianQuestion()
	{
		var numbers = new List<int>
		{
			_random.Next(2, 6),
			_random.Next(7, 11),
			_random.Next(12, 15),
			_random.Next(16, 20),
			_random.Next(21, 25)
		};
		var median = numbers[2];
		var scrambled = numbers.OrderBy(_ => _random.Next()).ToList();
		var correct = median.ToString();
		var wrong1 = numbers[1].ToString();
		var wrong2 = numbers[3].ToString();
		var wrong3 = ((numbers[0] + numbers[4]) / 2).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-MED-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-039",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Quelle est la médiane de la série statistique suivante : {string.Join(", ", scrambled)} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Range d'abord les 5 valeurs dans l'ordre croissant. La médiane est la valeur située exactement au milieu (la 3e).",
			HintLevel2 = $"Série ordonnée : {string.Join(" < ", numbers)}. La valeur du milieu est {median}.",
			ExplanationText = $"La médiane est la valeur centrale d'une série ordonnée : {median}."
		};
	}

	public ExerciseQuestion GenerateRangeQuestion()
	{
		var min = _random.Next(2, 8);
		var max = _random.Next(22, 35);
		var mid1 = _random.Next(min + 1, 15);
		var mid2 = _random.Next(16, max - 1);
		var range = max - min;
		var correct = $"{range} °C";
		var wrong1 = $"{range + 4} °C";
		var wrong2 = $"{range - 3} °C";
		var wrong3 = $"{max + min} °C";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-RNG-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-037",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Une station météo a relevé les températures quotidiennes suivantes : {mid1} °C, {min} °C, {max} °C et {mid2} °C. Quelle est l'étendue de cette série ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'étendue est la différence entre la valeur maximale et la valeur minimale de la série.",
			HintLevel2 = $"Maximum = {max} °C, Minimum = {min} °C. Calcule {max} - {min}.",
			ExplanationText = $"Étendue = Valeur max ({max}) - Valeur min ({min}) = {range} °C."
		};
	}

	public ExerciseQuestion GenerateFrequencyQuestion()
	{
		var part = _random.Next(3, 8);
		var total = part * _random.Next(3, 6);
		var percentage = (part * 100) / total;
		var correct = $"{percentage} %";
		var wrong1 = $"{percentage + 10} %";
		var wrong2 = $"{part} %";
		var wrong3 = $"{100 - percentage} %";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-FREQ-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-037",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Dans un groupe de {total} élèves, {part} pratiquent l'escalade. Quelle est la fréquence de ces élèves en pourcentage ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La fréquence est le quotient de l'effectif concerné par l'effectif total. Multiplie par 100 pour obtenir le pourcentage.",
			HintLevel2 = $"Calcule ({part} / {total}) × 100.",
			ExplanationText = $"Fréquence = ({part} / {total}) × 100 = {percentage} %."
		};
	}
}

