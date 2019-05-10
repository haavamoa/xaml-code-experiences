namespace nonblockingui.ViewModels
{
    public class FriendViewModel
    {
        public FriendViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}