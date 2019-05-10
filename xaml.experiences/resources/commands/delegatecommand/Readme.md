# DelegateCommand
When dealing with the MVVM design pattern we should use ``Commands`` to trigger an ``Action`` when we press a 
``Button`` or any other control that has the ``Command`` property.

``Commands`` has to be implemented by implementing the interface ``ICommand``.

One implementation of an ``ICommand`` can be a [``DelegateCommand``](Resources/Commands/DelegateCommand.cs). The idea 
is that we have to provide it with an ``Action<object>``(``execute``) that should run when the Xaml ``control`` that 
uses it is triggering a pressed event and if the ``canExecute`` is fulfilled. 

If used with a button, the ``canExecute`` will update a buttons ``IsEnabled`` property when it returns true or false.
 
 Using the ``DelegateCommand`` in a view model can be found [here](ViewModels/MainViewModel.cs).
 
 Binding to it in Xaml can be found [here](MainWindow.xaml).