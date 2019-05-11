namespace applicationskeleton.DataModel
{
    public class Friend
    {
        public Friend(string firstName, string lastName, HairColor hairColor)
        {
            FirstName = firstName;
            LastName = lastName;
            HairColor = hairColor;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public HairColor HairColor { get; set; }
    }
}