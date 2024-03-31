namespace RadioButtonText;

public partial class MainPage : ContentPage
{
    private const bool APPLY_WORKAROUND = true;
    
    public MainPage()
    {
        InitializeComponent();
        
#if IOS
        if (APPLY_WORKAROUND)
        {
            BuggedRadioButton.Content = new Label
            {
                Text = "Hello, world!",
                TextColor = Colors.Red,
                FontSize = 50,
                TextTransform = TextTransform.Uppercase,
                FontAttributes = FontAttributes.Bold
            };
        }
#endif
    }
}