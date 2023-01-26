using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WA_Front.Model;

namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class CurrentViewModel
{
    [ObservableProperty]
    public ObservableCollection<DayPartWeatherModel> dayPartWeather = new()
    {
        new DayPartWeatherModel() { Part="Morning", Temperature = 8, Rain = 80, ImageSource = "rainy", RealTemperature = 4 },
        new DayPartWeatherModel() { Part="Afternoon", Temperature = 7, Rain = 8, ImageSource = "sunny", RealTemperature = 10 },
        new DayPartWeatherModel() { Part="Night", Temperature = 6, Rain = 18, ImageSource = "cloudy", RealTemperature = 5 },
    };

    [ObservableProperty]
    public CurrentWeatherModel currentWeather = new()
    {
        Temperature = 0,
        Rain = 0,
        ImageSource = "sunny",
        RealTemperature = 0,
    };
}
