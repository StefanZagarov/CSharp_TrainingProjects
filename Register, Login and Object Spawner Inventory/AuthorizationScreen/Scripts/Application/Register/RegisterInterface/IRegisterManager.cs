using ModelClasses;
using System.Collections.Generic;

namespace App.RegisterInterface
{
    public interface IRegisterManager
    {
        public List<string> GetAllAccounts();
        public void SaveAccountInfo(User user);
    }
}