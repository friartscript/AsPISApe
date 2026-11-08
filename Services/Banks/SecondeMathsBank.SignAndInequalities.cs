using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateSignAndInequalitiesQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateAffineFunctionSignQuestion(),
			1 => GenerateProductSignTableQuestion(),
			_ => GenerateQuotientSignTableQuestion()
		};
	}

	private ExerciseQuestion GenerateAffineFunctionSignQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(2, 8);
		var root = b;
		var factor = a;

		var correct = $"Strictement négative sur ]-∞ ; {root}], puis strictement positive sur [{root} ; +∞[";
		var wrong1 = $"Strictement positive sur ]-∞ ; {root}], puis négative";
		var wrong2 = "Toujours strictement positive sur R";
		var wrong3 = $"Strictement négative sur tout R sauf en x = -{root}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-SGN-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-10",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quel est le signe de la fonction affine f(x) = {factor}x - {factor * root} sur R ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une fonction affine ax + b est du signe de a pour x supérieur à la racine -b/a.",
			HintLevel2 = $"La racine est x = {root} et le coefficient a = {factor} > 0.",
			ExplanationText = $"a > 0 donc f est négative avant la racine {root} et positive après."
		};
	}

	private ExerciseQuestion GenerateProductSignTableQuestion()
	{
		var r1 = _random.Next(1, 4);
		var r2 = r1 + _random.Next(2, 5);

		var correct = $"S = ]-∞ ; {r1}] ∪ [{r2} ; +∞[";
		var wrong1 = $"S = [{r1} ; {r2}]";
		var wrong2 = $"S = [{-r2} ; {-r1}]";
		var wrong3 = $"S = ]-∞ ; {r1}[";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-PRDS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-10",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Résolvez dans R l'inéquation produit : (x - {r1})(x - {r2}) ≥ 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Dressez un tableau de signes avec les deux racines rangées dans l'ordre croissant.",
			HintLevel2 = $"Le produit de deux facteurs de même signe est positif : à l'extérieur des racines {r1} et {r2}.",
			ExplanationText = $"Le produit est positif à l'extérieur des racines [{r1} ; {r2}]."
		};
	}

	private ExerciseQuestion GenerateQuotientSignTableQuestion()
	{
		var numRoot = _random.Next(1, 4);
		var denomRoot = numRoot + _random.Next(2, 5);

		var correct = $"S = [{numRoot} ; {denomRoot}[";
		var wrong1 = $"S = [{numRoot} ; {denomRoot}]";
		var wrong2 = $"S = ]-∞ ; {numRoot}] ∪ ]{denomRoot} ; +∞[";
		var wrong3 = "S = ]-∞ ; +∞[";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-QTS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-10",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Résolvez l'inéquation quotient : (x - {numRoot}) / (x - {denomRoot}) ≤ 0.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention à la valeur interdite qui annule le dénominateur : crochet obligatoirement ouvert.",
			HintLevel2 = $"{numRoot} est solution car le quotient peut être nul, mais {denomRoot} est strictement exclu.",
			ExplanationText = $"Le quotient est négatif entre les racines avec la valeur interdite {denomRoot} exclue."
		};
	}
}
