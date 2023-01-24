using System.Collections.ObjectModel;
using WA_Front.ViewModel;

namespace WA_Front.View;

public partial class MasterPage : ContentPage
{
	public MasterPage(MasterPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}