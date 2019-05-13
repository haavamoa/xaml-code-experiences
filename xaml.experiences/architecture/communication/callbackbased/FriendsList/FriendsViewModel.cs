using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using callbackbased.FriendDetail;
using callbackbased.Services;
using observingobjects;

namespace callbackbased.FriendsList
{
    public class FriendsViewModel : BaseViewModel, IFriendsViewModel
    {
        private readonly IFriendsService m_friendsService;

        private bool m_isBusy;
        private FriendViewModel m_selectedFriend;

        public FriendsViewModel(IFriendsService friendsService)
        {
            m_friendsService = friendsService;
            Friends = new ObservableCollection<FriendViewModel>();
        }

        public async Task Initialize(Action onFriendChanged)
        {
            try
            {
                IsBusy = true;
                var friendsFetched = await m_friendsService.Get();
                foreach (var friend in friendsFetched)
                {
                    Friends.Add(new FriendViewModel(friend, onFriendChanged));
                }
            }
            catch (Exception exception)
            {
                //Log it, fix it or show it
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ObservableCollection<FriendViewModel> Friends { get; }

        public FriendViewModel SelectedFriend
        {
            get => m_selectedFriend;
            set => SetProperty(ref m_selectedFriend, value);
        }

        public bool IsBusy
        {
            get => m_isBusy;
            set => SetProperty(ref m_isBusy, value);
        }
    }
}