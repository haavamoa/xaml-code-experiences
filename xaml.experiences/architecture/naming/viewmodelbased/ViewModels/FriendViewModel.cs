using viewmodelbased.DataModels;

namespace viewmodelbased.ViewModels
{
    internal class FriendViewModel
    {
        private Friend m_friend;

        public FriendViewModel(Friend friend)
        {
            m_friend = friend;
        }

        public string Name => m_friend.Name;
    }
}