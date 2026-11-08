using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateRelativeNumbersAdditionSubtraction()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateAddTwoNegativesQuestion(),
			1 => CreateAddOppositeSignsQuestion(),
			2 => CreateSubtractRelativeQuestion(),
			_ => CreatePisaBankBalanceQuestion()
		};
	}

	private ExerciseQuestion CreateAddTwoNegativesQuestion()
	{
		var a = _random.Next(4, 12);
		var b = _random.Next(3, 9);
		var sum = -(a + b);
		var correct = sum.ToString();
		var w1 = (a + b).ToString();
		var w2 = (a - b).ToString();
		var w3 = (b - a).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : (-{a}) + (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour additionner deux nombres négatifs, on garde le signe - et on additionne les distances à zéro.",
			HintLevel2 = $"Gardez le signe négatif et calculez {a} + {b}.",
			ExplanationText = $"(-{a}) + (-{b}) = -({a} + {b}) = {sum}."
		};
	}

	private ExerciseQuestion CreateAddOppositeSignsQuestion()
	{
		var a = _random.Next(6, 15);
		var b = _random.Next(2, a);
		var sum = -a + b;
		var correct = sum.ToString();
		var w1 = (-sum).ToString();
		var w2 = (-(a + b)).ToString();
		var w3 = (a + b).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez : (-{a}) + (+{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "On prend le signe du nombre qui a la plus grande distance à zéro et on soustrait les distances.",
			HintLevel2 = $"{a} > {b}, donc le résultat est négatif : -({a} - {b}).",
			ExplanationText = $"(-{a}) + (+{b}) = -({a} - {b}) = {sum}."
		};
	}

	private ExerciseQuestion CreateSubtractRelativeQuestion()
	{
		var a = _random.Next(3, 10);
		var b = _random.Next(5, 12);
		var diff = a - (-b);
		var correct = diff.ToString();
		var w1 = (a - b).ToString();
		var w2 = (-diff).ToString();
		var w3 = (b - a).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : (+{a}) - (-{b})",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Soustraire un nombre relatif revient à ajouter son opposé.",
			HintLevel2 = $"(+{a}) - (-{b}) = {a} + {b}.",
			ExplanationText = $"Soustraire (-{b}) revient à ajouter {b} : {a} + {b} = {diff}."
		};
	}

	private ExerciseQuestion CreatePisaBankBalanceQuestion()
	{
		var initial = _random.Next(3, 9) * 10;
		var deposit = _random.Next(10, 25) * 10;
		var finalBalance = -initial + deposit;
		var correct = $"+{finalBalance} €";
		var w1 = $"{finalBalance - 50} €";
		var w2 = $"-{initial + deposit} €";
		var w3 = $"+{deposit} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S9-{Guid.NewGuid():N}",
			SubjectId = "maths_col_relatifs_operations",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Un compte en banque affiche un solde débiteur de -{initial} €. Un virement de {deposit} € arrive. Quel est le nouveau solde ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionnez le montant reçu au solde initial : Solde = (-initial) + virement.",
			HintLevel2 = $"Calculez (-{initial}) + {deposit} = {deposit} - {initial}.",
			ExplanationText = $"Nouveau solde = -{initial} + {deposit} = +{finalBalance} €."
		};
	}
}

