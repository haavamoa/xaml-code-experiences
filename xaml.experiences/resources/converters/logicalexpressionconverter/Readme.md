# Logical Expression Converter
A multi value converter that takes ``boolean`` inputs and can return either a ``boolean`` or ``Visibility`` output based on 
on a desired [logical gate](Resources/Converters/LogicalGate.cs).
 
 This can be used when dealing with multiple 
properties that are used in a ``<MultiBinding>``, and you need to be able to do some logic on the properties and 
return a desired [return type](Resources/Converters/ReturnType.cs).

[The converter](Resources/Converters/LogicalExpressionConverter.cs) is used in [MainWindow, line 37-40](MainWindow.xaml). 