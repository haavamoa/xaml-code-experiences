using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace markupextension.Resources.Converters
{
    public class BoolToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this; 
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Checks both if the value is null or if the converter somehow gets used ahead of time
            if (value == null || value == DependencyProperty.UnsetValue)
            {
                return false;
            }
            
            //Could not parse incoming value
            if (!bool.TryParse(value.ToString(), out var parsedResult)) return false;
            
            if (parsedResult)
            {
                return !Inverted ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return !Inverted ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public bool Inverted { get; set; }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}