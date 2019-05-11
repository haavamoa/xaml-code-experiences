using System.Collections.Generic;
using applicationskeleton.DataModel;
using applicationskeleton.FriendDetail;

namespace applicationskeleton.HairColorCounting
{
    public interface IHairCountingViewModel
    {
        int NumberOfBlackHair { get; }

        void EvaluateFriendsWithBlackHair(List<FriendViewModel> friends);
    }
}