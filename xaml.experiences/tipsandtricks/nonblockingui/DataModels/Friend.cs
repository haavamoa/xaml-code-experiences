namespace nonblockingui.DataModels
{
    public class Friend
    {
        public Friend(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}