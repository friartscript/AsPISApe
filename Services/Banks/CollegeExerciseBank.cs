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
			1 => _mathsBank.GenerateQuestionBySubject(_random.Next(1, 21)),
			2 => _mathsBank.GenerateQuestionBySubject(_random.Next(21, 46)),
			3 => _mathsBank.GenerateQuestionBySubject(_random.Next(46, 71)),
			4 => _mathsBank.GenerateQuestionBySubject(_random.Next(71, 93)),
			_ => _mathsBank.GenerateQuestionBySubject(_random.Next(93, 112))
		};
	}

	private ExerciseQuestion GenerateFrenchQuestion(int slot)
	{
		return slot switch
		{
			1 => _frenchBank.GenerateQuestionBySubject(_random.Next(1, 11)),
			2 => _frenchBank.GenerateQuestionBySubject(_random.Next(11, 23)),
			3 => _frenchBank.GenerateQuestionBySubject(_random.Next(23, 38)),
			4 => _frenchBank.GenerateQuestionBySubject(_random.Next(38, 53)),
			_ => _frenchBank.GenerateQuestionBySubject(_random.Next(53, 69))
		};
	}

	private ExerciseQuestion GeneratePisaMixQuestion(int slot)
	{
		return _pisaBank.GenerateQuestion(slot);
	}
}
