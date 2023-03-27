using App.LogIn.LogInInterface;
using ModelClasses;

namespace App.LogIn
{
    public class AccountTrackerService : IAccountGetter, IAccountSetter
    {
        private static User _loggedAccount;

        public User GetLoggedAccount()
        {
            return _loggedAccount;
        }

        public void TrackLoggedAccount(User account)
        {
            _loggedAccount = account;
        }
    }
}