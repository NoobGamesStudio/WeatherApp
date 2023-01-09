using CommunityToolkit.Mvvm.Input;

namespace WA_Front.View;

public partial class HourlyPage : ContentPage
{
	public HourlyPage()
	{
		InitializeComponent();
	}

    [RelayCommand]
    private async Task Navigate()
    {
        await Shell.Current.GoToAsync("..");
    }
}