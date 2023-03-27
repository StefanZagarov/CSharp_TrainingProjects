namespace ModelClasses
{
    [System.Serializable]
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Town { get; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public string PhoneNumber { get; }


        public User(string firstName, string lastName, string country, string town, string username,
            string password, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Town = town;
            Username = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }        
    }
}