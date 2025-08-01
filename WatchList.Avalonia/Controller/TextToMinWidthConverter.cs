using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace WatchList.Avalonia.Controller
{
    public class TextToMinWidthConverter : IValueConverter
    {
        private const int MaxWidth = 300;
        private const int MinWidth = 100;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return CalculateMinWidth(text);
            }

            return MinWidth; // Min width
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();

        private double CalculateMinWidth(string text)
        {
            try
            {
                // Create FormattedText for string measurement
                var formattedText = new FormattedText(
                    text,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Arial"), // Use your font
                    12, // Font size
                    Brushes.Black);

                var textWidth = formattedText.Width; // Width of the text
                var padding = 40; // padding (20 + 20) 

                return Math.Min(Math.Max(textWidth + padding, MinWidth), MaxWidth);
            }
            catch
            {
                return MinWidth; // Returning the default value if error
            }
        }
    }
}
