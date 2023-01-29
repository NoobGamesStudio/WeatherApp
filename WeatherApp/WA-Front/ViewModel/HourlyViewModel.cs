namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class HourlyViewModel
{
    [ObservableProperty]
    public ObservableCollection<HourlyModel> hourlyWeather;

    [ObservableProperty]
    public bool isLoading = true;

    public HourlyViewModel(Forecast forecast) 
    {
        Application.Current.Dispatcher.Dispatch(async () =>
        {
            IsLoading = true;
            var hourly = await forecast.Hourly().Unwrap();
            HourlyWeather = new(hourly?.Cast());
            IsLoading = false;
        });
    }
}
