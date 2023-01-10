using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using WA_Front.View;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

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
			})
			.ConfigureLifecycleEvents(events =>
			{
#if WINDOWS
				events.AddWindows(windows => 
					windows.OnWindowCreated((window) => 
					{
						IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
						WindowId nativeWindowId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
						AppWindow appWindow = AppWindow.GetFromWindowId(nativeWindowId);           
						window.ExtendsContentIntoTitleBar = false;
						window.Title = "Windows Title";
						(appWindow.Presenter as OverlappedPresenter).SetBorderAndTitleBar(false, false);
					})
				);
#endif
            });
#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<WA_Utility.Service.ExampleService>();
		builder.Services.AddSingleton<WA_WeatherAPI.Service.ExampleService>();
		builder.Services.AddSingleton<MasterPage>();

        return builder.Build();
	}
}
