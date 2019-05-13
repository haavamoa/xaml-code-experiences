using System.Collections.Generic;
using System.Threading.Tasks;
using interfacebased.DataModel;

namespace interfacebased.Services
{
    public interface IFriendsService
    {
        Task<IEnumerable<Friend>> Get();
    }
}