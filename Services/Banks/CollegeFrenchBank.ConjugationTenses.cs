using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
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
}

