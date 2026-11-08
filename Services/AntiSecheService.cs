namespace AsPISApe.Services;

public class AntiSecheService : IAntiSecheService
{
	private readonly Random _random = new();

	public int CalculateEarnedPoints(int basePoints, int hintLevelUsed)
	{
		if (hintLevelUsed <= 0) return basePoints;

		var penaltyRatio = hintLevelUsed switch
		{
			1 => 0.35,
			_ => 0.60
		};

		var pointsAfterPenalty = (int)Math.Round(basePoints * (1.0 - penaltyRatio));
		var floorPoints = Math.Max(2, (int)Math.Round(basePoints * 0.20));

		return Math.Max(floorPoints, pointsAfterPenalty);
	}

	public IReadOnlyList<int> GetFiftyFiftyHiddenIndices(int correctIndex, int choicesCount = 4)
	{
		var wrongIndices = new List<int>();
		for (var i = 0; i < choicesCount; i++)
		{
			if (i != correctIndex)
			{
				wrongIndices.Add(i);
			}
		}

		var hidden = new List<int>();
		while (hidden.Count < 2 && wrongIndices.Count > 0)
		{
			var pick = _random.Next(wrongIndices.Count);
			hidden.Add(wrongIndices[pick]);
			wrongIndices.RemoveAt(pick);
		}

		return hidden;
	}
}
