using System.Collections.Generic;
using System.Threading.Tasks;
using eventbased.DataModel;

namespace eventbased.Services
{
    public class FriendsService : IFriendsService
    {
        public async Task<IEnumerable<Friend>> Get()
        {
            await Task.Delay(1000);
            return new List<Friend>()
            {
                new Friend("John", "Collarado", "Blonde"),
                new Friend("Sarah", "Parker", "Black"),
                new Friend("Travis", "McConnelly", "Red"),
                new Friend("Paul", "Sighton", "Black"),
                new Friend("Carl", "Pilktington", "Red")
            };
        }
    }
}