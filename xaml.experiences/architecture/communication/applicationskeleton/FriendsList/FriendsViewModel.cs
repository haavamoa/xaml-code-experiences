using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eventbased.FriendDetail;
using eventbased.Services;

namespace eventbased.FriendsList
{
    public class FriendsViewModel : IFriendsViewModel
    {
        private readonly IFriendsService m_friendsService;

        public FriendsViewModel(IFriendsService friendsService)
        {
            m_friendsService = friendsService;
            Friends = new ObservableCollection<FriendViewModel>();
        }

        public async Task Initialize()
        {
            try
            {
                var friendsFetched = await m_friendsService.Get();
                foreach (var friend in friendsFetched)
                {
                    Friends.Add(new FriendViewModel(friend));
                }
            }
            catch (Exception exception)
            {
                //Log it, fix it or show it
            }
        }

        public ObservableCollection<FriendViewModel> Friends { get; }
    }
}