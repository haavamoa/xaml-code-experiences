using System;
using System.Linq;
using System.Threading.Tasks;
using interfacebased.FriendsList;
using interfacebased.HairColorCounting;

namespace interfacebased
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
                HairCountingViewModel.EvaluateFriendsWithBlackHair(FriendsViewModel.Friends.ToList());
            }
            catch (Exception exception)
            {
                //Log it, fix it or show it
            }
        }
    }
}