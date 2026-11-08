using AsPISApe.Models;

namespace AsPISApe.Services;

public partial class SubjectService
{
	private static readonly List<SubjectItem> _collegeMathsSubjects = new()
	{
		new SubjectItem
		{
			Id = "COL-M-01",
			Title = "Division euclidienne",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Quotient, reste, égalité fondamentale a = bq + r et partage équitable."
		},
		new SubjectItem
		{
			Id = "COL-M-02",
			Title = "Multiples et diviseurs",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Critères de divisibilité par 2, 3, 5, 9 et 10. Multiples communs."
		},
		new SubjectItem
		{
			Id = "COL-M-03",
			Title = "Nombres premiers et décomposition",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Nombres premiers inférieurs à 100 et décomposition en facteurs premiers."
		},
		new SubjectItem
		{
			Id = "COL-M-04",
			Title = "Opérations sur les nombres décimaux",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Addition, soustraction, multiplication et division décimale."
		},
		new SubjectItem
		{
			Id = "COL-M-05",
			Title = "Nombres relatifs et repérage",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Repérage sur axe et plan, comparaison et opérations de relatifs."
		},
		new SubjectItem
		{
			Id = "COL-M-06",
			Title = "Fractions : Généralités et égalité",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e 5e 4e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Quotients, égalité de fractions et fraction irréductible."
		},
		new SubjectItem
		{
			Id = "COL-M-07",
			Title = "Opérations sur les fractions",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Addition, soustraction, multiplication et division de fractions."
		},
		new SubjectItem
		{
			Id = "COL-M-08",
			Title = "Puissances et notation scientifique",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e 3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Puissances d'un nombre relatif, puissances de 10 et écriture scientifique."
		},
		new SubjectItem
		{
			Id = "COL-M-09",
			Title = "Racines carrées",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e 3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Définition de la racine carrée, carrés parfaits et calculs exacts."
		},
		new SubjectItem
		{
			Id = "COL-M-10",
			Title = "Calcul littéral et distributivité",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Développement, réduction, simple et double distributivité."
		},
		new SubjectItem
		{
			Id = "COL-M-11",
			Title = "Factorisation et identités remarquables",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e 3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Facteur commun et identités remarquables fondamentales."
		},
		new SubjectItem
		{
			Id = "COL-M-12",
			Title = "Équations du premier degré",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e 3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Résolution d'équations ax + b = c et équations produit nul."
		},
		new SubjectItem
		{
			Id = "COL-M-13",
			Title = "Algorithmique et programmes Scratch",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Algorithmique et programmation",
			Details = "Instructions de déplacement, boucles, conditions et variables."
		},
		new SubjectItem
		{
			Id = "COL-M-14",
			Title = "Statistiques : Moyenne et médiane",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Organisation et gestion de données",
			Details = "Effectifs, fréquences, moyenne pondérée, médiane et étendue."
		},
		new SubjectItem
		{
			Id = "COL-M-15",
			Title = "Probabilités et arbres des possibles",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Organisation et gestion de données",
			Details = "Expérience aléatoire, probabilité d'événements à 1 et 2 épreuves."
		},
		new SubjectItem
		{
			Id = "COL-M-16",
			Title = "Proportionnalité, Ratios et Pourcentages",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Organisation et gestion de données",
			Details = "Quatrième proportionnelle, ratios, hausses et baisses en pourcentage."
		},
		new SubjectItem
		{
			Id = "COL-M-17",
			Title = "Fonctions linéaires et affines",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "3e",
			Palier = 1,
			Domain = "Organisation et gestion de données",
			Details = "Image, antécédent, coefficient directeur et droite représentative."
		},
		new SubjectItem
		{
			Id = "COL-M-18",
			Title = "Périmètres, Aires et Durées",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e 5e",
			Palier = 1,
			Domain = "Grandeurs et mesures",
			Details = "Périmètres et aires des figures usuelles et calculs de durées."
		},
		new SubjectItem
		{
			Id = "COL-M-19",
			Title = "Volumes des solides de l'espace",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Grandeurs et mesures",
			Details = "Volumes de cube, pavé droit, cylindre, pyramide, cône et boule."
		},
		new SubjectItem
		{
			Id = "COL-M-20",
			Title = "Droites remarquables et médiatrice",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e 5e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Perpendiculaires, parallèles, médiatrice et cercle circonscrit."
		},
		new SubjectItem
		{
			Id = "COL-M-21",
			Title = "Triangles et inégalité triangulaire",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Inégalité triangulaire, somme des angles d'un triangle et hauteurs."
		},
		new SubjectItem
		{
			Id = "COL-M-22",
			Title = "Théorème de Pythagore",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e 3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Calcul de l'hypoténuse, côté adjacent, réciproque et contraposée."
		},
		new SubjectItem
		{
			Id = "COL-M-23",
			Title = "Théorème de Thalès",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Configurations emboîtées et croisées, calculs et réciproque."
		},
		new SubjectItem
		{
			Id = "COL-M-24",
			Title = "Trigonométrie dans le triangle rectangle",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Cosinus, sinus et tangente d'un angle aigu."
		},
		new SubjectItem
		{
			Id = "COL-M-25",
			Title = "Transformations du plan",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Symétries axiale et centrale, translation, rotation et homothétie."
		}
	};
}
