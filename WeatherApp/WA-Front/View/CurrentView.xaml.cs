namespace WA_Front.View;

public partial class CurrentView : ContentView
{
    public CurrentView()
	{
		InitializeComponent();
        BindingContext = MauiProgram.ServiceProvider.GetService<CurrentViewModel>();
    }
}