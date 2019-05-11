using System.Collections.Generic;
using System.Threading.Tasks;
using applicationskeleton.DataModel;

namespace applicationskeleton.Services
{
    public interface IFriendsService
    {
        Task<IEnumerable<Friend>> Get();
    }
}