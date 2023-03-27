using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using SaveSystem.Interfaces;

namespace SaveSystem
{
    public class Loader : ILoader
    {
        public string LoadRememberMeSettings(string location)
        {
            try
            {
                return File.ReadAllText(location + "/LogInSettings.json");
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);

                Debug.LogError("Settings file could not be found!");
                return string.Empty;
            }
        }

        public List<string> LoadAllAccounts(string location)
        {
            try
            {
                return Directory.GetFiles(location, "*.json").ToList();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);

                Debug.LogError("Account files could not be found!");
                return new List<string>();
            }
        }
    }
}