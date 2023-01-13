using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WA_Front.Model;

namespace WA_Front.View;

public partial class NowPage : ContentView
{
	public ObservableCollection<DayPartWeatherModel> dayPartWeatherModel { get; set; } = new()
	{
		new DayPartWeatherModel() { Part="Morning", Temperature = 8, Rain = 80, ImageSource = "rainy", RealTemperature = 4 },
		new DayPartWeatherModel() { Part="Afternoon", Temperature = 7, Rain = 8, ImageSource = "sunny", RealTemperature = 10 },
		new DayPartWeatherModel() { Part="Night", Temperature = 6, Rain = 18, ImageSource = "cloudy", RealTemperature = 5 },
	};

	public CurrentWeatherModel currentWeatherModel { get; set; } = new()
	{
		Temperature = 0,
		Rain = 0,
		ImageSource = "sunny",
		RealTemperature = 0,
	};

	public NowPage()
	{
		InitializeComponent();
		BindingContext = this;
	}
}