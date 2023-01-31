namespace WA_Front;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MasterPage), typeof(MasterPage));
	}
}
