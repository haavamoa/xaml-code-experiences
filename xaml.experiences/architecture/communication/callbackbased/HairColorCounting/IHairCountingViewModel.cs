using System.Collections.Generic;
using callbackbased.FriendDetail;

namespace callbackbased.HairColorCounting
{
    public interface IHairCountingViewModel
    {
        int NumberOfBlackHair { get; }

        void EvaluateFriendsWithBlackHair(List<FriendViewModel> friends);
    }
}