namespace WA_Front.View;

public partial class CalendarView : ContentView
{
	RadioButton selected = null;

	public CalendarView()
	{
		InitializeComponent();
		BindingContext = MauiProgram.ServiceProvider.GetService<CalendarViewModel>();
	}

    public override string ToString() => "Calendar";

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		if(e.Parameter is RadioButton button)
		{
            Content.BindingContext = button.BindingContext;

            if (selected == button)
            {
                button.IsChecked = !button.IsChecked;
            }

            selected = button.IsChecked ? button : null;
        }
    }
}