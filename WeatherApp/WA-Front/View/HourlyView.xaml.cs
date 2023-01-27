using WA_Front.Controls;
using WA_Front.ViewModel;

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
		Expander expander = sender as Expander;
		expander.IsExpanded = !expander.IsExpanded;
    }
}