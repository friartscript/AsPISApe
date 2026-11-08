using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class CollegePisaBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestion(int slot)
	{
		var capacity = _random.Next(3, 7) * 10;
		var used = capacity / 2;
		var remaining = capacity - used;

		var correct = $"{remaining} L";
		var wrong1 = $"{capacity + used} L";
		var wrong2 = $"{remaining - 5} L";
		var wrong3 = $"{used + 5} L";

		var choices = ShuffleChoices(correct, wrong1, wrong2, wrong3, out var correctIndex);

		return new ExerciseQuestion
		{
			Id = $"Q-PISA-COL-{Guid.NewGuid():N}",
			SubjectId = "pisa_col_lecture_calcul",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Un réservoir d'eau de pluie de {capacity} L est rempli à moitié. On en prélève la moitié du contenu. Combien de litres d'eau reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = correctIndex,
			HintLevel1 = "Calculez d'abord la moitié du réservoir, puis enlevez la quantité prélevée.",
			HintLevel2 = $"À moitié plein = {used} L. On retire la moitié de {used} L, soit {used / 2} L.",
			ExplanationText = $"Moitié = {used} L. Moitié prélevée = {used / 2} L. Il reste {used - (used / 2)} L."
		};
	}

	private List<string> ShuffleChoices(string correct, string w1, string w2, string w3, out int correctIndex)
	{
		var list = new List<string> { correct, w1, w2, w3 };
		var n = list.Count;
		while (n > 1)
		{
			n--;
			var k = _random.Next(n + 1);
			(list[k], list[n]) = (list[n], list[k]);
		}
		correctIndex = list.IndexOf(correct);
		return list;
	}
}

