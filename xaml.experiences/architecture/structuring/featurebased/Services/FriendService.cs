using System.Collections.Generic;
using System.Threading.Tasks;
using featurebased.DataModels;

namespace featurebased.Services
{
    internal class FriendService : IFriendService
    {
        public Task<List<Friend>> Get()
        {
            var friends = new List<Friend>()
            {
                new Friend("Tom", "Hagen", 23),
                new Friend("Henry", "McFlow", 52),
                new Friend("Kimberly", "Dane", 39),
                new Friend("Sean", "Austin",19),
                new Friend("Sarah", "Parker", 33),
                
            };
            return Task.FromResult(friends);
        }
    }
}