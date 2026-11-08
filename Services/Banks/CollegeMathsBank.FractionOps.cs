using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateFractionAdditionSubtraction()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateSameDenominatorAdditionQuestion(),
			1 => CreateSameDenominatorSubtractionQuestion(),
			2 => CreateMultipleDenominatorAdditionQuestion(),
			_ => CreatePisaPaintTankFractionQuestion()
		};
	}

	public ExerciseQuestion GenerateFractionMultiplicationDivision()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateFractionMultiplicationQuestion(),
			1 => CreateFractionByIntegerMultiplicationQuestion(),
			2 => CreateFractionDivisionQuestion(),
			_ => CreatePisaRecipePortionQuestion()
		};
	}

	private ExerciseQuestion CreateSameDenominatorAdditionQuestion()
	{
		var den = _random.Next(5, 12);
		var n1 = _random.Next(1, 4);
		var n2 = _random.Next(1, 4);
		var sum = n1 + n2;
		var correct = $"{sum}/{den}";
		var w1 = $"{sum}/{den * 2}";
		var w2 = $"{n1 * n2}/{den}";
		var w3 = $"{sum + 1}/{den}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {n1}/{den} + {n2}/{den}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour additionner deux fractions de même dénominateur, on additionne les numérateurs.",
			HintLevel2 = $"Le dénominateur reste {den}. Calculez {n1} + {n2}.",
			ExplanationText = $"On conserve le dénominateur {den} : {n1} + {n2} = {sum}/{den}."
		};
	}

	private ExerciseQuestion CreateSameDenominatorSubtractionQuestion()
	{
		var den = _random.Next(6, 13);
		var n1 = _random.Next(4, 8);
		var n2 = _random.Next(1, 4);
		var diff = n1 - n2;
		var correct = $"{diff}/{den}";
		var w1 = $"{diff}/0";
		var w2 = $"{n1 + n2}/{den}";
		var w3 = $"{diff}/{den * 2}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : {n1}/{den} - {n2}/{den}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour soustraire deux fractions de même dénominateur, on soustrait les numérateurs.",
			HintLevel2 = $"Le dénominateur reste {den}. Calculez {n1} - {n2}.",
			ExplanationText = $"On garde le dénominateur commun {den} : {n1} - {n2} = {diff}/{den}."
		};
	}

	private ExerciseQuestion CreateMultipleDenominatorAdditionQuestion()
	{
		var pool = new[]
		{
			(1, 3, 2, 6, "4/6 = 2/3"),
			(1, 4, 3, 8, "5/8"),
			(2, 5, 3, 10, "7/10"),
			(1, 2, 1, 6, "4/6 = 2/3")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5;
		var w1 = "4/9";
		var w2 = "3/7";
		var w3 = "5/12";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1}/{item.Item2} + {item.Item3}/{item.Item4}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Mettez les fractions au même dénominateur avant d'additionner les numérateurs.",
			HintLevel2 = $"{item.Item4} est un multiple de {item.Item2}. Multipliez le haut et le bas de la première fraction.",
			ExplanationText = $"Après mise au même dénominateur, le résultat vaut {correct}."
		};
	}

	private ExerciseQuestion CreatePisaPaintTankFractionQuestion()
	{
		var pool = new[]
		{
			(1, 4, 1, 2, "1/4", "3/4", "1/8", "1/3"),
			(2, 5, 1, 5, "2/5", "3/5", "1/5", "1/2"),
			(1, 3, 1, 6, "1/2", "2/9", "1/6", "3/4")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item5, item.Item6, item.Item7, item.Item8, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S16-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_add_sous",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Un peintre utilise {item.Item1}/{item.Item2} de son pot le matin et {item.Item3}/{item.Item4} l'après-midi. Quelle fraction du pot reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Faites la somme des fractions consommées puis soustrayez à 1.",
			HintLevel2 = "Mettez au même dénominateur pour faire l'addition puis déduisez le reste.",
			ExplanationText = $"Il reste la fraction {item.Item5} du pot de peinture."
		};
	}

	private ExerciseQuestion CreateFractionMultiplicationQuestion()
	{
		var pool = new[]
		{
			(2, 3, 4, 5, "8/15"),
			(3, 4, 1, 5, "3/20"),
			(5, 7, 2, 3, "10/21"),
			(1, 2, 3, 4, "3/8")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5;
		var w1 = $"{item.Item1 + item.Item3}/{item.Item2 + item.Item4}";
		var w2 = $"{item.Item1 * item.Item3}/{item.Item2 + item.Item4}";
		var w3 = $"{item.Item1}/{item.Item2 * item.Item4}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez le produit : ({item.Item1}/{item.Item2}) × ({item.Item3}/{item.Item4})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour multiplier deux fractions, on multiplie les numérateurs entre eux et les dénominateurs entre eux.",
			HintLevel2 = $"Calculez ({item.Item1} × {item.Item3}) / ({item.Item2} × {item.Item4}).",
			ExplanationText = $"Produit des numérateurs sur produit des dénominateurs = {correct}."
		};
	}

	private ExerciseQuestion CreateFractionByIntegerMultiplicationQuestion()
	{
		var pool = new[]
		{
			(4, 2, 7, "8/7"),
			(3, 5, 8, "15/8"),
			(5, 3, 11, "15/11"),
			(2, 4, 9, "8/9")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4;
		var w1 = $"{item.Item1 * item.Item2}/{item.Item1 * item.Item3}";
		var w2 = $"{item.Item2}/{item.Item3 * item.Item1}";
		var w3 = $"{item.Item1 + item.Item2}/{item.Item3}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1} × ({item.Item2}/{item.Item3})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multiplier un entier par une fraction revient à multiplier uniquement le numérateur par cet entier.",
			HintLevel2 = $"Calculez ({item.Item1} × {item.Item2}) / {item.Item3}.",
			ExplanationText = $"{item.Item1} × {item.Item2}/{item.Item3} = ({item.Item1} × {item.Item2})/{item.Item3} = {correct}."
		};
	}

	private ExerciseQuestion CreateFractionDivisionQuestion()
	{
		var pool = new[]
		{
			(2, 3, 5, 7, "14/15"),
			(3, 4, 2, 5, "15/8"),
			(1, 2, 3, 5, "5/6"),
			(4, 5, 3, 2, "8/15")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5;
		var w1 = $"{item.Item1 * item.Item3}/{item.Item2 * item.Item4}";
		var w2 = $"{item.Item1}/{item.Item3}";
		var w3 = "1/2";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Calculez le quotient : ({item.Item1}/{item.Item2}) ÷ ({item.Item3}/{item.Item4})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Diviser par une fraction revient à multiplier par son inverse.",
			HintLevel2 = $"Inversez la deuxième fraction : ({item.Item1}/{item.Item2}) × ({item.Item4}/{item.Item3}).",
			ExplanationText = $"On multiplie par l'inverse de la seconde fraction : {correct}."
		};
	}

	private ExerciseQuestion CreatePisaRecipePortionQuestion()
	{
		var pool = new[]
		{
			(3, 4, 1, 2, "3/8 de litre", "1/2 de litre", "3/4 de litre", "1/4 de litre"),
			(2, 3, 3, 4, "1/2 de litre", "5/7 de litre", "2/3 de litre", "1/3 de litre"),
			(4, 5, 1, 2, "2/5 de litre", "3/5 de litre", "1/5 de litre", "4/10 de litre")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item5, item.Item6, item.Item7, item.Item8, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S17-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_mult_div",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Une bouteille contient {item.Item1}/{item.Item2} de litre de jus. On en consomme la moitié ({item.Item1}/{item.Item2} × {item.Item3}/{item.Item4}). Quel volume a été bu ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Prendre la moitié d'une quantité revient à la multiplier par 1/2.",
			HintLevel2 = $"Calculez ({item.Item1} × 1) / ({item.Item2} × 2).",
			ExplanationText = $"Le volume bu correspond à {item.Item5}."
		};
	}
}

