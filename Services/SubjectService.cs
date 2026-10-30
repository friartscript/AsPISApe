using AsPISApe.Models;

namespace AsPISApe.Services;

public class SubjectService : ISubjectService
{
	private static readonly List<SubjectItem> _allSubjects = new()
	{
		// =========================================================================
		// 1. COLLÈGE — MATHÉMATIQUES (Palier 1 : 6e à 3e)
		// =========================================================================
		new SubjectItem
		{
			Id = "COL-M-01",
			Title = "Division euclidienne",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Quotient, reste, égalité fondamentale a = bq + r et résolution de problèmes de partage.",
			ReferencePage = "p. 12 (6e)"
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
			Details = "Critères de divisibilité par 2, 3, 5, 9 et 10. Propriétés des multiples et diviseurs.",
			ReferencePage = "p. 14 (5e)"
		},
		new SubjectItem
		{
			Id = "COL-M-03",
			Title = "Nombres premiers & Décomposition",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e-4e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Définition, liste des nombres premiers inférieurs à 100, décomposition en facteurs premiers.",
			ReferencePage = "p. 16 (5e-4e)"
		},
		new SubjectItem
		{
			Id = "COL-M-04",
			Title = "Nombres décimaux & Opérations",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Addition, soustraction, multiplication et division décimale d'entiers et de décimaux.",
			ReferencePage = "pp. 18-22 (6e)"
		},
		new SubjectItem
		{
			Id = "COL-M-05",
			Title = "Nombres relatifs & Repérage",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e-4e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Repérage sur axe et plan, comparaison, addition, soustraction, produit et quotient de relatifs.",
			ReferencePage = "pp. 24-34 (5e-4e)"
		},
		new SubjectItem
		{
			Id = "COL-M-06",
			Title = "Fractions : Égalité & Simplification",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e-5e-3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Fractions quotient, fractions égales, méthode de simplification et fraction irréductible.",
			ReferencePage = "pp. 36-40 (6e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-07",
			Title = "Opérations sur les fractions",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e-4e-3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Addition et soustraction avec dénominateur commun, multiplication et division de fractions.",
			ReferencePage = "pp. 42-45 (5e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-08",
			Title = "Puissances & Notation scientifique",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e-3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Puissances de 10, puissances d'un nombre relatif, règles de calcul et écriture scientifique.",
			ReferencePage = "pp. 48-51 (4e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-09",
			Title = "Racines carrées",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e-3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Définition de la racine carrée, carrés parfaits, calcul exact et encadrement décimal.",
			ReferencePage = "p. 52 (4e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-10",
			Title = "Calcul littéral & Distributivité",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e-4e-3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Expressions algébriques, réduction, simple et double distributivité, factorisation.",
			ReferencePage = "pp. 56-62 (5e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-11",
			Title = "Équations du premier degré",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e-3e",
			Palier = 1,
			Domain = "Nombres et calculs",
			Details = "Résolution d'équations ax + b = c, équations produit-nul (ax + b)(cx + d) = 0 et mise en équation.",
			ReferencePage = "pp. 64-68 (4e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-12",
			Title = "Proportionnalité, Ratios & Échelles",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Organisation de données",
			Details = "Tableaux de proportionnalité, coefficient, produit en croix, pourcentages, vitesse et ratios.",
			ReferencePage = "pp. 70-80 (6e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-13",
			Title = "Statistiques descriptives",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e-3e",
			Palier = 1,
			Domain = "Organisation de données",
			Details = "Effectifs, fréquences, moyenne pondérée, médiane, étendue et représentations graphiques.",
			ReferencePage = "pp. 82-88 (5e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-14",
			Title = "Probabilités élémentaires",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e-3e",
			Palier = 1,
			Domain = "Organisation de données",
			Details = "Expériences aléatoires, événements certains/impossibles, arbres des possibles à 1 et 2 épreuves.",
			ReferencePage = "pp. 90-96 (4e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-15",
			Title = "Algorithmique & Scratch",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Algorithmique",
			Details = "Séquences d'instructions, boucles 'répéter', conditions 'si alors', variables et tracé de figures.",
			ReferencePage = "pp. 98-106 (6e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-16",
			Title = "Théorème de Pythagore",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "4e-3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Calcul de la longueur de l'hypoténuse ou d'un côté de l'angle droit, réciproque et contraposée.",
			ReferencePage = "pp. 110-116 (4e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-17",
			Title = "Théorème de Thalès",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Rapports d'agrandissement et de réduction, configuration en triangle et papillon, réciproque.",
			ReferencePage = "pp. 118-124 (3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-18",
			Title = "Trigonométrie dans le triangle rectangle",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Cosinus, sinus, tangente d'un angle aigu. Calcul d'angles et de longueurs.",
			ReferencePage = "pp. 126-132 (3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-19",
			Title = "Transformations du plan",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "5e-4e-3e",
			Palier = 1,
			Domain = "Espace et géométrie",
			Details = "Symétries axiale et centrale, translation, rotation et homothétie. Propriétés d'invariance.",
			ReferencePage = "pp. 134-142 (5e-3e)"
		},
		new SubjectItem
		{
			Id = "COL-M-20",
			Title = "Solides de l'espace & Volumes",
			Discipline = "Maths",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grandeurs et mesures",
			Details = "Prismes droits, cylindres, pyramides, cônes et sphères. Patrons, aires et calculs de volume.",
			ReferencePage = "pp. 144-152 (6e-3e)"
		},

		// =========================================================================
		// 2. COLLÈGE — FRANÇAIS (Palier 1 : 6e à 3e)
		// =========================================================================
		new SubjectItem
		{
			Id = "COL-F-01",
			Title = "Les classes grammaticales",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Mots variables (nom, déterminant, adjectif, pronom, verbe) et invariables (adverbe, préposition...).",
			ReferencePage = "pp. 1-2"
		},
		new SubjectItem
		{
			Id = "COL-F-02",
			Title = "Le nom & Les déterminants",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Noms communs, noms propres. Articles définis, indéfinis, partitifs, possessifs et démonstratifs.",
			ReferencePage = "pp. 3-19"
		},
		new SubjectItem
		{
			Id = "COL-F-03",
			Title = "Les pronoms",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Pronoms personnels, possessifs, démonstratifs, relatifs, indéfinis et interrogatifs.",
			ReferencePage = "pp. 20-29"
		},
		new SubjectItem
		{
			Id = "COL-F-04",
			Title = "L'adjectif qualificatif",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Genre, nombre, degrés de l'adjectif (comparatif, superlatif) et fonctions (épithète, attribut).",
			ReferencePage = "pp. 30-33"
		},
		new SubjectItem
		{
			Id = "COL-F-05",
			Title = "Le verbe & Ses constructions",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Radical, terminaisons, groupes, transitifs directs/indirects, intransitifs et pronominaux.",
			ReferencePage = "pp. 34-40"
		},
		new SubjectItem
		{
			Id = "COL-F-06",
			Title = "Adverbes, Prépositions & Conjonctions",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Mots invariables, rôle de liaison, coordination (mais ou et donc or ni car) et subordination.",
			ReferencePage = "pp. 41-50"
		},
		new SubjectItem
		{
			Id = "COL-F-07",
			Title = "Les fonctions grammaticales essentielles",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Sujet, attribut du sujet, compléments d'objet (COD, COI, COS), complément d'agent.",
			ReferencePage = "pp. 53-72"
		},
		new SubjectItem
		{
			Id = "COL-F-08",
			Title = "Compléments circonstanciels",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Temps, lieu, cause, conséquence, but, manière, moyen. Distinction et identification.",
			ReferencePage = "pp. 73-75"
		},
		new SubjectItem
		{
			Id = "COL-F-09",
			Title = "Les expansions du nom",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Épithète liée/détachée, complément du nom, apposition et proposition subordonnée relative.",
			ReferencePage = "pp. 76-90"
		},
		new SubjectItem
		{
			Id = "COL-F-10",
			Title = "Types & Formes de phrases",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Phrases déclarative, interrogative, injonctive, exclamative. Formes affirmative et négative.",
			ReferencePage = "pp. 99-106"
		},
		new SubjectItem
		{
			Id = "COL-F-11",
			Title = "Propositions subordonnées",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "5e-3e",
			Palier = 1,
			Domain = "Grammaire",
			Details = "Subordonnées relatives, conjonctives complétives, interrogatives indirectes et circonstancielles.",
			ReferencePage = "pp. 107-120"
		},
		new SubjectItem
		{
			Id = "COL-F-12",
			Title = "Conjugaison : Les temps de l'indicatif",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Conjugaison",
			Details = "Présent, imparfait, passé simple, passé composé, plus-que-parfait, futur simple et antérieur.",
			ReferencePage = "pp. 125-148"
		},
		new SubjectItem
		{
			Id = "COL-F-13",
			Title = "Subjonctif, Conditionnel & Impératif",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "5e-3e",
			Palier = 1,
			Domain = "Conjugaison",
			Details = "Modes impersonnels et personnels. Emplois de l'hypothèse, de l'ordre, du souhait et du doute.",
			ReferencePage = "pp. 150-168"
		},
		new SubjectItem
		{
			Id = "COL-F-14",
			Title = "Accords fondamentaux & Participe passé",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Orthographe",
			Details = "Accord sujet-verbe, accord avec être et avoir, verbes pronominaux et pièges courants.",
			ReferencePage = "pp. 170-195"
		},
		new SubjectItem
		{
			Id = "COL-F-15",
			Title = "Lexique & Figures de style",
			Discipline = "Francais",
			Level = "College",
			ClassLevel = "6e-3e",
			Palier = 1,
			Domain = "Lexique et Style",
			Details = "Champs lexicaux, dérivation, métaphore, comparaison, personnification, hyperbole, anaphore.",
			ReferencePage = "pp. 200-240"
		},

		// =========================================================================
		// 3. LYCÉE — SECONDE (Palier 2)
		// =========================================================================
		new SubjectItem
		{
			Id = "LYC-2DE-01",
			Title = "Algorithmique & Python (2de)",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Algorithmique",
			Details = "Types de variables, affectations, structures conditionnelles, boucles 'for' et 'while', fonctions.",
			ReferencePage = "Ch. 1 (p. 12-41)"
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
			Details = "Ensembles N, Z, D, Q, R. Fractions, puissances, racines, nombres premiers et irrationalité de √2.",
			ReferencePage = "Ch. 2 (p. 42-67)"
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
			Details = "Notion d'intervalle, intersection et réunion, encadrements et valeur absolue sur la droite réelle.",
			ReferencePage = "Ch. 3 (p. 68-89)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-04",
			Title = "Identités remarquables & Équations",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Nombres et calculs",
			Details = "Développements, factorisations, équations se ramenant au 1er degré, équations quotient nul.",
			ReferencePage = "Ch. 4 (p. 90-113)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-05",
			Title = "Repérage & Géométrie dans le plan",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Géométrie",
			Details = "Coordonnées dans un repère orthonormé, coordonnées du milieu d'un segment, calcul de distances.",
			ReferencePage = "Ch. 5 (p. 114-133)"
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
			Details = "Translations, égalité et somme de vecteurs, relation de Chasles, coordonnées et colinéarité.",
			ReferencePage = "Ch. 6 (p. 134-161)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-07",
			Title = "Droites du plan & Systèmes linéaires",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Géométrie",
			Details = "Équations cartésiennes, coefficient directeur, droites parallèles/sécantes, systèmes de 2 équations.",
			ReferencePage = "Ch. 7 (p. 162-187)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-08",
			Title = "Fonctions & Fonctions de référence",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Fonctions",
			Details = "Image, antécédent, courbe représentative. Fonctions carré, inverse, racine carrée et cube.",
			ReferencePage = "Ch. 8 (p. 188-215)"
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
			Details = "Fonction croissante/décroissante, tableaux de variations, maximum et minimum sur un intervalle.",
			ReferencePage = "Ch. 9 (p. 216-239)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-10",
			Title = "Signe d'une fonction & Inéquations",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Fonctions",
			Details = "Signe d'une fonction affine ax + b, tableaux de signes d'un produit ou quotient, résolution d'inéquations.",
			ReferencePage = "Ch. 10 (p. 240-267)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-11",
			Title = "Proportions & Évolutions en pourcentage",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Statistiques et probabilités",
			Details = "Proportions de sous-populations, coefficient multiplicateur, taux d'évolution, évolutions réciproques.",
			ReferencePage = "Ch. 11 (p. 268-285)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-12",
			Title = "Statistiques descriptives (2de)",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Statistiques et probabilités",
			Details = "Moyenne, écart-type, médiane, quartiles Q1 et Q3, intervalle interquartile et diagrammes en boîte.",
			ReferencePage = "Ch. 12 (p. 286-309)"
		},
		new SubjectItem
		{
			Id = "LYC-2DE-13",
			Title = "Probabilités & Échantillonnage (2de)",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "2de",
			Palier = 2,
			Domain = "Statistiques et probabilités",
			Details = "Univers, probabilité d'événements, formules P(A U B) = P(A) + P(B) - P(A n B), arbres et fluctuation.",
			ReferencePage = "Ch. 13 (p. 310-345)"
		},

		// =========================================================================
		// 4. LYCÉE — PREMIÈRE SPÉCIALITÉ MATHS (Palier 3)
		// =========================================================================
		new SubjectItem
		{
			Id = "LYC-1RE-01",
			Title = "Notion de listes en Python (1re)",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Algorithmique",
			Details = "Création, accès indexé, méthodes append/pop, listes en compréhension et parcours d'éléments.",
			ReferencePage = "Ch. 1 (p. 12-41)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-02",
			Title = "Suites numériques (1re)",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Algèbre",
			Details = "Formule explicite et par récurrence, suites arithmétiques, suites géométriques, sommes de termes.",
			ReferencePage = "Ch. 2 (p. 42-79)"
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
			Details = "Forme canonique, discriminant Delta, factorisation, racines, signe du trinôme et paraboles.",
			ReferencePage = "Ch. 3 (p. 80-109)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-04",
			Title = "Dérivation : Taux de variation & Tangente",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Nombre dérivé, équation de la tangente y = f'(a)(x-a) + f(a), dérivées des fonctions usuelles.",
			ReferencePage = "Ch. 4 (p. 110-141)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-05",
			Title = "Variations & Étude de fonctions",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Lien entre le signe de f'(x) et les variations de f, recherche d'extremums locaux et asymptotes.",
			ReferencePage = "Ch. 5 (p. 142-167)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-06",
			Title = "La fonction exponentielle",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Définition unique f'=f et f(0)=1, relation exp(x+y)=exp(x)*exp(y), stricte positivité et variations.",
			ReferencePage = "Ch. 6 (p. 168-195)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-07",
			Title = "Trigonométrie & Fonctions sinus/cosinus",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Analyse",
			Details = "Radian, cercle trigonométrique, valeurs remarquables, cos²(x)+sin²(x)=1, parité et périodicité.",
			ReferencePage = "Ch. 7 (p. 196-221)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-08",
			Title = "Calcul vectoriel & Produit scalaire",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Géométrie",
			Details = "Formules u·v = ||u||*||v||*cos(theta), coordonnées orthonormées xx'+yy', projeté orthogonal.",
			ReferencePage = "Ch. 8 (p. 222-245)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-09",
			Title = "Géométrie repérée & Vecteur normal",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Géométrie",
			Details = "Vecteur normal à une droite, équation ax + by + c = 0, équation cartésienne de cercle (x-a)²+(y-b)²=R².",
			ReferencePage = "Ch. 9 (p. 246-267)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-10",
			Title = "Probabilités conditionnelles & Indépendance",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Probabilités",
			Details = "P_B(A) = P(A n B)/P(B), arbres pondérés, formule des probabilités totales, événements indépendants.",
			ReferencePage = "Ch. 10 (p. 268-295)"
		},
		new SubjectItem
		{
			Id = "LYC-1RE-11",
			Title = "Variables aléatoires réelles",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "1re Spé",
			Palier = 3,
			Domain = "Probabilités",
			Details = "Loi de probabilité, espérance mathématique E(X), variance V(X), écart-type sigma(X) et jeux équitables.",
			ReferencePage = "Ch. 11 (p. 296-327)"
		},

		// =========================================================================
		// 5. LYCÉE — TERMINALE SPÉCIALITÉ MATHS (Palier 4)
		// =========================================================================
		new SubjectItem
		{
			Id = "LYC-TLE-01",
			Title = "Suites & Raisonnement par récurrence",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Principe d'initialisation et d'hérédité, suites majorées/minorées, théorème de convergence monotone.",
			ReferencePage = "Ch. 1 (p. 12-47)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-02",
			Title = "Limites de fonctions & Asymptotes",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Limites à l'infini et en un point, asymptotes, théorèmes de comparaison (gendarmes), formes indéterminées.",
			ReferencePage = "Ch. 2 (p. 48-79)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-03",
			Title = "Continuité & Théorème des Valeurs Intermédiaires",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Continuité d'une fonction, TVI et corollaire de la bijection stricte, algorithme de dichotomie.",
			ReferencePage = "Ch. 4 (p. 108-135)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-04",
			Title = "Dérivation, Convexité & Points d'inflexion",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Dérivée seconde f'', convexité, concavité, positions relatives par rapport aux tangentes.",
			ReferencePage = "Ch. 5 (p. 136-167)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-05",
			Title = "Fonction logarithme népérien (ln)",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Définition comme réciproque de exp, propriétés algébriques ln(ab)=ln a + ln b, limites, dérivée.",
			ReferencePage = "Ch. 6 (p. 168-201)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-06",
			Title = "Primitives & Équations différentielles",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Primitives usuelles et composées, résolution des équations différentielles y' = ay et y' = ay + b.",
			ReferencePage = "Ch. 7 (p. 202-237)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-07",
			Title = "Calcul intégral",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Analyse",
			Details = "Intégrale définie, calcul d'aires, linéarité, positivité, relation de Chasles, intégration par parties.",
			ReferencePage = "Ch. 8 (p. 238-275)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-08",
			Title = "Géométrie dans l'espace & Représentations paramétriques",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Géométrie",
			Details = "Vecteurs coplanaires, bases et repères de l'espace, représentations paramétriques de droites et de plans.",
			ReferencePage = "Ch. 9 (p. 276-305)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-09",
			Title = "Produit scalaire dans l'espace & Plans",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Géométrie",
			Details = "Orthogonalité, vecteur normal à un plan, équation cartésienne ax + by + cz + d = 0, projeté orthogonal.",
			ReferencePage = "Ch. 10 (p. 306-333)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-10",
			Title = "Dénombrement & Combinatoire",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Algèbre",
			Details = "Listes, permutations (n!), combinaisons (n k), triangle de Pascal et formule du binôme de Newton.",
			ReferencePage = "Ch. 11 (p. 334-363)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-11",
			Title = "Loi binomiale & Épreuves de Bernoulli",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Probabilités",
			Details = "Schéma de Bernoulli à n épreuves indépendantes, loi B(n, p), espérance np, variance np(1-p).",
			ReferencePage = "Ch. 12 (p. 364-401)"
		},
		new SubjectItem
		{
			Id = "LYC-TLE-12",
			Title = "Concentration & Loi des grands nombres",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Spé",
			Palier = 4,
			Domain = "Probabilités",
			Details = "Inégalité de Markov, inégalité de Bienaymé-Tchebychev, inégalité de concentration.",
			ReferencePage = "Ch. 13 (p. 402-437)"
		},

		// =========================================================================
		// 6. LYCÉE — TERMINALE OPTION MATHS EXPERTES (Palier 5)
		// =========================================================================
		new SubjectItem
		{
			Id = "LYC-EXP-01",
			Title = "Nombres complexes : Algèbre & Polynômes",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Nombres complexes",
			Details = "Corps C, écriture a + ib, conjugué, résolution d'équations polynomiales à coefficients réels ou complexes.",
			ReferencePage = "Ch. 1 (p. 10-41)"
		},
		new SubjectItem
		{
			Id = "LYC-EXP-02",
			Title = "Nombres complexes : Géométrie & Trigonométrie",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Nombres complexes",
			Details = "Module, argument, forme exponentielle r*e^(i*theta), formules d'Euler et de Moivre, racines n-ièmes.",
			ReferencePage = "Ch. 2 (p. 42-77)"
		},
		new SubjectItem
		{
			Id = "LYC-EXP-03",
			Title = "Divisibilité & Congruences dans Z",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Arithmétique",
			Details = "Division euclidienne dans Z, relation de congruence a ≡ b [n], compatibilité avec les opérations.",
			ReferencePage = "Ch. 3 (p. 78-103)"
		},
		new SubjectItem
		{
			Id = "LYC-EXP-04",
			Title = "PGCD & Théorèmes de Bézout et Gauss",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Arithmétique",
			Details = "Algorithme d'Euclide, identité de Bézout au + bv = PGCD, théorème de Gauss, équations ax + by = c.",
			ReferencePage = "Ch. 4 (p. 104-131)"
		},
		new SubjectItem
		{
			Id = "LYC-EXP-05",
			Title = "Nombres premiers & Petit théorème de Fermat",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Arithmétique",
			Details = "Théorème fondamental de l'arithmétique, petit théorème de Fermat a^(p-1) ≡ 1 [p], cryptographie RSA.",
			ReferencePage = "Ch. 5 (p. 132-161)"
		},
		new SubjectItem
		{
			Id = "LYC-EXP-06",
			Title = "Calcul matriciel & Graphes",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Graphes et matrices",
			Details = "Produit de matrices, inverse d'une matrice carrée, matrice associée à un graphe, calcul des chemins.",
			ReferencePage = "Ch. 6 (p. 162-199)"
		},
		new SubjectItem
		{
			Id = "LYC-EXP-07",
			Title = "Chaînes de Markov & Graphes probabilistes",
			Discipline = "Maths",
			Level = "Lycee",
			ClassLevel = "Tle Expertes",
			Palier = 5,
			Domain = "Graphes et matrices",
			Details = "Matrice de transition P, état probabiliste P_n = P_0 * P^n, convergence vers une distribution stationnaire.",
			ReferencePage = "Ch. 7 (p. 200-235)"
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
