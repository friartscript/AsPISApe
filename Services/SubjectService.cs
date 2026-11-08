using AsPISApe.Models;

namespace AsPISApe.Services;

public partial class SubjectService : ISubjectService
{
	private static readonly List<SubjectItem> _allSubjects = _collegeMathsSubjects
		.Concat(_collegeFrenchSubjects)
		.Concat(_secondeSubjects)
		.Concat(_premiereSubjects)
		.Concat(_terminaleSubjects)
		.ToList();

	public IReadOnlyList<SubjectItem> GetAllSubjects()
	{
		return _allSubjects.AsReadOnly();
	}

	public IReadOnlyList<SubjectItem> FilterSubjects(string? discipline, string? level, string? classLevel, string? searchQuery)
	{
		IEnumerable<SubjectItem> query = _allSubjects;

		if (!string.IsNullOrWhiteSpace(discipline) && !discipline.Equals("Tous", StringComparison.OrdinalIgnoreCase))
		{
			query = query.Where(s => s.Discipline.Equals(discipline, StringComparison.OrdinalIgnoreCase));
		}

		if (!string.IsNullOrWhiteSpace(level) && !level.Equals("Tous", StringComparison.OrdinalIgnoreCase))
		{
			query = query.Where(s => s.Level.Equals(level, StringComparison.OrdinalIgnoreCase));
		}

		if (!string.IsNullOrWhiteSpace(classLevel) && !classLevel.Equals("Tous", StringComparison.OrdinalIgnoreCase))
		{
			query = query.Where(s => s.ClassLevel.Contains(classLevel, StringComparison.OrdinalIgnoreCase));
		}

		if (!string.IsNullOrWhiteSpace(searchQuery))
		{
			var normalized = searchQuery.Trim().ToLowerInvariant();
			query = query.Where(s =>
				s.Title.ToLowerInvariant().Contains(normalized) ||
				s.Domain.ToLowerInvariant().Contains(normalized) ||
				s.Details.ToLowerInvariant().Contains(normalized) ||
				s.ClassLevel.ToLowerInvariant().Contains(normalized)
			);
		}

		return query.ToList();
	}
}
