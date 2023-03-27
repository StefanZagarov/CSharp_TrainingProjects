using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using ModelClasses;
using SaveSystem;
using App.RegisterInterface;
using SaveSystem.Interfaces;

namespace App.Register
{
    public class RegisterManager : MonoBehaviour, IRegisterManager
    {
        private string _accountsSaveFolder;

        private ISaver _saver;
        private ILoader _loader;

        private void Awake()
        {
            _saver = new Saver();
            _loader = new Loader();

            _accountsSaveFolder = Application.dataPath + "/Accounts/";
        }

        public List<string> GetAllAccounts()
        {
            return _loader.LoadAllAccounts(_accountsSaveFolder);
        }

        public void SaveAccountInfo(User user)
        {
            string userInfo = JsonConvert.SerializeObject(user, Formatting.Indented);
            _saver.SaveAccount(_accountsSaveFolder, user.Username, userInfo);
        }
    }
}