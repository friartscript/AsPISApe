using AsPISApe.Models;

namespace AsPISApe.Services;

public interface ISubjectService
{
	IReadOnlyList<SubjectItem> GetAllSubjects();
	IReadOnlyList<SubjectItem> FilterSubjects(string? discipline, string? level, string? classLevel, string? searchQuery);
}
