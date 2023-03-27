namespace ModelClasses
{
    [System.Serializable]
    public class RememberMeSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public RememberMeSettings(string name, string password, bool rememberMe)
        {
            Username = name;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}