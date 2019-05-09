# Null to Visibility converter
[A simple converter](NullToVisibilityConverter.cs) that takes an ``object`` and checks if it is ``null``. If it is ``null`` it will return 
``Visibility
.Visible``, else return `Visibility.Collapsed`. This can be inverted by setting the `Inverted` property.


[This is used in my Dependency Injection project.](../../../architecture/designpatterns/dependencyinjection/MainWindow.xaml)