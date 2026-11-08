using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateAlgorithmQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateLoopIterationQuestion(),
			1 => GenerateConditionBranchQuestion(),
			_ => GenerateGeometricTraceQuestion()
		};
	}

	public ExerciseQuestion GenerateVariableQuestion()
	{
		var initVal = _random.Next(2, 6);
		var addVal = _random.Next(3, 8);
		var multVal = _random.Next(2, 4);
		var total = (initVal + addVal) * multVal;
		var correct = total.ToString();
		var wrong1 = (initVal + (addVal * multVal)).ToString();
		var wrong2 = (total - 2).ToString();
		var wrong3 = (initVal + addVal).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-VAR-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-033",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Dans un script Scratch : Mettre 'Score' à {initVal} ; Ajouter à 'Score' {addVal} ; Mettre 'Score' à 'Score' × {multVal}. Quelle est la valeur finale de Score ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Suis chaque instruction pas à pas dans l'ordre chronologique en mettant à jour la valeur de la variable.",
			HintLevel2 = $"{initVal} + {addVal} = {initVal + addVal}. Reste à multiplier par {multVal}.",
			ExplanationText = $"Score devient d'abord {initVal + addVal}, puis est multiplié par {multVal} = {total}."
		};
	}

	public ExerciseQuestion GenerateGeometricTraceQuestion()
	{
		var sides = new[]
		{
			("carré", 4, 90, 360),
			("triangle équilatéral", 3, 120, 360),
			("pentagone régulier", 5, 72, 360),
			("hexagone régulier", 6, 60, 360)
		};
		var item = sides[_random.Next(sides.Length)];
		var correct = $"Tourner de {item.Item3} degrés";
		var wrong1 = $"Tourner de {180 - item.Item3} degrés";
		var wrong2 = $"Tourner de {item.Item3 / 2} degrés";
		var wrong3 = "Tourner de 90 degrés";
		if (item.Item2 == 4) wrong3 = "Tourner de 45 degrés";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TRC-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-034",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Pour programmer le tracé d'un {item.Item1} fermé régulier dans Scratch avec une boucle « Répéter {item.Item2} fois », de quel angle extérieur le lutin doit-il tourner à chaque sommet ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un tour complet correspond à 360 degrés. Divise 360 par le nombre de côtés du polygone.",
			HintLevel2 = $"360° divisé par {item.Item2} côtés = {item.Item3}°.",
			ExplanationText = $"Pour un tour complet régulier à {item.Item2} côtés : 360 / {item.Item2} = {item.Item3}°."
		};
	}

	private ExerciseQuestion GenerateLoopIterationQuestion()
	{
		var repeatCount = _random.Next(4, 9);
		var step = _random.Next(10, 30);
		var totalDistance = repeatCount * step;
		var correct = $"{totalDistance} pas";
		var wrong1 = $"{totalDistance - step} pas";
		var wrong2 = $"{repeatCount + step} pas";
		var wrong3 = $"{totalDistance * 2} pas";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-LOOP-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-032",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Un lutin exécute la boucle suivante : « Répéter {repeatCount} fois : Avancer de {step} pas ». De combien de pas a-t-il avancé au total ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une boucle qui répète n fois une action multiplie l'effet par n.",
			HintLevel2 = $"Multiplie le nombre de répétitions ({repeatCount}) par les pas ({step}).",
			ExplanationText = $"{repeatCount} répétitions × {step} pas = {totalDistance} pas."
		};
	}

	private ExerciseQuestion GenerateConditionBranchQuestion()
	{
		var limit = _random.Next(10, 20);
		var testVal = limit + _random.Next(1, 6);
		var correct = "Bravo";
		var wrong1 = "Recommence";
		var wrong2 = "Erreur";
		var wrong3 = "Fin";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-COND-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-032",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Si x = {testVal}, que dit le programme : « Si x > {limit} alors dire 'Bravo' sinon dire 'Recommence' » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Compare la valeur actuelle de x à la condition du test.",
			HintLevel2 = $"{testVal} est strictement supérieur à {limit}, la condition est donc vraie.",
			ExplanationText = $"Comme {testVal} > {limit}, le test est validé et le lutin dit « Bravo »."
		};
	}
}

