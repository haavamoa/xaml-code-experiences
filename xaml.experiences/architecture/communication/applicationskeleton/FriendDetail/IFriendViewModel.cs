using System.Collections.ObjectModel;
using applicationskeleton.DataModel;

namespace applicationskeleton.FriendDetail
{
    public interface IFriendViewModel
    {
        HairColor HairColor { get; set; }
        string LastName { get; }
        string FirstName { get; }
        ObservableCollection<HairColor> AvailableColors { get; }
    }
}