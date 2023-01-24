using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using WA_Front.View;
using WA_Front.ViewModel;

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
        builder.Services.AddTransient<MasterPageModel>();
        builder.Services.AddTransient<CalendarViewModel>();
        builder.Services.AddTransient<CurrentViewModel>();
        builder.Services.AddTransient<HourlyViewModel>();
        builder.Services.AddTransient<SwitchViewModel>();
		builder.Services.AddTransient<MasterPage>();

		builder.Services.AddSingleton<WA_Utility.Service.ExampleService>();
		builder.Services.AddSingleton<WA_WeatherAPI.Service.ExampleService>();

		var app = builder.Build();
		ServiceProvider = app.Services;

        return app;
	}
}
