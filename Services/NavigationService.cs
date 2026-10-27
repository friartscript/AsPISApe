namespace AsPISApe.Services;

public class NavigationService : INavigationService
{
	private INavigation? _navigation;
	private bool _isNavigating;

	public void SetNavigation(INavigation navigation)
	{
		_navigation = navigation;
	}

	public async Task NavigateToAsync(Page targetPage)
	{
		if (_navigation == null || _isNavigating)
		{
			return;
		}

		_isNavigating = true;

		try
		{
			var currentPage = _navigation.NavigationStack.LastOrDefault();
			if (currentPage != null)
			{
				await currentPage.FadeToAsync(0, 160, Easing.CubicOut);
			}

			NavigationPage.SetHasNavigationBar(targetPage, false);
			NavigationPage.SetHasBackButton(targetPage, false);
			targetPage.Opacity = 0;
			await _navigation.PushAsync(targetPage, false);
			await targetPage.FadeToAsync(1, 220, Easing.CubicIn);

			if (currentPage != null)
			{
				currentPage.Opacity = 1;
			}
		}
		finally
		{
			_isNavigating = false;
		}
	}

	public async Task NavigateBackAsync()
	{
		if (_navigation == null || _isNavigating || _navigation.NavigationStack.Count <= 1)
		{
			return;
		}

		_isNavigating = true;

		try
		{
			var currentPage = _navigation.NavigationStack.Last();
			var previousIndex = _navigation.NavigationStack.Count - 2;
			var previousPage = _navigation.NavigationStack[previousIndex];

			await currentPage.FadeToAsync(0, 160, Easing.CubicOut);
			previousPage.Opacity = 0;
			await _navigation.PopAsync(false);
			await previousPage.FadeToAsync(1, 220, Easing.CubicIn);
		}
		finally
		{
			_isNavigating = false;
		}
	}
}
