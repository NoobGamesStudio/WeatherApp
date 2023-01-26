using WA_Front.ViewModel;

namespace WA_Front.View;

public partial class CalendarView : ContentView
{
	public CalendarView()
	{
		InitializeComponent();
		BindingContext = MauiProgram.ServiceProvider.GetService<CalendarViewModel>();
	}

    public override string ToString() => "Calendar";
}