using System.Windows;
using featurebased.FriendsList;
using featurebased.Services;

namespace featurebased
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {
        private FriendsViewModel m_friendsViewModel;

        public MainView()
        {
            InitializeComponent();  
            
            //Poor mans dependency injection
            m_friendsViewModel = new FriendsViewModel(new FriendService());
            DataContext = new MainViewModel(m_friendsViewModel);
            

            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            await m_friendsViewModel.Initialize();
        }
    }
}