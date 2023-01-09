using CommunityToolkit.Mvvm.Input;

namespace WA_Front.View;

public partial class NowPage : ContentPage
{
	public NowPage()
	{
		InitializeComponent();
	}

    [RelayCommand]
    private async Task Navigate()
    {
        await Shell.Current.GoToAsync("..");
    }
}