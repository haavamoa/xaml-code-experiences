using dependencyinjection.ViewModels.DependencyInjection.Interfaces;

namespace dependencyinjection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(IFooViewModel fooViewModel)
        {
            InitializeComponent();

            DataContext = fooViewModel;
        }
    }
}