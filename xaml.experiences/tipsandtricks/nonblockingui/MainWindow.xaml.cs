using nonblockingui.Services;
using nonblockingui.ViewModels;

namespace nonblockingui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
}