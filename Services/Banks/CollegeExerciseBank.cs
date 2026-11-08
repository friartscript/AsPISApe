using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public class CollegeExerciseBank
{
	private readonly Random _random = new();
	private readonly CollegeMathsBank _mathsBank = new();
	private readonly CollegeFrenchBank _frenchBank = new();
	private readonly CollegePisaBank _pisaBank = new();

	public ExerciseQuestion GenerateQuestion(string discipline, int slot)
	{
		return discipline switch
		{
			"Maths" => GenerateMathQuestion(slot),
			"Francais" => GenerateFrenchQuestion(slot),
			"Mixte" => GeneratePisaMixQuestion(slot),
			_ => _random.Next(2) == 0 ? GenerateMathQuestion(slot) : GenerateFrenchQuestion(slot)
		};
	}

	public IReadOnlyList<ExerciseQuestion> GetBaseQuestions()
	{
		var list = new List<ExerciseQuestion>();
		for (var slot = 1; slot <= 5; slot++)
		{
			list.Add(GenerateMathQuestion(slot));
			list.Add(GenerateFrenchQuestion(slot));
			list.Add(GeneratePisaMixQuestion(slot));
		}
		return list;
	}

	private ExerciseQuestion GenerateMathQuestion(int slot)
	{
		return slot switch
		{
			1 => _mathsBank.GenerateQuestionBySubject(_random.Next(1, 7)),
			2 => _mathsBank.GenerateQuestionBySubject(_random.Next(7, 13)),
			3 => _mathsBank.GenerateQuestionBySubject(_random.Next(13, 18)),
			4 => _mathsBank.GenerateQuestionBySubject(_random.Next(18, 20)),
			_ => _mathsBank.GenerateQuestionBySubject(_random.Next(20, 32))
		};
	}

	private ExerciseQuestion GenerateFrenchQuestion(int slot)
	{
		return slot switch
		{
			1 => _frenchBank.GenerateQuestionBySubject(_random.Next(1, 11)),
			2 => _frenchBank.GenerateQuestionBySubject(_random.Next(11, 23)),
			3 => _frenchBank.GenerateQuestionBySubject(_random.Next(23, 31)),
			4 => _frenchBank.GenerateQuestionBySubject(_random.Next(31, 38)),
			_ => _frenchBank.GenerateQuestionBySubject(_random.Next(1, 38))
		};
	}

	private ExerciseQuestion GeneratePisaMixQuestion(int slot)
	{
		return _pisaBank.GenerateQuestion(slot);
	}
}
