using Microsoft.Extensions.Logging;
using WA_Front.View;

namespace WA_Front;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<WA_Utility.Service.ExampleService>();
		builder.Services.AddSingleton<WA_WeatherAPI.Service.ExampleService>();

        builder.Services.AddTransient<NowPage>();
        builder.Services.AddTransient<HourlyPage>();
        builder.Services.AddTransient<DailyPage>();
        return builder.Build();
	}
}
