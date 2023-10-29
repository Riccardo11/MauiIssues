namespace LocalizationInRelease;

public partial class CollectionViewPage : ContentPage
{
	public CollectionViewPage()
	{
		InitializeComponent();
		BindingContext = new CollectionViewViewModel();
	}

    void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
		var cv = (CollectionView)sender;
		cv.ScrollTo(e.CurrentSelection[0]);
    }
}
