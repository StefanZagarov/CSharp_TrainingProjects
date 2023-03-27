namespace SaveSystem.Interfaces
{
    public interface ISaver
    {
        public void SaveLogInSettings(string location, string saveContent);
        public void SaveAccount(string location, string fileName, string saveString);
        public void SaveFields(string username, string password, bool rememberMeToggle, string location);
    }
}