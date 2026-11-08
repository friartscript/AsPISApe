using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateContinuityQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateTviBijectionQuestion(),
			1 => GenerateContinuityDifferentiabilityLinkQuestion(),
			_ => GenerateContinuityDefinitionQuestion()
		};
	}

	private ExerciseQuestion GenerateTviBijectionQuestion()
	{
		var correct = "L'équation f(x) = k admet une unique solution sur [a ; b]";
		var wrong1 = "L'équation f(x) = k admet au moins deux solutions sur [a ; b]";
		var wrong2 = "L'équation f(x) = k n'a aucune solution sur [a ; b]";
		var wrong3 = "f s'annule obligatoirement en a et en b";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-TVI-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-04",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Soit f continue et strictement monotone sur [a ; b]. Pour tout k compris entre f(a) et f(b), que garantit le corollaire du TVI ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La stricte monotonie empêche la fonction de repasser une deuxième fois par la même valeur k.",
			HintLevel2 = "Continuité assure l'existence d'une solution, stricte monotonie en assure l'unicité.",
			ExplanationText = "Le corollaire du TVI garantit l'existence et l'unicité de la solution."
		};
	}

	private ExerciseQuestion GenerateContinuityDifferentiabilityLinkQuestion()
	{
		var correct = "La dérivabilité implique la continuité (la réciproque est fausse)";
		var wrong1 = "La continuité implique obligatoirement la dérivabilité";
		var wrong2 = "Une fonction continue n'est jamais dérivable";
		var wrong3 = "Continuité et dérivabilité sont strictement équivalentes";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-CNDR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-04",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Quelle relation exacte lie la dérivabilité et la continuité d'une fonction en un point ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Pensez à la fonction valeur absolue en 0 : continue mais non dérivable (point anguleux).",
			HintLevel2 = "Toute fonction dérivable est continue, mais l'inverse n'est pas toujours vrai.",
			ExplanationText = "Si f est dérivable en x0, alors elle y est continue (réciproque fausse)."
		};
	}

	private ExerciseQuestion GenerateContinuityDefinitionQuestion()
	{
		var a = _random.Next(1, 5);
		var correct = $"lim (x -> {a}) f(x) = f({a})";
		var wrong1 = $"lim (x -> {a}) f'(x) = 0";
		var wrong2 = $"f({a}) = 0";
		var wrong3 = $"lim (x -> +∞) f(x) = {a}";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-DEFCNT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-04",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Par définition, que signifie qu'une fonction f est continue en un point d'abscisse a = {a} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La limite de la fonction lorsque x tend vers a doit coïncider avec l'image f(a).",
			HintLevel2 = "Le tracé de la courbe ne subit aucun saut ou rupture en x = a.",
			ExplanationText = $"f est continue en {a} ssi sa limite en {a} est égale à f({a})."
		};
	}
}

