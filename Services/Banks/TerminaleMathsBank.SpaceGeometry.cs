using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class TerminaleMathsBank
{
	public ExerciseQuestion GenerateSpaceGeometryQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateParametricLineEquationQuestion(),
			1 => GenerateCoplanarVectorsDefinitionQuestion(),
			_ => GenerateSkewLinesDefinitionQuestion()
		};
	}

	private ExerciseQuestion GenerateParametricLineEquationQuestion()
	{
		var xA = _random.Next(-3, 4);
		var yA = _random.Next(-3, 4);
		var zA = _random.Next(-3, 4);
		var a = _random.Next(1, 4);
		var b = _random.Next(1, 4);
		var c = _random.Next(1, 4);

		var correct = $"{{ x = {xA} + {a}t ; y = {yA} + {b}t ; z = {zA} + {c}t (t ∈ R)";
		var wrong1 = $"{{ x = {a} + {xA}t ; y = {b} + {yA}t ; z = {c} + {zA}t (t ∈ R)";
		var wrong2 = $"{a}x + {b}y + {c}z = 0";
		var wrong3 = $"{{ x = {xA}t ; y = {yA}t ; z = {zA}t (t ∈ R)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-PRML-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-09",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = $"Déterminez un système d'équations paramétriques de la droite de l'espace passant par A({xA} ; {yA} ; {zA}) et de vecteur directeur u({a} ; {b} ; {c}).",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Représentation paramétrique d'une droite : x = xA + at, y = yA + bt, z = zA + ct.",
			HintLevel2 = "Les coordonnées du point A forment les termes constants, celles de u sont les coefficients de t.",
			ExplanationText = $"Le système paramétrique est {{ x={xA}+{a}t ; y={yA}+{b}t ; z={zA}+{c}t."
		};
	}

	private ExerciseQuestion GenerateCoplanarVectorsDefinitionQuestion()
	{
		var correct = "w peut s'écrire comme combinaison linéaire : w = a*u + b*v";
		var wrong1 = "Les trois vecteurs ont la même norme";
		var wrong2 = "Le produit scalaire u · v · w est nul";
		var wrong3 = "Les vecteurs u et v sont colinéaires";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-CPLV-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-09",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Dans l'espace, que signifie que trois vecteurs u, v (non colinéaires) et w sont dits coplanaires ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Trois vecteurs sont coplanaires s'ils peuvent être tracés dans un même plan.",
			HintLevel2 = "Algébriquement, cela signifie que le troisième est combinaison linéaire des deux premiers.",
			ExplanationText = "Trois vecteurs sont coplanaires ssi w = a*u + b*v."
		};
	}

	private ExerciseQuestion GenerateSkewLinesDefinitionQuestion()
	{
		var correct = "Non coplanaires (ni sécantes, ni parallèles)";
		var wrong1 = "Parallèles";
		var wrong2 = "Sécantes en un point unique";
		var wrong3 = "Strictement confondues";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-TLE-SKW-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-TLE-09",
			Discipline = "Maths",
			ClassLevel = "Tale Spé",
			Palier = 4,
			QuestionText = "Dans l'espace, comment qualifie-t-on deux droites qui ne sont contenues dans aucun plan commun ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Contrairement au plan, deux droites de l'espace peuvent être disjointes sans être parallèles.",
			HintLevel2 = "Elles n'ont aucun point commun et leurs vecteurs directeurs ne sont pas colinéaires.",
			ExplanationText = "Deux droites sans plan commun sont dites non coplanaires."
		};
	}
}

