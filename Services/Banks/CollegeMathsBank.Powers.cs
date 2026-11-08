using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GeneratePowersBasics()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreatePowerSquareCubeQuestion(),
			1 => CreateNegativePowerOfTenQuestion(),
			2 => CreatePowerSignRulesQuestion(),
			_ => CreatePisaDigitalStorageQuestion()
		};
	}

	public ExerciseQuestion GenerateScientificNotation()
	{
		var variant = _random.Next(4);
		return variant switch
		{
			0 => CreateNumberToScientificNotationQuestion(),
			1 => CreateScientificNotationToDecimalQuestion(),
			2 => CreatePowerOfTenProductRuleQuestion(),
			_ => CreatePisaAstronomyDistanceQuestion()
		};
	}

	private ExerciseQuestion CreatePowerSquareCubeQuestion()
	{
		var pool = new[]
		{
			(5, 3, 125, "5 × 5 × 5"),
			(4, 3, 64, "4 × 4 × 4"),
			(6, 2, 36, "6 × 6"),
			(3, 4, 81, "3 × 3 × 3 × 3")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item3.ToString();
		var w1 = (item.Item1 * item.Item2).ToString();
		var w2 = (item.Item3 + 10).ToString();
		var w3 = (item.Item3 - 8).ToString();
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est la valeur de {item.Item1}^{item.Item2} ({item.Item1} puissance {item.Item2}) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "a^n désigne le produit de n facteurs tous égaux à a.",
			HintLevel2 = $"Calculez {item.Item4} (attention : ce n'est pas {item.Item1} × {item.Item2}).",
			ExplanationText = $"{item.Item1}^{item.Item2} = {item.Item4} = {item.Item3}."
		};
	}

	private ExerciseQuestion CreateNegativePowerOfTenQuestion()
	{
		var pool = new[]
		{
			(1, "0,1", "10⁻¹"),
			(2, "0,01", "10⁻²"),
			(3, "0,001", "10⁻³"),
			(4, "0,0001", "10⁻⁴")
		};
		var item = pool[_random.Next(pool.Length)];
		var correct = item.Item2;
		var w1 = (-item.Item1 * 10).ToString();
		var w2 = $"0,{new string('0', item.Item1)}1";
		var w3 = "1";
		var choices = Shuffle(correct, w1, w2, w3, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est l'écriture décimale de 10⁻{item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "10⁻ⁿ = 1 / 10ⁿ, le 1 se trouve au n-ième rang après la virgule.",
			HintLevel2 = $"Il y a {item.Item1} zéros au total en comptant celui avant la virgule.",
			ExplanationText = $"10⁻{item.Item1} s'écrit {correct}."
		};
	}

	private ExerciseQuestion CreatePowerSignRulesQuestion()
	{
		var pool = new[]
		{
			("(-3)²", "9", "-9", "6", "-6"),
			("(-2)³", "-8", "8", "-6", "6"),
			("-4²", "-16", "16", "-8", "8"),
			("(-5)²", "25", "-25", "10", "-10")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Calculez : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Si le nombre négatif est entre parenthèses, la puissance s'applique au signe moins.",
			HintLevel2 = "Un nombre négatif élevé à une puissance paire devient positif.",
			ExplanationText = $"{item.Item1} est égal à {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaDigitalStorageQuestion()
	{
		var pool = new[]
		{
			("1 kilo-octet (ko)", "10³ octets", "10⁶ octets", "10² octets", "10⁹ octets"),
			("1 méga-octet (Mo)", "10⁶ octets", "10³ octets", "10⁹ octets", "10¹² octets"),
			("1 giga-octet (Go)", "10⁹ octets", "10⁶ octets", "10¹² octets", "10³ octets")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S18-{Guid.NewGuid():N}",
			SubjectId = "maths_col_puissances",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"En informatique et selon les normes internationales, à combien d'octets équivaut {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Préfixes : kilo = 1 000 (10³), méga = 1 000 000 (10⁶), giga = 1 000 000 000 (10⁹).",
			HintLevel2 = "Comptez le nombre de groupes de 3 zéros.",
			ExplanationText = $"{item.Item1} correspond à {item.Item2}."
		};
	}

	private ExerciseQuestion CreateNumberToScientificNotationQuestion()
	{
		var pool = new[]
		{
			(45000, "4,5 × 10⁴", "45 × 10³", "0,45 × 10⁵", "4,5 × 10³"),
			(320000, "3,2 × 10⁵", "32 × 10⁴", "3,2 × 10⁶", "0,32 × 10⁶"),
			(1800, "1,8 × 10³", "18 × 10²", "1,8 × 10⁴", "0,18 × 10⁴")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 20,
			QuestionText = $"Quelle est la notation scientifique du nombre {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "La notation scientifique s'écrit a × 10ⁿ avec 1 ≤ a < 10.",
			HintLevel2 = "Le premier nombre ne doit comporter qu'un seul chiffre non nul avant la virgule.",
			ExplanationText = $"La notation scientifique de {item.Item1} est {item.Item2}."
		};
	}

	private ExerciseQuestion CreateScientificNotationToDecimalQuestion()
	{
		var pool = new[]
		{
			("7,2 × 10³", "7 200", "72 000", "720", "0,0072"),
			("3,05 × 10⁴", "30 500", "305 000", "3 050", "0,0305"),
			("6,4 × 10⁻²", "0,064", "0,64", "0,0064", "640")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Quelle est l'écriture décimale du nombre {item.Item1} ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Déplacez la virgule du nombre de rangs indiqué par l'exposant.",
			HintLevel2 = "Vers la droite pour une puissance positive, vers la gauche pour une puissance négative.",
			ExplanationText = $"{item.Item1} s'écrit sous forme décimale : {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePowerOfTenProductRuleQuestion()
	{
		var pool = new[]
		{
			("10³ × 10⁴", "10⁷", "10¹²", "10¹", "10⁰"),
			("10⁵ × 10⁻²", "10³", "10⁻¹⁰", "10⁷", "10⁻⁷"),
			("10⁶ ÷ 10²", "10⁴", "10³", "10⁸", "10¹²")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 15,
			QuestionText = $"Écrivez sous la forme d'une seule puissance de 10 : {item.Item1}",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Règles : 10ᵃ × 10ᵇ = 10ᵃ⁺ᵇ et 10ᵃ ÷ 10ᵇ = 10ᵃ⁻ᵇ.",
			HintLevel2 = "Additionnez les exposants pour un produit, soustrayez-les pour un quotient.",
			ExplanationText = $"{item.Item1} = {item.Item2}."
		};
	}

	private ExerciseQuestion CreatePisaAstronomyDistanceQuestion()
	{
		var pool = new[]
		{
			(150000000, "1,5 × 10⁸ km", "15 × 10⁷ km", "1,5 × 10⁶ km", "0,15 × 10⁹ km"),
			(384000, "3,84 × 10⁵ km", "38,4 × 10⁴ km", "3,84 × 10⁶ km", "0,384 × 10⁶ km"),
			(778000000, "7,78 × 10⁸ km", "77,8 × 10⁷ km", "7,78 × 10⁹ km", "0,778 × 10⁹ km")
		};
		var item = pool[_random.Next(pool.Length)];
		var choices = Shuffle(item.Item2, item.Item3, item.Item4, item.Item5, out var idx);

		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-S19-{Guid.NewGuid():N}",
			SubjectId = "maths_col_notation_scientifique",
			Discipline = "Mixte",
			ClassLevel = "4e",
			Palier = 1,
			BasePoints = 25,
			QuestionText = $"La distance Terre-Soleil moyenne est d'environ {item.Item1:#,##0} km. Quelle est sa notation scientifique exacte ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Placez la virgule après le premier chiffre non nul et comptez le nombre de rangs.",
			HintLevel2 = "La forme requise est obligatoirement comprise entre 1 et 10 multipliée par 10ⁿ.",
			ExplanationText = $"La distance scientifique s'écrit {item.Item2}."
		};
	}
}

