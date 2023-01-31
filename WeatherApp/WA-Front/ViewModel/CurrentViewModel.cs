namespace WA_Front.ViewModel;

public partial class CurrentViewModel : ObservableObject
{
    public ObservableCollection<DayPartWeatherModel> DayPartWeather { get; init; } = new();

    [ObservableProperty]
    public CurrentWeather currentWeather;

    [ObservableProperty]
    public string city;

    public CurrentViewModel(Forecast forecast)
    {
        GetData(forecast, new() { { "City", "Szczecin" } });

        WeakReferenceMessenger.Default
            .Register<CurrentViewModel, string, string>(
                this, 
                nameof(MessageChannels.Refresh), 
                (r, o) => r.GetData(forecast, new() { { "City", o } }));
    }

    async void GetData(Forecast forecast, Dictionary<string, object> parameters)
    {
        DayPartWeather.Clear();
        var current = GetCurrent(forecast, parameters);
        var part = GetPart(forecast, parameters);
        CurrentWeather = (await current)?.CurrentWeather;
        (await part)?.ForEach(DayPartWeather.Add);
        City = forecast.City;
    }

    async Task<Current> GetCurrent(Forecast forecast, Dictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("City", out object city))
        {
            return await forecast.Current(city as string);
        }
        else
        {
            return await forecast.Current();
        }
    }

    async Task<List<DayPartWeatherModel>> GetPart(Forecast forecast, Dictionary<string, object> parameters)
    {
        Task<Hourly> period;
        if (parameters.TryGetValue("City", out object city))
        {
            period = forecast.Hourly(city as string);
        }
        else
        {
            period = forecast.Hourly();
        }

        GC.Collect();
        return (await period)?.Cast()
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
            })
            .ToList();       
    }

    [RelayCommand]
    void Search(string parameter)
    {
        WeakReferenceMessenger.Default.Send(parameter, nameof(MessageChannels.Refresh));
    }
}
