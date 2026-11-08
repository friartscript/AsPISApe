using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateLexicalFieldQuestion()
	{
		var fields = new[]
		{
			("vague, marée, récif, écume, gouvernail", "la mer et la navigation", "la montagne et l'escalade", "le ciel et l'astronomie", "la forêt et la faune"),
			("épée, bouclier, armure, heaume, tournoi", "la chevalerie médiévale", "la cuisine moderne", "l'agriculture antique", "la peinture impressionniste"),
			("sombre, frisson, grincement, angoisse, spectre", "la peur et le fantastique", "la joie et la fête", "le voyage touristique", "la science-fiction futuriste"),
			("toile, palette, chevalet, pinceau, vernis", "la peinture artistique", "la menuiserie", "la musique symphonique", "la sculpture sur pierre")
		};
		var item = fields[_random.Next(fields.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-CHAMLEX-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-050",
			Discipline = "Francais",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = $"À quel champ lexical appartient la liste de mots suivante : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un champ lexical regroupe l'ensemble des mots qui se rapportent à un même thème ou une même notion.",
			HintLevel2 = $"Tous ces termes renvoient au thème de {item.Item2}.",
			ExplanationText = $"Cette liste constitue le champ lexical de {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateLanguageRegisterQuestion()
	{
		var cases = new[]
		{
			("« Ce bouquin est carrément trop stylé ! »", "familier", "courant", "soutenu", "technique"),
			("« Cet ouvrage présente un intérêt littéraire remarquable. »", "soutenu", "courant", "familier", "argotique"),
			("« Ce livre est très intéressant à lire. »", "courant", "soutenu", "familier", "poétique"),
			("« J'ai la flemme d'aller au bahut ce matin. »", "familier", "courant", "soutenu", "administratif")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-REGIST-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-051",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Quel est le niveau de langue de la phrase suivante : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Distingue les trois niveaux de langue : familier (oral décontracté), courant (neutre et standard), soutenu (recherché et soigné).",
			HintLevel2 = $"Le vocabulaire et la syntaxe employés relèvent du niveau {item.Item2}.",
			ExplanationText = $"Cette phrase appartient au registre {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateMeliorativePejorativeQuestion()
	{
		var cases = new[]
		{
			("« Cette magnifique et somptueuse demeure émerveille les passants. »", "mélioratif (élogieux, valorisant)", "péjoratif (dévalorisant)", "neutre (purement descriptif)", "ironique"),
			("« Ce taudis sinistre et délabré tombe en ruine. »", "péjoratif (dévalorisant, négatif)", "mélioratif (valorisant)", "neutre", "admiratif"),
			("« Le bâtiment mesure quinze mètres de hauteur et comporte trois étages. »", "neutre (objectif, informatif)", "mélioratif", "péjoratif", "enthousiaste")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-MELIOR-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-052",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Quelle est la tonalité du vocabulaire employé dans : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un terme mélioratif exprime un jugement positif ou valorisant. Un terme péjoratif dévalorise ou critique.",
			HintLevel2 = $"Le vocabulaire est {item.Item2}.",
			ExplanationText = $"Le vocabulaire employé est {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateDirectIndirectSpeechQuestion()
	{
		var cases = new[]
		{
			("Le capitaine s'écria : « Hissez la grand-voile immédiatement ! »", "Discours direct (guillemets, deux-points, verbe de parole)", "Discours indirect", "Discours indirect libre", "Récit de paroles"),
			("Le capitaine ordonna que les marins hissent la grand-voile immédiatement.", "Discours indirect (subordonnée introduite par que, sans guillemets)", "Discours direct", "Discours narratif", "Monologue intérieur"),
			("Il ne cèderait pas. Qu'ils viennent donc le chercher s'ils l'osaient !", "Discours indirect libre (pensées intégrées au récit sans verbe introducteur)", "Discours direct", "Discours indirect classique", "Description théâtrale")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-DISCOURS-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-053",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Sous quelle forme de paroles rapportées se présente cet extrait : « {item.Item1} » ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Observe la ponctuation (deux-points, guillemets), la présence de propositions subordonnées ou l'absence de verbe introducteur.",
			HintLevel2 = $"Cet extrait relève du : {item.Item2}.",
			ExplanationText = $"Cet extrait est rédigé au {item.Item2}."
		};
	}
}

