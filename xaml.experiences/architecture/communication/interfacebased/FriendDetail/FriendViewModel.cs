using System.Collections.ObjectModel;
using interfacebased.DataModel;
using observingobjects;

namespace interfacebased.FriendDetail
{
    public class FriendViewModel : BaseViewModel, IFriendViewModel
    {
        private Friend m_friend;
        private IHandleFriendChanged m_friendChangedHandler;

        public FriendViewModel(Friend friend, IHandleFriendChanged friendChangedHandler)
        {
            m_friend = friend;
            m_friendChangedHandler = friendChangedHandler;
            AvailableColors = new ObservableCollection<HairColor>()
            {
                new HairColor("Black"),
                new HairColor("White"),
                new HairColor("Red"),
                new HairColor("Brown"),
                new HairColor("Green"),
                new HairColor("Pink"),
                new HairColor("Blue"),
                new HairColor("Yellow"),
            };
        }

        public string FirstName => m_friend.FirstName;
        public ObservableCollection<HairColor> AvailableColors { get; }

        public string LastName => m_friend.LastName;

        public HairColor HairColor
        {
            get => m_friend.HairColor;
            set
            {
                m_friend.HairColor = value;
                OnPropertyChanged();
                m_friendChangedHandler.OnFriendChanged();
            }
        }
    }
}