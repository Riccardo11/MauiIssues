namespace GraphicsViewInScrollView;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        GraphicsView.Drawable = new MyDrawable();
    }
}