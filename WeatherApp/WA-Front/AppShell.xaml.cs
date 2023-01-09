using WA_Front.View;

namespace WA_Front;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(NowPage), typeof(NowPage));
		Routing.RegisterRoute(nameof(DailyPage), typeof(DailyPage));
		Routing.RegisterRoute(nameof(HourlyPage), typeof(HourlyPage));
	}
}
