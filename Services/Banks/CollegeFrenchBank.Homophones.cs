using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateBasicHomophonesQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateAOrAGraveQuestion(),
			1 => GenerateOntOrOnQuestion(),
			_ => GenerateSonOrSontQuestion()
		};
	}

	public ExerciseQuestion GenerateDemonstrativeHomophonesQuestion()
	{
		var variant = _random.Next(2);
		return variant switch
		{
			0 => GenerateCeOrSeQuestion(),
			_ => GenerateCestOrSestQuestion()
		};
	}

	public ExerciseQuestion GenerateToutAgreementQuestion()
	{
		var items = new[]
		{
			("Elle a lu [...] les consignes avant de débuter l'épreuve.", "toutes", "tout", "tous", "touts", "féminin pluriel (déterminant s'accordant avec « les consignes »)"),
			("[...] le monde s'accorde sur l'importance du travail d'équipe.", "Tout", "Tous", "Toute", "Toutes", "masculin singulier (« le monde »)"),
			("Ils sont [...] arrivés à l'heure au rendez-vous.", "tous", "tout", "toute", "toutes", "pronom masculin pluriel remplaçant « ils »"),
			("Cette décision s'applique à [...] vitesse.", "toute", "tout", "tous", "toutes", "féminin singulier (« vitesse »)")
		};
		var item = items[_random.Next(items.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-TOUT-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-042",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Complète correctement la phrase : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Détermine si « tout » est déterminant, pronom ou adverbe, et repère le genre et le nombre du nom associé.",
			HintLevel2 = $"Ici, l'accord se fait au {item.Item6}.",
			ExplanationText = $"L'orthographe correcte selon le contexte est : {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateLeurAgreementQuestion()
	{
		var items = new[]
		{
			("Les élèves rangent [...] cahiers dans leurs sacs.", "leurs", "leur", "leure", "leures", "déterminant possessif devant un nom pluriel (cahiers)"),
			("Nous [...] avons expliqué la règle trois fois.", "leur", "leurs", "leure", "leures", "pronom personnel invariable (complément d'objet)"),
			("Les oiseaux nourrissent [...] petits dans le nid.", "leurs", "leur", "leure", "leures", "déterminant possessif devant le nom pluriel petits"),
			("Il faut [...] donner une seconde chance.", "leur", "leurs", "leure", "leures", "pronom personnel invariable placé devant le verbe")
		};
		var item = items[_random.Next(items.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-LEUR-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-043",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Choisis la bonne graphie entre « leur » et « leurs » : « {item.Item1} »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "« Leur » devant un verbe est un pronom personnel INVARIABLE (jamais de s). Devant un nom pluriel, c'est un déterminant possessif qui prend un s.",
			HintLevel2 = $"Dans cette phrase, il s'agit d'un {item.Item6}.",
			ExplanationText = $"La bonne graphie est : {item.Item2} ({item.Item6})."
		};
	}

	private ExerciseQuestion GenerateAOrAGraveQuestion()
	{
		var correct = "a / à";
		var wrong1 = "à / a";
		var wrong2 = "a / a";
		var wrong3 = "à / à";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-HOM1-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-044",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = "Complète : « Paul [...] invité sa cousine [...] venir dîner ce soir. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Astuce : si tu peux remplacer par « avait », il s'agit du verbe avoir (a sans accent). Sinon, c'est la préposition à.",
			HintLevel2 = "On peut dire « Paul avait invité » mais pas « avait venir ».",
			ExplanationText = "« Paul a (avait) invité sa cousine à (préposition) venir »."
		};
	}

	private ExerciseQuestion GenerateOntOrOnQuestion()
	{
		var correct = "On / ont";
		var wrong1 = "Ont / on";
		var wrong2 = "On / on";
		var wrong3 = "Ont / ont";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-HOM2-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-044",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = "Complète : « [...] sait que les joueurs [...] tout donné pour gagner ce match. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "« On » est un pronom sujet remplaçable par « il ». « Ont » est le verbe avoir remplaçable par « avaient ».",
			HintLevel2 = "« Il sait que les joueurs avaient tout donné ».",
			ExplanationText = "« On (il) sait que les joueurs ont (avaient) tout donné »."
		};
	}

	private ExerciseQuestion GenerateSonOrSontQuestion()
	{
		var correct = "son / sont";
		var wrong1 = "sont / son";
		var wrong2 = "son / son";
		var wrong3 = "sont / sont";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-HOM3-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-044",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = "Complète : « Marc a pris [...] manteau car les nuits [...] fraîches en automne. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "« Son » est un déterminant possessif (remplaçable par « mon »). « Sont » est le verbe être (remplaçable par « étaient »).",
			HintLevel2 = "« Marc a pris mon manteau car les nuits étaient fraîches ».",
			ExplanationText = "« Son (mon) manteau car les nuits sont (étaient) fraîches »."
		};
	}

	private ExerciseQuestion GenerateCeOrSeQuestion()
	{
		var correct = "se / ce";
		var wrong1 = "ce / se";
		var wrong2 = "se / se";
		var wrong3 = "ce / ce";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-HOM4-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-045",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = "Complète : « L'athlète [...] prépare activement pour [...] grand championnat. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "« Se » est un pronom réfléchi placé devant un verbe pronominal (se préparer). « Ce » est un déterminant démonstratif placé devant un nom (ce championnat).",
			HintLevel2 = "On écrit « se prépare » (verbe) et « ce championnat » (nom masculin).",
			ExplanationText = "« Se prépare » (pronom réfléchi) et « ce championnat » (déterminant démonstratif)."
		};
	}

	private ExerciseQuestion GenerateCestOrSestQuestion()
	{
		var correct = "s'est / c'est";
		var wrong1 = "c'est / s'est";
		var wrong2 = "s'est / s'est";
		var wrong3 = "c'est / c'est";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-HOM5-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-045",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = "Complète : « Thomas [...] trompé de chemin, mais [...] sans gravité. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "« S'est » vient du verbe pronominal se tromper (à la 1re personne : je me suis trompé). « C'est » sert à présenter une chose (remplaçable par cela est).",
			HintLevel2 = "Thomas s'est trompé (se tromper) ; c'est sans gravité (cela est).",
			ExplanationText = "« S'est trompé » (verbe pronominal) et « c'est sans gravité » (présentatif = cela est)."
		};
	}
}

