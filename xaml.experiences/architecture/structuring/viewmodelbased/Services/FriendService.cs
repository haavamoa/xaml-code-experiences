using System.Collections.Generic;
using System.Threading.Tasks;
using viewmodelbased.DataModels;

namespace viewmodelbased.Services
{
    internal class FriendService : IFriendService
    {
        public Task<List<Friend>> Get()
        {
            var friends = new List<Friend>()
            {
                new Friend("Tom"),
                new Friend("Henry"),
                new Friend("Kimberly"),
                new Friend("Sean"),
                new Friend("Sarah"),
                
            };
            return Task.FromResult(friends);
        }
    }
}