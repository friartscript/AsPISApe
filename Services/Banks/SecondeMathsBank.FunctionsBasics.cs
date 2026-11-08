using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class SecondeMathsBank
{
	public ExerciseQuestion GenerateFunctionsBasicsQuestion()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => GenerateReferenceFunctionSquareQuestion(),
			1 => GenerateReferenceFunctionInverseQuestion(),
			2 => GenerateFunctionParityQuestion(),
			_ => GenerateDefinitionDomainQuestion()
		};
	}

	private ExerciseQuestion GenerateReferenceFunctionSquareQuestion()
	{
		var a = _random.Next(3, 8);
		var aSq = a * a;

		var correct = $"Deux antécédents : -{a} et {a}";
		var wrong1 = $"Un seul antécédent : {a}";
		var wrong2 = $"Deux antécédents : 0 et {a}";
		var wrong3 = "Aucun antécédent car un carré est positif";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-SQR2-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-08",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Soit la fonction carré f(x) = x². Quels sont les antécédents de {aSq} par f ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Résolvez l'équation x² = k pour un nombre k > 0.",
			HintLevel2 = $"x² = {aSq} a deux solutions réelles distinctes : -√{aSq} et √{aSq}.",
			ExplanationText = $"x² = {aSq} équivaut à x = -{a} ou x = {a}."
		};
	}

	private ExerciseQuestion GenerateReferenceFunctionInverseQuestion()
	{
		var frac = _random.Next(2, 7);
		var correct = "R* = ]-∞ ; 0[ ∪ ]0 ; +∞[";
		var wrong1 = "[0 ; +∞[";
		var wrong2 = "R";
		var wrong3 = "]-∞ ; 0]";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-INV-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-08",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = "Quel est l'ensemble de définition de la fonction inverse f(x) = 1 / x ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le dénominateur d'une fraction ne peut jamais être égal à zéro.",
			HintLevel2 = "0 est la seule valeur interdite de la fonction inverse.",
			ExplanationText = "La fonction inverse est définie sur tous les réels non nuls R*."
		};
	}

	private ExerciseQuestion GenerateFunctionParityQuestion()
	{
		var funcs = new (string expr, string parity, string prop, string w1, string w2, string w3)[]
		{
			("f(x) = x² + 4", "Paire", "Symétrique par rapport à l'axe des ordonnées", "Impaire", "Ni paire ni impaire", "Périodique"),
			("f(x) = x³", "Impaire", "Symétrique par rapport à l'origine O", "Paire", "Constante", "Ni paire ni impaire"),
			("f(x) = 2x", "Impaire", "Symétrique par rapport à l'origine O", "Paire", "Symétrique par rapport à l'axe (Ox)", "Ni paire ni impaire"),
			("f(x) = 3x²", "Paire", "Symétrique par rapport à l'axe des ordonnées", "Impaire", "Décroissante sur R", "Ni paire ni impaire")
		};
		var pick = funcs[_random.Next(funcs.Length)];

		var choices = Shuffle(pick.parity, pick.w1, pick.w2, pick.w3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-PAR2-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-08",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quelle est la parité de la fonction définie par {pick.expr} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calculez f(-x) et comparez avec f(x) : paire si f(-x)=f(x), impaire si f(-x)=-f(x).",
			HintLevel2 = $"{pick.prop}.",
			ExplanationText = $"{pick.expr} est une fonction {pick.parity}."
		};
	}

	private ExerciseQuestion GenerateDefinitionDomainQuestion()
	{
		var a = _random.Next(1, 8);
		var correct = $"[{a} ; +∞[";
		var wrong1 = $"]{a} ; +∞[";
		var wrong2 = $"[-∞ ; {a}]";
		var wrong3 = "R";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-SEC-DOM-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-2DE-08",
			Discipline = "Maths",
			ClassLevel = "2de",
			Palier = 2,
			QuestionText = $"Quel est l'ensemble de définition de la fonction f(x) = √(x - {a}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'expression sous une racine carrée doit obligatoirement être supérieure ou égale à 0.",
			HintLevel2 = $"Résolvez x - {a} ≥ 0.",
			ExplanationText = $"x - {a} ≥ 0 équivaut à x ≥ {a}, soit [{a} ; +∞[."
		};
	}
}
