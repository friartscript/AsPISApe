using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateAdvancedQuestion()
	{
		var variant = _random.Next(5);
		return variant switch
		{
			0 => GenerateColorAdjectiveAgreementTrap(),
			1 => GeneratePronominalCodAfterTrap(),
			2 => GeneratePronominalInvariableVerbsTrap(),
			3 => GenerateSubjunctiveConcessionTrap(),
			_ => GenerateFigureLitoteEphemismeTrap()
		};
	}

	private ExerciseQuestion GenerateColorAdjectiveAgreementTrap()
	{
		var items = new[]
		{
			("des chaussures", "marron", "marronnes", "marrons", "marronne", "nom de fruit employé comme adjectif"),
			("des vestes", "bleu marine", "bleues marines", "bleu marines", "bleues marine", "adjectif de couleur composé"),
			("des rideaux", "orange", "oranges", "orangees", "oranger", "nom de fruit employé comme adjectif"),
			("des yeux", "vert clair", "verts clairs", "vert clairs", "verts clair", "adjectif de couleur composé")
		};
		var item = items[_random.Next(items.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-ADV-COL-{_random.Next(1000, 9999)}",
			SubjectId = "FR-ADV-001",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 35,
			QuestionText = $"Quelle est l'orthographe correcte pour : « {item.Item1} [...] » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les adjectifs de couleur composés ou dérivés d'un nom de fruit/fleur/matière sont invariables.",
			HintLevel2 = $"Ici « {item.Item2} » est un {item.Item6}, il ne prend donc ni 's' ni 'e'.",
			ExplanationText = $"Règle d'or : les adjectifs de couleur composés ou dérivés de noms restent invariables."
		};
	}

	private ExerciseQuestion GeneratePronominalCodAfterTrap()
	{
		var items = new[]
		{
			("Elles se sont", "lavé", "les mains", "lavées", "lavés", "lavée"),
			("Elle s'est", "coupé", "le doigt", "coupée", "coupés", "coupee"),
			("Ils se sont", "acheté", "une maison", "achetés", "achetée", "achetées"),
			("Elle s'est", "brossé", "les cheveux", "brossée", "brossés", "brosse")
		};
		var item = items[_random.Next(items.Length)];
		var choices = Shuffle(item.Item2, item.Item4, item.Item5, item.Item6, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-ADV-PRON-COD-{_random.Next(1000, 9999)}",
			SubjectId = "FR-ADV-002",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 40,
			QuestionText = $"Complète la phrase : « {item.Item1} [...] {item.Item3}. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le participe d'un verbe pronominal s'accorde avec le COD seulement si celui-ci est placé AVANT le verbe.",
			HintLevel2 = $"Le COD « {item.Item3} » est placé APRÈS le verbe. Il n'y a donc pas d'accord.",
			ExplanationText = $"Le COD ({item.Item3}) étant placé après le verbe, le participe passé reste invariable : {item.Item2}."
		};
	}

	private ExerciseQuestion GeneratePronominalInvariableVerbsTrap()
	{
		var items = new[]
		{
			("Elles se sont", "parlé", "parlées", "parlés", "parlée", "parler à quelqu'un"),
			("Ils se sont", "succédé", "succédés", "succédées", "succedee", "succéder à quelqu'un"),
			("Mes amies se sont", "téléphoné", "téléphonées", "téléphonés", "telephonee", "téléphoner à quelqu'un"),
			("Les deux rivaux se sont", "souri", "souris", "sourirent", "sourit", "sourire à quelqu'un")
		};
		var item = items[_random.Next(items.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-ADV-PRON-COI-{_random.Next(1000, 9999)}",
			SubjectId = "FR-ADV-003",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 40,
			QuestionText = $"Quel est l'accord correct : « {item.Item1} [...] pendant des heures. » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Ces verbes se construisent avec la préposition 'à'. Ils ne peuvent jamais avoir de COD.",
			HintLevel2 = $"On dit « {item.Item6} ». Sans COD possible, le participe passé est toujours invariable.",
			ExplanationText = $"Ce verbe admet un COI et jamais de COD : le participe passé reste toujours invariable."
		};
	}

	private ExerciseQuestion GenerateSubjunctiveConcessionTrap()
	{
		var correct = "soit";
		var w1 = "est";
		var w2 = "sera";
		var w3 = "serait";

		var choices = Shuffle(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-FR-ADV-SUBJ-{_random.Next(1000, 9999)}",
			SubjectId = "FR-ADV-004",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 35,
			QuestionText = "Complète la phrase : « Bien qu'il [...] épuisé par le voyage, il participe au tournoi. »",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La conjonction de subordination 'bien que' exige obligatoirement un mode particulier.",
			HintLevel2 = "'Bien que' et 'quoique' introduisent une concession et régissent toujours le subjonctif.",
			ExplanationText = "La locution conjonctive 'bien que' est toujours suivie du mode subjonctif : 'soit'."
		};
	}

	private ExerciseQuestion GenerateFigureLitoteEphemismeTrap()
	{
		var correct = "Une litote (dire moins pour faire entendre plus)";
		var w1 = "Un euphémisme (atténuer une réalité choquante ou douloureuse)";
		var w2 = "Une antiphrase (dire le contraire de ce que l'on pense)";
		var w3 = "Une hyperbole (exagérer pour impressionner)";

		var choices = Shuffle(correct, w1, w2, w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-FR-ADV-RHET-{_random.Next(1000, 9999)}",
			SubjectId = "FR-ADV-005",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			BasePoints = 50,
			QuestionText = "Dans la phrase : « Ce joueur n'est pas maladroit du tout devant les buts ! », quelle figure de style est employée ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La phrase utilise une négation pour en réalité exprimer un fort éloge ('il est très doué').",
			HintLevel2 = "Affaiblir une idée par une double négation pour lui donner plus de force s'appelle une litote.",
			ExplanationText = "La litote atténue l'expression pour renforcer le sens positif : 'pas maladroit' = très adroit."
		};
	}
}
