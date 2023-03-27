using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using ModelClasses;
using System;
using SaveSystem;
using App.LogInInterface;
using SaveSystem.Interfaces;

namespace App.LogIn
{
    public class LogInManager : MonoBehaviour, ILogInManager
    {
        private string _accountsSaveFolder;

        private List<string> _loadedAccounts = new();

        private ILoader _loader;

        private void Start()
        {
            _loader = new Loader();

            _accountsSaveFolder = Application.dataPath + "/Accounts/";
        }

        public bool UserExists(string username, string password)
        {
            //Get accounts
            try
            {
                if (Directory.Exists(_accountsSaveFolder))
                {
                    _loadedAccounts = _loader.LoadAllAccounts(_accountsSaveFolder);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                Debug.LogError("No existing accounts!");
            }

            //Check for existing account
            foreach (string account in _loadedAccounts)
            {
                string readFile = File.ReadAllText(account);
                User userID = JsonConvert.DeserializeObject<User>(readFile);

                if (username == userID.Username
                    && password == userID.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}