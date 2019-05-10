using eventbased.FriendsList;
using eventbased.HairColorCounting;
using eventbased.Services;

namespace eventbased
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var mainViewModel = new MainViewModel(new FriendsViewModel(new FriendsService()), new HairCountingViewModel());

            DataContext = mainViewModel;

            Loaded += async (a, e) => await mainViewModel.Initialize();
        }
    }
}