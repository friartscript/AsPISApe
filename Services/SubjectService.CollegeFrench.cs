using AsPISApe.Models;

namespace AsPISApe.Services;

public partial class SubjectService
{
	private static readonly List<SubjectItem> _collegeFrenchSubjects = new()
	{
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
		}
	};
}
