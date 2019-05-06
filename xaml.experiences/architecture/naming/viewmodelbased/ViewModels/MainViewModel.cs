using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using observingobjects;
using viewmodelbased.Models;
using viewmodelbased.Services;

namespace viewmodelbased.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private List<FriendViewModel> m_friends;
        private IFriendService m_friendService;

        public MainViewModel(IFriendService friendService)
        {
            m_friendService = friendService;
        }

        public List<FriendViewModel> Friends
        {
            get => m_friends;
            set => SetProperty(ref m_friends, value);
        }

        public async Task Initialize()
        {
            var friends = await m_friendService.Get();
            
            var friendsViewModels = new List<FriendViewModel>();
            
            foreach (var friend in friends)
            {
                friendsViewModels.Add(new FriendViewModel(friend));
            }

            Friends = friendsViewModels;
        }
    }
}