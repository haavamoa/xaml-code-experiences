using System.Collections.ObjectModel;
using System.Threading.Tasks;
using applicationskeleton.FriendDetail;

namespace applicationskeleton.FriendsList
{
    public interface IFriendsViewModel
    {
        ObservableCollection<FriendViewModel> Friends { get; }
        FriendViewModel SelectedFriend { get; set; }
        bool IsBusy { get; }
        Task Initialize();
    }
}