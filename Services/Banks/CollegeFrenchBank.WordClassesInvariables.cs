using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
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
}

