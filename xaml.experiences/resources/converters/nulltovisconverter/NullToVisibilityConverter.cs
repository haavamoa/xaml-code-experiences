using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace nulltovisconverter
{
    public class NullToVisibilityConverter : MarkupExtension, IValueConverter
    {

        public bool Inverted { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null ? (!Inverted) ? Visibility.Visible : Visibility.Collapsed : (!Inverted) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}