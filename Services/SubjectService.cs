using AsPISApe.Models;

namespace AsPISApe.Services;

public class SubjectService : ISubjectService
{
	private static readonly List<SubjectItem> _allSubjects = new()
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
		},

		new SubjectItem
		{
			Id = "COL-F-01",
			Title = "Les classes grammaticales",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Mots variables et invariables (nom, déterminant, adjectif, verbe)."
		},
		new SubjectItem
		{
			Id = "COL-F-02",
			Title = "Le nom et les déterminants",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Articles définis, indéfinis, partitifs, possessifs et démonstratifs."
		},
		new SubjectItem
		{
			Id = "COL-F-03",
			Title = "Les pronoms",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Pronoms personnels, possessifs, démonstratifs, relatifs et indéfinis."
		},
		new SubjectItem
		{
			Id = "COL-F-04",
			Title = "L'adjectif qualificatif",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Genre, nombre, degrés et fonctions (épithète, attribut)."
		},
		new SubjectItem
		{
			Id = "COL-F-05",
			Title = "Le verbe et ses constructions",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Radical, terminaison, transitivité directe/indirecte et voix."
		},
		new SubjectItem
		{
			Id = "COL-F-06",
			Title = "Mots invariables : Adverbes et prépositions",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Adverbes, prépositions et conjonctions de coordination/subordination."
		},
		new SubjectItem
		{
			Id = "COL-F-07",
			Title = "Les fonctions grammaticales essentielles",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Sujet, attribut du sujet, compléments d'objet (COD, COI, COS)."
		},
		new SubjectItem
		{
			Id = "COL-F-08",
			Title = "Les compléments circonstanciels",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Temps, lieu, cause, conséquence, but, manière et moyen."
		},
		new SubjectItem
		{
			Id = "COL-F-09",
			Title = "Les expansions du nom",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Épithète liée/détachée, complément du nom et proposition relative."
		},
		new SubjectItem
		{
			Id = "COL-F-10",
			Title = "Types et formes de phrases",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Déclarative, interrogative, impérative, exclamative et négation."
		},
		new SubjectItem
		{
			Id = "COL-F-11",
			Title = "Propositions subordonnées conjonctives",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Complétives, circonstancielles et interrogatives indirectes."
		},
		new SubjectItem
		{
			Id = "COL-F-12",
			Title = "Situation d'énonciation et discours rapporté",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Orthographe et Énonciation",
			Details = "Indices d'énonciation, discours direct, indirect et indirect libre."
		},
		new SubjectItem
		{
			Id = "COL-F-13",
			Title = "Organisation du texte et connecteurs",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Orthographe et Énonciation",
			Details = "Ponctuation, reprises anaphoriques et connecteurs logiques."
		},
		new SubjectItem
		{
			Id = "COL-F-14",
			Title = "Règles d'accord : Sujet, adjectif et déterminant",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Orthographe",
			Details = "Accord du verbe avec le sujet et pluriel des adjectifs."
		},
		new SubjectItem
		{
			Id = "COL-F-15",
			Title = "Accord du participe passé",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Orthographe",
			Details = "Accords avec être, avoir et avec le COD placé avant le verbe."
		},
		new SubjectItem
		{
			Id = "COL-F-16",
			Title = "Homophones grammaticaux fondamentaux",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Orthographe",
			Details = "Distinguer a/à, et/est, son/sont, on/ont, ce/se, ces/ses."
		},
		new SubjectItem
		{
			Id = "COL-F-17",
			Title = "Conjugaison : Les temps de l'indicatif",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Conjugaison",
			Details = "Présent, imparfait, passé simple, futur et temps composés."
		},
		new SubjectItem
		{
			Id = "COL-F-18",
			Title = "Valeur des modes : Subjonctif et conditionnel",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "5e 4e 3e",
			Palier = 1,
			Domain = "Conjugaison",
			Details = "Emplois de l'indicatif, subjonctif, impératif et conditionnel."
		},
		new SubjectItem
		{
			Id = "COL-F-19",
			Title = "Formation et étymologie des mots",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Vocabulaire",
			Details = "Préfixes, suffixes, radicaux grecs/latins et familles de mots."
		},
		new SubjectItem
		{
			Id = "COL-F-20",
			Title = "Sens des mots et champ lexical",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Vocabulaire",
			Details = "Polysémie, dénotation, connotation, synonymie et antonymie."
		},
		new SubjectItem
		{
			Id = "COL-F-21",
			Title = "Genres littéraires : Récit, Théâtre et Poésie",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Littérature",
			Details = "Conte, roman, nouvelle, tragédie, comédie, fable et versification."
		},
		new SubjectItem
		{
			Id = "COL-F-22",
			Title = "Les principales figures de style",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e 5e 4e 3e",
			Palier = 1,
			Domain = "Littérature",
			Details = "Métaphore, comparaison, personnification, antithèse et hyperbole."
		},

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
		},

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
		},

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

	public IReadOnlyList<SubjectItem> GetAllSubjects()
	{
		return _allSubjects.AsReadOnly();
	}

	public IReadOnlyList<SubjectItem> FilterSubjects(string? discipline, string? level, string? classLevel, string? searchQuery)
	{
		IEnumerable<SubjectItem> query = _allSubjects;

		if (!string.IsNullOrWhiteSpace(discipline) && !discipline.Equals("Tous", StringComparison.OrdinalIgnoreCase))
		{
			query = query.Where(s => s.Discipline.Equals(discipline, StringComparison.OrdinalIgnoreCase));
		}

		if (!string.IsNullOrWhiteSpace(level) && !level.Equals("Tous", StringComparison.OrdinalIgnoreCase))
		{
			query = query.Where(s => s.Level.Equals(level, StringComparison.OrdinalIgnoreCase));
		}

		if (!string.IsNullOrWhiteSpace(classLevel) && !classLevel.Equals("Tous", StringComparison.OrdinalIgnoreCase))
		{
			query = query.Where(s => s.ClassLevel.Contains(classLevel, StringComparison.OrdinalIgnoreCase));
		}

		if (!string.IsNullOrWhiteSpace(searchQuery))
		{
			var normalized = searchQuery.Trim().ToLowerInvariant();
			query = query.Where(s =>
				s.Title.ToLowerInvariant().Contains(normalized) ||
				s.Domain.ToLowerInvariant().Contains(normalized) ||
				s.Details.ToLowerInvariant().Contains(normalized) ||
				s.ClassLevel.ToLowerInvariant().Contains(normalized)
			);
		}

		return query.ToList();
	}
}
