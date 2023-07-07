using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RailRoadApp.Services.Converters;

public class ColorToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is not System.Drawing.Color) {
            throw new InvalidOperationException(nameof(Color));
        }

        var color = (System.Drawing.Color) value;
        var mediaColor = Color.FromArgb(color.A, color.R, color.G, color.B);
        mediaColor.ScA = .6f;
        return new SolidColorBrush(mediaColor);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => new NotImplementedException();
}
