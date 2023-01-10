namespace WA_Front;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

		if(window is not null)
		{
			window.Title = "Testing title";
		}

		return window;
    }
}
