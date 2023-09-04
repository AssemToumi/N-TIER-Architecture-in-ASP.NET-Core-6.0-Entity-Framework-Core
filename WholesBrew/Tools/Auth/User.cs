namespace Helper
{
    public class User
    {
        private readonly string _firstName;

        private readonly string _lastName;

        private readonly string _displayName;

        public string FirstName => _firstName;

        public string LastName => _lastName;

        public string DisplayName => _displayName;

        public User(string firstName, string lastName, string displayName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _displayName = displayName;
        }
    }
}
