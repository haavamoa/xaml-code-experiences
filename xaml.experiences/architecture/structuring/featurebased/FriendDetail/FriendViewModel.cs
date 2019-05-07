using System.Collections.Generic;
using System.Threading;
using featurebased.DataModels;
using observingobjects;

namespace featurebased.FriendDetail
{
    internal class FriendViewModel : BaseViewModel
    {
        private readonly Friend m_friend;

        public FriendViewModel(Friend friend)
        {
            m_friend = friend;
        }
        

        public string FirstName
        {
            get => m_friend.FirstName;
            set
            {
                if(m_friend.FirstName.Equals(value))
                {
                    return;
                }
                
                m_friend.FirstName = value;
                OnPropertyChanged();
            } 
        }
        
        public string LastName
        {
            get => m_friend.LastName;
            set
            {
                if(m_friend.LastName.Equals(value))
                {
                    return;
                }
                
                m_friend.LastName = value;
                OnPropertyChanged();
            } 
        }

        
        public int Age
        {
            get => m_friend.Age;
            set
            {
                if(m_friend.Age.Equals(value))
                {
                    return;
                }
                
                m_friend.Age = value;
                OnPropertyChanged();
            } 
        }

    }
}