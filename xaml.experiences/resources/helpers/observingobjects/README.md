# Observing objects
In order for the view to get notified about changes to the view model, the view model should implement 
`INotifiedPropertyChanged`. In fact, if the view model does not implement this, it [could lead to memory leaks.](https://onewindowsdev.com/2016/09/22/a-memory-leak-may-occur-when-you-use-data-binding-in-windows-presentation-foundation/)

With a [``BaseViewModel``](BaseViewModel.cs) we can abstract this out and reuse it when creating new view models.

A typical case when dealing with notification is changing a property. With this base view model you could do the 
following:

```csharp
namespace observingobjects
{
    public class FooBarViewModel : BaseViewModel
    {
        private string m_bar;

        public string Bar
        {
            get => m_bar;
            set => SetProperty(ref m_bar, value);
        }

        public void Foo()
        {
            Bar = "New value";
        }
    }
}
```` 

Code explanation:
- We have created a field to store the value of ``Bar`` in.
- When we call ``Foo()`` we change the value of ``m_bar`` through ``Bar`` by calling ``SetProperty()``.
- ``SetProperty()`` is a method that comes from ``BaseViewModel`` and that does a equality comparing.
- If the value has been changed, it will notify property changed. That way, the UI will update its value.

> The code for ``FooBarViewModel`` can be found [here](FooBarViewModel.cs).

> The code for ``BaseViewModel`` can be found [here](BaseViewModel.cs)