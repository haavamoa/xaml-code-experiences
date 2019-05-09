using dependencyinjection.ViewModels.DependencyInjection.Interfaces;
using observingobjects;

namespace dependencyinjection.ViewModels.NoDependencyInjection
{
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
}