using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateSubjectVerbAgreementQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateInvertedSubjectAgreement(),
			1 => GenerateCollectiveSubjectAgreement(),
			_ => GenerateMultipleSubjectsAgreement()
		};
	}

	public ExerciseQuestion GeneratePastParticipleEtreQuestion()
	{
		var subjects = new[]
		{
			("Mes deux sœurs", "sont parties", "sont parti", "sont partie", "sont partis", "féminin pluriel"),
			("La directrice", "est revenue", "est revenu", "est revenues", "est revenut", "féminin singulier"),
			("Tous les délégués", "sont arrivés", "sont arrivé", "sont arrivée", "sont arrivées", "masculin pluriel"),
			("L'actrice principale", "est montée", "est monté", "est montés", "est montées", "féminin singulier")
		};
		var item = subjects[_random.Next(subjects.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-PPE-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-038",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Complète la phrase correctement : « {item.Item1} [...] ce matin. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le participe passé employé avec l'auxiliaire être s'accorde toujours en genre et en nombre avec le sujet.",
			HintLevel2 = $"Le sujet « {item.Item1} » est au {item.Item6}.",
			ExplanationText = $"Avec l'auxiliaire être, le participe passé s'accorde avec le sujet : {item.Item2}."
		};
	}

	public ExerciseQuestion GeneratePastParticipleAvoirQuestion()
	{
		var scenarios = new[]
		{
			("Ces photographies, je les ai", "prises", "pris", "prise", "prient", "féminin pluriel"),
			("La pomme que tu as", "mangée", "mangé", "mangés", "mangées", "féminin singulier"),
			("Les messages qu'il a", "envoyés", "envoyé", "envoyée", "envoyes", "masculin pluriel"),
			("Quelle belle surprise il nous a", "faite", "fait", "faits", "faites", "féminin singulier")
		};
		var item = scenarios[_random.Next(scenarios.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-PPA-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-039",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Trouve la bonne orthographe du participe passé : « {item.Item1} [...] hier. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Avec l'auxiliaire avoir, le participe passé s'accorde avec le COD seulement si celui-ci est placé AVANT le verbe.",
			HintLevel2 = $"Le COD placé avant est au {item.Item6}.",
			ExplanationText = $"Le COD est placé avant le verbe avoir, donc accord en genre et nombre : {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateAdjectiveAgreementQuestion()
	{
		var items = new[]
		{
			("des robes et des vestes", "bleues", "bleu", "bleus", "bleue", "féminin pluriel"),
			("un pantalon et une chemise", "neufs", "neuf", "neuve", "neuves", "masculin pluriel (le masculin l'emporte)"),
			("des eaux minérales particulièrement", "fraîches", "frais", "fraîche", "fraiches", "féminin pluriel"),
			("des exercices et des devoirs", "faciles", "facile", "facil", "facils", "masculin pluriel")
		};
		var item = items[_random.Next(items.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-ADJ-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-040",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = $"Quel est le bon accord de l'adjectif qualificatif dans : « Il a acheté {item.Item1} [...] » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'adjectif s'accorde en genre et en nombre avec le ou les noms qu'il qualifie. S'il y a un masculin et un féminin, le masculin l'emporte.",
			HintLevel2 = $"Le groupe nominal qualifié s'accorde au {item.Item6}.",
			ExplanationText = $"L'adjectif prend la marque du genre et du pluriel : {item.Item2}."
		};
	}

	private ExerciseQuestion GenerateInvertedSubjectAgreement()
	{
		var correct = "s'élèvent";
		var wrong1 = "s'élève";
		var wrong2 = "s'élèves";
		var wrong3 = "s'élever";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-AGR1-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-041",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = "Dans la phrase : « Au loin, derrière les collines, [...] de hautes fumées noires. », quelle est la forme correcte du verbe s'élever ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention au sujet inversé ! Pose la question : qui est-ce qui s'élève ?",
			HintLevel2 = "Le sujet est « de hautes fumées noires », placé après le verbe (3e personne du pluriel).",
			ExplanationText = "Le sujet inversé « de hautes fumées noires » impose la terminaison -ent : s'élèvent."
		};
	}

	private ExerciseQuestion GenerateCollectiveSubjectAgreement()
	{
		var correct = "ont voté";
		var wrong1 = "a voté";
		var wrong2 = "ont voter";
		var wrong3 = "a voter";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-AGR2-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-041",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = "Complète : « La plupart des citoyens [...] en faveur du projet environnemental. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Avec « la plupart », le verbe s'accorde toujours au pluriel avec le complément (ou au pluriel sous-entendu).",
			HintLevel2 = "« La plupart » appelle l'accord au pluriel : ils ont voté.",
			ExplanationText = "« La plupart » entraîne obligatoirement l'accord au pluriel : ont voté."
		};
	}

	private ExerciseQuestion GenerateMultipleSubjectsAgreement()
	{
		var correct = "irons";
		var wrong1 = "ira";
		var wrong2 = "irez";
		var wrong3 = "iront";
		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-AGR3-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-041",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = "Complète : « Ma sœur et moi [...] au cinéma ce samedi soir. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un sujet composé d'une 3e personne et de « moi » équivaut au pronom « nous » (1re personne du pluriel).",
			HintLevel2 = "« Ma sœur et moi » = « Nous », donc terminaison -ons.",
			ExplanationText = "« Ma sœur et moi » équivaut à « nous », d'où l'accord : irons."
		};
	}
}

