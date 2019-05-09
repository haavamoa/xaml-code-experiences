using System.Threading.Tasks;
using dependencyinjection.ViewModels.DependencyInjection.Interfaces;
using observingobjects;

namespace dependencyinjection.ViewModels.DependencyInjection
{
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
}