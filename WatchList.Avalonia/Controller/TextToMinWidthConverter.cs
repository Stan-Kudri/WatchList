using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace WatchList.Avalonia.Controller
{
    public class TextToMinWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double parentWidth)
            {
                // Возвращаем минимальную ширину, достаточную для отображения текста
                // Можно добавить дополнительную логику для расчета
                return 100; // Начальное значение, можно настроить
            }
            return 100; // значение по умолчанию
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
