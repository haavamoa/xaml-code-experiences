using System;
using System.Threading.Tasks;
using eventbased.FriendsList;
using eventbased.HairColorCounting;

namespace eventbased
{
    public class MainViewModel
    {
        public MainViewModel(IFriendsViewModel friendsViewModel, IHairCountingViewModel hairCountingViewModel)
        {
            FriendsViewModel = friendsViewModel;
            HairCountingViewModel = hairCountingViewModel;
        }

        public IFriendsViewModel FriendsViewModel { get; }

        public IHairCountingViewModel HairCountingViewModel { get; }

        public async Task Initialize()
        {
            try
            {
                await FriendsViewModel.Initialize();
            }
            catch (Exception exception)
            {
                //Log it, fix it or show it
            }
        }
    }
}