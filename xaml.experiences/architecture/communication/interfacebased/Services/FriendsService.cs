using System.Collections.Generic;
using System.Threading.Tasks;
using interfacebased.DataModel;

namespace interfacebased.Services
{
    public class FriendsService : IFriendsService
    {
        public async Task<IEnumerable<Friend>> Get()
        {
            await Task.Delay(1000);
            return new List<Friend>()
            {
                new Friend("John", "Collarado", new HairColor("Green")),
                new Friend("Sarah", "Parker", new HairColor("Black")),
                new Friend("Travis", "McConnelly", new HairColor("Red")),
                new Friend("Paul", "Sighton", new HairColor("Black")),
                new Friend("Carl", "Pilktington", new HairColor("Red"))
            };
        }
    }
}