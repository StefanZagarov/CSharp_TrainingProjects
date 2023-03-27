using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using Interface;
using App.LogInInterface;
using App.LogIn;

namespace UI
{
    public class LogInUI : MonoBehaviour
    {
        [SerializeField] private GameObject _logInScreen;
        [SerializeField] private GameObject _welcomeScreen;

        [SerializeField] private TMP_InputField _username;
        [SerializeField] private TMP_InputField _password;
        [SerializeField] private Toggle _rememberMeToggle;

        private ILogInManager _logInManager;
        private IRememberMeManager _rememberMeToggler;
        private IMessageDisplayer _messageDisplayer;

        private void Start()
        {
            _logInManager = GetComponent<LogInManager>();
            _rememberMeToggler = GetComponent<RememberMeToggler>();
            _messageDisplayer = GetComponentInParent<MessageDisplayer>();

            if (_rememberMeToggler.GetRememberedUser())
            {
                _username.text = _rememberMeToggler.GetUsername();
                _password.text = _rememberMeToggler.GetPassword();
                _rememberMeToggle.isOn = _rememberMeToggler.GetToggle();
            }
        }

        public bool HasEmptyField()
        {
            foreach (TMP_InputField field in GetComponentsInChildren<TMP_InputField>())
            {
                if (string.IsNullOrEmpty(field.text))
                {
                    _messageDisplayer.WriteLogInMessageRed("Please fill all fields!");

                    field.image.color = Color.red;
                    return true;
                }
            }
            return false;
        }


        //Buttons    
        public void LogIn()
        {
            if (HasEmptyField()) return;

            string username = _username.text;
            string password = _password.text;
            bool toggle = _rememberMeToggle.isOn;

            if (_logInManager.UserExists(username, password))
            {
                try
                {
                    if (toggle)
                    {
                        _rememberMeToggler.SaveLogInInfo(toggle, username, password);
                    }
                    else
                    {
                        Directory.Delete(_rememberMeToggler.GetSaveLocation(), true); //gives access denied error
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex.Message);
                }

                SceneManager.LoadScene(1);
            }
            else
            {
                _messageDisplayer.WriteLogInMessageRed("Invalid account!");
            }
        }

        public void GoToWelcomeScreen()
        {
            _messageDisplayer.ClearLogInMessageField();

            foreach (TMP_InputField field in GetComponentsInChildren<TMP_InputField>())
            {
                field.image.color = Color.white;
            }

            _logInScreen.SetActive(false);
            _welcomeScreen.SetActive(true);
        }
    }
}