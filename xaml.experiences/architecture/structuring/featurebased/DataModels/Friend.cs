namespace featurebased.DataModels
{
    internal class Friend
    {
        public Friend(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}