using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateFutureTensesQuestion()
	{
		var pool = new[]
		{
			("Demain, nous prendrons le premier train.", "prendrons", "Futur simple (action à venir)", "Futur antérieur", "Présent de l'indicatif", "Conditionnel"),
			("Dès que tu auras fini, nous partirons.", "auras fini", "Futur antérieur (antériorité dans le futur)", "Futur simple", "Passé composé", "Subjonctif passé"),
			("Tu rangeras ta chambre immédiatement !", "rangeras", "Futur à valeur d'ordre / injonction", "Futur de prédiction", "Futur antérieur", "Conditionnel")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_temps_futur",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Identifiez le temps et la nuance de « {item.Item2} » dans : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le futur situe une action à venir ou peut exprimer un ordre atténué ou ferme.",
			HintLevel2 = "Le futur antérieur exprime une action accomplie avant une autre action future.",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateConditionnelValuesQuestion()
	{
		var pool = new[]
		{
			("Pourriez-vous m'indiquer l'heure, s'il vous plaît ?", "Conditionnel de politesse", "Conditionnel d'information incertaine", "Conditionnel de regret", "Conditionnel de souhait"),
			("Si j'avais des ailes, je volerais vers les îles.", "Conditionnel de potentiel / hypothèse", "Conditionnel de politesse", "Futur simple", "Ordre impératif"),
			("D'après les rumeurs, le ministre démissionnerait.", "Conditionnel d'information incertaine", "Conditionnel de politesse", "Souhait réalisable", "Vérité générale"),
			("J'aimerais tant visiter le Japon un jour.", "Conditionnel de souhait", "Conditionnel d'ordre", "Information incertaine", "Imparfait de narration")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_valeurs_conditionnel",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Quelle nuance exprime le conditionnel dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le conditionnel exprime l'imaginaire, la demande polie, l'hypothèse ou l'incertitude.",
			HintLevel2 = "Attention au contexte (formule de politesse, phrase avec 'si', ou propos journalistique).",
			ExplanationText = $"Dans cette phrase, le conditionnel exprime un {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateSubjonctifValuesQuestion()
	{
		var pool = new[]
		{
			("Il faut absolument que vous veniez à l'heure.", "L'obligation / la nécessité", "Le doute absolu", "La certitude scientifique", "Le passé révolu"),
			("Je doute qu'il parvienne à finir ce devoir.", "Le doute / l'incertitude", "L'affirmation certaine", "L'habitude", "L'ordre direct"),
			("Je souhaite de tout cœur qu'elle réussisse.", "Le souhait / le désir", "L'obligation légale", "Le constat objectif", "La cause réelle")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_valeurs_subjonctif",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Dans « {item.Item1} », quelle nuance modale justifie l'emploi du subjonctif ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le subjonctif est le mode du virtuel, du sentiment, de la volonté et de l'incertitude.",
			HintLevel2 = "Il s'emploie principalement après des verbes de volonté, d'obligation ou de doute.",
			ExplanationText = $"Le subjonctif exprime ici {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateImperatifValuesQuestion()
	{
		var pool = new[]
		{
			("Fermez la porte à clé avant de partir !", "Un ordre formel", "Un conseil amical", "Une interdiction", "Une simple prière"),
			("Prends un parapluie, le ciel se couvre.", "Un conseil", "Un ordre militaire", "Une prière suppliante", "Une constatation"),
			("Ne marchez pas sur les pelouses.", "Une défense (interdiction)", "Un souhait", "Une autorisation", "Une politesse")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_valeurs_imperatif",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle nuance exprime l'impératif dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'impératif sert à donner un ordre, formuler un conseil ou poser une interdiction.",
			HintLevel2 = "L'impératif négatif (« ne... pas ») exprime une interdiction (ou défense).",
			ExplanationText = $"L'impératif exprime ici {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateSimpleVsCompoundTensesQuestion()
	{
		var pool = new[]
		{
			("nous avions couru", "Temps composé (plus-que-parfait)", "Temps simple (imparfait)", "Temps composé (passé composé)", "Temps simple (passé simple)"),
			("nous courions", "Temps simple (imparfait)", "Temps composé (plus-que-parfait)", "Temps simple (passé simple)", "Temps composé (passé antérieur)"),
			("ils seront partis", "Temps composé (futur antérieur)", "Temps simple (futur simple)", "Temps composé (passé composé)", "Temps simple (présent)")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_temps_simples_composes",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"La forme verbale « {item.Item1} » est-elle un temps simple ou composé ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un temps composé est constitué d'un auxiliaire conjugué (être ou avoir) et d'un participe passé.",
			HintLevel2 = "Comptez le nombre de mots constituant la forme verbale.",
			ExplanationText = $"« {item.Item1} » est un {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateInfinitiveVsParticipleQuestion()
	{
		var pool = new[]
		{
			("Il a préféré (partager) son repas.", "partager", "partagé", "partagez", "partagée", "On peut remplacer par un verbe du 3e groupe : « vendre »."),
			("Le projet a été (valider) par l'équipe.", "validé", "valider", "validez", "validés", "On peut remplacer par « vendu »."),
			("Tu dois (écouter) attentivement.", "écouter", "écouté", "écoutez", "écoutés", "On peut remplacer par « mordre ».")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_infinitif_participe",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Choisissez la graphie exacte pour compléter : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = item.Item6,
			HintLevel2 = "Si on peut dire « vendre », écrivez -er. Si on peut dire « vendu », écrivez -é.",
			ExplanationText = $"La terminaison attendue est « {item.Item2} »."
		};
	}

	public ExerciseQuestion GenerateAuxiliariesConjugationQuestion()
	{
		var pool = new[]
		{
			("Il faut que nous (être) ___ ponctuels.", "soyons", "sommes", "serons", "étions"),
			("Si vous (avoir) ___ le temps, prévenez-moi.", "aviez", "avez", "aurez", "ayez"),
			("Demain, ils (être) ___ en vacances.", "seront", "seraient", "sont", "furent")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_auxiliaires",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Conjuguez correctement l'auxiliaire : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Soyez attentif au mode demandé par la proposition (subjonctif après 'il faut que', etc.).",
			HintLevel2 = "Vérifiez l'accord de la personne avec le pronom sujet.",
			ExplanationText = $"La forme correcte de l'auxiliaire est « {item.Item2} »."
		};
	}

	public ExerciseQuestion GenerateFirstSecondGroupConjugationQuestion()
	{
		var pool = new[]
		{
			("Nous (franchir, présent) ___ la ligne.", "franchissons", "franchisons", "franchissez", "franchirons"),
			("Ils (manger, imparfait) ___ ensemble.", "mangeaient", "mangèrent", "mangeaint", "mangiaient"),
			("Vous (choisir, passé simple) ___ la difficulté.", "choisîtes", "choisissiez", "choisissez", "choisirez")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_verbes_1er_2e_groupes",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Complétez avec la conjugaison exacte : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les verbes du 2e groupe forment leur pluriel en -issons, -issez, -issaient.",
			HintLevel2 = "Attention aux particularités orthographiques (le 'e' muet après le 'g' devant a/o).",
			ExplanationText = $"La forme exacte est « {item.Item2} »."
		};
	}

	public ExerciseQuestion GenerateThirdGroupIrregularConjugationQuestion()
	{
		var pool = new[]
		{
			("Ils (faire, présent) ___ attention à la consigne.", "font", "faisez", "faisent", "feront"),
			("Vous (dire, présent) ___ toujours la vérité.", "dites", "diseur", "disez", "diraient"),
			("Soudain, il (prendre, passé simple) ___ la parole.", "prit", "prenait", "prendit", "prît"),
			("Nous (pouvoir, futur simple) ___ vous aider demain.", "pourrons", "pouvons", "pourrions", "pouvrons")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_verbes_irreguliers_3e_groupe",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Complétez avec le verbe du 3e groupe correctement conjugué : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention aux pièges fréquents : vous faites, vous dites, ils font, ils vont.",
			HintLevel2 = "Les verbes du 3e groupe ont souvent un radical irrégulier au présent ou au futur.",
			ExplanationText = $"La bonne forme du verbe est « {item.Item2} »."
		};
	}
}

