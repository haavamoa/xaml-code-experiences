using logicalexpressionconverter.ViewModels;

namespace logicalexpressionconverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = new MainViewModel();
        }
    }
}