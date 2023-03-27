using ModelClasses;

namespace App.RegisterInterface
{
    public interface IRegisterValidator
    {
        public bool HasEmptyField();
        public bool HasPasswordMismatch(string confirmPassword, string password);
        public bool UsernameExists(string username);
        public bool EmailExists(string email);
        public void SendAccountInfo(User user);
    }
}