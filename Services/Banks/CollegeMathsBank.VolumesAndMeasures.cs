using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateCirclePerimeterQuestion()
	{
		var diameters = new[] { 10, 20, 30, 40 };
		var d = diameters[_random.Next(diameters.Length)];
		var p = (int)Math.Round(Math.PI * d);
		var correct = $"{p} cm (ou {d}π cm)";
		var wrong1 = $"{p / 2} cm";
		var wrong2 = $"{d * 2} cm";
		var wrong3 = $"{d * d} cm";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PERCIRC-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-056",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = $"Une roue de vélo a un diamètre de {d} cm. Quel est son périmètre (arrondi à l'entier près) selon la formule P = π × d ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le périmètre d'un cercle se calcule avec P = π × d ou P = 2 × π × r.",
			HintLevel2 = $"Multiplie {d} par 3,1416.",
			ExplanationText = $"P = π × {d} ≈ {p} cm."
		};
	}

	public ExerciseQuestion GenerateTrapezoidAreaQuestion()
	{
		var bLarge = _random.Next(6, 12) * 2;
		var bSmall = bLarge - _random.Next(2, 5) * 2;
		var h = _random.Next(3, 8);
		var area = ((bLarge + bSmall) * h) / 2;
		var correct = $"{area} m²";
		var wrong1 = $"{bLarge * h} m²";
		var wrong2 = $"{area + 10} m²";
		var wrong3 = $"{(bLarge + bSmall) * h} m²";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-AREATRAP-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-059",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Un terrain en forme de trapèze a une grande base B = {bLarge} m, une petite base b = {bSmall} m et une hauteur h = {h} m. Quelle est son aire avec A = ((B + b) × h) / 2 ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionne les deux bases, multiplie par la hauteur, puis divise le résultat par 2.",
			HintLevel2 = $"({bLarge} + {bSmall}) × {h} / 2 = {bLarge + bSmall} × {h} / 2.",
			ExplanationText = $"A = ({bLarge} + {bSmall}) × {h} / 2 = {area} m²."
		};
	}

	public ExerciseQuestion GenerateTimeConversionQuestion()
	{
		var cases = new[]
		{
			(1, 45, 105, "1 h 45 min", "1,75 h"),
			(2, 15, 135, "2 h 15 min", "2,25 h"),
			(2, 30, 150, "2 h 30 min", "2,5 h"),
			(3, 20, 200, "3 h 20 min", "200 min")
		};
		var item = cases[_random.Next(cases.Length)];
		var correct = $"{item.Item3} minutes";
		var wrong1 = $"{item.Item1 * 100 + item.Item2} minutes";
		var wrong2 = $"{item.Item3 - 15} minutes";
		var wrong3 = $"{item.Item3 + 30} minutes";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-DUR-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-061",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Un documentaire dure {item.Item4}. Combien de minutes cela représente-t-il au total ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "1 heure équivaut à 60 minutes. Multiplie le nombre d'heures par 60 et ajoute les minutes restantes.",
			HintLevel2 = $"{item.Item1} × 60 + {item.Item2} = {item.Item1 * 60} + {item.Item2}.",
			ExplanationText = $"{item.Item1} h = {item.Item1 * 60} min. Total = {item.Item1 * 60} + {item.Item2} = {item.Item3} minutes."
		};
	}

	public ExerciseQuestion GeneratePavedVolumeQuestion()
	{
		var l = _random.Next(4, 9);
		var w = _random.Next(3, 6);
		var h = _random.Next(2, 5);
		var vol = l * w * h;
		var correct = $"{vol} m³";
		var wrong1 = $"{2 * (l + w + h)} m³";
		var wrong2 = $"{l * w} m³";
		var wrong3 = $"{vol + 12} m³";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-VOLPAV-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-063",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Une citerne d'eau en pavé droit mesure L = {l} m, l = {w} m et h = {h} m. Quel est son volume en m³ ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le volume d'un pavé droit s'obtient en multipliant Longueur × largeur × hauteur.",
			HintLevel2 = $"Calcule {l} × {w} × {h}.",
			ExplanationText = $"V = {l} × {w} × {h} = {vol} m³ (soit {vol * 1000} L)."
		};
	}

	public ExerciseQuestion GenerateCylinderVolumeQuestion()
	{
		var r = _random.Next(2, 6);
		var h = _random.Next(4, 10);
		var baseArea = r * r;
		var piFactor = baseArea * h;
		var approx = (int)Math.Round(Math.PI * piFactor);
		var correct = $"{approx} cm³ (ou {piFactor}π cm³)";
		var wrong1 = $"{baseArea * h} cm³";
		var wrong2 = $"{approx / 3} cm³";
		var wrong3 = $"{2 * r * h} cm³";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-VOLCYL-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-063",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Une boîte de conserve cylindrique a un rayon r = {r} cm et une hauteur h = {h} cm. Quel est son volume selon V = π × r² × h (valeur arrondie) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calcule l'aire de la base circulaire (π × r²), puis multiplie par la hauteur h.",
			HintLevel2 = $"r² = {r * r}. Aire base = {r * r}π. Multiplie par {h} = {piFactor}π.",
			ExplanationText = $"V = π × {r}² × {h} = {piFactor}π ≈ {approx} cm³."
		};
	}

	public ExerciseQuestion GenerateConeVolumeQuestion()
	{
		var r = 3;
		var h = _random.Next(4, 9);
		var piFactor = (r * r * h) / 3;
		var approx = (int)Math.Round(Math.PI * piFactor);
		var correct = $"{approx} cm³ (ou {piFactor}π cm³)";
		var wrong1 = $"{approx * 3} cm³";
		var wrong2 = $"{r * h} cm³";
		var wrong3 = $"{approx / 2} cm³";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-VOLCONE-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-064",
			Discipline = "Maths",
			ClassLevel = "3e",
			Palier = 1,
			QuestionText = $"Un cône de révolution a un rayon r = {r} cm et une hauteur h = {h} cm. Calcule son volume avec la formule V = (1/3) × π × r² × h.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Le volume d'un cône est le tiers du volume d'un cylindre de mêmes dimensions : V = (π × r² × h) / 3.",
			HintLevel2 = $"r² = {r * r}. (1/3) × {r * r} × {h} = {piFactor}. Multiplie par π.",
			ExplanationText = $"V = (1/3) × π × {r}² × {h} = {piFactor}π ≈ {approx} cm³."
		};
	}
}

