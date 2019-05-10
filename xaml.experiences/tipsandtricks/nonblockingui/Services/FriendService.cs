using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using nonblockingui.DataModels;

namespace nonblockingui.Services
{
    public class FriendService : IFriendService
    {
        public async Task<IEnumerable<Friend>> Get()
        {
            var friends = new List<Friend>()
            {
                new Friend("Todd", "Deney"),
                new Friend("Magnus", "Carlsen"),
                new Friend("Sean", "Austin")
            };
            await Task.Delay(6000);
            return friends;
        }
    }

    public interface IFriendService
    {
        Task<IEnumerable<Friend>> Get();
    }
}