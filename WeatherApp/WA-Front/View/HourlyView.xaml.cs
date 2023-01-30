namespace WA_Front.View;

public partial class HourlyView : ContentView
{
	public HourlyView()
	{
		InitializeComponent();
		BindingContext = MauiProgram.ServiceProvider.GetService<HourlyViewModel>();
	}

	public override string ToString() => "Hourly";

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		if(sender is Expander expander)
		{
			expander.IsExpanded = !expander.IsExpanded;
		}
    }
}