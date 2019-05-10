# Dependency Injection (DI)
The actual design pattern is called ``Inversion of Control (IOC)`` and can be implemented in different ways (events, 
delegate etc.). ``DI`` is a implementation of `IOC` and is working by constructor injection, property injection or method injection.

### But what is injecting dependencies?
The main goal of ``IOC`` and `DI` is to remove dependencies of classes, this makes the code decoupled and much more maintainable. 

Rather than hard code your dependencies directly in the class [like this](ViewModels/NoDependencyInjection/FooViewModel.cs):

```c#
 public class FooViewModel : BaseViewModel
    {
        private BarViewModel m_barViewModel;

        public FooViewModel()
        {
            BarViewModel = new BarViewModel();
        }
        
        public BarViewModel BarViewModel    
        {
            get => m_barViewModel;
            private set => SetProperty(ref m_barViewModel, value);
        }
    }
```

One could let someone else `inject` the dependency into the class by its constructor, [like this](ViewModels/DependencyInjection/FooViewModel.cs):

````c#
public class FooViewModel : BaseViewModel, IFooViewModel
    {

        public FooViewModel(IBarViewModel barViewModel)
        {
            BarViewModel = barViewModel;
        }

        private IBarViewModel m_barViewModel;

        public IBarViewModel BarViewModel
        {
            get => m_barViewModel;
            private set => SetProperty(ref m_barViewModel, value);
        }
    }
````

The biggest change here is that we have created a abstraction for `BarViewModel` by adding a interface called 
[`IBarViewModel`](ViewModels/DependencyInjection/Interfaces/IBarViewModel.cs).

### But what do we achieve?
First of all, working with abstractions rather than implementations is a winning strategy. 

You have a application where the user should choose what kind of persistence (Database, local JSON file, In memory) it 
would like to use. You could create some kind of configuration that the user can fiddle with, and you could design your 
application to read the configuration and inject the correct type of implementation down your application. You would
only need to create a interface called `IPersistence` or more popular: `IRepository`. Now you have to create a 
class pr persistence choice and implement that interface.

This kind of architecture leads to loosely coupled code, that can in fact be much easier to test.

My rule of thumb is; whenever I `new` something up I ask myself if I can create a abstraction and pass it into the constructor instead. Because I know that this will serve much better when I move onto testing. 

In most cases I rarely switch implementations of a abstraction. But in the rare cases where I have to, I thank myself that I chose this approach.
 
 ### How do we inject?
By using a `DI` container. [And there is loads of them!](https://www.hanselman.com/blog/ListOfNETDependencyInjectionContainersIOC.aspx). 

Now, for this project I have chosen [LightInject](https://www.lightinject.net/). This is because this is the one I am
 most familiar with.
 
#### How to use `LightInject` in Wpf :
 * Added `IFooViewModel` to the constructor of `MainWindow` and set the `DataContext` to the instance of  `IFooViewModel`.
 * Removed `StartupUrl="MainWindow.xaml` from [`App.xaml`](App.xaml).
 * Override `void OnStartup(StartupEventArgs e)` in [`App.xaml.cs`](App.xaml.cs) with the following:
   * Calling `base.OnStartup(e)` because we have to. 
   * Creates a new `LightInject` container, and turns of property injection (because this can be troublesome when working with Wpf). 
   * Register a `CompositionRoot` in the container, this class is where I set up the dependencies for the project. 
   * Next I resolve `MainWindow` from the container and run `Show()`. 
   * Resolving means that it has used the container to fetch a `MainWindow` instance with its dependenciesinjected into it.
 ```c#
 protected override void OnStartup(StartupEventArgs e)
         {
             base.OnStartup(e);
             var container = new ServiceContainer(new ContainerOptions { EnablePropertyInjection = false });
             container.RegisterFrom<CompositionRoot>();
             container.GetInstance<MainWindow>().Show();
         }
 ```
 
* Create [`CompositionRoot`](CompositionRoot.cs) that implements `ICompositionRoot` from `LightInject`:
  * Register ``IFooViewModel``, ``IBarViewModel``, and `MainWindow`. The flow of the dependencies is: 
``MainWindow`` wants `IFooViewModel` that wants `IBarViewModel`.
```c#
public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IBarViewModel, BarViewModel>();
            serviceRegistry.Register<IFooViewModel, FooViewModel>();
            serviceRegistry.Register<MainWindow>();
        }
```
So when resolving `MainWindow` , it will resolve a `IFooViewModel` that will inject a `IBarViewModel` into 
`FooViewModel` and inject that `FooViewModel` into `MainWindow`.



> [I have created a skeleton for using LightInject with WPF.](https://github.com/haavamoa/LightInject.WPF.Skeleton)

### Tests:
The benefit of using ``DI`` is that you can test your classes in total isolation. What this means is that you can test only your class and verify that it uses its dependencies, without going into much details about your dependencies.
You can also use frameworks like ``Moq`` to create mocks / stubs for your dependencies.

I have used ``Moq`` because this is what I am familiar with. 

I wont go into much details about test driven development, but I have added a [`FooViewModelTests`](Tests/FooViewModelTests.cs) class.
This test class is using DI to its favor by creating a mock / stubbed version of `IBarViewModel`. That way I can test `FooViewModel` in total isolation. With Moq it can verify that methods on `IBarViewModel` has been invoked and setup what methods or properties `IBarViewModel` should return.
 
 
 
  
