using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateCircumstantialComplementQuestion()
	{
		var pool = new[]
		{
			("Dès l'aube, les pêcheurs prennent la mer.", "Dès l'aube", "Complément circonstanciel de temps", "Complément de lieu", "Complément de cause", "Complément de manière"),
			("Il a résolu l'énigme grâce à sa persévérance.", "grâce à sa persévérance", "Complément circonstanciel de cause", "Complément de but", "Complément de moyen", "Complément de manière"),
			("Elle range soigneusement ses affaires.", "soigneusement", "Complément circonstanciel de manière", "Complément de moyen", "Attribut", "COD"),
			("Ils travaillent dur pour réussir leurs examens.", "pour réussir leurs examens", "Complément circonstanciel de but", "Complément de cause", "Complément de temps", "COI")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_complements_circonstanciels",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans la phrase « {item.Item1} », quelle circonstance exprime « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les compléments circonstanciels sont déplaçables et supprimables.",
			HintLevel2 = "Posez la question : quand ? où ? comment ? pourquoi ? ou dans quel but ?",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateNounExpansionsQuestion()
	{
		var pool = new[]
		{
			("Le train à grande vitesse entre en gare.", "à grande vitesse", "Complément du nom", "Épithète", "Attribut du sujet", "Proposition subordonnée"),
			("Le vent qui souffle fort décoiffe les passants.", "qui souffle fort", "Proposition subordonnée relative", "Complément du nom", "Attribut", "Épithète"),
			("Une décision courageuse a été prise.", "courageuse", "Adjectif qualificatif épithète", "Attribut", "Apposition", "Complément de manière")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_expansions_nom",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle expansion enrichit le nom dans : « {item.Item1} » (« {item.Item2} ») ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les trois grandes expansions du nom sont : l'épithète, le complément du nom et la relative.",
			HintLevel2 = "Regardez la structure (adjectif seul, groupe avec préposition, ou verbe avec 'qui').",
			ExplanationText = $"« {item.Item2} » est une expansion du nom sous forme de {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateNounComplementQuestion()
	{
		var pool = new[]
		{
			("Une tasse en porcelaine reposait sur la table.", "en porcelaine", "Complément du nom « tasse »", "Épithète", "Attribut", "Complément de matière"),
			("Le silence de la nuit enveloppait la ville.", "de la nuit", "Complément du nom « silence »", "COI du verbe", "Complément de temps", "Épithète"),
			("Une machine à coudre ancienne trônait au salon.", "à coudre", "Complément du nom « machine »", "Verbe à l'infinitif COD", "Attribut", "Complément de but")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_complement_nom",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans « {item.Item1} », quelle est la fonction du groupe prépositionnel « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le complément du nom est introduit par une préposition et complète un nom noyau.",
			HintLevel2 = "Il ne complète pas le verbe mais directement le nom qui le précède.",
			ExplanationText = $"« {item.Item2} » a pour fonction {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateEpithetFunctionQuestion()
	{
		var pool = new[]
		{
			("Des nuages menaçants obscurcissent le ciel.", "menaçants", "Épithète liée", "Attribut du sujet", "Épithète détachée (apposée)", "Adverbe"),
			("Fatigués, les randonneurs firent une pause.", "Fatigués", "Épithète détachée (apposée)", "Épithète liée", "Attribut du sujet", "Complément de cause"),
			("Une douce mélodie résonne dans la pièce.", "douce", "Épithète liée", "Attribut", "Complément d'objet", "Adverbe")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_fonction_epithete",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans « {item.Item1} », quelle est la fonction précise de l'adjectif « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'épithète liée est collée au nom. L'épithète détachée est séparée par une virgule.",
			HintLevel2 = "Il n'y a pas de verbe d'état entre le nom et cet adjectif.",
			ExplanationText = $"« {item.Item2} » est {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateAppositionQuestion()
	{
		var pool = new[]
		{
			("Marseille, cité phocéenne, est tournée vers la mer.", "cité phocéenne", "Groupe nominal en apposition", "Attribut du sujet", "Complément du nom", "Épithète liée"),
			("Mon cousin, un artiste passionné, expose ses toiles.", "un artiste passionné", "Groupe nominal en apposition", "Sujet principal", "COD", "Attribut"),
			("Le mont Blanc, toit de l'Europe, domine les Alpes.", "toit de l'Europe", "Groupe nominal en apposition", "Complément de lieu", "Épithète", "COI")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_apposition",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Dans la phrase « {item.Item1} », quelle est la fonction du groupe entre virgules « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'apposition est un élément explicatif séparé du mot qu'il précise par des virgules.",
			HintLevel2 = "Elle désigne la même réalité que le nom qu'elle accompagne.",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateAdjectiveFunctionsQuestion()
	{
		var pool = new[]
		{
			("Ces enfants semblent joyeux.", "joyeux", "Attribut du sujet (relié par un verbe d'état)", "Épithète liée (collée au nom)", "Complément circonstanciel", "Adverbe"),
			("Les joyeux enfants rient aux éclats.", "joyeux", "Épithète liée (collée au nom)", "Attribut du sujet", "Apposition", "Complément d'objet"),
			("Joyeux, les enfants entament la danse.", "Joyeux", "Épithète détachée (apposée)", "Attribut du sujet", "Épithète liée", "Complément de manière")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_fonctions_adjectif",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Identifiez la fonction exacte de l'adjectif dans : « {item.Item1} » (« {item.Item2} »)",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Distinguez l'épithète (liée ou détachée) de l'attribut (séparé par un verbe d'état).",
			HintLevel2 = "Observez la présence éventuelle d'un verbe d'état ou d'une virgule.",
			ExplanationText = $"« {item.Item2} » a pour fonction : {item.Item3}."
		};
	}

	public ExerciseQuestion GenerateApostropheFunctionQuestion()
	{
		var pool = new[]
		{
			("Amis, écoutez ce message de paix !", "Amis", "Apostrophe (terme d'adresse)", "Sujet du verbe", "COD", "Interjection"),
			("Pourquoi tardes-tu autant, Thomas ?", "Thomas", "Apostrophe (terme d'adresse)", "Sujet inversé", "Attribut", "Complément de lieu"),
			("Soldats, le moment de gloire est venu !", "Soldats", "Apostrophe (terme d'adresse)", "Sujet de la phrase", "Épithète", "Nom commun COD")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_apostrophe",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans « {item.Item1} », quelle est la fonction du mot « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'apostrophe sert à désigner la personne à qui l'on s'adresse directement.",
			HintLevel2 = "Elle est toujours isolée par la ponctuation et n'est pas le sujet du verbe.",
			ExplanationText = $"« {item.Item2} » est une {item.Item3.ToLowerInvariant()}."
		};
	}
}

