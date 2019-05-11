# Using Events to communicate
Events is a pub-sub way of communicating. 
One view model has a event that another view model can subscribe to. When the first view model invoke the event, 
the second view model will run its code.

> Note: When dealing with events, one should always unsubscribe to the events. Failing to do so can lead to memory 
leaks. 

## How did I implement it?

Added event in friendviewmodel
invoke it in an appropriate place
subscribed to it in mainviewmodel
unsubscribe to it in mainviewmodel 
    added onexit in mainwindow.xaml.cs