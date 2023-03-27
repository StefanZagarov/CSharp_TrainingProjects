using System.Collections.Generic;

namespace SaveSystem.Interfaces
{
    public interface ILoader
    {
        public string LoadRememberMeSettings(string location);
        public List<string> LoadAllAccounts(string location);
    }
}