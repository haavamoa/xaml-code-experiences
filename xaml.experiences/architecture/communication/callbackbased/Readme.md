# Callback based communication
This way of communicating is very similar to [interface based](../interfacebased). Instead of passing a interface, it
 will pass ``Action``s. The ``Actions`` can then be invoked in the appropriate places
 
 ### The idea
 
 [``MainViewModel``](MainViewModel.cs) is the glue between [``IFriendsViewModel``](FriendsList/IFriendsViewModel.cs) 
 and [``IHairColorCountingViewModel``](HairColorCounting/IHairCountingViewModel.cs). So, each [``IFriendViewModel``](FriendDetail/IFriendViewModel.cs) 
 has to tell ``MainViewModel`` that its hair color has changed, that way it can tell ``HairColorCountingViewModel`` to
  reevaluate.
  
  ``MainViewModel`` should pass an ``Action`` to ``FriendsViewModel``, which then passes that ``Action`` for each 
  ``FriendViewModel``. The ``FriendViewModel`` should invoke the action when changing it's hair color.
  
  ### How did I implemented it?
  
  Expanded the ``constructor`` of ``FriendViewModel`` with ``Action OnFriendChanged``. Saves the action in a backing 
    field (``m_onFriendChanged``).
  
  ``FriendViewModel`` invokes ``m_onFriendChanged`` in ``HairColor`` setter.
    
  Expanded ``FriendsViewModel.Initialize`` with an ``Action OnFriendChanged``.
  
  ``MainViewModel`` sends ``EvaluateHairColor`` to ``FriendsViewModel.Initialize``.
  
  ``FriendsViewModel`` sends ``OnFriendChanged`` to each ``FriendViewModel`` ``constructor``.
  
  ### Summary
  This pattern is very similar to [ìnterface based](../interfacebased), and is probably more suitable for smaller 
  projects with not that much communication. But this can be troublesome when dealing with loads of communication.
  I believe that having ``interface``s that can be expanded is better than having to send many actions back and forth.
  It is also not strongly typed, so you could be facing bugs where you send the wrong action down the line. This can 
  be fixed with using an ``Action<MyArgumentClass``, that way you are strongly typed.