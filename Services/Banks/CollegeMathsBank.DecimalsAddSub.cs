using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateDecimalAdditionSubtraction()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateDecimalAdditionQuestion(),
			1 => CreateDecimalSubtractionQuestion(),
			2 => CreateMissingDecimalTermQuestion(),
			_ => CreatePisaChangeReturnQuestion()
		};
	}

	private ExerciseQuestion CreateDecimalAdditionQuestion()
	{
		var centsA = _random.Next(120, 650) * 5;
		var centsB = _random.Next(50, 400) * 5;
		var valA = centsA / 100m;
		var valB = centsB / 100m;
		var sum = valA + valB;

		var correct = $"{sum:F2}".Replace('.', ',');
		var w1 = $"{sum + 1m:F2}".Replace('.', ',');
		var w2 = $"{sum - 0.10m:F2}".Replace('.', ',');
		var w3 = $"{sum + 0.05m:F2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {valA:F2}".Replace('.', ',') + $" + {valB:F2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Alignez les virgules verticalement avant d'additionner les chiffres de même rang.",
			HintLevel2 = "Additionnez d'abord les centièmes, puis les dixièmes et les unités.",
			ExplanationText = $"{valA:F2} + {valB:F2} = {sum:F2}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateDecimalSubtractionQuestion()
	{
		var centsA = _random.Next(400, 950) * 5;
		var centsB = _random.Next(100, 350) * 5;
		var valA = centsA / 100m;
		var valB = centsB / 100m;
		var diff = valA - valB;

		var correct = $"{diff:F2}".Replace('.', ',');
		var w1 = $"{diff + 1m:F2}".Replace('.', ',');
		var w2 = $"{diff - 0.10m:F2}".Replace('.', ',');
		var w3 = $"{diff + 0.20m:F2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {valA:F2}".Replace('.', ',') + $" - {valB:F2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Alignez les virgules et complétez éventuellement avec un zéro.",
			HintLevel2 = $"Retirez {valB:F2} à {valA:F2} en tenant compte des retenues.".Replace('.', ','),
			ExplanationText = $"{valA:F2} - {valB:F2} = {diff:F2}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateMissingDecimalTermQuestion()
	{
		var centsA = _random.Next(100, 500) * 5;
		var centsMissing = _random.Next(100, 400) * 5;
		var valA = centsA / 100m;
		var valMissing = centsMissing / 100m;
		var sum = valA + valMissing;

		var correct = $"{valMissing:F2}".Replace('.', ',');
		var w1 = $"{valMissing + 1m:F2}".Replace('.', ',');
		var w2 = $"{valMissing - 0.10m:F2}".Replace('.', ',');
		var w3 = $"{sum + valA:F2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Trouvez le nombre manquant : {valA:F2}".Replace('.', ',') + $" + ? = {sum:F2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour trouver un terme manquant dans une addition, effectuez une soustraction.",
			HintLevel2 = $"Calculez {sum:F2} - {valA:F2}.".Replace('.', ','),
			ExplanationText = $"Le terme manquant vaut {sum:F2} - {valA:F2} = {valMissing:F2}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreatePisaChangeReturnQuestion()
	{
		var prices = new[] { 13.40m, 17.65m, 24.80m, 32.50m, 41.25m };
		var price = prices[_random.Next(prices.Length)];
		var bill = price < 20m ? 20m : 50m;
		var change = bill - price;

		var correct = $"{change:F2} €".Replace('.', ',');
		var w1 = $"{change + 1m:F2} €".Replace('.', ',');
		var w2 = $"{change - 0.50m:F2} €".Replace('.', ',');
		var w3 = $"{bill - price + 0.20m:F2} €".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S4-{Guid.NewGuid():N}",
			SubjectId = "maths_col_addition_soustraction_decimaux",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Un achat coûte {price:F2} €. Le client paie avec un billet de {bill:F0} €. Combien lui rend-on ?".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La monnaie rendue correspond à la différence entre le billet donné et le montant dû.",
			HintLevel2 = $"Calculez {bill:F0} - {price:F2}.".Replace('.', ','),
			ExplanationText = $"On lui rend {bill:F0} - {price:F2} = {change:F2} €.".Replace('.', ',')
		};
	}
}

