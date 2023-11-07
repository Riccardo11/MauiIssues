// Only one must be enabled

#define NEWLINE_IOS
// #define STRING_NOT_VISIBLE_IOS

using Font = Microsoft.Maui.Graphics.Font;

namespace MeasureStringWrongBounds;

public class MyDrawable : IDrawable
{
#if NEWLINE_IOS
    private const string StringToVisualize = "HELLO, WORLD!\nCiao mondo row 2\n\nGuten tag!?àèìòù@";
#endif
    
#if STRING_NOT_VISIBLE_IOS
    private const string StringToVisualize = "HELLO, WORLD!";
#endif
    
    private const int FontSize = 20;
    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();
        
        var stringSize = canvas.GetStringSize(StringToVisualize, Font.Default, FontSize);
        
        // This seems to solve https://github.com/dotnet/maui/issues/8486
        // var stringBounds = new RectF(new PointF(0, 0), new Size(stringSize.Width, stringSize.Height + 2));
        var stringBounds = new RectF(new PointF(0, 0), stringSize);
        
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 2;
        canvas.DrawRectangle(stringBounds);
        
        canvas.FontSize = FontSize;
        
    #if NEWLINE_IOS // Because of https://github.com/dotnet/maui/issues/8486, larger bounds must be set to visualize the string
        canvas.DrawString(StringToVisualize, 0, 0, 200, 200, HorizontalAlignment.Left, VerticalAlignment.Top);
    #endif
        
    #if STRING_NOT_VISIBLE_IOS
        canvas.DrawString(StringToVisualize, stringBounds, HorizontalAlignment.Left, VerticalAlignment.Top);
    #endif
        
        canvas.RestoreState();
    }
}