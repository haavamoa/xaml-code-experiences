# Interface based communication
The name of this way of communicating is in lack of a better name. The idea with this kind of architecture is to pass
 ``interfaces`` around, and to invoke methods or whatever is suitable in the appropriate places. This is one of the 
 methods that I have been using more and more lately.
 
 ### The idea
 
 [``MainViewModel``](MainViewModel.cs) is the glue between [``IFriendsViewModel``](FriendsList/IFriendsViewModel.cs) and [``IHairColorCountingViewModel``](HairColorCounting/IHairCountingViewModel.cs). So, each [``IFriendViewModel``](FriendDetail/IFriendViewModel.cs) 
 has to tell ``MainViewModel`` that its hair color has changed, that way it can tell ``HairColorCountingViewModel`` to
  reevaluate.
  
  ``MainViewModel`` should implement an ``interface`` that is passed down to ``FriendsViewModel``, that will pass it to 
  each ``FriendViewModel``. That way, each ``FriendViewModel`` can tell ``MainViewModel`` that it should reevaluate.
  
 
 ## How did I implement it?
 
 Created an ``interface`` called [``IHandleFriendChanged``](IHandleFriendChanged.cs) and created a `void 
 OnFriendChanged` in the ``interface``.
 
 Implemented ``IHandleFriendChanged`` in [``MainViewModel``](MainViewModel.cs). ``OnFriendChanged`` is now 
 running ``HairCountingViewModel.EvaluateFriendsWithBlackHair``.
 
 Expanded ``Initialize`` with ``IHandleFriendChanged`` argument.
 
 Passed the ``instance`` of ``MainViewModel`` to [``FriendsViewModel.Initialize``](FriendsList/FriendsViewModel.cs).
 
 Expanded ``constructor`` of [``FriendViewModel``](FriendDetail/FriendViewModel.cs) with ``IHandleFriendChanged``.
 
Send ``IHandleFriendChanged`` in ``FriendsViewModel.Initialize`` to each ``FriendViewModel.Initialize``.
 
Saved ``IHandleFriendChanged`` to a backing store in ``FriendViewModel``.

Run ``OnFriendChanged`` in ``HairColor`` setter. 

## Summary
I like this way of communication much better than [event based communication](../eventbased). It is much easier to 
follow now, as we can get a sense of who is implementing it, who is  referring the ``interface`` and where it is 
running the different methods that the ``interface`` has. It also feels like we have some more flexibility as we can 
very easily send arguments, without any overhead like when we are dealing with events.

 
