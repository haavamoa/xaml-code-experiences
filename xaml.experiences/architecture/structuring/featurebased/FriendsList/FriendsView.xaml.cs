using System.Windows;
using System.Windows.Controls;
using featurebased.Services;

namespace featurebased.FriendsList
{
    public partial class FriendsView : UserControl
    {
        private FriendsViewModel m_friendsViewModel;

        public FriendsView()
        {
            InitializeComponent();
        }
    }
}