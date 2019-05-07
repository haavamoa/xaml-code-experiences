using System.Collections.Generic;
using System.Threading.Tasks;
using viewmodelbased.DataModels;

namespace viewmodelbased.Services
{
    internal interface IFriendService
    {
        Task<List<Friend>> Get();
    }
}