using System;
using System.Linq;
using System.Threading.Tasks;
using applicationskeleton.FriendsList;
using applicationskeleton.HairColorCounting;

namespace applicationskeleton
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