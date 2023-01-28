namespace WA_Front.View;

public partial class SwitchView : ContentView
{
	public SwitchView()
	{
		InitializeComponent();
		BindingContext = MauiProgram.ServiceProvider.GetService<SwitchViewModel>();
		(Buttons.Children.FirstOrDefault() as RadioButton).IsChecked= true;
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		(BindingContext as SwitchViewModel).Switch((sender as RadioButton).BindingContext as ContentView);
    }
}