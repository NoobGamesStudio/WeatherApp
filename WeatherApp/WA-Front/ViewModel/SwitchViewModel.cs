using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WA_Front.View;

namespace WA_Front.ViewModel;

[INotifyPropertyChanged]
public partial class SwitchViewModel
{
    [ObservableProperty]
    public ObservableCollection<ContentView> models = new()
    {
        new HourlyView(),
        new CalendarView()
    };

    [ObservableProperty]
    public ContentView chosenModel;

    public void Switch(ContentView view)
    {
        ChosenModel = view;
    }
}
