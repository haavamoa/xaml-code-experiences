using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eventbased.FriendDetail;

namespace eventbased.FriendsList
{
    public interface IFriendsViewModel
    {
        Task Initialize();
        ObservableCollection<FriendViewModel> Friends { get; }
    }
}