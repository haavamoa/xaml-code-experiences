using System.Collections.Generic;
using interfacebased.FriendDetail;

namespace interfacebased.HairColorCounting
{
    public interface IHairCountingViewModel
    {
        int NumberOfBlackHair { get; }

        void EvaluateFriendsWithBlackHair(List<FriendViewModel> friends);
    }
}