using System.Collections.Generic;
using System.Threading.Tasks;
using featurebased.DataModels;

namespace featurebased.Services
{
    internal interface IFriendService
    {
        Task<List<Friend>> Get();
    }
}