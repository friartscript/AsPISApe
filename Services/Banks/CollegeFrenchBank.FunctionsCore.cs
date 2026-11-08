using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateNatureVsFunctionQuestion()
	{
		var pool = new[]
		{
			("Le chat dort sur le canapé.", "Le chat", "Sujet du verbe", "Nom commun", "Groupe verbal", "Complément circonstanciel"),
			("Le vent souffle avec violence.", "avec violence", "Complément circonstanciel de manière", "Groupe nominal", "Sujet", "Attribut"),
			("Mon frère regarde les étoiles.", "les étoiles", "Complément d'objet direct (COD)", "Groupe nominal", "Attribut du sujet", "Sujet")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_nature_fonction",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans la phrase « {item.Item1} », quelle est la fonction du groupe « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La nature est ce que le mot est, la fonction est son rôle dans la phrase.",
			HintLevel2 = "Posez la question par rapport au verbe principal.",
			ExplanationText = $"« {item.Item2} » a pour fonction : {item.Item3}."
		};
	}

	public ExerciseQuestion GenerateSubjectFunctionQuestion()
	{
		var pool = new[]
		{
			("Dans la forêt chantaient de nombreux oiseaux.", "de nombreux oiseaux", "Sujet inversé", "Complément d'objet direct", "Complément circonstanciel de lieu", "Attribut"),
			("Partir tôt me semble indispensable.", "Partir tôt", "Verbe à l'infinitif sujet", "COD", "Complément circonstanciel", "Attribut"),
			("Que tu réussisses me réjouit profondément.", "Que tu réussisses", "Proposition subordonnée complétive sujet", "COD", "COI", "Circonstanciel de cause")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_fonction_sujet",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans « {item.Item1} », quelle est la nature et fonction exacte de « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Posez la question : « Qui est-ce qui ? » avant le verbe.",
			HintLevel2 = "Le sujet peut être placé après le verbe (sujet inversé) ou être un infinitif.",
			ExplanationText = $"« {item.Item2} » est le {item.Item3.ToLowerInvariant()} de la phrase."
		};
	}

	public ExerciseQuestion GenerateAttributeFunctionQuestion()
	{
		var pool = new[]
		{
			("Cet homme paraît sincère.", "sincère", "Attribut du sujet", "Épithète liée", "COD", "Complément de manière"),
			("L'océan est devenu tumultueux après la tempête.", "tumultueux", "Attribut du sujet", "Épithète détachée", "COI", "Complément circonstanciel"),
			("Ce projet semble une réussite totale.", "une réussite totale", "Groupe nominal attribut du sujet", "COD", "Sujet inversé", "Complément du nom")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_fonction_attribut",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans la phrase « {item.Item1} », quelle est la fonction précise de « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'attribut est relié au sujet par un verbe d'état (être, paraître, sembler, devenir...).",
			HintLevel2 = "On ne peut pas supprimer l'attribut sans rendre la phrase incorrecte.",
			ExplanationText = $"« {item.Item2} » est {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateObjectComplementQuestion()
	{
		var pool = new[]
		{
			("Le guide parle aux randonneurs des dangers de la montagne.", "aux randonneurs", "Complément d'objet indirect (COI)", "Complément d'objet direct (COD)", "Complément d'agent", "Attribut"),
			("Elle a cueilli des roses sauvages dans le sous-bois.", "des roses sauvages", "Complément d'objet direct (COD)", "Complément d'objet indirect (COI)", "Sujet", "Complément de lieu"),
			("Il a confié son secret à son meilleur ami.", "son secret", "Complément d'objet direct (COD)", "COI", "Complément d'agent", "Attribut du sujet")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_complements_objet",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans « {item.Item1} », quelle est la fonction du groupe « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le COD répond à la question « qui ? » ou « quoi ? » directement après le verbe.",
			HintLevel2 = "Le COI est introduit par une préposition (à qui ? de quoi ?).",
			ExplanationText = $"« {item.Item2} » est un {item.Item3}."
		};
	}

	public ExerciseQuestion GenerateAgentComplementQuestion()
	{
		var pool = new[]
		{
			("La fresque a été restaurée par un maître d'art.", "par un maître d'art", "Complément d'agent", "Complément circonstanciel de moyen", "COI", "Attribut"),
			("Le vainqueur fut applaudi par toute la foule.", "par toute la foule", "Complément d'agent", "Complément circonstanciel de manière", "COD", "Sujet"),
			("Le village était entouré de hautes collines.", "de hautes collines", "Complément d'agent", "Complément du nom", "Complément de lieu", "Attribut")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B2-{Guid.NewGuid():N}",
			SubjectId = "francais_col_complement_agent",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Dans la phrase passive « {item.Item1} », quelle est la fonction de « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le complément d'agent indique qui accomplit l'action dans une phrase à la voix passive.",
			HintLevel2 = "Il est généralement introduit par la préposition « par » ou « de ».",
			ExplanationText = $"« {item.Item2} » est le complément d'agent du verbe passif."
		};
	}
}

