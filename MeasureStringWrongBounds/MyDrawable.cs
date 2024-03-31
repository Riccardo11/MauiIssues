// Only one must be enabled

// #define NEWLINE_IOS
#define STRING_NOT_VISIBLE_IOS

#if IOS
using CoreGraphics;
using Foundation;
using UIKit;
using Microsoft.Maui.Graphics.Platform;
#endif

using Font = Microsoft.Maui.Graphics.Font;

namespace MeasureStringWrongBounds;

public class MyDrawable : IDrawable
{
#if NEWLINE_IOS
    private const string StringToVisualize = "HELLO, WORLD!\nCiao mondo row 2\nGuten tag!?àèìòù@";
    // private const string StringToVisualize = "Ciaomondorowfdskle";
#endif
    
#if STRING_NOT_VISIBLE_IOS
    private const string StringToVisualize = "HELLO, WORLD!";
#endif
    
    private const int FontSize = 40;
    
    // This makes better the NEWLINE_IOS with the non deprecated API
    private static Font Font = new("Arial");
    // private static Font Font = Font.Default;
    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();
        
// #if !IOS
        var stringSize = canvas.GetStringSize(StringToVisualize, Font, FontSize);
// #endif
// #if IOS
//     var cgSize = new NSString(StringToVisualize).GetBoundingRect( 
//         CGSize.Empty, 
//         NSStringDrawingOptions.UsesLineFragmentOrigin,
//         new UIStringAttributes { Font = Font.ToPlatformFont(FontSize),  }, 
//         null).Size;
//     var stringSize = new SizeF((float)cgSize.Width, (float)cgSize.Height);
    
    
    // var cgSize = new NSString(StringToVisualize).StringSize(Font.Default.ToPlatformFont(FontSize), CGSize.Empty);
    // var stringSize = new SizeF((float)cgSize.Width, (float)cgSize.Height);
    
    // var stringSize = canvas.GetStringSize(StringToVisualize, Font, FontSize, HorizontalAlignment.Left, VerticalAlignment.Top);
// #endif
        
        
        
        // This seems to solve https://github.com/dotnet/maui/issues/8486
        // var stringBounds = new RectF(new PointF(0, 0), new Size(stringSize.Width, stringSize.Height + 2));
        var stringBounds = new RectF(new PointF(0, 0), stringSize);
        
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 2;
        canvas.DrawRectangle(stringBounds);
        
        canvas.FontSize = FontSize;
        canvas.Font = Font;
        
    #if NEWLINE_IOS // Because of https://github.com/dotnet/maui/issues/8486, larger bounds must be set to visualize the string
        canvas.DrawString(StringToVisualize, 0, 0, dirtyRect.Width, dirtyRect.Height, HorizontalAlignment.Left, VerticalAlignment.Top);
    #endif
        
    #if STRING_NOT_VISIBLE_IOS
        canvas.DrawString(StringToVisualize, stringBounds, HorizontalAlignment.Left, VerticalAlignment.Top);
    #endif
        
        canvas.RestoreState();
    }
}