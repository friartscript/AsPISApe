using AsPISApe.Models;

namespace AsPISApe.Services;

public partial class SubjectService
{
	private static readonly List<SubjectItem> _secondeSubjects = new()
	{
		new SubjectItem
		{
			Id = "LYC-2DE-01",
			Title = "Algorithmique et programmation Python",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Algorithmique et programmation",
			Details = "Variables, affectation, boucles bornées et non bornées, fonctions."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-02",
			Title = "Nombres et calculs numériques",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Nombres et calculs",
			Details = "Ensembles N, Z, D, Q, R, fractions, puissances, racines et irrationalité."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-03",
			Title = "Intervalles et inégalités",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Nombres et calculs",
			Details = "Intervalles de R, intersection, réunion, encadrements et valeur absolue."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-04",
			Title = "Identités remarquables et équations",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Nombres et calculs",
			Details = "Calculs algébriques, factorisations et équations produit/quotient nul."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-05",
			Title = "Repérage et géométrie du plan",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Géométrie",
			Details = "Repère orthonormé, milieu d'un segment et distance dans le plan."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-06",
			Title = "Vecteurs du plan",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Géométrie",
			Details = "Translations, relation de Chasles, coordonnées et colinéarité."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-07",
			Title = "Droites du plan et systèmes",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Géométrie",
			Details = "Équations cartésiennes, coefficient directeur et systèmes linéaires 2x2."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-08",
			Title = "Généralités sur les fonctions",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Fonctions",
			Details = "Courbes représentatives, fonctions carré, inverse, racine et cube."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-09",
			Title = "Variations et extremums de fonctions",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Fonctions",
			Details = "Croissance, décroissance, tableau de variations, maximum et minimum."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-10",
			Title = "Signe d'une fonction et inéquations",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Fonctions",
			Details = "Tableaux de signes, inéquations produit nul et inéquations quotient."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-11",
			Title = "Proportions et évolutions en pourcentage",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Statistiques et probabilités",
			Details = "Sous-populations, coefficient multiplicateur et évolutions successives."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-12",
			Title = "Statistiques descriptives",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Statistiques et probabilités",
			Details = "Moyenne, écart-type, médiane, quartiles et diagrammes en boîte."
		},
		new SubjectItem
		{
			Id = "LYC-2DE-13",
			Title = "Probabilités et échantillonnage",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Statistiques et probabilités",
			Details = "Univers, probabilités d'événements, arbres et échantillonnage."
		}
	};
}
