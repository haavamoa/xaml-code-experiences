using dependencyinjection.ViewModels.DependencyInjection;
using dependencyinjection.ViewModels.DependencyInjection.Interfaces;
using LightInject;

namespace dependencyinjection
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IBarViewModel, BarViewModel>();
            serviceRegistry.Register<IFooViewModel, FooViewModel>();
            serviceRegistry.Register<MainWindow>();
        }
    }
}