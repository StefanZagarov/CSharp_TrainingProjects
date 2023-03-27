using TMPro;
using UnityEngine;

namespace UI
{
    public class WelcomeScreenUI : MonoBehaviour
    {
        [SerializeField] private GameObject _welcomeScreen;
        [SerializeField] private GameObject _logInScreen;
        [SerializeField] private GameObject _registerScreen;

        public void GoToLogInScreen()
        {
            foreach (TMP_InputField field in GetComponentsInChildren<TMP_InputField>())
            {
                field.text = "";
                field.GetComponent<TMP_InputField>().image.color = Color.white;
            }

            _welcomeScreen.SetActive(false);
            _logInScreen.SetActive(true);
        }

        public void GoToRegisterScreen()
        {
            foreach (TMP_InputField field in GetComponentsInChildren<TMP_InputField>())
            {
                field.GetComponent<TMP_InputField>().image.color = Color.white;
            }

            _registerScreen.SetActive(true);
            _welcomeScreen.SetActive(false);
        }
    }
}