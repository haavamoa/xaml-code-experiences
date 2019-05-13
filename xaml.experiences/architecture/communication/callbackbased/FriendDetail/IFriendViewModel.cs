using System.Collections.ObjectModel;
using callbackbased.DataModel;

namespace callbackbased.FriendDetail
{
    public interface IFriendViewModel
    {
        HairColor HairColor { get; set; }
        string LastName { get; }
        string FirstName { get; }
        ObservableCollection<HairColor> AvailableColors { get; }
    }
}