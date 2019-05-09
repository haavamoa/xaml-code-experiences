using System.Threading.Tasks;

namespace dependencyinjection.ViewModels.DependencyInjection.Interfaces
{
    public interface IFooViewModel
    {
        IBarViewModel BarViewModel { get; }
    }
}