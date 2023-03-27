using System.IO;
using ModelClasses;
using Newtonsoft.Json;
using SaveSystem.Interfaces;

namespace SaveSystem
{
    public class Saver : ISaver
    {
        public void SaveLogInSettings(string location, string saveContent)
        {
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            File.WriteAllText(location + "LogInSettings.json", saveContent);
        }

        public void SaveAccount(string location, string fileName, string saveString)
        {
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            File.WriteAllText(location + fileName + ".json", saveString);
        }

        public void SaveFields(string username, string password, bool rememberMeToggle, string location)
        {
            RememberMeSettings logInSettings = new RememberMeSettings(username, password, rememberMeToggle);
            string usernameAndToggle = JsonConvert.SerializeObject(logInSettings, Formatting.Indented);
            SaveLogInSettings(location, usernameAndToggle);
        }
    }
}