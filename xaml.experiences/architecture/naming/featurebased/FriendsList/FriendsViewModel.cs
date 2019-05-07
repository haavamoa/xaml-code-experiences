using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using featurebased.DataModels;
using featurebased.FriendDetail;
using featurebased.Services;
using observingobjects;

namespace featurebased.FriendsList
{
    internal class FriendsViewModel : BaseViewModel
    {
        private readonly IFriendService m_friendService;

        public FriendsViewModel(IFriendService friendService)
        {
            m_friendService = friendService;
            Friends = new List<FriendViewModel>();
        }

        public List<FriendViewModel> Friends { get; set; }

        private FriendViewModel m_selectedFriend;

        public FriendViewModel SelectedFriend
        {
            get => m_selectedFriend;
            set => SetProperty(ref m_selectedFriend, value);
        }

        public async Task Initialize()
        {
            var friends = await m_friendService.Get();
            friends.ForEach(f => Friends.Add(new FriendViewModel(f)));
        }
    }
}