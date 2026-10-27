using AsPISApe.Services;
using AsPISApe.Views;

namespace AsPISApe;

public partial class App : Application
{
	private readonly INavigationService _navigationService;
	private readonly ISoundService _soundService;
	private readonly IProfileService _profileService;

	public App(INavigationService navigationService, ISoundService soundService, IProfileService profileService)
	{
		InitializeComponent();
		_navigationService = navigationService;
		_soundService = soundService;
		_profileService = profileService;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var welcomePage = new WelcomePage(_navigationService, _soundService, _profileService);
		var navigationPage = new NavigationPage(welcomePage);
		NavigationPage.SetHasNavigationBar(welcomePage, false);

		_navigationService.SetNavigation(navigationPage.Navigation);

		const double targetWidth = 450;
		const double targetHeight = 800;

		return new Window(navigationPage)
		{
			Title = "AsPISApe",
			Width = targetWidth,
			Height = targetHeight,
			MinimumWidth = targetWidth,
			MinimumHeight = targetHeight,
			MaximumWidth = targetWidth,
			MaximumHeight = targetHeight
		};
	}
}