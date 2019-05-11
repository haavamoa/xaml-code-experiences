using System;
using System.Collections.ObjectModel;
using eventbased.DataModel;

namespace eventbased.FriendDetail
{
    public interface IFriendViewModel
    {
        HairColor HairColor { get; set; }
        string LastName { get; }
        string FirstName { get; }
        ObservableCollection<HairColor> AvailableColors { get; }
        event EventHandler FriendChangedEvent;
    }
}