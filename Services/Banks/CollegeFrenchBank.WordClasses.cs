using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
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
			HintLevel2 = "Ce mot est invariable ou appartient à une catégorie morphologique précise.",
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
			HintLevel2 = "Vérifiez son accord en genre et en nombre avec le nom qu'il qualifie.",
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
}

