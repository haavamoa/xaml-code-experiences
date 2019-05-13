using System.Collections.Generic;
using System.Threading.Tasks;
using callbackbased.DataModel;

namespace callbackbased.Services
{
    public interface IFriendsService
    {
        Task<IEnumerable<Friend>> Get();
    }
}