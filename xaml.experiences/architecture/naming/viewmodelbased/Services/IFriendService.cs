using System.Collections.Generic;
using System.Threading.Tasks;
using viewmodelbased.Models;

namespace viewmodelbased.Services
{
    public interface IFriendService
    {
        Task<List<Friend>> Get();
    }
}