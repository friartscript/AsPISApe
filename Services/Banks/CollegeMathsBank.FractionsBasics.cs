using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateFractionBasics()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateFractionVocabularyQuestion(),
			1 => CreateFractionOfQuantityQuestion(),
			2 => CreateFractionQuotientQuestion(),
			_ => CreatePisaPizzaSharingQuestion()
		};
	}

	public ExerciseQuestion GenerateFractionEquality()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateEqualFractionsMultiplierQuestion(),
			1 => CreateMissingFractionNumeratorQuestion(),
			2 => CreateCrossProductEqualityQuestion(),
			_ => CreatePisaEqualDosageQuestion()
		};
	}

	private ExerciseQuestion CreateFractionVocabularyQuestion()
	{
		var pool = new[]
		{
			(3, 7, "3", "Le numérateur", "Le dénominateur", "Le quotient", "Le reste"),
			(5, 8, "8", "Le dénominateur", "Le numérateur", "Le facteur", "Le dividende"),
			(2, 9, "9", "Le dénominateur", "Le numérateur", "La somme", "Le produit")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item4, item.Item5, item.Item6, item.Item7, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans l'écriture fractionnaire {item.Item1}/{item.Item2}, que représente le nombre {item.Item3} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le nombre du haut est le numérateur, le nombre du bas est le dénominateur.",
			HintLevel2 = "Le dénominateur donne le nom des parts et se trouve en bas.",
			ExplanationText = $"Dans une fraction, le terme recherché est {item.Item4.ToLowerInvariant()}."
		};
	}

	private ExerciseQuestion CreateFractionOfQuantityQuestion()
	{
		var pool = new[]
		{
			(3, 4, 28, 21),
			(2, 5, 35, 14),
			(5, 6, 42, 35),
			(3, 8, 48, 18)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4.ToString();
		var w1 = (item.Item4 + 3).ToString();
		var w2 = (item.Item4 - 4).ToString();
		var w3 = (item.Item3 / item.Item2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Calculez les {item.Item1}/{item.Item2} de {item.Item3} :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Prendre une fraction d'un nombre revient à diviser par le dénominateur puis multiplier par le numérateur.",
			HintLevel2 = $"Calculez ({item.Item3} ÷ {item.Item2}) × {item.Item1}.",
			ExplanationText = $"({item.Item3} ÷ {item.Item2}) × {item.Item1} = {item.Item4}."
		};
	}

	private ExerciseQuestion CreateFractionQuotientQuestion()
	{
		var pool = new[]
		{
			(7, 2, "3,5", "3,2", "3,7", "4"),
			(9, 4, "2,25", "2,5", "2,15", "3"),
			(3, 4, "0,75", "0,5", "0,8", "1,25")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est l'écriture décimale exacte de la fraction {item.Item1}/{item.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fraction représente le quotient exact du numérateur par le dénominateur.",
			HintLevel2 = $"Effectuez la division décimale : {item.Item1} ÷ {item.Item2}.",
			ExplanationText = $"{item.Item1}/{item.Item2} est égal à {item.Item3}."
		};
	}

	private ExerciseQuestion CreatePisaPizzaSharingQuestion()
	{
		var pool = new[]
		{
			(8, 3, "5/8", "3/8", "5/5", "1/2"),
			(12, 5, "7/12", "5/12", "7/7", "1/3"),
			(10, 4, "6/10", "4/10", "3/5", "1/2")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S13-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_generalites",
			Discipline = "Mixte",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une tarte est découpée en {item.Item1} parts égales. On en mange {item.Item2}. Quelle fraction de la tarte reste-t-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La tarte entière correspond à la fraction {item.Item1}/{item.Item1}.",
			HintLevel2 = $"Calculez ({item.Item1} - {item.Item2}) / {item.Item1}.",
			ExplanationText = $"Il reste {item.Item1 - item.Item2}/{item.Item1} de la tarte."
		};
	}

	private ExerciseQuestion CreateEqualFractionsMultiplierQuestion()
	{
		var pool = new[]
		{
			(3, 5, 4, "12/20", "7/9", "12/15", "15/20"),
			(2, 7, 3, "6/21", "5/10", "6/14", "8/21"),
			(4, 9, 2, "8/18", "6/11", "8/9", "12/18")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item4, item.Item5, item.Item6, item.Item7, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle fraction est égale à {item.Item1}/{item.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "On obtient une fraction égale en multipliant numérateur et dénominateur par un même nombre.",
			HintLevel2 = $"Multipliez le haut et le bas par {item.Item3}.",
			ExplanationText = $"{item.Item1}/{item.Item2} = ({item.Item1} × {item.Item3})/({item.Item2} × {item.Item3}) = {item.Item4}."
		};
	}

	private ExerciseQuestion CreateMissingFractionNumeratorQuestion()
	{
		var pool = new[]
		{
			(5, 6, 24, 20),
			(3, 8, 32, 12),
			(4, 7, 35, 20),
			(2, 9, 27, 6)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4.ToString();
		var w1 = (item.Item4 + 2).ToString();
		var w2 = (item.Item4 - 3).ToString();
		var w3 = (item.Item1 * 2).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Trouvez le numérateur manquant pour respecter l'égalité : {item.Item1}/{item.Item2} = ?/{item.Item3}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Repérez par quel facteur le dénominateur a été multiplié.",
			HintLevel2 = $"{item.Item2} × {item.Item3 / item.Item2} = {item.Item3}. Multipliez {item.Item1} par ce même facteur.",
			ExplanationText = $"Le facteur multiplicateur est {item.Item3 / item.Item2}, donc le numérateur vaut {item.Item4}."
		};
	}

	private ExerciseQuestion CreateCrossProductEqualityQuestion()
	{
		var pool = new[]
		{
			(6, 9, 8, 12, true),
			(4, 10, 6, 15, true),
			(5, 8, 7, 11, false),
			(3, 7, 5, 12, false)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item5 ? "Oui, car 6×12 = 9×8" : "Non, les produits en croix sont différents";
		var w1 = item.Item5 ? "Non, elles n'ont pas les mêmes chiffres" : "Oui, elles sont presque égales";
		var w2 = "Impossible à déterminer";
		var w3 = "Seulement si le numérateur est supérieur";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Les fractions {item.Item1}/{item.Item2} et {item.Item3}/{item.Item4} sont-elles égales ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux fractions a/b et c/d sont égales si et seulement si a × d = b × c (produit en croix).",
			HintLevel2 = $"Calculez {item.Item1} × {item.Item4} et comparez à {item.Item2} × {item.Item3}.",
			ExplanationText = $"Les produits en croix valent {item.Item1 * item.Item4} et {item.Item2 * item.Item3}."
		};
	}

	private ExerciseQuestion CreatePisaEqualDosageQuestion()
	{
		var pool = new[]
		{
			(2, 5, 100, 40),
			(3, 4, 80, 60),
			(1, 3, 90, 30)
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = $"{item.Item4} cL";
		var w1 = $"{item.Item4 + 10} cL";
		var w2 = $"{item.Item4 - 5} cL";
		var w3 = $"{item.Item3 / 2} cL";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S14-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_egalite",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Une recette demande une proportion de {item.Item1}/{item.Item2} de jus. Pour préparer {item.Item3} cL de boisson, quel volume de jus faut-il ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Appliquez la fraction au volume total ou utilisez l'égalité de fractions.",
			HintLevel2 = $"Calculez ({item.Item1} × {item.Item3}) ÷ {item.Item2}.",
			ExplanationText = $"Il faut {item.Item4} cL de jus pour respecter le dosage."
		};
	}
}

