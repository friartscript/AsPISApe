using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateStatisticsQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateInterquartileRangeQuestion(),
			1 => GenerateStandardDeviationInterpretationQuestion(),
			2 => GenerateMedianDiscreteSeriesQuestion(),
			_ => GenerateWeightedMeanQuestion()
		};
	}

	private ExerciseQuestion GenerateInterquartileRangeQuestion()
	{
		var q1 = _random.Next(8, 12);
		var q3 = q1 + _random.Next(4, 9);
		var iqr = q3 - q1;

		var correct = $"{iqr}";
		var wrong1 = $"{q3 + q1}";
		var wrong2 = $"{(q3 + q1) / 2}";
		var wrong3 = $"{iqr + 2}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-IQR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-12",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Une étude statistique donne un premier quartile Q1 = {q1} et un troisième quartile Q3 = {q3}. Quel est l'écart interquartile de la série ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Par définition, l'écart interquartile est la différence : Q3 - Q1.",
			HintLevel2 = $"Calculez simplement {q3} - {q1}.",
			ExplanationText = $"Écart interquartile = Q3 - Q1 = {q3} - {q1} = {iqr}."
		};
	}

	private ExerciseQuestion GenerateStandardDeviationInterpretationQuestion()
	{
		var correct = "Mesure la dispersion des valeurs autour de la moyenne";
		var wrong1 = "Donne la valeur du milieu de la série ordonnée";
		var wrong2 = "Est égal à la différence entre la plus grande et la plus petite valeur";
		var wrong3 = "Représente la valeur la plus fréquente de la série";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-STD-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-12",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = "En statistiques descriptives de Seconde, que mesure concrètement l'écart-type noté σ ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'écart-type est la racine carrée de la variance.",
			HintLevel2 = "Plus l'écart-type est faible, plus les valeurs sont resserrées autour de la moyenne.",
			ExplanationText = "L'écart-type mesure la dispersion des valeurs autour de la moyenne arithmétique."
		};
	}

	private ExerciseQuestion GenerateMedianDiscreteSeriesQuestion()
	{
		var med = _random.Next(10, 16);
		var v1 = med - 4;
		var v2 = med - 2;
		var v4 = med + 2;
		var v5 = med + 5;

		var correct = $"{med}";
		var wrong1 = $"{med - 1}";
		var wrong2 = $"{(v1 + v5) / 2}";
		var wrong3 = $"{v2}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-MED-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-12",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quelle est la médiane de la série statistique ordonnée suivante : {v1} ; {v2} ; {med} ; {v4} ; {v5} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pour un effectif impair N = 5, la médiane est la (N+1)/2 = 3e valeur.",
			HintLevel2 = $"La 3e valeur de la liste ordonnée est {med}.",
			ExplanationText = $"La médiane est la valeur centrale : {med}."
		};
	}

	private ExerciseQuestion GenerateWeightedMeanQuestion()
	{
		var n1 = 10;
		var c1 = 2;
		var n2 = 14;
		var c2 = 3;
		var sumWeighted = (n1 * c1) + (n2 * c2);
		var totalCoef = c1 + c2;
		var mean = (double)sumWeighted / totalCoef;

		var correct = $"{mean:0.0}";
		var wrong1 = $"{(n1 + n2) / 2.0:0.0}";
		var wrong2 = $"{mean + 1:0.0}";
		var wrong3 = $"{mean - 1:0.0}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-MEA-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-12",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Un élève obtient la note {n1} (coefficient {c1}) et la note {n2} (coefficient {c2}). Quelle est sa moyenne pondérée ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Moyenne pondérée = somme(note * coeff) / somme(coeff).",
			HintLevel2 = $"({n1} * {c1} + {n2} * {c2}) / ({c1} + {c2}) = ({n1 * c1} + {n2 * c2}) / {totalCoef}.",
			ExplanationText = $"Moyenne pondérée = {sumWeighted} / {totalCoef} = {mean:0.0}."
		};
	}
}
