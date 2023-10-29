namespace LocalizationInRelease;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CollectionViewPage), typeof(CollectionViewPage));
	}
}

