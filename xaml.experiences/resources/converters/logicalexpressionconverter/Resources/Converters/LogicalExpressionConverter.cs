using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace logicalexpressionconverter.Resources.Converters
{
    /// <summary>
    /// A converter to run a logical gate on multiple boolean values <see cref="LogicalGate"/>.
    /// Return value can be set by using <see cref="ReturnType"/>
    /// </summary>
    public class LogicalExpressionConverter : MarkupExtension, IMultiValueConverter
    {
        public LogicalGate LogicalGate { get; set; }

        public ReturnType ReturnType { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                switch (ReturnType)
                {
                    case ReturnType.Visibility:
                        return Visibility.Collapsed;
                    case ReturnType.Boolean:
                        return false;
                    case ReturnType.Undefined:
                        return Visibility.Collapsed;
                }
            }

            foreach (var value in values)
            {
                if(value == DependencyProperty.UnsetValue || value == null)
                {
                    switch (ReturnType)
                    {
                        case ReturnType.Visibility:
                            return Visibility.Collapsed;
                        case ReturnType.Boolean:
                            return false;
                        case ReturnType.Undefined:
                            return Visibility.Collapsed;
                    }
                }
            }

            try
            {
                List<bool> bools = values.Cast<bool>().ToList();

                bool logcalExpression = false;
                switch (LogicalGate)
                {
                    case LogicalGate.Undefined:
                        throw new ArgumentException($"LogicalConverter undefined property: {nameof(LogicalGate)}");
                    case LogicalGate.And:
                        logcalExpression = bools.All(b => b);
                        break;
                    case LogicalGate.Nand:
                        logcalExpression = bools.All(b => !b);
                        break;
                    case LogicalGate.Or:
                        logcalExpression = bools.Any(b => b);
                        break;
                    case LogicalGate.Nor:
                        logcalExpression = bools.Any(b => !b);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                switch (ReturnType)
                {
                    case ReturnType.Boolean:
                        return logcalExpression;
                    case ReturnType.Visibility:
                        return logcalExpression ? Visibility.Visible : Visibility.Collapsed;
                    case ReturnType.Undefined:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                throw new Exception("LogicalExpressionConverter : Something went wrong while converting:", e);
            }
            return null;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("EmbeddedBrowser : LogicalExpressionConverter does not support convert back");
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}