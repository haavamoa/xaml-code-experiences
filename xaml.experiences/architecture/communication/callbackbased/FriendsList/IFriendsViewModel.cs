using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using callbackbased.FriendDetail;

namespace callbackbased.FriendsList
{
    public interface IFriendsViewModel
    {
        ObservableCollection<FriendViewModel> Friends { get; }
        FriendViewModel SelectedFriend { get; set; }
        bool IsBusy { get; }
        Task Initialize(Action onFriendChanged);
    }
}