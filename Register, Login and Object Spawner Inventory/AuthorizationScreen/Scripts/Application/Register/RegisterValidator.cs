using App.RegisterInterface;
using ModelClasses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace App.Register
{
    public class RegisterValidator : MonoBehaviour, IRegisterValidator
    {
        private IRegisterManager _registerManager;

        private List<string> _loadedFiles;

        private void Start()
        {
            _registerManager = GetComponent<RegisterManager>();

            _loadedFiles = new List<string>();
            _loadedFiles = _registerManager.GetAllAccounts();
        }

        public bool HasEmptyField()
        {
            foreach (TMP_InputField field in GetComponentsInChildren<TMP_InputField>())
            {
                if (string.IsNullOrEmpty(field.text))
                {
                    field.image.color = Color.red;
                    return true;
                }
            }
            return false;
        }

        public bool HasPasswordMismatch(string confirmPassword, string password)
        {
            if (confirmPassword != password)
            {
                return true;
            }
            return false;
        }

        public bool UsernameExists(string username)
        {
            foreach (string file in _loadedFiles)
            {
                string readFile = File.ReadAllText(file);
                User userID = JsonConvert.DeserializeObject<User>(readFile);

                if (username == userID.Username)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EmailExists(string email)
        {
            foreach (string file in _loadedFiles)
            {
                string readFile = File.ReadAllText(file);
                User userID = JsonConvert.DeserializeObject<User>(readFile);
                if (email == userID.Email)
                {
                    return true;
                }
            }
            return false;
        }

        public void SendAccountInfo(User user)
        {
            _registerManager.SaveAccountInfo(user);
        }
    }
}