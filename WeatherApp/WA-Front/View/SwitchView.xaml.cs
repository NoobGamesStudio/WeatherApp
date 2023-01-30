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
		if(BindingContext is SwitchViewModel viewModel && 
			sender is RadioButton radioButton &&
			radioButton.BindingContext is ContentView view) 
		{
			viewModel.Switch(view);
		}
    }
}