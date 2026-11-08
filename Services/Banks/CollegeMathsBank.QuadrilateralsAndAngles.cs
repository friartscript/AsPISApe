using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateParallelogramPropertiesQuestion()
	{
		var properties = new[]
		{
			("ses diagonales se coupent en leur milieu", "un parallélogramme", "un trapèze quelconque", "un triangle", "un pentagone"),
			("ses diagonales sont perpendiculaires et ont le même milieu", "un losange", "un rectangle non carré", "un trapèze", "un parallélogramme quelconque"),
			("ses diagonales ont la même longueur et le même milieu", "un rectangle", "un losange non carré", "un parallélogramme quelconque", "un cerf-volant"),
			("ses diagonales sont perpendiculaires, ont la même longueur et le même milieu", "un carré", "un losange non rectangle", "un rectangle non losange", "un trapèze isocèle")
		};
		var item = properties[_random.Next(properties.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-QUAD-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-081",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Si un quadrilatère a {item.Item1}, alors c'est nécessairement :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Rappelle-toi les propriétés spécifiques des diagonales : losange (perpendiculaires), rectangle (égales), carré (les deux).",
			HintLevel2 = $"Cette propriété caractéristique des diagonales définit : {item.Item2}.",
			ExplanationText = $"Un quadrilatère dont {item.Item1} est {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateOppositeAnglesQuestion()
	{
		var angle = _random.Next(25, 75);
		var correct = $"{angle}°";
		var wrong1 = $"{180 - angle}°";
		var wrong2 = $"{90 - angle}°";
		var wrong3 = $"{angle * 2}°";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-OPPANG-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-087",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Deux droites sécantes forment quatre angles. Si l'un des angles mesure {angle}°, quelle est la mesure de l'angle qui lui est opposé par le sommet ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux angles opposés par le sommet ont toujours exactement la même mesure.",
			HintLevel2 = $"L'angle opposé par le sommet mesure donc {angle}°.",
			ExplanationText = $"Deux angles opposés par le sommet sont égaux : ils mesurent tous deux {angle}°."
		};
	}

	public ExerciseQuestion GenerateAlternateInteriorAnglesQuestion()
	{
		var angle = _random.Next(35, 80);
		var correct = $"{angle}° (ils sont alternes-internes et de même mesure)";
		var wrong1 = $"{180 - angle}° (ils sont supplémentaires)";
		var wrong2 = $"{90 - angle}° (ils sont complémentaires)";
		var wrong3 = "On ne peut pas savoir sans connaître la distance";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-ALTINT-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-087",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Deux droites parallèles (d1) et (d2) sont coupées par une sécante (s). Si un angle alterne-interne mesure {angle}°, que mesure son angle alterne-interne associé ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Lorsque deux droites parallèles sont coupées par une même sécante, les angles alternes-internes ont la même mesure.",
			HintLevel2 = $"Les droites étant parallèles, les deux angles alternes-internes sont égaux à {angle}°.",
			ExplanationText = $"Deux droites parallèles coupées par une sécante forment des angles alternes-internes égaux ({angle}°)."
		};
	}

	public ExerciseQuestion GenerateSupplementaryAnglesQuestion()
	{
		var angle = _random.Next(40, 85);
		var supp = 180 - angle;
		var correct = $"{supp}°";
		var wrong1 = $"{angle}°";
		var wrong2 = $"{90 - angle}°";
		var wrong3 = $"{180 + angle}°";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-SUPPANG-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-085",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Deux angles adjacents forment un angle plat. Si le premier mesure {angle}°, quelle est la mesure du second angle supplémentaire ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux angles supplémentaires ont une somme égale à 180°.",
			HintLevel2 = $"Calcule 180° - {angle}°.",
			ExplanationText = $"Angles supplémentaires : 180° - {angle}° = {supp}°."
		};
	}
}

