using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateAlgorithmChapterQuestion()
	{
		var variant = _random.Next(5);
		return variant switch
		{
			0 => GeneratePythonForLoopQuestion(),
			1 => GeneratePythonWhileLoopQuestion(),
			2 => GeneratePythonConditionalQuestion(),
			3 => GeneratePythonVariableTypesQuestion(),
			_ => GeneratePythonFunctionQuestion()
		};
	}

	private ExerciseQuestion GeneratePythonForLoopQuestion()
	{
		var n = _random.Next(3, 7);
		var step = _random.Next(2, 5);
		var total = 0;
		for (var i = 0; i < n; i++)
		{
			total += step;
		}

		var correct = total.ToString();
		var wrong1 = (total + step).ToString();
		var wrong2 = (total - step).ToString();
		var wrong3 = (n * (n + 1) / 2).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-ALG-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-01",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Que vaut la variable s après l'exécution de ce code Python ?\ns = 0\nfor i in range({n}):\n    s = s + {step}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La boucle range(n) effectue n répétitions de 0 à n-1.",
			HintLevel2 = $"On ajoute {step} exactement {n} fois.",
			ExplanationText = $"La boucle tourne {n} fois : {n} * {step} = {total}."
		};
	}

	private ExerciseQuestion GeneratePythonWhileLoopQuestion()
	{
		var init = _random.Next(10, 25);
		var threshold = _random.Next(70, 120);
		var multiplier = 2;

		var val = init;
		var count = 0;
		while (val < threshold)
		{
			val *= multiplier;
			count++;
		}

		var correct = count.ToString();
		var wrong1 = (count + 1).ToString();
		var wrong2 = Math.Max(1, count - 1).ToString();
		var wrong3 = (count + 2).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-WHL-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-01",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Une colonie de bactéries compte {init} individus et double à chaque étape. Combien d'itérations effectue la boucle ?\nu = {init}\nn = 0\nwhile u < {threshold}:\n    u = u * 2\n    n = n + 1",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calculez les valeurs successives de u jusqu'à dépasser le seuil.",
			HintLevel2 = $"Multipliez {init} par 2 successivement jusqu'à atteindre au moins {threshold}.",
			ExplanationText = $"La condition u < {threshold} devient fausse après {count} itérations."
		};
	}

	private ExerciseQuestion GeneratePythonConditionalQuestion()
	{
		var price = _random.Next(30, 90);
		var discountThreshold = 50;
		var finalPrice = price > discountThreshold ? price - 10 : price;

		var correct = $"{finalPrice} €";
		var wrong1 = $"{price} €";
		var wrong2 = $"{price - 10} €";
		var wrong3 = $"{finalPrice + 5} €";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-IF-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-01",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quel montant affiche le programme pour un panier p = {price} ?\nif p > {discountThreshold}:\n    p = p - 10\nprint(p)",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Vérifiez si la condition if est vraie ou fausse pour ce panier.",
			HintLevel2 = price > discountThreshold ? $"Comme {price} > {discountThreshold}, la réduction s'applique." : $"Comme {price} <= {discountThreshold}, pas de remise.",
			ExplanationText = $"Condition validée ou non, le résultat est {finalPrice} €."
		};
	}

	private ExerciseQuestion GeneratePythonVariableTypesQuestion()
	{
		var types = new[] { ("7 / 2", "float", "int", "bool", "str"), ("\"3.14\"", "str", "float", "int", "list"), ("5 == 5", "bool", "int", "str", "float"), ("4 * 3", "int", "float", "tuple", "str") };
		var pick = types[_random.Next(types.Length)];

		var choices = Shuffle(pick.Item2, pick.Item3, pick.Item4, pick.Item5, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-TYP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-01",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"En Python, quel est le type de l'expression : type({pick.Item1}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "float désigne les réels, int les entiers, str le texte et bool un booléen.",
			HintLevel2 = $"L'expression {pick.Item1} produit une valeur de ce type.",
			ExplanationText = $"{pick.Item1} est de type {pick.Item2} en Python."
		};
	}

	private ExerciseQuestion GeneratePythonFunctionQuestion()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(1, 9);
		var x = _random.Next(2, 6);
		var res = (a * x) + b;

		var correct = res.ToString();
		var wrong1 = (res + a).ToString();
		var wrong2 = ((a + b) * x).ToString();
		var wrong3 = (res - b).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-FCT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-01",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Que renvoie l'appel f({x}) pour cette fonction Python ?\ndef f(x):\n    return {a} * x + {b}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Remplacez l'argument x par sa valeur dans le corps de la fonction.",
			HintLevel2 = $"Calculez {a} * {x} + {b}.",
			ExplanationText = $"f({x}) = {a} * {x} + {b} = {res}."
		};
	}
}
