using System.Collections.Generic;
using System.Linq;
using eventbased.DataModel;
using eventbased.FriendDetail;
using observingobjects;

namespace eventbased.HairColorCounting
{
    public class HairCountingViewModel : BaseViewModel, IHairCountingViewModel
    {
        private int m_numberOfBlackHair;

        public int NumberOfBlackHair
        {
            get => m_numberOfBlackHair;
            set => SetProperty(ref m_numberOfBlackHair, value);
        }

        public void EvaluateFriendsWithBlackHair(List<IFriendViewModel> friends)
        {
            NumberOfBlackHair = friends.Count(f => f.HairColor.Equals(new HairColor("Black")));
        }
    }
}