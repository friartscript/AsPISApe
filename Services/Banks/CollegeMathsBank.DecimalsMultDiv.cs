using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateDecimalMultiplication()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateDecimalPowerOfTenMultiplicationQuestion(),
			1 => CreateDecimalByIntegerMultiplicationQuestion(),
			2 => CreateTwoDecimalsMultiplicationQuestion(),
			_ => CreatePisaAreaOrWeightMultiplicationQuestion()
		};
	}

	public ExerciseQuestion GenerateDecimalDivisionByInteger()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateExactDecimalDivisionQuestion(),
			1 => CreateDecimalPowerOfTenDivisionQuestion(),
			2 => CreateIntegerDivisionToDecimalQuestion(),
			_ => CreatePisaBillSharingQuestion()
		};
	}

	private ExerciseQuestion CreateDecimalPowerOfTenMultiplicationQuestion()
	{
		var factors = new[] { 10, 100, 1000 };
		var factor = factors[_random.Next(factors.Length)];
		var decimals = new[] { 3.45m, 0.78m, 12.6m, 4.09m, 0.05m };
		var val = decimals[_random.Next(decimals.Length)];
		var prod = val * factor;

		var correct = $"{prod:G29}".Replace('.', ',');
		var w1 = $"{prod * 10:G29}".Replace('.', ',');
		var w2 = $"{prod / 10:G29}".Replace('.', ',');
		var w3 = $"{val + factor:G29}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {val}".Replace('.', ',') + $" × {factor}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multiplier par 10, 100 ou 1000 revient à décaler la virgule vers la droite.",
			HintLevel2 = $"Déplacez la virgule de {factor.ToString().Length - 1} rang(s) vers la droite.",
			ExplanationText = $"{val} × {factor} = {prod}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateDecimalByIntegerMultiplicationQuestion()
	{
		var pool = new[]
		{
			(2.5m, 4, 10m),
			(3.25m, 4, 13m),
			(1.75m, 3, 5.25m),
			(4.5m, 6, 27m),
			(6.2m, 5, 31m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m}".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.5m}".Replace('.', ',');
		var w3 = $"{item.Item1 * (item.Item2 + 1)}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {item.Item1}".Replace('.', ',') + $" × {item.Item2}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multipliez sans tenir compte de la virgule, puis replacez la virgule au résultat.",
			HintLevel2 = $"Le résultat comporte le même nombre de décimales que {item.Item1}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} × {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateTwoDecimalsMultiplicationQuestion()
	{
		var pool = new[]
		{
			(1.5m, 0.4m, 0.6m),
			(2.5m, 1.2m, 3.0m),
			(0.8m, 0.5m, 0.4m),
			(1.2m, 0.3m, 0.36m),
			(0.7m, 0.6m, 0.42m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 * 10m}".Replace('.', ',');
		var w2 = $"{item.Item3 / 10m}".Replace('.', ',');
		var w3 = $"{item.Item1 + item.Item2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1}".Replace('.', ',') + $" × {item.Item2}".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le nombre de décimales du produit est la somme des décimales des deux facteurs.",
			HintLevel2 = "Multipliez les entiers puis placez la virgule avec le bon nombre de chiffres après.",
			ExplanationText = $"{item.Item1} × {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreatePisaAreaOrWeightMultiplicationQuestion()
	{
		var pool = new[]
		{
			(2.5m, 2.40m, 6.00m, "kg de pommes", "€ le kg"),
			(3.2m, 1.50m, 4.80m, "mètres de tissu", "€ le mètre"),
			(4.5m, 2.00m, 9.00m, "kg d'oranges", "€ le kg")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3:F2} €".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m:F2} €".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.60m:F2} €".Replace('.', ',');
		var w3 = $"{item.Item1 + item.Item2:F2} €".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S5-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiplication_decimaux",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"On achète {item.Item1} {item.Item4} à {item.Item2:F2} {item.Item5}. Quel est le montant total ?".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Montant total = Quantité × Prix unitaire.",
			HintLevel2 = $"Multipliez {item.Item1} par {item.Item2:F2}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} × {item.Item2:F2} = {item.Item3:F2} €.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateExactDecimalDivisionQuestion()
	{
		var pool = new[]
		{
			(34.5m, 5, 6.9m),
			(48.6m, 6, 8.1m),
			(25.6m, 4, 6.4m),
			(14.8m, 4, 3.7m),
			(63.9m, 9, 7.1m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m}".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.2m}".Replace('.', ',');
		var w3 = $"{item.Item3 * 10m}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez le quotient exact : {item.Item1}".Replace('.', ',') + $" ÷ {item.Item2}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Placez la virgule au quotient dès que vous descendez le chiffre des dixièmes.",
			HintLevel2 = $"{item.Item2} × {item.Item3} = {item.Item1}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} ÷ {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateDecimalPowerOfTenDivisionQuestion()
	{
		var factors = new[] { 10, 100 };
		var factor = factors[_random.Next(factors.Length)];
		var pool = new[] { 45.8m, 127.4m, 8.9m, 63.2m };
		var val = pool[_random.Next(pool.Length)];
		var quot = val / factor;

		var correct = $"{quot:G29}".Replace('.', ',');
		var w1 = $"{quot * 10m:G29}".Replace('.', ',');
		var w2 = $"{quot / 10m:G29}".Replace('.', ',');
		var w3 = $"{val * factor:G29}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {val}".Replace('.', ',') + $" ÷ {factor}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Diviser par 10 ou 100 revient à décaler la virgule vers la gauche.",
			HintLevel2 = $"Déplacez la virgule de {factor.ToString().Length - 1} rang(s) vers la gauche.",
			ExplanationText = $"{val} ÷ {factor} = {quot}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreateIntegerDivisionToDecimalQuestion()
	{
		var pool = new[]
		{
			(15, 4, 3.75m),
			(27, 5, 5.4m),
			(39, 6, 6.5m),
			(18, 4, 4.5m),
			(7, 2, 3.5m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3}".Replace('.', ',');
		var w1 = $"{item.Item3 + 1m}".Replace('.', ',');
		var w2 = $"{item.Item3 - 0.25m}".Replace('.', ',');
		var w3 = $"{item.Item1 - item.Item2}".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez l'écriture décimale exacte de {item.Item1} ÷ {item.Item2}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Poursuivez la division au-delà des unités en ajoutant des zéros aux dixièmes.",
			HintLevel2 = $"{item.Item2} × {item.Item3} = {item.Item1}.".Replace('.', ','),
			ExplanationText = $"{item.Item1} ÷ {item.Item2} = {item.Item3}.".Replace('.', ',')
		};
	}

	private ExerciseQuestion CreatePisaBillSharingQuestion()
	{
		var pool = new[]
		{
			(68.40m, 4, 17.10m),
			(45.50m, 5, 9.10m),
			(75.60m, 3, 25.20m),
			(52.80m, 4, 13.20m)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item3:F2} €".Replace('.', ',');
		var w1 = $"{item.Item3 + 2m:F2} €".Replace('.', ',');
		var w2 = $"{item.Item3 - 1m:F2} €".Replace('.', ',');
		var w3 = $"{item.Item1 / (item.Item2 + 1):F2} €".Replace('.', ',');
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S6-{Guid.NewGuid():N}",
			SubjectId = "maths_col_division_decimale",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Une addition de restaurant de {item.Item1:F2} € est partagée équitablement entre {item.Item2} amis. Combien paie chacun ?".Replace('.', ','),
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez le montant total par le nombre de personnes.",
			HintLevel2 = $"Calculez {item.Item1:F2} ÷ {item.Item2}.".Replace('.', ','),
			ExplanationText = $"Chacun paie {item.Item1:F2} ÷ {item.Item2} = {item.Item3:F2} €.".Replace('.', ',')
		};
	}
}

