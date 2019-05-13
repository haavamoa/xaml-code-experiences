# Using Events to communicate
Events is a publisher-subscriber way of communicating. 
One view model has a event that another view model can subscribe to. When the first view model invoke the event, 
the second view model will run its code.

> Note: When dealing with events, one should always unsubscribe to the events. [Failing to do so can lead to memory 
leaks](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events#unsubscribing).

### The idea

[``MainViewModel``](MainViewModel.cs) is the glue between [``IFriendsViewModel``](FriendsList/IFriendsViewModel.cs) 
and [``IHairColorCountingViewModel``](HairColorCounting/IHairCountingViewModel.cs). So, each [``IFriendViewModel``](FriendDetail/IFriendViewModel.cs) 
has to tell ``MainViewModel`` that its hair color has changed, that way it can tell ``HairColorCountingViewModel`` to
 reevaluate.
 
## How did I implement it?
For each ``FriendViewModel`` I have added a [``HairColorChangedEvent``](FriendDetail/IFriendViewModel.cs). The event 
gets invoked in the ``HairColor`` setter (that will run each time the user chooses a hair color).

The [``MainViewModel``](MainViewModel.cs) assigns the event for each friend after it has retrieved all the friends. 
It assigns the event with the code that evaluates the hair color counter.
 
 ``MainVieWModel`` has also implemented ``IDisposable`` and a ``Dispose`` method. This method de-assigns the event for 
 each of the friends. ``Dispose`` will be called by [``MainWindow.xaml.cs``](MainWindow.xaml.cs) from a ``Closed`` 
 event assignment.
 
## Summary
Using events is a fairly straight forward way of implementing communication. Disposing the events are important, and 
this can be hard to remember when working with a large project.

One of the reasons why I really do not like event is that you get no ``references`` from code vision. This means it 
can be hard to follow the flow of events. One would need to search for the event in all of its code base in order to 
understand what gets called when.