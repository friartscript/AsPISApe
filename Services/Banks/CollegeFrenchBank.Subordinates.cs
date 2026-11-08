using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateJuxtapositionCoordinationQuestion()
	{
		var cases = new[]
		{
			("Le vent soufflait fort, les branches craquaient dans la nuit.", "Juxtaposées (séparées par une virgule)", "Coordonnées par une conjonction", "Subordonnées relatives", "Une proposition indépendante et une subordonnée"),
			("Le ciel s'assombrit et les premières gouttes de pluie tombent.", "Coordonnées par la conjonction 'et'", "Juxtaposées par un signe de ponctuation", "Subordonnées complétives", "Subordonnées circonstancielles"),
			("Le train est arrivé en retard car un incident technique est survenu.", "Coordonnées par la conjonction 'car'", "Juxtaposées par deux-points", "Subordonnées relatives", "Subordonnées participiales")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-JUXT-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-046",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Dans la phrase : « {item.Item1} », comment sont reliées les deux propositions ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Deux propositions juxtaposées sont séparées par une ponctuation (, ; :). Deux propositions coordonnées sont reliées par 'mais, où, et, donc, or, ni, car'.",
			HintLevel2 = $"Ici, les propositions sont : {item.Item2}.",
			ExplanationText = $"Dans cette phrase, les propositions sont {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateRelativeClauseQuestion()
	{
		var clauses = new[]
		{
			("Le livre [qui est posé sur la table] appartient à Thomas.", "qui est posé sur la table", "Le livre", "Proposition subordonnée relative", "introduite par le pronom relatif 'qui', antécédent 'livre'"),
			("La maison [que nous avons visitée hier] possède un grand jardin.", "que nous avons visitée hier", "La maison", "Proposition subordonnée relative", "introduite par le pronom relatif 'que', antécédent 'maison'"),
			("L'artiste [dont tout le monde parle] expose ses toiles au musée.", "dont tout le monde parle", "L'artiste", "Proposition subordonnée relative", "introduite par le pronom relatif 'dont', antécédent 'artiste'")
		};
		var item = clauses[_random.Next(clauses.Length)];
		var correct = "Proposition subordonnée relative (complément de l'antécédent)";
		var wrong1 = "Proposition subordonnée complétive (COD)";
		var wrong2 = "Proposition subordonnée circonstancielle de temps";
		var wrong3 = "Proposition principale indépendante";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-REL-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-047",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Quelle est la nature de la proposition entre crochets : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une proposition subordonnée relative est introduite par un pronom relatif (qui, que, quoi, dont, où...) et complète un nom appelé antécédent.",
			HintLevel2 = item.Item5,
			ExplanationText = $"C'est une proposition subordonnée relative complétant l'antécédent « {item.Item3} »."
		};
	}

	public ExerciseQuestion GenerateCompletiveClauseQuestion()
	{
		var clauses = new[]
		{
			("Je pense [que nous réussirons cette épreuve ensemble].", "que nous réussirons cette épreuve ensemble", "penser"),
			("Le professeur exige [que chaque élève rende son devoir à l'heure].", "que chaque élève rende son devoir à l'heure", "exiger"),
			("Nous savons tous [que la Terre tourne autour du Soleil].", "que la Terre tourne autour du Soleil", "savoir")
		};
		var item = clauses[_random.Next(clauses.Length)];
		var correct = "Proposition subordonnée conjonctive complétive (COD du verbe)";
		var wrong1 = "Proposition subordonnée relative (épithète)";
		var wrong2 = "Proposition subordonnée circonstancielle de but";
		var wrong3 = "Proposition subordonnée circonstancielle de cause";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-COMPL-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-048",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Quelle est la nature et la fonction de la proposition entre crochets : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une proposition subordonnée complétive est introduite par la conjonction 'que' et complète directement un verbe (elle occupe la fonction de COD).",
			HintLevel2 = $"Elle complète le verbe « {item.Item3} » : Je pense [quoi ?].",
			ExplanationText = $"C'est une subordonnée conjonctive complétive ayant la fonction de COD du verbe « {item.Item3} »."
		};
	}

	public ExerciseQuestion GenerateCircumstantialClauseQuestion()
	{
		var items = new[]
		{
			("Pendant que les enfants dorment, la neige recouvre la forêt.", "de temps (simultanéité)", "de cause", "de conséquence", "de but"),
			("Comme il n'avait pas révisé, il a hésité sur plusieurs questions.", "de cause", "de comparaison", "de temps", "de concession"),
			("Elle s'entraîne tous les jours pour qu'elle puisse décrocher la médaille.", "de but (avec subjonctif)", "de cause", "de conséquence", "de condition"),
			("Il a tellement plu que la rivière a débordé de son lit.", "de conséquence", "de cause", "de temps", "de but")
		};
		var item = items[_random.Next(items.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-CIRCPROP-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-049",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Dans la phrase : « {item.Item1} », quelle est la nuance circonstancielle exprimée par la subordonnée ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Observe le mot subordonnant ('pendant que', 'comme', 'pour que', 'tellement... que') et le sens de la phrase.",
			HintLevel2 = $"La nuance exprimée est : {item.Item2}.",
			ExplanationText = $"La proposition subordonnée exprime une circonstance {item.Item2}."
		};
	}
}

