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
        Application.Current.Dispatcher.Dispatch(async () =>
        {
            IsLoading = true;
            var daily = await forecast.Daily().Unwrap();
            DailyWeather = new(daily?.Cast());
            IsLoading = false;
        });
    }
}
