namespace App.LogInInterface
{
    public interface IRememberMeManager
    {
        void SaveLogInInfo(bool toggle, string username, string password);
        bool GetRememberedUser();
        string GetUsername();
        public string GetPassword();
        public bool GetToggle();
        public string GetSaveLocation();
    }
}