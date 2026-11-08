using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateRecurrenceQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateRecurrenceStepsQuestion(),
			1 => GenerateMonotoneConvergenceQuestion(),
			_ => GenerateSqueezeTheoremQuestion()
		};
	}

	private ExerciseQuestion GenerateRecurrenceStepsQuestion()
	{
		var correct = "Initialisation, Hérédité et Conclusion";
		var wrong1 = "Hypothèse, Calcul et Vérification";
		var wrong2 = "Dérivation, Factorisation et Tableau de signes";
		var wrong3 = "Conjecture, Test numérique et Généralisation";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-REC-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-01",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelles sont les trois étapes obligatoires et rigoureuses d'un raisonnement par récurrence ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La preuve vérifie la propriété au premier rang puis sa transmission d'un rang au suivant.",
			HintLevel2 = "On initialise pour n0, on démontre l'hérédité pour tout k, puis on conclut.",
			ExplanationText = "Un raisonnement par récurrence exige l'initialisation, l'hérédité et la conclusion."
		};
	}

	private ExerciseQuestion GenerateMonotoneConvergenceQuestion()
	{
		var correct = "La suite converge vers une limite réelle finie L ≤ M";
		var wrong1 = "La suite diverge vers +∞";
		var wrong2 = "La suite est constante";
		var wrong3 = "La suite oscille indéfiniment";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-TCM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-01",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Soit une suite (u_n) croissante et majorée par un réel M. Que garantit le théorème de convergence monotone ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le théorème de la convergence monotone relie sens de variation et bornes.",
			HintLevel2 = "Toute suite croissante et majorée est obligatoirement convergente.",
			ExplanationText = "Une suite croissante et majorée converge vers une limite finie L ≤ M."
		};
	}

	private ExerciseQuestion GenerateSqueezeTheoremQuestion()
	{
		var limVal = _random.Next(2, 6);
		var correct = $"lim v_n = {limVal}";
		var wrong1 = "lim v_n = 0";
		var wrong2 = "lim v_n = +∞";
		var wrong3 = "On ne peut pas conclure sur la limite de (v_n)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-SQU-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-01",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Pour tout n, on a u_n ≤ v_n ≤ w_n. Sachant que lim u_n = lim w_n = {limVal}, que donne le théorème des gendarmes ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Si une suite est encadrée par deux suites ayant la même limite finie L, elle converge vers L.",
			HintLevel2 = $"Les deux suites encadrantes convergent toutes deux vers {limVal}.",
			ExplanationText = $"Par le théorème des gendarmes, (v_n) converge aussi vers {limVal}."
		};
	}
}

