using App.LogInInterface;
using ModelClasses;
using Newtonsoft.Json;
using SaveSystem;
using SaveSystem.Interfaces;
using System;
using UnityEngine;

namespace App.LogIn
{
    public class RememberMeToggler : MonoBehaviour, IRememberMeManager
    {
        private string _settingsSaveFolder;

        private RememberMeSettings _rememberMeSettings;

        private ISaver _saver;
        private ILoader _loader;

        private void Awake()
        {
            _saver = new Saver();
            _loader = new Loader();

            _settingsSaveFolder = Application.dataPath + "/LogInSettings/";
        }

        public void SaveLogInInfo(bool toggle, string username, string password)
        {
            _saver.SaveFields(username, password, toggle, _settingsSaveFolder);
        }

        public bool GetRememberedUser()
        {
            try
            {
                string loadedFiles = _loader.LoadRememberMeSettings(_settingsSaveFolder);
                _rememberMeSettings = JsonConvert.DeserializeObject<RememberMeSettings>(loadedFiles);

                if (_rememberMeSettings.RememberMe == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                Debug.LogError("No saved settings!");
                return false;
            }
        }

        public string GetUsername()
        {
            return _rememberMeSettings.Username;
        }
        public string GetPassword()
        {
            return _rememberMeSettings.Password;
        }
        public bool GetToggle()
        {
            return _rememberMeSettings.RememberMe;
        }
        public string GetSaveLocation()
        {
            return _settingsSaveFolder;
        }
    }
}