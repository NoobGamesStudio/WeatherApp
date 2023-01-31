namespace WA_Front.ViewModel;

public partial class HourlyViewModel : ObservableObject
{
    public ObservableCollection<HourlyModel> HourlyWeather { get; init; } = new();

    [ObservableProperty]
    public bool isLoading = true;

    public HourlyViewModel(Forecast forecast) 
    {
        GetData(forecast, new() {{ "City", "Szczecin" }});

        WeakReferenceMessenger.Default
            .Register<HourlyViewModel, string, string>(
                this,
                nameof(MessageChannels.Refresh),
                (r, o) => r.GetData(forecast, new() { { "City", o } }));
    }

    async void GetData(Forecast forecast, Dictionary<string, object> parameters)
    {
        IsLoading = true;
        HourlyWeather.Clear();
        var hourly = Task.Run(() =>
        {
            if (parameters.TryGetValue("City", out object city))
            {
                return forecast.Hourly(city as string);
            }
            else
            {
                return forecast.Hourly();
            }
        });
        (await hourly)?.Cast()
            .ForEach(HourlyWeather.Add);
        IsLoading = false;
    }
}
