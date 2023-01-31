namespace WA_Front.ViewModel;

public partial class CalendarViewModel : ObservableObject
{
    public ObservableCollection<DailyModel> DailyWeather { get; init; } = new();

    [ObservableProperty]
    public bool isLoading = true;

    public CalendarViewModel(Forecast forecast)
    {
        GetData(forecast, new() { { "City", "Szczecin" } });
        WeakReferenceMessenger.Default
            .Register<CalendarViewModel, string, string>(
                this, 
                nameof(MessageChannels.Refresh), 
                (r, o) => r.GetData(forecast, new() { { "City", o } }));
    }

    async void GetData(Forecast forecast, Dictionary<string, object> parameters)
    {
        IsLoading = true;
        DailyWeather.Clear();
        var daily = Task.Run(() =>
        {
            if (parameters.TryGetValue("City", out object city))
            {
                 return forecast.Daily(city as string);
            }
            else
            {
                 return forecast.Daily();
            }
        });
        (await daily)?.Cast()
            .ForEach(DailyWeather.Add);
        IsLoading = false;
    }
}
