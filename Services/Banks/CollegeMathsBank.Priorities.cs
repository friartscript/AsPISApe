using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateCalculationPriorities()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreatePriorityMultiplicationOverAdditionQuestion(),
			1 => CreatePriorityParenthesesQuestion(),
			2 => CreatePriorityDivisionAndSubtractionQuestion(),
			_ => CreatePisaInvoicingPriorityQuestion()
		};
	}

	private ExerciseQuestion CreatePriorityMultiplicationOverAdditionQuestion()
	{
		var pool = new[]
		{
			("5 + 3 × (-4)", "-7", "-32", "17", "-2"),
			("12 - 2 × (-5)", "22", "-50", "2", "-8"),
			("8 + (-4) × 3", "-4", "12", "-36", "4"),
			("15 - 3 × 6", "-3", "72", "-21", "3")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"En respectant les priorités opératoires, calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La multiplication est toujours prioritaire sur l'addition et la soustraction.",
			HintLevel2 = "Effectuez d'abord le produit avant d'additionner ou soustraire.",
			ExplanationText = $"En appliquant la priorité de la multiplication, on trouve {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePriorityParenthesesQuestion()
	{
		var pool = new[]
		{
			("(-2) × (7 - 12)", "10", "-10", "-26", "5"),
			("3 × (4 - 9)", "-15", "15", "-21", "-3"),
			("(-4) × (2 - 8)", "24", "-24", "0", "-16"),
			("5 × (-3 - 4)", "-35", "35", "-11", "-7")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les calculs entre parenthèses sont strictement prioritaires.",
			HintLevel2 = "Calculez d'abord la parenthèse, puis multipliez le résultat.",
			ExplanationText = $"Après calcul de la parenthèse et multiplication : {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePriorityDivisionAndSubtractionQuestion()
	{
		var pool = new[]
		{
			("20 - 15 ÷ (-3)", "25", "15", "-5", "3"),
			("18 + (-24) ÷ 6", "14", "-7", "22", "-1"),
			("30 - (-16) ÷ (-4)", "26", "34", "-4", "10"),
			("10 + 20 ÷ (-5)", "6", "-6", "-2", "14")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La division est prioritaire sur l'addition et la soustraction.",
			HintLevel2 = "Effectuez d'abord le quotient avec la règle des signes.",
			ExplanationText = $"En effectuant la division en premier, on obtient {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaInvoicingPriorityQuestion()
	{
		var pool = new[]
		{
			(4, 15, 3, 5, 45),
			(5, 12, 2, 8, 44),
			(3, 20, 4, 6, 36)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item5} €";
		var w1 = $"{item.Item5 + 10} €";
		var w2 = $"{item.Item5 - 8} €";
		var w3 = $"{item.Item1 * item.Item2} €";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S12-{Guid.NewGuid():N}",
			SubjectId = "maths_col_priorites_operatoires",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"Un groupe achète {item.Item1} billets à {item.Item2} € et bénéficie d'un bon de réduction de {item.Item3} × {item.Item4} €. Quel est le montant final ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Montant = ({item.Item1} × {item.Item2}) - ({item.Item3} × {item.Item4}).",
			HintLevel2 = $"Calculez {item.Item1 * item.Item2} - {item.Item3 * item.Item4}.",
			ExplanationText = $"Montant final = {item.Item1 * item.Item2} - {item.Item3 * item.Item4} = {item.Item5} €."
		};
	}
}

