namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class CurrentViewModel
{
    [ObservableProperty]
    public ObservableCollection<DayPartWeatherModel> dayPartWeather = new();

    [ObservableProperty]
    public CurrentWeather currentWeather;

    [ObservableProperty]
    public string city;

    public CurrentViewModel(Forecast forecast)
    {
        Task.Run(() => GetData(forecast, new() {{ "City", "Szczecin" }}));

        WeakReferenceMessenger.Default
            .Register<CurrentViewModel, string, string>(
                this, 
                nameof(MessageChannels.Refresh), 
                (r, o) => r.GetData(forecast, new() {{ "City", o }}));
    }

    void GetData(Forecast forecast, Dictionary<string, object> parameters) => Application.Current.Dispatcher.DispatchAsync(async () =>
    {
        await GetCurrent(forecast, parameters);
        await GetPart(forecast, parameters);
    });

    async Task GetCurrent(Forecast forecast, Dictionary<string, object> parameters)
    {
        Current current;
        if (parameters.TryGetValue("City", out object city))
        {
            current = await forecast.Current(city as string);
        }
        else
        {
            current = await forecast.Current();
        }
        CurrentWeather = current?.CurrentWeather;
    }

    async Task GetPart(Forecast forecast, Dictionary<string, object> parameters)
    {
        Hourly period;
        if (parameters.TryGetValue("City", out object city))
        {
            period = await forecast.Hourly(city as string);
        }
        else
        {
            period = await forecast.Hourly();
        }

        DayPartWeather.Clear();
        GC.Collect();
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
            })
            .ToList()
            .ForEach(p => DayPartWeather.Add(p));
        City = forecast.City;
    }

    [RelayCommand]
    void Search(string parameter)
    {
        WeakReferenceMessenger.Default.Send(parameter, nameof(MessageChannels.Refresh));
    }
}
