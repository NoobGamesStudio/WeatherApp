namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class CalendarViewModel
{
    [ObservableProperty]
    public ObservableCollection<DailyModel> dailyWeather = new();

    [ObservableProperty]
    public bool isLoading = true;

    public CalendarViewModel(Forecast forecast)
    {
        Task.Run(() => GetData(forecast, new() { { "City", "Szczecin" } }));
        WeakReferenceMessenger.Default
            .Register<CalendarViewModel, string, string>(
                this, 
                nameof(MessageChannels.Refresh), 
                (r, o) => r.GetData(forecast, new() {{ "City", o }}));
    }

    void GetData(Forecast forecast, Dictionary<string, object> parameters) => Application.Current.Dispatcher.DispatchAsync(async () =>
    {
        Daily daily;
        IsLoading = true;
        DailyWeather.Clear();
        GC.Collect();
        if (parameters.TryGetValue("City", out object city))
        {
            daily = await forecast.Daily(city as string);
        }
        else
        {
            daily = await forecast.Daily();
        }
        daily?.Cast()
            .ForEach(d => DailyWeather.Add(d));
        IsLoading = false;
    });
}
