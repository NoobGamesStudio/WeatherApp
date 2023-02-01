namespace WA_Front;

public static class MauiProgram
{
    public static IServiceProvider ServiceProvider;

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Rubik-Light.ttf", "RubikLight");
			})
			.ConfigureLifecycleEvents(events =>
			{
#if WINDOWS
				events.AddWindows(windows => 
					windows.OnWindowCreated((window) => 
					{
						//window.ExtendsContentIntoTitleBar = false;
					})
				);
#endif
            });
#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<MasterPageModel>();
        builder.Services.AddSingleton<CalendarViewModel>();
        builder.Services.AddSingleton<CurrentViewModel>();
        builder.Services.AddSingleton<HourlyViewModel>();
        builder.Services.AddSingleton<SwitchViewModel>();
		builder.Services.AddSingleton<MasterPage>();

		builder.Services.AddSingleton<Forecast>();
		builder.Services.AddSingleton<Localization>();

		var app = builder.Build();
		ServiceProvider = app.Services;

        return app;
	}
}
