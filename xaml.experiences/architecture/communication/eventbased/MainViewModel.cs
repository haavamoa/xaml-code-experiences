using System;
using System.Linq;
using System.Threading.Tasks;
using eventbased.FriendDetail;
using eventbased.FriendsList;
using eventbased.HairColorCounting;

namespace eventbased
{
    public class MainViewModel : IDisposable
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
                EvaluateHairColorCount();
                SubscribeToEvents();
            }
            catch (Exception exception)
            {
                //Log it, fix it or show it
            }
        }

        private void EvaluateHairColorCount()
        {
            HairCountingViewModel.EvaluateFriendsWithBlackHair(FriendsViewModel.Friends.ToList());
        }

        private void SubscribeToEvents()
        {
            foreach (var friendViewModel in FriendsViewModel.Friends)
            {
                friendViewModel.FriendChangedEvent += (a,e) =>  EvaluateHairColorCount();
            }
        }

        public void Dispose()
        {
            foreach (var friendViewModel in FriendsViewModel.Friends)
            {
                friendViewModel.FriendChangedEvent -= (a,e) => EvaluateHairColorCount();
            }
        }
    }
}