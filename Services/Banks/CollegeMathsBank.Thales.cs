using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateThalesDirectTriangleQuestion()
	{
		var ab = 6;
		var am = 2;
		var ac = 9;
		var an = (am * ac) / ab;
		var correct = $"{an} cm";
		var wrong1 = $"{an + 1} cm";
		var wrong2 = $"{am * 2} cm";
		var wrong3 = "5 cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-THALDIR-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-078",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Dans le triangle ABC, M appartient à [AB], N appartient à [AC] et les droites (MN) et (BC) sont parallèles. On sait que AB = {ab} cm, AM = {am} cm et AC = {ac} cm. Calcule AN.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "D'après le théorème de Thalès : AM / AB = AN / AC = MN / BC. Utilise l'égalité des deux premiers rapports et le produit en croix.",
			HintLevel2 = $"AN = (AM × AC) / AB = ({am} × {ac}) / {ab} = {am * ac} / {ab}.",
			ExplanationText = $"AN = ({am} × {ac}) / {ab} = {an} cm."
		};
	}

	public ExerciseQuestion GenerateThalesButterflyQuestion()
	{
		var oa = 4;
		var ob = 8;
		var ab = 5;
		var cd = (ob * ab) / oa;
		var correct = $"{cd} cm";
		var wrong1 = $"{cd + 2} cm";
		var wrong2 = $"{ab * 3} cm";
		var wrong3 = "7 cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-THALPAP-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-078",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Deux droites (AD) et (BC) se coupent en O (configuration papillon). Les droites (AB) et (CD) sont parallèles. On donne OA = {oa} cm, OB = {ob} cm et AB = {ab} cm. Si OC = {ob} cm, que vaut CD sachant que OB/OA = CD/AB ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "En configuration papillon, le théorème de Thalès s'applique avec le point d'intersection O comme sommet commun.",
			HintLevel2 = $"Rapport d'agrandissement = {ob} / {oa} = {ob / oa}. Multiplie AB ({ab}) par {ob / oa}.",
			ExplanationText = $"CD = AB × (OB / OA) = {ab} × ({ob} / {oa}) = {cd} cm."
		};
	}

	public ExerciseQuestion GenerateThalesConverseQuestion()
	{
		var cases = new[]
		{
			(2, 6, 3, 9, "Oui, car AM/AB = 2/6 = 1/3 et AN/AC = 3/9 = 1/3 (rapports égaux dans le même ordre)", "Non, 2/6 ≠ 3/9", "Oui, seulement si l'angle est droit", "Non, les points ne sont pas alignés"),
			(2, 5, 4, 8, "Non, car 2/5 = 0,4 alors que 4/8 = 0,5 (rapports inégaux)", "Oui, car 4 est le double de 2", "Oui, les droites sont parallèles", "Non, car 2 + 5 ≠ 4 + 8"),
			(3, 9, 4, 12, "Oui, car 3/9 = 1/3 et 4/12 = 1/3 (rapports égaux)", "Non, 9/3 ≠ 12/4", "Oui, mais uniquement si ABC est isocèle", "Non, car 3 et 4 sont consécutifs")
		};
		var item = cases[_random.Next(cases.Length)];
		var choices = Shuffle(item.Item5, item.Item6, item.Item7, item.Item8, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-THALREC-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-079",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Sur les côtés d'un triangle ABC, on a AM = {item.Item1} cm, AB = {item.Item2} cm, AN = {item.Item3} cm et AC = {item.Item4} cm (points alignés dans le même ordre). Les droites (MN) et (BC) sont-elles parallèles ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calcule et compare séparément les quotients AM / AB et AN / AC.",
			HintLevel2 = $"AM / AB = {item.Item1} / {item.Item2} et AN / AC = {item.Item3} / {item.Item4}.",
			ExplanationText = item.Item5
		};
	}

	public ExerciseQuestion GenerateThalesPisaShadowQuestion()
	{
		var stickH = 1;
		var stickShadow = 2;
		var treeShadow = _random.Next(6, 12) * 2;
		var treeH = (treeShadow * stickH) / stickShadow;
		var correct = $"{treeH} m";
		var wrong1 = $"{treeShadow - stickShadow} m";
		var wrong2 = $"{treeH * 2} m";
		var wrong3 = $"{treeShadow} m";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-THALPISA-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-078",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Pour mesurer la hauteur d'un arbre sans y monter, un élève plante un bâton de {stickH} m à la verticale. L'ombre du bâton mesure {stickShadow} m. Au même moment, l'ombre de l'arbre mesure {treeShadow} m. Quelle est la hauteur de l'arbre d'après le théorème de Thalès ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Les rayons du soleil étant parallèles, les hauteurs des objets sont proportionnelles à la longueur de leurs ombres.",
			HintLevel2 = $"Hauteur de l'arbre = (Ombre de l'arbre × Hauteur du bâton) / Ombre du bâton = ({treeShadow} × {stickH}) / {stickShadow}.",
			ExplanationText = $"Hauteur = ({treeShadow} × {stickH}) / {stickShadow} = {treeH} m."
		};
	}
}

