using AsPISApe.Models;

namespace AsPISApe.Services;

public partial class SubjectService
{
	private static readonly List<SubjectItem> _terminaleSubjects = new()
	{
		new SubjectItem
		{
			Id = "LYC-TLE-01",
			Title = "Suites et récurrence",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Raisonnement par récurrence, limites et convergence monotone."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-02",
			Title = "Limites de fonctions",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Limites à l'infini, limites finies, asymptotes et théorèmes d'encadrement."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-03",
			Title = "Fonctions cosinus et sinus",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Dérivées des fonctions trigonométriques et modélisations périodiques."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-04",
			Title = "Continuité et TVI",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Théorème des valeurs intermédiaires, corollaire de la bijection stricte."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-05",
			Title = "Dérivation et convexité",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Dérivée seconde, convexité, concavité et points d'inflexion."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-06",
			Title = "Fonction logarithme népérien",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Définition, propriétés algébriques, limites et croissances comparées."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-07",
			Title = "Primitives et équations différentielles",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Recherche de primitives et équations différentielles y' = ay + b."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-08",
			Title = "Calcul intégral",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Intégrale, calcul d'aires, linéarité et intégration par parties."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-09",
			Title = "Vecteurs, droites et plans de l'espace",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Algèbre et géométrie",
			Details = "Représentations paramétriques de droites et de plans dans l'espace."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-10",
			Title = "Produit scalaire dans l'espace",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Algèbre et géométrie",
			Details = "Orthogonalité, vecteur normal et équation cartésienne de plan."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-11",
			Title = "Dénombrement et combinatoire",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Algèbre et géométrie",
			Details = "Listes, permutations, combinaisons et formule du binôme de Newton."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-12",
			Title = "Schéma de Bernoulli et loi binomiale",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Probabilités",
			Details = "Succession d'épreuves indépendantes, loi B(n, p) et paramètres."
		},
		new SubjectItem
		{
			Id = "LYC-TLE-13",
			Title = "Loi des grands nombres",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Probabilités",
			Details = "Inégalité de Bienaymé-Tchebychev et inégalité de concentration."
		},

		new SubjectItem
		{
			Id = "LYC-EXP-01",
			Title = "Nombres complexes : Algèbre et polynômes",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Nombres complexes",
			Details = "Forme algébrique, conjugué et résolution d'équations dans C."
		},
		new SubjectItem
		{
			Id = "LYC-EXP-02",
			Title = "Nombres complexes : Géométrie",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Nombres complexes",
			Details = "Module, argument, forme exponentielle et racines n-ièmes."
		},
		new SubjectItem
		{
			Id = "LYC-EXP-03",
			Title = "Divisibilité et congruences dans Z",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Arithmétique",
			Details = "Division euclidienne, relation a ≡ b [n] et calcul modulaire."
		},
		new SubjectItem
		{
			Id = "LYC-EXP-04",
			Title = "PGCD et théorèmes de Bézout et Gauss",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Arithmétique",
			Details = "Algorithme d'Euclide, identité de Bézout et équations diophantiennes."
		},
		new SubjectItem
		{
			Id = "LYC-EXP-05",
			Title = "Nombres premiers et petit théorème de Fermat",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Arithmétique",
			Details = "Théorème fondamental de l'arithmétique et chiffrement RSA."
		},
		new SubjectItem
		{
			Id = "LYC-EXP-06",
			Title = "Calcul matriciel et graphes",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Graphes et matrices",
			Details = "Opérations sur matrices, puissances, inverse et graphes."
		},
		new SubjectItem
		{
			Id = "LYC-EXP-07",
			Title = "Chaînes de Markov",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Graphes et matrices",
			Details = "Matrice de transition et convergence vers un état stable."
		}
	};
}
