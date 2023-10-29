namespace GraphicsViewInScrollView;

public class MyDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.DrawString("Hello World", 0, 0, dirtyRect.Width, dirtyRect.Height, HorizontalAlignment.Left, VerticalAlignment.Top);
    }
}