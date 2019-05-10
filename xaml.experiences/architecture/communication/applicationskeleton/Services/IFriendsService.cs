using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using eventbased.DataModel;

namespace eventbased.Services
{
    public interface IFriendsService
    {
        Task<IEnumerable<Friend>> Get();
    }
}