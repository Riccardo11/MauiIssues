using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace williambuchanan2Android;

public partial class Williambuchanan2Page : ContentPage
{
	public Williambuchanan2Page()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
    }
}
