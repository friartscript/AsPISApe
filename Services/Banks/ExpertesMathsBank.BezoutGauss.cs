using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class ExpertesMathsBank
{
	public ExerciseQuestion GenerateBezoutGaussQuestion()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateBezoutTheoremQuestion(),
			1 => GenerateGaussTheoremQuestion(),
			_ => GenerateEuclideanAlgorithmQuestion()
		};
	}

	private ExerciseQuestion GenerateBezoutTheoremQuestion()
	{
		var correct = "Il existe des entiers relatifs u et v tels que au + bv = 1";
		var wrong1 = "Pour tous entiers relatifs u et v, au + bv = 1";
		var wrong2 = "Le produit ab est un nombre premier";
		var wrong3 = "a divise b ou b divise a";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-BZT-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-04",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "D'après le théorème de Bézout, quelle condition caractérise deux entiers a et b premiers entre eux (PGCD(a, b) = 1) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "L'identité de Bézout est une combinaison linéaire égale à 1.",
			HintLevel2 = "L'existence de coefficients de Bézout entiers u et v tels que au + bv = 1 est une CNS.",
			ExplanationText = "Théorème de Bézout : PGCD(a,b)=1 ssi il existe u,v tels que au + bv = 1."
		};
	}

	private ExerciseQuestion GenerateGaussTheoremQuestion()
	{
		var correct = "a divise obligatoirement c";
		var wrong1 = "a divise obligatoirement b";
		var wrong2 = "b divise obligatoirement c";
		var wrong3 = "c est un nombre premier";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-GSS-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-04",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = "Soient trois entiers a, b et c. Si a divise le produit bc et si a est premier avec b, que conclut le théorème de Gauss ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Comme a ne partage aucun facteur commun avec b, toute la divisibilité se reporte sur c.",
			HintLevel2 = "C'est l'énoncé fondamental du théorème de Gauss.",
			ExplanationText = "Théorème de Gauss : si a divise bc et PGCD(a, b)=1, alors a divise c."
		};
	}

	private ExerciseQuestion GenerateEuclideanAlgorithmQuestion()
	{
		var triples = new (int a, int b, int pgcd, int w1, int w2, int w3)[]
		{
			(360, 252, 36, 18, 72, 12),
			(455, 130, 65, 13, 5, 26),
			(510, 357, 51, 17, 3, 102),
			(84, 60, 12, 6, 24, 4)
		};
		var pick = triples[_random.Next(triples.Length)];

		var choices = Shuffle(pick.pgcd.ToString(), pick.w1.ToString(), pick.w2.ToString(), pick.w3.ToString(), out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-EXP-EUCAL-{_random.Next(1000, 9999)}",
			SubjectId = "LYC-EXP-04",
			Discipline = "Maths",
			ClassLevel = "Tale Exp",
			Palier = 5,
			QuestionText = $"Déterminez le PGCD de {pick.a} et {pick.b} à l'aide de l'algorithme d'Euclide.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Effectuez des divisions euclidiennes successives jusqu'au dernier reste non nul.",
			HintLevel2 = "Le PGCD est le dernier reste non nul de l'algorithme d'Euclide.",
			ExplanationText = $"Le dernier reste non nul de l'algorithme d'Euclide est {pick.pgcd}."
		};
	}
}

