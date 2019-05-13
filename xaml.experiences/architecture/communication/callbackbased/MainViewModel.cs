using System;
using System.Linq;
using System.Threading.Tasks;
using callbackbased.FriendsList;
using callbackbased.HairColorCounting;

namespace callbackbased
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
                await FriendsViewModel.Initialize(EvaluateHairCounter);
                EvaluateHairCounter();
            }
            catch (Exception exception)
            {
                //Log it, fix it or show it
            }
        }

        private void EvaluateHairCounter()
        {
            HairCountingViewModel.EvaluateFriendsWithBlackHair(FriendsViewModel.Friends.ToList());
        }
    }
}