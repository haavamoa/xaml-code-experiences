using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace colortobrushconverter
{
    public class StringToSolidBrushConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentException("ColorToBrushConverter : Value can not be null");
            }
            
            try
            {
                var colorFromString = ColorConverter.ConvertFromString(value.ToString());
                if (colorFromString != null)
                {
                    if (colorFromString is Color)
                    {
                        return new SolidColorBrush(((Color)colorFromString));    
                    }
                }
            }
            catch (Exception e)
            {
                return new SolidColorBrush(Colors.Transparent);
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}