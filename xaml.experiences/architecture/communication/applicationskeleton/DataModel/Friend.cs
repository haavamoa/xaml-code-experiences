namespace eventbased.DataModel
{
    public class Friend
    {
        public Friend(string firstName, string lastName, string hairColor)
        {
            FirstName = firstName;
            LastName = lastName;
            HairColor = hairColor;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string HairColor { get; set; }
    }
}