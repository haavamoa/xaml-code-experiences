using eventbased.DataModel;
using observingobjects;

namespace eventbased.FriendDetail
{
    public class FriendViewModel : BaseViewModel
    {
        private Friend m_friend;

        public FriendViewModel(Friend friend)
        {
            m_friend = friend;
        }


        public string FirstName => m_friend.FirstName;

        public string LastName => m_friend.LastName;


        public string HairColor
        {
            get => m_friend.HairColor;
            set
            {
                m_friend.HairColor = value;
                OnPropertyChanged();
            }
        }
    }
}