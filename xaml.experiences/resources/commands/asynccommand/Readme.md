# AsyncCommand
When designing applications one have to have the ability to run asynchronously methods. Running a `Task` that saves 
the record in the database, or maybe validate your username when logging in to the application.

Running asynchronously can also lead to a more responsive UI, as you can show a busy message while you wait for a 
``Task`` to finish.

[This command](Resources/Commands/AsyncCommand.cs) can be implemented to set up a ``ICommand`` that you can bind in Xaml to a run a 
`Task`. The idea behind it is very much the same as the [``DelegateCommand``](../delegatecommand), except that this 
will require a ``Func<object, Task>`` to be execute. 

This will enable you to write beautiful [MVVM-Xaml](MainWindow.xaml), bound to [this](MainViewModel.cs).

