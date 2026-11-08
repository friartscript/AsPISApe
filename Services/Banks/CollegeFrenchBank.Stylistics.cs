using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	public ExerciseQuestion GenerateComparisonVsMetaphorQuestion()
	{
		var cases = new[]
		{
			("« Ses yeux brillaient comme deux étoiles dans la nuit. »", "une comparaison (avec l'outil 'comme')", "une métaphore", "une personnification", "une hyperbole"),
			("« Cet enfant est un véritable rayon de soleil pour sa famille. »", "une métaphore (assimilation directe sans mot-outil)", "une comparaison", "une anaphore", "un oxymore"),
			("« La lune était une faucille d'or posée sur le velours du ciel. »", "une métaphore (analogie sans outil de comparaison)", "une comparaison avec outil", "une antithèse", "une allitération"),
			("« Il court aussi vite que l'éclair sur la piste. »", "une comparaison (avec l'outil 'aussi... que')", "une métaphore", "un oxymore", "une litote")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-COMPMET-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-060",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Quelle figure de style est employée dans la phrase suivante : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La comparaison utilise un outil de comparaison (comme, tel, pareil à, plus que). La métaphore établit un rapprochement direct sans mot-outil.",
			HintLevel2 = $"Il s'agit d'{item.Item2}.",
			ExplanationText = $"Cette phrase contient {item.Item2}."
		};
	}

	public ExerciseQuestion GeneratePersonificationQuestion()
	{
		var cases = new[]
		{
			("« Le vent hurlait de colère à travers les volets fermés. »", "une personnification", "une hyperbole", "une métaphore", "une antithèse"),
			("« La forêt murmurait de vieux secrets aux promeneurs attentifs. »", "une personnification", "une comparaison", "un oxymore", "une ellipse"),
			("« L'horloge dévorait les minutes avec une cruelle indifférence. »", "une personnification", "une litote", "une gradation", "une assonance")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-PERSO-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-061",
			Discipline = "Francais",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Dans la phrase : {item.Item1}, quelle figure de style attribue un comportement humain à une chose ou un élément naturel ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La personnification consiste à attribuer des caractéristiques, des sentiments ou des comportements humains à un animal, un objet ou une idée.",
			HintLevel2 = "C'est une personnification.",
			ExplanationText = "La personnification prête des traits humains à un élément inanimé."
		};
	}

	public ExerciseQuestion GenerateHyperboleQuestion()
	{
		var cases = new[]
		{
			("« Je meurs de faim après cette longue randonnée ! »", "une hyperbole (exagération pour frapper l'imagination)", "une litote", "un euphémisme", "une métaphore"),
			("« J'ai répété cette consigne un million de fois aujourd'hui. »", "une hyperbole (exagération numérique démesurée)", "une comparaison", "une anaphore", "un oxymore"),
			("« Des torrents de larmes inondaient son visage bouleversé. »", "une hyperbole (amplification expressive)", "une personnification", "un pléonasme", "une métonymie")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-HYPERB-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-062",
			Discipline = "Francais",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Quelle figure d'amplification exagère délibérément la réalité dans : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'hyperbole repose sur l'exagération démesurée des termes pour produire une forte impression.",
			HintLevel2 = $"Il s'agit d'{item.Item2}.",
			ExplanationText = $"Cette formule repose sur {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateOxymoronAntithesisQuestion()
	{
		var cases = new[]
		{
			("« Cette obscure clarté qui tombe des étoiles. » (Corneille)", "un oxymore (deux termes contradictoires juxtaposés côte à côte)", "une antithèse", "une comparaison", "une métaphore"),
			("« Paris est tout petit pour ceux qui s'aiment d'un aussi grand amour. » (Prévert)", "une antithèse (opposition petit / grand dans une même phrase)", "un oxymore", "une hyperbole", "une anaphore"),
			("« Un silence assourdissant envahit soudain la pièce. »", "un oxymore (union de deux mots aux sens contraires)", "une hyperbole", "une litote", "une gradation")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-FR-COL-OXYM-{_random.Next(1000, 9999)}",
			SubjectId = "FR-COL-063",
			Discipline = "Francais",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Quelle figure d'opposition remarquable est présente dans la citation : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'oxymore réunit deux termes de sens opposés dans un même groupe de mots. L'antithèse oppose deux idées dans une même phrase.",
			HintLevel2 = $"Il s'agit d'{item.Item2}.",
			ExplanationText = $"Cette figure est {item.Item2}."
		};
	}
}

