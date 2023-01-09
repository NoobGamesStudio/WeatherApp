using CommunityToolkit.Mvvm.Input;

namespace WA_Front.View;

public partial class DailyPage : ContentPage
{
	public DailyPage()
	{
		InitializeComponent();
	}

	[RelayCommand]
	private async Task Navigate()
	{
		await Shell.Current.GoToAsync("..");
	}
}