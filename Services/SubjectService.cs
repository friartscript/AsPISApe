using AsPISApe.Models;

namespace AsPISApe.Services;

public partial class SubjectService : ISubjectService
{
	private static List<SubjectItem>? _allSubjectsCache;

	private static List<SubjectItem> GetOrBuildAllSubjects()
	{
		if (_allSubjectsCache != null)
		{
			return _allSubjectsCache;
		}

		var list = new List<SubjectItem>(
			_collegeMathsSubjects.Count +
			_collegeFrenchSubjects.Count +
			_secondeSubjects.Count +
			_premiereSubjects.Count +
			_terminaleSubjects.Count);

		list.AddRange(_collegeMathsSubjects);
		list.AddRange(_collegeFrenchSubjects);
		list.AddRange(_secondeSubjects);
		list.AddRange(_premiereSubjects);
		list.AddRange(_terminaleSubjects);
		_allSubjectsCache = list;
		return _allSubjectsCache;
	}

	public IReadOnlyList<SubjectItem> GetAllSubjects()
	{
		return GetOrBuildAllSubjects().AsReadOnly();
	}

	public IReadOnlyList<SubjectItem> FilterSubjects(string? discipline, string? level, string? classLevel, string? searchQuery)
	{
		IEnumerable<SubjectItem> query = GetOrBuildAllSubjects();

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
