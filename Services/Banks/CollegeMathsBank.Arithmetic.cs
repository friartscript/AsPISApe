using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateEuclideanDivision()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateFindRemainderQuestion(),
			1 => CreateFindQuotientQuestion(),
			2 => CreateFindDividendQuestion(),
			_ => CreatePisaPackagingQuestion()
		};
	}

	public ExerciseQuestion GenerateMultiplesAndDivisors()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateDivisibilityByThreeOrNineQuestion(),
			1 => CreateDivisibilityByTwoFiveTenQuestion(),
			2 => CreateCommonDivisorQuestion(),
			_ => CreatePisaGroupingQuestion()
		};
	}

	private ExerciseQuestion CreateFindRemainderQuestion()
	{
		var divisor = _random.Next(6, 15);
		var quotient = _random.Next(8, 25);
		var remainder = _random.Next(1, divisor);
		var dividend = (divisor * quotient) + remainder;

		var correct = remainder.ToString();
		var w1 = (remainder + 1).ToString();
		var w2 = quotient.ToString();
		var w3 = (divisor - 1).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans la division euclidienne de {dividend} par {divisor}, quel est le reste ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Dividende = (Diviseur × Quotient) + Reste, avec 0 ≤ Reste < Diviseur.",
			HintLevel2 = $"{dividend} = ({divisor} × {quotient}) + Reste. Soustrayez {divisor * quotient} à {dividend}.",
			ExplanationText = $"{dividend} = {divisor} × {quotient} + {remainder}. Le reste est {remainder}."
		};
	}

	private ExerciseQuestion CreateFindQuotientQuestion()
	{
		var divisor = _random.Next(5, 12);
		var quotient = _random.Next(10, 30);
		var remainder = _random.Next(1, divisor);
		var dividend = (divisor * quotient) + remainder;

		var correct = quotient.ToString();
		var w1 = (quotient - 1).ToString();
		var w2 = (quotient + 2).ToString();
		var w3 = remainder.ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans la division euclidienne de {dividend} par {divisor}, quel est le quotient entier ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le quotient est le plus grand nombre de fois que le diviseur rentre dans le dividende.",
			HintLevel2 = $"{divisor} × {quotient} = {divisor * quotient} ≤ {dividend}.",
			ExplanationText = $"{dividend} = {divisor} × {quotient} + {remainder}. Le quotient est {quotient}."
		};
	}

	private ExerciseQuestion CreateFindDividendQuestion()
	{
		var divisor = _random.Next(4, 11);
		var quotient = _random.Next(7, 20);
		var remainder = _random.Next(1, divisor);
		var dividend = (divisor * quotient) + remainder;

		var correct = dividend.ToString();
		var w1 = (dividend + 2).ToString();
		var w2 = (divisor * quotient).ToString();
		var w3 = (dividend - remainder).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans une division euclidienne, le diviseur est {divisor}, le quotient est {quotient} et le reste est {remainder}. Quel est le dividende ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Dividende = Diviseur × Quotient + Reste.",
			HintLevel2 = $"Calculez ({divisor} × {quotient}) + {remainder}.",
			ExplanationText = $"Dividende = ({divisor} × {quotient}) + {remainder} = {dividend}."
		};
	}

	private ExerciseQuestion CreatePisaPackagingQuestion()
	{
		var capacity = _random.Next(6, 13);
		var items = _random.Next(50, 120);
		var boxes = items / capacity;
		var leftOver = items % capacity;

		var correct = $"{boxes} boîtes pleines (reste {leftOver})";
		var w1 = $"{boxes + 1} boîtes pleines (reste 0)";
		var w2 = $"{boxes - 1} boîtes pleines (reste {leftOver + capacity})";
		var w3 = $"{boxes} boîtes pleines (reste {leftOver + 1})";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S1-{Guid.NewGuid():N}",
			SubjectId = "maths_col_div_euclidienne",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une usine conditionne {items} objets dans des cartons pouvant en contenir {capacity} chacun. Combien de cartons complets remplit-on et combien d'objets reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Effectuez la division euclidienne du nombre total d'objets par la capacité d'un carton.",
			HintLevel2 = $"{items} = ({capacity} × {boxes}) + {leftOver}.",
			ExplanationText = $"{items} ÷ {capacity} donne {boxes} cartons pleins et il reste {leftOver} objets."
		};
	}

	private ExerciseQuestion CreateDivisibilityByThreeOrNineQuestion()
	{
		var baseVal = _random.Next(15, 80) * 9;
		var correct = $"{baseVal} (somme des chiffres = multiple de 9)";
		var w1 = $"{baseVal + 1}";
		var w2 = $"{baseVal + 2}";
		var w3 = $"{baseVal + 4}";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = "Lequel de ces nombres est divisible par 9 ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un nombre est divisible par 9 si la somme de ses chiffres est un multiple de 9.",
			HintLevel2 = "Additionnez les chiffres de chaque proposition.",
			ExplanationText = $"La somme des chiffres de {baseVal} est un multiple de 9."
		};
	}

	private ExerciseQuestion CreateDivisibilityByTwoFiveTenQuestion()
	{
		var lastDigits = new[] { 0, 5 };
		var digit = lastDigits[_random.Next(lastDigits.Length)];
		var candidate = (_random.Next(12, 90) * 10) + digit;

		var correct = digit == 0 ? "Divisible par 2, 5 et 10" : "Divisible par 5 uniquement";
		var w1 = "Divisible par 2 uniquement";
		var w2 = "Divisible par 3";
		var w3 = "Divisible par aucun";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Le nombre {candidate} se termine par {digit}. Que peut-on affirmer ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un nombre terminé par 0 est divisible par 2, 5 et 10. Terminé par 5, il est divisible par 5.",
			HintLevel2 = $"Examinez uniquement le chiffre des unités ({digit}).",
			ExplanationText = $"{candidate} se termine par {digit}, donc {correct.ToLowerInvariant()}."
		};
	}

	private ExerciseQuestion CreateCommonDivisorQuestion()
	{
		var pairs = new[]
		{
			(24, 36, 12, 8, 5, 7),
			(30, 45, 15, 10, 8, 4),
			(42, 70, 14, 12, 9, 6),
			(36, 60, 12, 18, 8, 5)
		};
		var p = pairs[_random.Next(pairs.Length)];
		var choices = Shuffle(p.Item3.ToString(), p.Item4.ToString(), p.Item5.ToString(), p.Item6.ToString(), out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quel est le plus grand commun diviseur (PGCD) de {p.Item1} et {p.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Cherchez le plus grand nombre qui divise à la fois les deux entiers sans reste.",
			HintLevel2 = $"{p.Item1} = {p.Item3} × {p.Item1 / p.Item3} et {p.Item2} = {p.Item3} × {p.Item2 / p.Item3}.",
			ExplanationText = $"Le plus grand diviseur commun à {p.Item1} et {p.Item2} est {p.Item3}."
		};
	}

	private ExerciseQuestion CreatePisaGroupingQuestion()
	{
		var groups = _random.Next(4, 9);
		var pensPerGroup = _random.Next(5, 12);
		var total = groups * pensPerGroup;

		var correct = $"{pensPerGroup} stylos";
		var w1 = $"{pensPerGroup + 2} stylos";
		var w2 = $"{pensPerGroup - 1} stylos";
		var w3 = $"{pensPerGroup + 4} stylos";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S2-{Guid.NewGuid():N}",
			SubjectId = "maths_col_multiples_diviseurs",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une association répartit équitablement {total} stylos dans {groups} trousses identiques sans qu'il n'en reste. Combien de stylos contient chaque trousse ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Puisqu'il n'y a pas de reste, le nombre cherché est le diviseur exact de la division.",
			HintLevel2 = $"Calculez {total} ÷ {groups}.",
			ExplanationText = $"{total} ÷ {groups} = {pensPerGroup} stylos par trousse."
		};
	}
}

