using featurebased.FriendsList;
using featurebased.Services;

namespace featurebased
{
    internal class MainViewModel
    {
        public MainViewModel(FriendsViewModel friendsViewModel)
        {
            FriendsViewModel = friendsViewModel;
        }

        public FriendsViewModel FriendsViewModel { get; set; }
    }
}