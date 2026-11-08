using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateSolidSectionQuestion()
	{
		var sections = new[]
		{
			("une sphère coupée par n'importe quel plan sécant", "un cercle", "un rectangle", "un ovale ou ellipse", "un triangle"),
			("un pavé droit coupé par un plan parallèle à une de ses faces", "un rectangle identique à la face", "un triangle", "un cercle", "un losange"),
			("un cylindre coupé par un plan perpendiculaire à son axe de révolution", "un disque identique à la base", "un rectangle", "un triangle", "un trapèze"),
			("un cylindre coupé par un plan parallèle à son axe de révolution", "un rectangle", "un disque", "un triangle", "un carré obligatoirement")
		};
		var item = sections[_random.Next(sections.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-SECT-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-110",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Quelle est la forme de la section plane obtenue avec : {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Visualise la tranche de coupe à travers le solide 3D.",
			HintLevel2 = $"La section plane est : {item.Item2}.",
			ExplanationText = $"La section plane donne : {item.Item2}."
		};
	}

	public ExerciseQuestion Generate3DCoordinatesQuestion()
	{
		var x = _random.Next(1, 6);
		var y = _random.Next(1, 6);
		var z = _random.Next(1, 6);
		var correct = $"({x} ; {y} ; {z}) [abscisse, ordonnée, altitude]";
		var wrong1 = $"({z} ; {y} ; {x})";
		var wrong2 = $"({y} ; {x} ; {z})";
		var wrong3 = $"({x} ; {z}) [en 2D]";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-COORD3D-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-111",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Dans un repère de l'espace (O; I, J, K), un point M a pour abscisse x = {x}, pour ordonnée y = {y} et pour altitude z = {z}. Comment s'écrivent ses coordonnées ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Dans l'espace, les trois coordonnées s'écrivent dans l'ordre alphabétique standard : (abscisse ; ordonnée ; altitude).",
			HintLevel2 = $"L'ordre est (x ; y ; z), soit ({x} ; {y} ; {z}).",
			ExplanationText = $"Dans l'espace 3D, les coordonnées s'ordonnent en (x ; y ; z) : ({x} ; {y} ; {z})."
		};
	}

	public ExerciseQuestion GenerateSphereCoordinatesQuestion()
	{
		var cities = new[]
		{
			("Paris", "48° N et 2° E", "Nord (latitude) et Est (longitude)"),
			("Sydney", "33° S et 151° E", "Sud (latitude) et Est (longitude)"),
			("Rio de Janeiro", "22° S et 43° O", "Sud (latitude) et Ouest (longitude)"),
			("New York", "40° N et 74° O", "Nord (latitude) et Ouest (longitude)")
		};
		var item = cities[_random.Next(cities.Length)];
		var correct = item.Item2;
		var wrong1 = item.Item2.Replace("N", "S").Replace("E", "O");
		var wrong2 = "0° N et 0° E (Golfe de Guinée)";
		var wrong3 = "90° N (Pôle Nord)";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-GPS-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-111",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Sur la sphère terrestre, la latitude se mesure par rapport à l'Équateur (Nord/Sud) et la longitude par rapport au méridien de Greenwich (Est/Ouest). Pour {item.Item1}, les coordonnées approchées sont :",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = $"Pense à la situation de {item.Item1} : {item.Item3}.",
			HintLevel2 = $"Les coordonnées GPS sont {item.Item2}.",
			ExplanationText = $"Pour {item.Item1}, la position terrestre est : {item.Item2}."
		};
	}

	public ExerciseQuestion GenerateCubeNetFacesQuestion()
	{
		var correct = "6 faces carrées identiques";
		var wrong1 = "8 faces carrées";
		var wrong2 = "4 faces carrées et 2 rectangles";
		var wrong3 = "12 faces triangulaires";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PATRON-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-105",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = "De combien de faces et de quelle forme est composé le patron d'un cube ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Un cube possède 6 faces égales qui sont toutes des carrés.",
			HintLevel2 = "Un patron de cube déplié comporte 6 carrés reliés par leurs arêtes.",
			ExplanationText = "Le patron d'un cube est formé de 6 faces carrées identiques superposables."
		};
	}
}

