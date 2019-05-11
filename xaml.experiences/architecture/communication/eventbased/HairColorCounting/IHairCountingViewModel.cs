using System.Collections.Generic;
using eventbased.FriendDetail;

namespace eventbased.HairColorCounting
{
    public interface IHairCountingViewModel
    {
        int NumberOfBlackHair { get; }

        void EvaluateFriendsWithBlackHair(List<IFriendViewModel> friends);
    }
}