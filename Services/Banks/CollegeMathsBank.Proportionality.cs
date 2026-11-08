using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeMathsBank
{
	public ExerciseQuestion GenerateFourthProportionalQuestion()
	{
		var priceFor1 = _random.Next(2, 6);
		var q1 = _random.Next(2, 5);
		var p1 = priceFor1 * q1;
		var q2 = q1 * _random.Next(2, 4);
		var p2 = priceFor1 * q2;

		var correct = $"{p2} €";
		var wrong1 = $"{p2 + priceFor1} €";
		var wrong2 = $"{p1 * 2} €";
		var wrong3 = $"{p2 - 3} €";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PROP1-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-044",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Au marché, {q1} kg de pommes coûtent {p1} €. Combien coûtent {q2} kg des mêmes pommes à ce tarif proportionnel ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Utilise le produit en croix ou calcule d'abord le prix pour 1 kg (coefficient de proportionnalité).",
			HintLevel2 = $"1 kg coûte {p1} / {q1} = {priceFor1} €. Multiplie par {q2}.",
			ExplanationText = $"Prix unitaire = {priceFor1} €/kg. Pour {q2} kg : {q2} × {priceFor1} = {p2} €."
		};
	}

	public ExerciseQuestion GenerateRatioQuestion()
	{
		var ratioA = 2;
		var ratioB = 3;
		var totalParts = ratioA + ratioB;
		var multiplier = _random.Next(4, 12);
		var totalAmount = totalParts * multiplier;
		var partA = ratioA * multiplier;
		var partB = ratioB * multiplier;

		var correct = $"{partA} € et {partB} €";
		var wrong1 = $"{totalAmount / 2} € et {totalAmount / 2} €";
		var wrong2 = $"{partA - 2} € et {partB + 2} €";
		var wrong3 = $"{partB} € et {partA} €";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-RATIO-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-045",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Deux amis partagent une somme de {totalAmount} € selon le ratio {ratioA} : {ratioB}. Quelle part reçoit chacun ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Additionne les parts du ratio pour trouver le nombre total de parts égales, puis divise la somme totale par ce nombre.",
			HintLevel2 = $"{ratioA} + {ratioB} = {totalParts} parts. 1 part = {totalAmount} / {totalParts} = {multiplier} €.",
			ExplanationText = $"1 part vaut {multiplier} €. Premier : {ratioA}×{multiplier} = {partA} €. Second : {ratioB}×{multiplier} = {partB} €."
		};
	}

	public ExerciseQuestion GeneratePercentageDiscountQuestion()
	{
		var initialPrice = _random.Next(3, 9) * 10;
		var discounts = new[] { 10, 20, 30, 40, 50 };
		var discountPct = discounts[_random.Next(discounts.Length)];
		var reduction = (initialPrice * discountPct) / 100;
		var finalPrice = initialPrice - reduction;

		var correct = $"{finalPrice} €";
		var wrong1 = $"{initialPrice - discountPct} €";
		var wrong2 = $"{finalPrice + 5} €";
		var wrong3 = $"{reduction} €";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PCT1-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-046",
			Discipline = "Maths",
			ClassLevel = "5e",
			Palier = 1,
			QuestionText = $"Un sac à dos affiché à {initialPrice} € bénéficie d'une remise de {discountPct} % pendant les soldes. Quel est son prix soldé ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Calcule le montant de la remise : (Prix initial × Pourcentage) / 100, puis déduis-le du prix de départ.",
			HintLevel2 = $"Remise = ({initialPrice} × {discountPct}) / 100 = {reduction} €. Calcule {initialPrice} - {reduction}.",
			ExplanationText = $"Montant de remise = {reduction} €. Prix soldé = {initialPrice} - {reduction} = {finalPrice} €."
		};
	}

	public ExerciseQuestion GeneratePercentageIncreaseQuestion()
	{
		var baseQuantity = _random.Next(2, 6) * 50;
		var increasePct = 10;
		var increaseVal = (baseQuantity * increasePct) / 100;
		var newQuantity = baseQuantity + increaseVal;

		var correct = $"{newQuantity} spectateurs";
		var wrong1 = $"{baseQuantity + increasePct} spectateurs";
		var wrong2 = $"{newQuantity + 15} spectateurs";
		var wrong3 = $"{baseQuantity - increaseVal} spectateurs";

		var choices = Shuffle(correct, wrong1, wrong2, wrong3, out var idx);
		return new ExerciseQuestion
		{
			Id = $"Q-MA-COL-PCT2-{_random.Next(1000, 9999)}",
			SubjectId = "MA-COL-046",
			Discipline = "Maths",
			ClassLevel = "4e",
			Palier = 1,
			QuestionText = $"La fréquentation d'un théâtre passe de {baseQuantity} spectateurs à une hausse de {increasePct} % la semaine suivante. Combien de spectateurs sont présents ?",
			Choices = choices,
			CorrectChoiceIndex = idx,
			HintLevel1 = "Une augmentation de 10 % revient à ajouter 10 % du montant initial ou à multiplier par 1,10.",
			HintLevel2 = $"Hausse de 10 % = {baseQuantity} × 0,10 = {increaseVal}. Ajoute cette valeur à {baseQuantity}.",
			ExplanationText = $"Hausse = {increaseVal} spectateurs. Nouveau total = {baseQuantity} + {increaseVal} = {newQuantity} spectateurs."
		};
	}
}

