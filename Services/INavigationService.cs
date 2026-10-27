namespace AsPISApe.Services;

public interface INavigationService
{
	void SetNavigation(INavigation navigation);
	Task NavigateToAsync(Page targetPage);
	Task NavigateBackAsync();
}
