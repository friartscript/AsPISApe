using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateFormulasAndCalculus()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateQuadraticEvaluation(),
			1 => GenerateLinearExpressionEvaluation(),
			_ => GenerateTaxiFareFormula()
		};
	}

	public ExerciseQuestion GenerateFormulaUsage()
	{
		var variant = _random.Next(3);
		return variant switch
		{
			0 => GenerateSpeedFormulaQuestion(),
			1 => GenerateTriangleAreaFormulaQuestion(),
			_ => GenerateRectanglePerimeterFormulaQuestion()
		};
	}

	private ExerciseQuestion GenerateQuadraticEvaluation()
	{
		var a = _random.Next(2, 5);
		var b = _random.Next(1, 6);
		var c = _random.Next(2, 8);
		var x = _random.Next(2, 5);
		var correctVal = (a * x * x) - (b * x) + c;
		var correct = correctVal.ToString();
		var wrong1 = ((a * x) - (b * x) + c).ToString();
		var wrong2 = (correctVal + (2 * x)).ToString();
		var wrong3 = (correctVal - b).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-FORM-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-026",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Soit l'expression A = {a}x² - {b}x + {c}. Pour x = {x}, que vaut A ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Remplace chaque x par sa valeur numérique et respecte les priorités (les carrés en premier).",
			HintLevel2 = $"Calcule d'abord x² = {x * x}, puis multiplie par {a}.",
			ExplanationText = $"A = {a}×({x}²) - {b}×{x} + {c} = {correctVal}."
		};
	}

	private ExerciseQuestion GenerateLinearExpressionEvaluation()
	{
		var a = _random.Next(2, 6);
		var b = _random.Next(3, 9);
		var x = -_random.Next(1, 5);
		var correctVal = (a * x) + b;
		var correct = correctVal.ToString();
		var wrong1 = ((a * Math.Abs(x)) + b).ToString();
		var wrong2 = (correctVal - 2).ToString();
		var wrong3 = (a + x + b).ToString();

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-EVAL-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-026",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Soit l'expression B = {a}x + {b}. Pour x = {x}, quelle est la valeur de B ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Attention au signe de x : le produit d'un nombre positif par un négatif est négatif.",
			HintLevel2 = $"{a} × ({x}) = {a * x}. Ajoute ensuite {b}.",
			ExplanationText = $"B = {a}×({x}) + {b} = {a * x} + {b} = {correctVal}."
		};
	}

	private ExerciseQuestion GenerateTaxiFareFormula()
	{
		var baseFee = _random.Next(3, 6);
		var kmRate = _random.Next(2, 4);
		var km = _random.Next(8, 25);
		var total = baseFee + (kmRate * km);
		var correct = $"{total} €";
		var wrong1 = $"{total + kmRate} €";
		var wrong2 = $"{baseFee * km} €";
		var wrong3 = $"{total - 4} €";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-TAXI-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-026",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Un artisan applique le tarif T = {baseFee} + {kmRate}d, où d est la distance en km. Pour un trajet de {km} km, quel est le prix ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Remplace la lettre d par la distance parcourue dans la formule.",
			HintLevel2 = $"Multiplie d'abord {kmRate} par {km}, puis ajoute la prise en charge de {baseFee} €.",
			ExplanationText = $"T = {baseFee} + {kmRate}×{km} = {baseFee} + {kmRate * km} = {total} €."
		};
	}

	private ExerciseQuestion GenerateSpeedFormulaQuestion()
	{
		var speeds = new[] { 50, 60, 70, 80, 90, 100, 110 };
		var speed = speeds[_random.Next(speeds.Length)];
		var time = _random.Next(2, 5);
		var distance = speed * time;
		var correct = $"{speed} km/h";
		var wrong1 = $"{speed - 15} km/h";
		var wrong2 = $"{speed + 20} km/h";
		var wrong3 = $"{distance / 2} km/h";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-SPD-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-030",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"Un train parcourt {distance} km en {time} heures à vitesse constante. Quelle est sa vitesse moyenne selon la formule v = d / t ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Applique la formule v = d / t en divisant la distance par le temps.",
			HintLevel2 = $"Divise {distance} par {time}.",
			ExplanationText = $"v = {distance} / {time} = {speed} km/h."
		};
	}

	private ExerciseQuestion GenerateTriangleAreaFormulaQuestion()
	{
		var b = _random.Next(4, 12) * 2;
		var h = _random.Next(3, 10);
		var area = (b * h) / 2;
		var correct = $"{area} cm²";
		var wrong1 = $"{b * h} cm²";
		var wrong2 = $"{area + 6} cm²";
		var wrong3 = $"{b + h} cm²";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-AREA-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-030",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Un fanion triangulaire a une base b = {b} cm et une hauteur h = {h} cm. Calcule son aire avec A = (b × h) / 2.",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Multiplie la base par la hauteur, puis divise le résultat par 2.",
			HintLevel2 = $"{b} × {h} = {b * h}. Reste à diviser par 2.",
			ExplanationText = $"A = ({b} × {h}) / 2 = {b * h} / 2 = {area} cm²."
		};
	}

	private ExerciseQuestion GenerateRectanglePerimeterFormulaQuestion()
	{
		var l = _random.Next(12, 28);
		var w = _random.Next(4, 11);
		var perimeter = 2 * (l + w);
		var correct = $"{perimeter} m";
		var wrong1 = $"{l * w} m";
		var wrong2 = $"{l + w} m";
		var wrong3 = $"{perimeter + 4} m";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PERIM-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-030",
			Discipline = "Maths",
			ClassLevel = "6e",
			Palier = 1,
			QuestionText = $"Un terrain rectangulaire mesure {l} m de long sur {w} m de large. Quel est son périmètre avec P = 2 × (L + l) ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionne d'abord la longueur et la largeur, puis double le tout.",
			HintLevel2 = $"Longueur + largeur = {l + w} m. Multiplie par 2.",
			ExplanationText = $"P = 2 × ({l} + {w}) = 2 × {l + w} = {perimeter} m."
		};
	}
}

