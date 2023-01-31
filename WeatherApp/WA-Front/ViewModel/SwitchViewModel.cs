namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class SwitchViewModel
{
    [ObservableProperty]
    public ObservableCollection<ContentView> models = new()
    {
        new HourlyView(),
        new CalendarView(),
    };

    [ObservableProperty]
    public ContentView chosenModel;

    public void Switch(ContentView view)
    {
        ChosenModel = view;
    }
}
