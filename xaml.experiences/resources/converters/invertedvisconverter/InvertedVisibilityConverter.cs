using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace invertedvisconverter
{
    public class InvertedVisibilityConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public bool ShouldBeHidden { get; set; }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentException("InvertedVisibilityConverter, value is null");
            }

            if (!((value is Visibility)))
            {
                throw new ArgumentException($"InvertedVisibilityConverter is expecting a Visibility value, current value was :{((Type)value)}");
            }

            var visValue = (Visibility)value;
            if (visValue == Visibility.Visible)
            {
                return ShouldBeHidden ? Visibility.Hidden : Visibility.Collapsed;
            }
            else if (visValue == Visibility.Collapsed || visValue == Visibility.Hidden)
            {
                return Visibility.Visible;
            }

            throw new Exception("InvertedVisibilityConverter : Something went wrong w");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}