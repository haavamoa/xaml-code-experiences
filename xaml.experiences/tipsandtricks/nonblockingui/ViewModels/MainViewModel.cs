using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using nonblockingui.Services;
using observingobjects;

namespace nonblockingui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IFriendService m_friendService;

        public MainViewModel(IFriendService friendService)
        {
            m_friendService = friendService;
            Friends = new ObservableCollection<FriendViewModel>();
        }

        public ObservableCollection<FriendViewModel> Friends { get; private set; }
        
        private bool m_isBusy;

        public bool IsBusy
        {
            get => m_isBusy;
            set => SetProperty(ref m_isBusy, value);
        }

        public async Task Initialize()
        {
            try
            {
                IsBusy = true;
                var fetchedFriends = await m_friendService.Get();
                foreach (var fetchedFriend in fetchedFriends)
                {
                    Friends.Add(new FriendViewModel(fetchedFriend.FirstName, fetchedFriend.LastName));
                }
                IsBusy = false;
            }
            catch (Exception e)
            {
                //Try to resolve the issue and fix it, log it and/or show it.
            }
        }
    }
}