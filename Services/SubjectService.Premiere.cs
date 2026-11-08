using AsPISApe.Models;

namespace AsPISApe.Services;

public partial class SubjectService
{
	private static readonly List<SubjectItem> _premiereSubjects = new()
	{
		new SubjectItem
		{
			Id = "LYC-1RE-01",
			Title = "Notion de liste en Python",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Algorithmique et programmation",
			Details = "Indexation, listes en compréhension, parcours et manipulations."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-02",
			Title = "Suites numériques",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Algèbre",
			Details = "Suites arithmétiques, suites géométriques, variations et sommes."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-03",
			Title = "Polynômes du second degré",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Algèbre",
			Details = "Forme canonique, discriminant, factorisation et signe du trinôme."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-04",
			Title = "Dérivation",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Taux de variation, nombre dérivé, équation de tangente et formules."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-05",
			Title = "Variations et courbes représentatives",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Signe de f'(x), sens de variation, extremums locaux et optimisation."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-06",
			Title = "Fonction exponentielle",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Définition, relation e^(x+y) = e^x * e^y, stricte positivité et courbe."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-07",
			Title = "Fonctions trigonométriques",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Cercle trigonométrique, radian, cosinus, sinus, parité et périodicité."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-08",
			Title = "Calcul vectoriel et produit scalaire",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Géométrie",
			Details = "Définitions géométriques, produit scalaire en coordonnées et projeté."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-09",
			Title = "Géométrie repérée",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Géométrie",
			Details = "Vecteur normal, équation générale de droite et équation de cercle."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-10",
			Title = "Probabilités conditionnelles",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Probabilités et statistiques",
			Details = "Probabilités conditionnelles, formule des probabilités totales."
		},
		new SubjectItem
		{
			Id = "LYC-1RE-11",
			Title = "Variables aléatoires réelles",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Probabilités et statistiques",
			Details = "Loi de probabilité, espérance E(X), variance V(X) et écart-type."
		}
	};
}
