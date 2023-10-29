namespace LocalizationInRelease;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		await Shell.Current.GoToAsync(nameof(CollectionViewPage));

		//try
		//{
		//	var supportedFile = new[] { "public.comma-separated-values-text" };
		//	var fileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
		//	{
		//		{ DevicePlatform.MacCatalyst, supportedFile }
		//	});
		//	var result = await FilePicker.PickAsync(new PickOptions
		//	{
		//		PickerTitle = "Carica il PDF del tuo documento",
		//		FileTypes = fileTypes
		//	});
		//}
		//catch (Exception ex)
		//{
		//	Console.WriteLine("ex: " + ex.Message);
		//}
    }
}


