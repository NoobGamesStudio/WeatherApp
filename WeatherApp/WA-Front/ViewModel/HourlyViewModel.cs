using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WA_Front.Model;

namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class HourlyViewModel
{
    [ObservableProperty]
    public ObservableCollection<HourlyWeatherModel> hourlyWeather = new()
    {
        new HourlyWeatherModel() { Temperature = 8, Rain = 80, ImageSource = "p50.png", RealTemperature = 4 },
        new HourlyWeatherModel() { Temperature = 7, Rain = 8, ImageSource = "p50.png", RealTemperature = 10 },
        new HourlyWeatherModel() { Temperature = 6, Rain = 18, ImageSource = "p50.png", RealTemperature = 5 },
    };
}
