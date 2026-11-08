using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateRandomVariablesQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateExpectationQuestion(),
			1 => GenerateLinearExpectationPropertyQuestion(),
			_ => GenerateVarianceLinearPropertyQuestion()
		};
	}

	private ExerciseQuestion GenerateExpectationQuestion()
	{
		var gain = _random.Next(5, 12);
		var loss = _random.Next(2, 6);
		var pGain = 0.4;
		var pLoss = 0.6;
		var eX = (gain * pGain) - (loss * pLoss);

		var correct = $"{eX:0.00} €";
		var wrong1 = $"{(gain - loss):0.00} €";
		var wrong2 = $"{((gain + loss) / 2.0):0.00} €";
		var wrong3 = "0,00 €";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-EXPX-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-11",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Un jeu permet de gagner {gain} € avec une probabilité de {pGain:0.0} et de perdre {loss} € (gain -{loss} €) avec une probabilité de {pLoss:0.0}. Quelle est l'espérance mathématique E(X) du jeu ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Formule de l'espérance : E(X) = somme(x_i * p_i).",
			HintLevel2 = $"Calculez ({gain} * {pGain:0.0}) + ((-{loss}) * {pLoss:0.0}).",
			ExplanationText = $"E(X) = {gain}*{pGain:0.0} - {loss}*{pLoss:0.0} = {correct}."
		};
	}

	private ExerciseQuestion GenerateLinearExpectationPropertyQuestion()
	{
		var a = _random.Next(2, 5);
		var b = _random.Next(3, 8);
		var eX = _random.Next(2, 6);
		var eY = (a * eX) + b;

		var correct = eY.ToString();
		var wrong1 = (a * eX).ToString();
		var wrong2 = (eX + b).ToString();
		var wrong3 = (a * (eX + b)).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-LINX-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-11",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Sachant que E(X) = {eX}, que vaut l'espérance de la variable aléatoire Y = {a}X + {b} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété de linéarité de l'espérance : E(aX + b) = a * E(X) + b.",
			HintLevel2 = $"Calculez {a} * {eX} + {b}.",
			ExplanationText = $"E({a}X + {b}) = {a} * {eX} + {b} = {eY}."
		};
	}

	private ExerciseQuestion GenerateVarianceLinearPropertyQuestion()
	{
		var a = _random.Next(2, 5);
		var b = _random.Next(3, 8);
		var vx = _random.Next(2, 6);
		var aSq = a * a;
		var vy = aSq * vx;

		var correct = vy.ToString();
		var wrong1 = (a * vx).ToString();
		var wrong2 = (vy + b).ToString();
		var wrong3 = ((a * vx) + b).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-VARX-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-11",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Sachant que la variance V(X) = {vx}, que vaut la variance de Y = {a}X + {b} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Propriété de la variance : V(aX + b) = a² * V(X). La constante b ne modifie pas la dispersion.",
			HintLevel2 = $"Calculez {a}² * {vx} = {aSq} * {vx}.",
			ExplanationText = $"V({a}X + {b}) = {a}² * V(X) = {aSq} * {vx} = {vy}."
		};
	}
}
