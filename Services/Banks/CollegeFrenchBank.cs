using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class CollegeFrenchBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestionBySubject(int subjectIndex)
	{
		return subjectIndex switch
		{
			1 => GenerateWordClassQuestion(),
			2 => GenerateNounQuestion(),
			3 => GenerateDeterminerQuestion(),
			4 => GeneratePronounQuestion(),
			5 => GenerateAdjectiveQuestion(),
			6 => GenerateVerbQuestion(),
			7 => GenerateAdverbQuestion(),
			8 => GeneratePrepositionQuestion(),
			9 => GenerateConjunctionQuestion(),
			10 => GenerateInterjectionQuestion(),
			11 => GenerateNatureVsFunctionQuestion(),
			12 => GenerateSubjectFunctionQuestion(),
			13 => GenerateAttributeFunctionQuestion(),
			14 => GenerateObjectComplementQuestion(),
			15 => GenerateAgentComplementQuestion(),
			16 => GenerateCircumstantialComplementQuestion(),
			17 => GenerateNounExpansionsQuestion(),
			18 => GenerateNounComplementQuestion(),
			19 => GenerateEpithetFunctionQuestion(),
			20 => GenerateAppositionQuestion(),
			21 => GenerateAdjectiveFunctionsQuestion(),
			22 => GenerateApostropheFunctionQuestion(),
			23 => GeneratePresentValuesQuestion(),
			24 => GenerateImparfaitValuesQuestion(),
			25 => GeneratePasseSimpleValuesQuestion(),
			26 => GenerateImparfaitVsPasseSimpleQuestion(),
			27 => GeneratePasseComposeValuesQuestion(),
			28 => GeneratePlusQueParfaitQuestion(),
			29 => GenerateFutureTensesQuestion(),
			30 => GenerateConditionnelValuesQuestion(),
			31 => GenerateSubjonctifValuesQuestion(),
			32 => GenerateImperatifValuesQuestion(),
			33 => GenerateSimpleVsCompoundTensesQuestion(),
			34 => GenerateInfinitiveVsParticipleQuestion(),
			35 => GenerateAuxiliariesConjugationQuestion(),
			36 => GenerateFirstSecondGroupConjugationQuestion(),
			37 => GenerateThirdGroupIrregularConjugationQuestion(),
			_ => GenerateWordClassQuestion()
		};
	}

	public ExerciseQuestion GenerateWordClassQuestion()
	{
		var pool = new[]
		{
			("paisiblement", "Un adverbe", "Un adjectif qualificatif", "Un verbe", "Un nom commun"),
			("lumineux", "Un adjectif qualificatif", "Un adverbe", "Un pronom", "Une préposition"),
			("devant", "Une préposition", "Un adverbe", "Une conjonction", "Un nom"),
			("ils", "Un pronom personnel", "Un déterminant", "Un nom", "Un adjectif"),
			("cependant", "Un adverbe", "Une préposition", "Un adjectif", "Un verbe"),
			("naviguer", "Un verbe à l'infinitif", "Un nom masculin", "Un adjectif", "Un adverbe")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_classes_mots",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est la classe grammaticale du mot « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La classe grammaticale est l'identité fixe d'un mot dans le dictionnaire.",
			HintLevel2 = $"Ce mot est invariable ou appartient à une catégorie morphologique précise.",
			ExplanationText = $"« {item.Item1} » est {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateNounQuestion()
	{
		var pool = new[]
		{
			("Le courage des marins est remarquable.", "courage", "Nom commun abstrait", "Adjectif qualificatif", "Verbe conjugué", "Adverbe de manière"),
			("Paris s'illumine dès la tombée de la nuit.", "Paris", "Nom propre", "Nom commun", "Pronom personnel", "Adjectif qualificatif"),
			("La liberté est une valeur fondamentale.", "liberté", "Nom commun abstrait", "Adjectif", "Verbe d'état", "Déterminant")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_nom",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Dans la phrase « {item.Item1} », quelle est la nature précise du mot « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Distinguez les noms communs (précédés d'un déterminant) des noms propres (majuscule).",
			HintLevel2 = $"Le mot « {item.Item2} » désigne un concept, une personne, un lieu ou un objet.",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateDeterminerQuestion()
	{
		var pool = new[]
		{
			("Chaque matin, il part courir.", "Chaque", "Déterminant indéfini", "Pronom indéfini", "Adverbe", "Préposition"),
			("Ces arbres centenaires protègent la maison.", "Ces", "Déterminant démonstratif", "Déterminant possessif", "Pronom démonstratif", "Article défini"),
			("Leurs bagages sont déjà enregistrés.", "Leurs", "Déterminant possessif", "Pronom personnel", "Pronom possessif", "Article partitif"),
			("Des oiseaux migrateurs traversent le ciel.", "Des", "Article indéfini", "Article défini contracté", "Pronom personnel", "Préposition")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_determinants",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est la catégorie exacte du déterminant « {item.Item2} » dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un déterminant précède immédiatement un nom et s'accorde en genre et en nombre.",
			HintLevel2 = "Observez s'il indique la possession, montre un objet ou exprime une quantité générale.",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GeneratePronounQuestion()
	{
		var pool = new[]
		{
			("Le livre que tu lis est passionnant.", "que", "Pronom relatif", "Conjonction de subordination", "Pronom personnel", "Adverbe interrogatif"),
			("Prends le tien, je garde le mien.", "le mien", "Pronom possessif", "Déterminant possessif", "Nom commun", "Pronom démonstratif"),
			("Celui-ci semble plus robuste que l'autre.", "Celui-ci", "Pronom démonstratif", "Déterminant démonstratif", "Nom propre", "Pronom indéfini"),
			("Nous les avons aperçus au loin.", "les", "Pronom personnel COD", "Article défini", "Pronom relatif", "Déterminant possessif")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_pronoms",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la classe précise du mot « {item.Item2} » dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un pronom remplace un nom ou un groupe nominal pour éviter la répétition.",
			HintLevel2 = "Attention à ne pas le confondre avec un déterminant qui accompagne un nom.",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateAdjectiveQuestion()
	{
		var pool = new[]
		{
			("Une eau limpide et fraîche jaillit de la roche.", "limpide", "Adjectif qualificatif épithète", "Nom commun", "Adverbe de manière", "Participe passé"),
			("Ces résultats semblent excellents.", "excellents", "Adjectif qualificatif attribut", "Adverbe", "Nom commun pluriel", "Participe présent"),
			("Un silence pesant s'installa dans la salle.", "pesant", "Adjectif qualificatif (issu d'un participe)", "Verbe au participe présent", "Nom masculin", "Adverbe")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_adjectif",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans la phrase « {item.Item1} », quelle est la nature de « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'adjectif qualificatif apporte une précision sur les caractéristiques d'un nom.",
			HintLevel2 = $"Vérifiez son accord en genre et en nombre avec le nom qu'il qualifie.",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateVerbQuestion()
	{
		var pool = new[]
		{
			("Il a franchi la ligne d'arrivée en tête.", "a franchi", "Verbe au passé composé", "Verbe à l'imparfait", "Temps simple", "Plus-que-parfait"),
			("Dès que tu seras arrivé, téléphone-moi.", "seras arrivé", "Verbe au futur antérieur", "Verbe au futur simple", "Conditionnel passé", "Passé composé"),
			("Il faut que nous prenions une décision.", "prenions", "Verbe au subjonctif présent", "Verbe à l'indicatif imparfait", "Conditionnel présent", "Indicatif présent")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_verbe",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Identifiez le temps et le mode du verbe « {item.Item2} » dans : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Observez la structure du verbe : auxiliaire + participe passé (temps composé).",
			HintLevel2 = "Repérez le temps de l'auxiliaire pour en déduire le temps composé correspondant.",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateAdverbQuestion()
	{
		var pool = new[]
		{
			("Il a répondu poliment à la question.", "poliment", "Adverbe de manière", "Adverbe de temps", "Adverbe de lieu", "Adjectif qualificatif"),
			("Nous irons bientôt explorer cette région.", "bientôt", "Adverbe de temps", "Adverbe de manière", "Adverbe de quantité", "Préposition"),
			("Il a trop mangé lors de ce dîner.", "trop", "Adverbe de quantité / intensité", "Adverbe de lieu", "Adjectif qualificatif", "Nom masculin"),
			("Installez-vous ici pour assister au concert.", "ici", "Adverbe de lieu", "Adverbe de temps", "Pronom démonstratif", "Préposition")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_adverbes",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle nuance précise apporte l'adverbe « {item.Item2} » dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'adverbe est un mot invariable qui modifie le sens d'un verbe, d'un adjectif ou d'un autre adverbe.",
			HintLevel2 = "Posez la question : comment ? quand ? où ? ou combien ?",
			ExplanationText = $"« {item.Item2} » est un {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GeneratePrepositionQuestion()
	{
		var pool = new[]
		{
			("Il partit sans un mot d'adieu.", "sans", "Une préposition", "Un adverbe", "Une conjonction de coordination", "Un pronom"),
			("Le navire s'éloigne vers l'horizon.", "vers", "Une préposition", "Un nom commun", "Un adverbe de lieu", "Un adjectif"),
			("Un gâteau fait avec amour.", "avec", "Une préposition", "Un adverbe", "Une conjonction", "Un pronom relatif")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_prepositions",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est la classe grammaticale de « {item.Item2} » dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Moyen mnémotechnique : à, dans, par, pour, en, vers, avec, de, sans, sous.",
			HintLevel2 = "La préposition introduit un groupe nominal ou un verbe à l'infinitif.",
			ExplanationText = $"« {item.Item2} » est {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateConjunctionQuestion()
	{
		var pool = new[]
		{
			("Il voulait sortir mais la pluie l'en a empêché.", "mais", "Conjonction de coordination", "Conjonction de subordination", "Adverbe de liaison", "Préposition"),
			("Je viendrai dès que les cours seront terminés.", "dès que", "Conjonction de subordination", "Conjonction de coordination", "Préposition", "Locution adverbiale"),
			("Elle hésite entre le thé ou le café.", "ou", "Conjonction de coordination", "Pronom relatif", "Préposition", "Adverbe")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_conjonctions",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Identifiez la catégorie exacte du mot « {item.Item2} » dans : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Conjonctions de coordination : mais, ou, et, donc, or, ni, car.",
			HintLevel2 = "Une conjonction de subordination introduit une proposition subordonnée.",
			ExplanationText = $"« {item.Item2} » est une {item.Item3.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateInterjectionQuestion()
	{
		var pool = new[]
		{
			("Hélas ! Tout espoir semblait perdu.", "Hélas", "Une interjection", "Un adverbe de négation", "Un nom propre", "Une conjonction"),
			("Bravo pour cette magnifique prestation !", "Bravo", "Une interjection", "Un adjectif qualificatif", "Un nom commun", "Un verbe à l'impératif"),
			("Chut ! Les enfants dorment à poings fermés.", "Chut", "Une interjection (ou onomatopée)", "Un adverbe de lieu", "Un verbe", "Une préposition")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B1-{Guid.NewGuid():N}",
			SubjectId = "francais_col_interjections",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 10,
			QuestionText = $"Quelle est la classe grammaticale du mot « {item.Item2} » dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "C'est un mot invariable, souvent suivi d'un point d'exclamation, exprimant une émotion vive.",
			HintLevel2 = "Il ne joue pas de rôle syntaxique direct dans la proposition.",
			ExplanationText = $"« {item.Item2} » est {item.Item3.ToLowerInvariant()}."
		};
	}

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

	public ExerciseQuestion GeneratePresentValuesQuestion()
	{
		var pool = new[]
		{
			("La Terre tourne autour du Soleil.", "Présent de vérité générale", "Présent d'énonciation", "Présent de narration", "Présent d'habitude"),
			("Je vous écris en ce moment même.", "Présent d'énonciation", "Présent de vérité générale", "Présent de passé proche", "Présent d'habitude"),
			("Tous les matins, il prend son café à sept heures.", "Présent d'habitude / répétition", "Présent d'énonciation", "Présent de vérité générale", "Présent de futur proche"),
			("Soudain, le chevalier s'élance et frappe le monstre.", "Présent de narration", "Présent de vérité générale", "Présent d'énonciation", "Présent d'habitude")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_valeurs_present",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la valeur du présent dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Distinguez ce qui se passe au moment où l'on parle d'un fait scientifique ou d'une habitude.",
			HintLevel2 = "Observez si l'action est permanente, répétée ou rend le récit plus vivant.",
			ExplanationText = $"Ce verbe a pour valeur : {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateImparfaitValuesQuestion()
	{
		var pool = new[]
		{
			("Le ciel était d'un bleu limpide et les oiseaux chantaient.", "Imparfait de description", "Imparfait d'habitude", "Imparfait de narration", "Imparfait de rupture"),
			("Chaque été, nous allions camper au bord du lac.", "Imparfait d'habitude / répétition", "Imparfait de description", "Imparfait d'action soudaine", "Imparfait d'hypothèse"),
			("Pendant qu'il lisait, la bougie s'éteignit.", "Imparfait d'action en cours (arrière-plan)", "Imparfait de premier plan", "Imparfait d'habitude", "Imparfait de politesse")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_valeurs_imparfait",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la valeur de l'imparfait dans : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'imparfait sert à peindre le décor, exprimer une routine ou une action non délimitée dans le temps.",
			HintLevel2 = "Observez s'il s'agit d'un tableau descriptif, d'une habitude ou de l'arrière-plan.",
			ExplanationText = $"Il s'agit d'un {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GeneratePasseSimpleValuesQuestion()
	{
		var pool = new[]
		{
			("Soudain, un coup de tonnerre retentit.", "Action soudaine et brève de premier plan", "Action durable en arrière-plan", "Répétition habituelle", "Description d'un paysage"),
			("Il prit son épée, franchit le pont et entra dans le château.", "Succession d'actions délimitées", "Description de décor", "Habitude du passé", "Action inachevée"),
			("La guerre dura dix ans.", "Action passée délimitée dans le temps", "Action sans fin définie", "Habitude passée", "Présent de narration")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_valeurs_passe_simple",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la valeur du passé simple dans la phrase : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le passé simple fait progresser l'histoire avec des actions ponctuelles de premier plan.",
			HintLevel2 = "Il s'oppose à l'imparfait descriptif en marquant un fait précis et achevé.",
			ExplanationText = $"Le passé simple exprime une {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GenerateImparfaitVsPasseSimpleQuestion()
	{
		var pool = new[]
		{
			("Il (dormir) paisiblement quand le réveil (sonner).", "dormait / sonna", "dormit / sonnait", "dormait / sonnait", "dormit / sonna"),
			("Le vent (souffler) fort lorsque le navire (heurter) le récif.", "soufflait / heurta", "souffla / heurtait", "soufflait / heurtait", "souffla / heurta"),
			("Tandis que Marie (préparer) le dîner, Lucas (arriver).", "préparait / arriva", "prépara / arrivait", "préparait / arrivait", "prépara / arriva")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_imparfait_passe_simple",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Complétez avec les temps du récit adaptés : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Action longue en cours = imparfait ; événement bref et soudain qui coupe = passé simple.",
			HintLevel2 = "Le second verbe marque la rupture dans l'action en cours.",
			ExplanationText = $"On emploie l'imparfait pour l'arrière-plan et le passé simple pour la rupture : {item.Item2}."
		};
	}

	public ExerciseQuestion GeneratePasseComposeValuesQuestion()
	{
		var pool = new[]
		{
			("J'ai terminé tous mes devoirs, je peux sortir.", "Action achevée ayant des conséquences dans le présent", "Action imaginaire", "Habitude passée", "Ordre formel"),
			("Hier, nous avons visité le musée.", "Fait ponctuel du passé coupé du présent", "Description d'état", "Futur immédiat", "Vérité générale"),
			("As-tu déjà pris ton petit-déjeuner ?", "Bilan dans le présent d'une action passée", "Action en cours", "Hypothèse", "Ordre direct")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_valeurs_passe_compose",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans « {item.Item1} », quelle est la valeur d'emploi du passé composé ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le passé composé relie souvent un fait passé à la situation d'énonciation présente.",
			HintLevel2 = "Observez le lien entre l'action accomplie et l'état actuel.",
			ExplanationText = $"Le passé composé exprime une {item.Item2.ToLowerInvariant()}."
		};
	}

	public ExerciseQuestion GeneratePlusQueParfaitQuestion()
	{
		var pool = new[]
		{
			("Quand il arriva, le train était déjà parti.", "était parti", "Antériorité par rapport à une autre action passée", "Action simultanée", "Postériorité future", "Habitude présente"),
			("Elle retrouva la clé qu'elle avait perdue.", "avait perdue", "Antériorité par rapport au verbe 'retrouva'", "Action postérieure", "Fait incertain", "Présent de narration"),
			("Ils avaient mangé avant de prendre la route.", "avaient mangé", "Action accomplie avant une autre dans le passé", "Action future", "Ordre impératif", "Description continue")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item3, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-B3-{Guid.NewGuid():N}",
			SubjectId = "francais_col_plus_que_parfait",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Dans « {item.Item1} », quelle valeur exprime le verbe au plus-que-parfait « {item.Item2} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le plus-que-parfait marque une action accomplie avant une autre action déjà passée.",
			HintLevel2 = "Il indique que l'événement s'est déroulé en amont du passé simple ou de l'imparfait.",
			ExplanationText = $"Le plus-que-parfait marque l'{item.Item3.ToLowerInvariant()}."
		};
	}

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

	private List<string> Shuffle(string c, string w1, string w2, string w3, out int correctIndex)
	{
		var list = new List<string> { c, w1, w2, w3 };
		var n = list.Count;
		while (n > 1)
		{
			n--;
			var k = _random.Next(n + 1);
			(list[k], list[n]) = (list[n], list[k]);
		}
		correctIndex = list.IndexOf(c);
		return list;
	}
}

