using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WA_Front.Model;

namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class CalendarViewModel
{
    [ObservableProperty]
    public ObservableCollection<DailyWeatherModel> dailyWeather = new()
    {
        new DailyWeatherModel() { Temperature = 8, Rain = 80, ImageSource = "p50.png", RealTemperature = 4 },
        new DailyWeatherModel() { Temperature = 7, Rain = 8, ImageSource = "p50.png", RealTemperature = 10 },
        new DailyWeatherModel() { Temperature = 5, Rain = 18, ImageSource = "p50.png", RealTemperature = 5 },
        new DailyWeatherModel() { Temperature = 4, Rain = 18, ImageSource = "p50.png", RealTemperature = 5 },
        new DailyWeatherModel() { Temperature = 3, Rain = 18, ImageSource = "p50.png", RealTemperature = 5 },
        new DailyWeatherModel() { Temperature = 1, Rain = 18, ImageSource = "p50.png", RealTemperature = 5 },
    };
}
