using System.Collections.Generic;
using System.Linq;
using callbackbased.DataModel;
using callbackbased.FriendDetail;
using observingobjects;

namespace callbackbased.HairColorCounting
{
    public class HairCountingViewModel : BaseViewModel, IHairCountingViewModel
    {
        private int m_numberOfBlackHair;

        public int NumberOfBlackHair
        {
            get => m_numberOfBlackHair;
            set => SetProperty(ref m_numberOfBlackHair, value);
        }

        public void EvaluateFriendsWithBlackHair(List<FriendViewModel> friends)
        {
            NumberOfBlackHair = friends.Count(f => f.HairColor.Equals(new HairColor("Black")));
        }
    }
}