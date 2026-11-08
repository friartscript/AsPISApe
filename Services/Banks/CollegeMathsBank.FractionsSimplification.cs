using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateFractionSimplification()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateIrreducibleFractionQuestion(),
			1 => CreateDivideByCommonFactorQuestion(),
			2 => CreateRecognizeIrreducibleQuestion(),
			_ => CreatePisaSimplifiedProportionQuestion()
		};
	}

	private ExerciseQuestion CreateIrreducibleFractionQuestion()
	{
		var pool = new[]
		{
			(18, 24, "3/4", "6/8", "9/12", "1/2"),
			(28, 42, "2/3", "4/6", "14/21", "1/3"),
			(35, 50, "7/10", "5/10", "14/20", "3/5"),
			(45, 60, "3/4", "9/12", "15/20", "5/6")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la forme irréductible de la fraction {item.Item1}/{item.Item2} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez le numérateur et le dénominateur par leur plus grand commun diviseur (PGCD).",
			HintLevel2 = "Une fraction est irréductible si son numérateur et son dénominateur sont premiers entre eux.",
			ExplanationText = $"La forme simplifiée au maximum est {item.Item3}."
		};
	}

	private ExerciseQuestion CreateDivideByCommonFactorQuestion()
	{
		var pool = new[]
		{
			(24, 36, 12, "2/3"),
			(30, 45, 15, "2/3"),
			(40, 56, 8, "5/7"),
			(21, 49, 7, "3/7")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item4;
		var w1 = "1/2";
		var w2 = "3/4";
		var w3 = "4/5";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Simplifiez la fraction {item.Item1}/{item.Item2} par {item.Item3} :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Divisez le numérateur par {item.Item3} et le dénominateur par {item.Item3}.",
			HintLevel2 = $"{item.Item1} ÷ {item.Item3} = {item.Item1 / item.Item3} et {item.Item2} ÷ {item.Item3} = {item.Item2 / item.Item3}.",
			ExplanationText = $"{item.Item1}/{item.Item2} simplifié par {item.Item3} donne {correct}."
		};
	}

	private ExerciseQuestion CreateRecognizeIrreducibleQuestion()
	{
		var pool = new[]
		{
			("7/11", "6/9", "15/25", "14/21"),
			("5/9", "8/12", "10/15", "12/18"),
			("11/13", "9/15", "14/28", "20/30")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item1, item.Item2, item.Item3, item.Item4, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = "Parmi ces fractions, laquelle est déjà irréductible ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fraction est irréductible lorsqu'on ne peut plus simplifier par aucun entier autre que 1.",
			HintLevel2 = "Vérifiez si les deux termes n'ont aucun diviseur commun supérieur à 1.",
			ExplanationText = $"{item.Item1} est irréductible car son numérateur et son dénominateur sont premiers entre eux."
		};
	}

	private ExerciseQuestion CreatePisaSimplifiedProportionQuestion()
	{
		var pool = new[]
		{
			(16, 24, "2 élèves sur 3", "1 élève sur 2", "3 élèves sur 4", "4 élèves sur 5"),
			(15, 20, "3 élèves sur 4", "2 élèves sur 3", "1 élève sur 2", "4 élèves sur 5"),
			(12, 18, "2 élèves sur 3", "1 élève sur 3", "3 élèves sur 5", "5 élèves sur 6")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S15-{Guid.NewGuid():N}",
			SubjectId = "maths_col_fractions_simplification",
			Discipline = "Mixte",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans une classe de {item.Item2} élèves, {item.Item1} pratiquent une activité sportive. Sous forme simplifiée, quelle est cette proportion ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Écrivez la fraction {item.Item1}/{item.Item2} puis simplifiez-la au maximum.",
			HintLevel2 = "Divisez le haut et le bas par leur plus grand diviseur commun.",
			ExplanationText = $"La proportion simplifiée correspond à {item.Item3}."
		};
	}
}

