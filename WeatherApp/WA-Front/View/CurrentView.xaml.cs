using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WA_Front.Model;
using WA_Front.ViewModel;

namespace WA_Front.View;

public partial class CurrentView : ContentView
{
    public CurrentView()
	{
		InitializeComponent();
        BindingContext = MauiProgram.ServiceProvider.GetService<CurrentViewModel>();
    }
}