namespace AsPISApe.Services;

public interface IAntiSecheService
{
	int CalculateEarnedPoints(int basePoints, int hintLevelUsed);
	IReadOnlyList<int> GetFiftyFiftyHiddenIndices(int correctIndex, int choicesCount = 4);
}
