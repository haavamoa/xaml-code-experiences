using applicationskeleton.FriendsList;
using applicationskeleton.HairColorCounting;
using applicationskeleton.Services;

namespace applicationskeleton
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
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