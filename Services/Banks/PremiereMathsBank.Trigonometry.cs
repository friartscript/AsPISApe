using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class PremiereMathsBank
{
	public ExerciseQuestion GenerateTrigonometryQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateRemarkableAngleValueQuestion(),
			1 => GenerateTrigPythagoreanIdentityQuestion(),
			2 => GenerateTrigParityQuestion(),
			_ => GenerateAssociatedAnglesQuestion()
		};
	}

	private ExerciseQuestion GenerateRemarkableAngleValueQuestion()
	{
		var angles = new (string angle, string cosVal, string sinVal, string w1, string w2)[]
		{
			("π / 3", "1 / 2", "√3 / 2", "√2 / 2", "0"),
			("π / 6", "√3 / 2", "1 / 2", "√2 / 2", "1"),
			("π / 4", "√2 / 2", "√2 / 2", "1 / 2", "√3 / 2"),
			("π / 2", "0", "1", "-1", "1 / 2"),
			("π", "-1", "0", "1", "√2 / 2")
		};
		var pick = angles[_random.Next(angles.Length)];

		var choices = Shuffle(pick.cosVal, pick.w1, pick.w2, pick.sinVal == pick.cosVal ? "-1/2" : pick.sinVal, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-TRG1-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-07",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = $"Quelle est la valeur exacte du cosinus de l'angle {pick.angle} radians ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Repérez la position de cet angle remarquable sur le cercle trigonométrique.",
			HintLevel2 = "L'abscisse du point donne le cosinus et l'ordonnée donne le sinus.",
			ExplanationText = $"Sur le cercle trigonométrique, cos({pick.angle}) = {pick.cosVal}."
		};
	}

	private ExerciseQuestion GenerateTrigPythagoreanIdentityQuestion()
	{
		var correct = "cos²(x) + sin²(x) = 1";
		var wrong1 = "cos²(x) - sin²(x) = 1";
		var wrong2 = "cos(x) + sin(x) = 1";
		var wrong3 = "cos²(x) + sin²(x) = 0";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-TRGP-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-07",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Quelle relation fondamentale lie le cosinus et le sinus de tout nombre réel x ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Cette relation découle directement du théorème de Pythagore dans le cercle trigonométrique de rayon 1.",
			HintLevel2 = "La somme des carrés de l'abscisse et de l'ordonnée vaut 1.",
			ExplanationText = "Pour tout réel x, l'identité fondamentale est cos²(x) + sin²(x) = 1."
		};
	}

	private ExerciseQuestion GenerateTrigParityQuestion()
	{
		var correct = "cos(-x) = cos(x) (paire) et sin(-x) = -sin(x) (impaire)";
		var wrong1 = "cos(-x) = -cos(x) et sin(-x) = sin(x)";
		var wrong2 = "Le cosinus et le sinus sont tous les deux des fonctions paires";
		var wrong3 = "Le cosinus et le sinus sont tous les deux des fonctions impaires";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-TRGPR-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-07",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Quelles sont les propriétés de parité respectives des fonctions cosinus et sinus ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les points d'angles x et -x sur le cercle sont symétriques par rapport à l'axe des abscisses.",
			HintLevel2 = "Leurs abscisses sont identiques mais leurs ordonnées sont opposées.",
			ExplanationText = "La fonction cosinus est paire et la fonction sinus est impaire."
		};
	}

	private ExerciseQuestion GenerateAssociatedAnglesQuestion()
	{
		var correct = "cos(π - x) = -cos(x)";
		var wrong1 = "cos(π - x) = cos(x)";
		var wrong2 = "cos(π - x) = sin(x)";
		var wrong3 = "cos(π - x) = -sin(x)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-1RE-TRGAS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-1RE-07",
			Discipline = "Maths",
			ClassLevel = "1re Spé",
			Palier = 3,
			QuestionText = "Parmi ces formules d'angles associés, laquelle est exacte ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les points x et π - x sont symétriques par rapport à l'axe des ordonnées.",
			HintLevel2 = "Leurs abscisses sont donc opposées : cos(π - x) = -cos(x).",
			ExplanationText = "Par symétrie axiale, cos(π - x) = -cos(x)."
		};
	}
}
