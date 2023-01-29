namespace WA_Front.ViewModel;

public partial class CurrentViewModel : ObservableObject
{
    [ObservableProperty]
    public ObservableCollection<DayPartWeatherModel> dayPartWeather = new();

    [ObservableProperty]
    public CurrentWeather currentWeather;

    Forecast _forecast;

    [ObservableProperty]
    public string city;

    public CurrentViewModel(Forecast forecast)
    {
        _forecast = forecast;
        GetCurrent();
        GetPart();
    }

    void GetCurrent() => Application.Current.Dispatcher.Dispatch(async () =>
    {
        var current = await _forecast.Current().Unwrap();
        CurrentWeather = current?.CurrentWeather;
    });

    void GetPart() => Application.Current.Dispatcher.Dispatch(async () =>
    {
        var period = await _forecast.Hourly().Unwrap();
        period?.Cast()
            .SkipWhile(p => p.Data.Time < DateTime.UtcNow)
            .Where((p, i) => i % 6 == 0)
            .Take(3)
            .Select(p => new DayPartWeatherModel
            {
                Part = p.Data.Time?.Hour switch
                {
                    < 6 => "Noon",
                    < 12 => "Morning",
                    < 18 => "Afternoon",
                    _ => "Night"
                },
                Data = p
            }).ToList().ForEach(e => DayPartWeather.Add(e));
        City = _forecast.City;
    });

    [RelayCommand]
    async Task Search(string parameter)
    {
        _forecast.City = parameter;
        GC.Collect();
        await Shell.Current.GoToAsync(nameof(MasterPage), false);
        var page = Shell.Current.CurrentPage;
    }
}
