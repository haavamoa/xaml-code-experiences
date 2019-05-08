# Using `MarkupExtensions` in a converter
This approach will give you the opportunity to use your converter in a one-liner in Xaml.
It will also make it possible to work with `properties` in your converter. 

Example of a converter that is using ``MarkupExtensions`` : 
````c#
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
````

Code explanation:

This is a fairly normal converter to use when you are creating a Xaml based app. The converter takes a ``boolean`` 
value as input and returns a ``Visibility`` value based on the ``boolean`` value.
This converter is used in [MainWindow.xaml](MainWindow.xaml) in order for it to determine when it should show its 
``<TextBlock>``'s.
 
Now, how can I reference this converter without having to add it as a  ```<Window.Resource>```([MainWindow, line 15-17](MainWindow.xaml)) with a 
``x:Key``. 

The magic here is that the converter is inheriting from [``MarkupExtensions``](https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/markup-extensions-and-wpf-xaml).
This class requires you to provide a value, which is the value that should be returned to the element that requires 
the markup extension. In this case, [MainWindow.xaml](MainWindow.xaml) line 34.

This also gives me the opportunity to set ``properties`` when using the converter. In this case I have set the 
``Inverted`` property to make the converter invert the output.  