using System;
using System.Linq;
using System.Threading.Tasks;
using interfacebased.FriendsList;
using interfacebased.HairColorCounting;

namespace interfacebased
{
    public class MainViewModel : IHandleFriendChanged
    {
        public MainViewModel(IFriendsViewModel friendsViewModel, IHairCountingViewModel hairCountingViewModel)
        {
            FriendsViewModel = friendsViewModel;
            HairCountingViewModel = hairCountingViewModel;
        }

        public IFriendsViewModel FriendsViewModel { get; }

        public IHairCountingViewModel HairCountingViewModel { get; }

        public void OnFriendChanged() => ReevaluateHairCount();

        public async Task Initialize()
        {
            try
            {
                await FriendsViewModel.Initialize(this);
                ReevaluateHairCount();
            }
            catch (Exception exception)
            {
                //Log it, fix it or show it
            }
        }

        private void ReevaluateHairCount()
        {
            HairCountingViewModel.EvaluateFriendsWithBlackHair(FriendsViewModel.Friends.ToList());
        }
    }
}