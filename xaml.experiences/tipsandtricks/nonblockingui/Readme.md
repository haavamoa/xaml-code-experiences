# Async loading data with non-blocking UI
When developing an application, you should aim for a non-blocking UI thread. Blocking the UI thread will lead to 
frustrated and disappointed users.

A clean way of running an asynchronously method that loads data when the application is starting is by subscribing to
 a view elements ``Loaded`` event and running an ``Task`` on the view model.

  
[Here](MainWindow.xaml.cs) is an example of a view that is finished loading and that is calling a ``Initialize`` method on the view 
model :

```c#
public partial class MainWindow
 {
     private MainViewModel m_mainViewModel;

     public MainWindow()
     {
         InitializeComponent();
         
         m_mainViewModel = new MainViewModel(new FriendService());
         
         DataContext = m_mainViewModel;
         
         //Loaded occurs when the element (MainWindow) is finished loaded (laid out and rendered) and ready for interaction.
         Loaded += async (a, e) => await m_mainViewModel.Initialize();
     }
 }
 
```

[``Initialize``](ViewModels/MainViewModel.cs) will do mark the view model as busy before it goes to a service and fetches friends 
(this service 
could be a REST service that would take some time). When fetching is completed it will mark the view model as non 
busy.
```c#
public async Task Initialize()
{
    IsBusy = true;
    var fetchedFriends = await m_friendService.Get();
    foreach (var fetchedFriend in fetchedFriends)
    {
        Friends.Add(new FriendViewModel(fetchedFriend.FirstName, fetchedFriend.LastName));
    }
    IsBusy = false;
}
```

Here is the result: (weird artifacts appeared)

![result]

[result]:gifs/nonblockingui.gif