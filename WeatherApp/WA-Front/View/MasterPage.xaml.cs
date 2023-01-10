using System.Collections.ObjectModel;

namespace WA_Front.View;

public partial class MasterPage : ContentPage
{
	public ObservableCollection<ContentView> Views { get; set; } = new()
	{
		new NowPage(),
		new HourlyPage(),
		new DailyPage(),
	};

	public MasterPage()
	{
		InitializeComponent();
	}
}