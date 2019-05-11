using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eventbased.FriendDetail;

namespace eventbased.FriendsList
{
    public interface IFriendsViewModel
    {
        ObservableCollection<IFriendViewModel> Friends { get; }
        FriendViewModel SelectedFriend { get; set; }
        bool IsBusy { get; }
        Task Initialize();
    }
}