using Microsoft.Extensions.Logging;
using AsPISApe.Services;
using AsPISApe.Views;

namespace AsPISApe;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<INavigationService, NavigationService>();
		builder.Services.AddSingleton<ISoundService, SoundService>();
		builder.Services.AddSingleton<IProfileService, ProfileService>();
		builder.Services.AddSingleton<ISubjectService, SubjectService>();
		builder.Services.AddSingleton<IExerciseBankService, ExerciseBankService>();
		builder.Services.AddSingleton<ISessionGenerator, SessionGenerator>();
		builder.Services.AddSingleton<IAntiSecheService, AntiSecheService>();
		builder.Services.AddSingleton<IChallengeService, ChallengeService>();
		builder.Services.AddTransient<WelcomePage>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<SubjectsPage>();
		builder.Services.AddTransient<SessionPlayPage>();
		builder.Services.AddTransient<SessionSummaryPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
