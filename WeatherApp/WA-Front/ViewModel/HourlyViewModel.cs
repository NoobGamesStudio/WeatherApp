namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class HourlyViewModel
{
    [ObservableProperty]
    public ObservableCollection<HourlyModel> hourlyWeather = new();

    [ObservableProperty]
    public bool isLoading = true;

    public HourlyViewModel(Forecast forecast) 
    {
        Task.Run(() => GetData(forecast, new() {{ "City", "Szczecin" }}));

        WeakReferenceMessenger.Default
            .Register<HourlyViewModel, string, string>(
                this,
                nameof(MessageChannels.Refresh),
                (r, o) => r.GetData(forecast, new(){{ "City", o }}));
    }

    void GetData(Forecast forecast, Dictionary<string, object> parameters) => Application.Current.Dispatcher.DispatchAsync(async () =>
    {
        Hourly hourly;
        IsLoading = true;
        HourlyWeather.Clear();
        GC.Collect();
        if (parameters.TryGetValue("City", out object city))
        {
            hourly = await forecast.Hourly(city as string);
        }
        else
        {
            hourly = await forecast.Hourly();
        }
        hourly?.Cast()
            .ForEach(h => HourlyWeather.Add(h));
        IsLoading = false;
    });
}
