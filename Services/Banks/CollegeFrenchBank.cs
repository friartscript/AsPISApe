using AsPISApe.Models;

namespace AsPISApe.Services.Banks;

public partial class CollegeFrenchBank
{
	private readonly Random _random = new();

	public ExerciseQuestion GenerateQuestionBySubject(int subjectIndex)
	{
		return subjectIndex switch
		{
			1 => GenerateWordClassQuestion(),
			2 => GenerateNounQuestion(),
			3 => GenerateDeterminerQuestion(),
			4 => GeneratePronounQuestion(),
			5 => GenerateAdjectiveQuestion(),
			6 => GenerateVerbQuestion(),
			7 => GenerateAdverbQuestion(),
			8 => GeneratePrepositionQuestion(),
			9 => GenerateConjunctionQuestion(),
			10 => GenerateInterjectionQuestion(),
			11 => GenerateNatureVsFunctionQuestion(),
			12 => GenerateSubjectFunctionQuestion(),
			13 => GenerateAttributeFunctionQuestion(),
			14 => GenerateObjectComplementQuestion(),
			15 => GenerateAgentComplementQuestion(),
			16 => GenerateCircumstantialComplementQuestion(),
			17 => GenerateNounExpansionsQuestion(),
			18 => GenerateNounComplementQuestion(),
			19 => GenerateEpithetFunctionQuestion(),
			20 => GenerateAppositionQuestion(),
			21 => GenerateAdjectiveFunctionsQuestion(),
			22 => GenerateApostropheFunctionQuestion(),
			23 => GeneratePresentValuesQuestion(),
			24 => GenerateImparfaitValuesQuestion(),
			25 => GeneratePasseSimpleValuesQuestion(),
			26 => GenerateImparfaitVsPasseSimpleQuestion(),
			27 => GeneratePasseComposeValuesQuestion(),
			28 => GeneratePlusQueParfaitQuestion(),
			29 => GenerateFutureTensesQuestion(),
			30 => GenerateConditionnelValuesQuestion(),
			31 => GenerateSubjonctifValuesQuestion(),
			32 => GenerateImperatifValuesQuestion(),
			33 => GenerateSimpleVsCompoundTensesQuestion(),
			34 => GenerateInfinitiveVsParticipleQuestion(),
			35 => GenerateAuxiliariesConjugationQuestion(),
			36 => GenerateFirstSecondGroupConjugationQuestion(),
			37 => GenerateThirdGroupIrregularConjugationQuestion(),
			38 => GeneratePastParticipleEtreQuestion(),
			39 => GeneratePastParticipleAvoirQuestion(),
			40 => GenerateAdjectiveAgreementQuestion(),
			41 => GenerateSubjectVerbAgreementQuestion(),
			42 => GenerateToutAgreementQuestion(),
			43 => GenerateLeurAgreementQuestion(),
			44 => GenerateBasicHomophonesQuestion(),
			45 => GenerateDemonstrativeHomophonesQuestion(),
			46 => GenerateJuxtapositionCoordinationQuestion(),
			47 => GenerateRelativeClauseQuestion(),
			48 => GenerateRelativeClauseQuestion(),
			49 => GenerateCompletiveClauseQuestion(),
			50 => GenerateCompletiveClauseQuestion(),
			51 => GenerateCircumstantialClauseQuestion(),
			52 => GenerateCircumstantialClauseQuestion(),
			53 => GenerateLexicalFieldQuestion(),
			54 => GenerateLexicalFieldQuestion(),
			55 => GenerateLanguageRegisterQuestion(),
			56 => GenerateLanguageRegisterQuestion(),
			57 => GenerateMeliorativePejorativeQuestion(),
			58 => GenerateDirectIndirectSpeechQuestion(),
			59 => GenerateComparisonVsMetaphorQuestion(),
			60 => GenerateComparisonVsMetaphorQuestion(),
			61 => GenerateComparisonVsMetaphorQuestion(),
			62 => GeneratePersonificationQuestion(),
			63 => GeneratePersonificationQuestion(),
			64 => GenerateHyperboleQuestion(),
			65 => GenerateHyperboleQuestion(),
			66 => GenerateOxymoronAntithesisQuestion(),
			67 => GenerateOxymoronAntithesisQuestion(),
			68 => GenerateOxymoronAntithesisQuestion(),
			_ => GenerateWordClassQuestion()
		};
	}

	private List<string> Shuffle(string c, string w1, string w2, string w3, out int correctIndex)
	{
		var list = new List<string> { c, w1, w2, w3 };
		var n = list.Count;
		while (n > 1)
		{
			n--;
			var k = _random.Next(n + 1);
			(list[k], list[n]) = (list[n], list[k]);
		}
		correctIndex = list.IndexOf(c);
		return list;
	}
}
