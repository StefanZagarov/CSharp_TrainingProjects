using App.Register;
using App.RegisterInterface;
using Interface;
using ModelClasses;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class RegisterUI : MonoBehaviour
    {
        [SerializeField] private GameObject _registerScreen;
        [SerializeField] private GameObject _welcomeScreen;

        [SerializeField] private TMP_InputField _firstNameField;
        [SerializeField] private TMP_InputField _lastNameField;
        [SerializeField] private TMP_Dropdown _countryDropdown;
        private int _countryIndex;
        [SerializeField] private TMP_Dropdown _townDropdown;
        private int _townIndex;

        List<string> _austriaTowns = new List<string> { "Graz", "Innsbruck", "Linz", "Salzburg", "Vienna" };
        List<string> _bulgariaTowns = new List<string> { "Burgas", "Plovdiv", "Sofia", "Stara Zagora", "Varna" };

        [SerializeField] private TMP_InputField _usernameField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private TMP_InputField _confirmPasswordField;
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private TMP_InputField _phoneNumberField;

        private IRegisterValidator _registerValidator;
        private IMessageDisplayer _messageDisplayer;

        private void Start()
        {
            _registerValidator = GetComponent<RegisterValidator>();
            _messageDisplayer = GetComponentInParent<MessageDisplayer>();

            TownDropdown();
        }

        public int GetCountryIndex()
        {
            return _countryIndex = _countryDropdown.value;
        }

        public int GetTownIndex()
        {
            return _townIndex = _townDropdown.value;
        }

        public void TownDropdown()
        {
            switch (GetCountryIndex())
            {
                case 0:
                    _townDropdown.ClearOptions();

                    _townDropdown.AddOptions(_austriaTowns);
                    break;

                case 1:
                    _townDropdown.ClearOptions();

                    _townDropdown.AddOptions(_bulgariaTowns);
                    break;
            }
        }

        public User CreateUser()
        {
            string firstName = _firstNameField.text;
            string lastName = _lastNameField.text;
            string country = _countryDropdown.options[GetCountryIndex()].text;
            string town = _townDropdown.options[GetTownIndex()].text;
            string username = _usernameField.text;
            string password = _passwordField.text;
            string email = _emailField.text;
            string phoneNumber = _phoneNumberField.text;

            User user = new(firstName, lastName, country, town, username, password, email, phoneNumber);
            return user;
        }

        //Buttons
        public void CreateAccount()
        {
            CreateUser();

            if (_registerValidator.HasEmptyField())
            {
                _messageDisplayer.WriteRegisterMessageRed("Please fill all fields!");

                return;
            }

            if (_registerValidator.HasPasswordMismatch(_confirmPasswordField.text, _passwordField.text))
            {
                _messageDisplayer.WriteRegisterMessageRed("Passwords do not match!");

                _confirmPasswordField.image.color = Color.red;
                return;
            }

            if (_registerValidator.UsernameExists(_usernameField.text))
            {
                _messageDisplayer.WriteRegisterMessageRed("Username already exists!");

                _usernameField.image.color = Color.red;
                return;
            }

            if (_registerValidator.EmailExists(_emailField.text))
            {
                _messageDisplayer.WriteRegisterMessageRed("Email already exists!");

                _emailField.image.color = Color.red;
                return;
            }

            _registerValidator.SendAccountInfo(CreateUser());

            _messageDisplayer.WriteRegisterMessageGreen("Registration Successful!");
        }

        public void GoToWelcomeScreen()
        {
            foreach (TMP_InputField field in GetComponentsInChildren<TMP_InputField>())
            {
                field.text = "";
                field.image.color = Color.white;
            }

            _messageDisplayer.ClearRegisterMessageField();

            _registerScreen.SetActive(false);
            _welcomeScreen.SetActive(true);
        }
    }
}