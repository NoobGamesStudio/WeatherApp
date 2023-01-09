using WA_Front.Service;
using CommunityToolkit.Mvvm.Input;

namespace WA_Front.View;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(
		WA_WeatherAPI.Service.ExampleService apiExample, 
		WA_Utility.Service.ExampleService uExample)
	{
		InitializeComponent();
		BindingContext = new ExampleCombined()
		{
			Value = apiExample.Value + " " + uExample.Value
		};
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	[RelayCommand]
	private async Task Navigate(string uri)
	{
		await Shell.Current.GoToAsync(uri);
	}
}

