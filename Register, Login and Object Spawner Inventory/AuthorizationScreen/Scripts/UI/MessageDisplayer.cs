using Interface;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MessageDisplayer : MonoBehaviour, IMessageDisplayer
    {
        [SerializeField] private TMP_Text _registerMessage;
        [SerializeField] private TMP_Text _logInMessage;

        public void ClearRegisterMessageField()
        {
            _registerMessage.text = "";
        }

        public void WriteRegisterMessageGreen(string message)
        {
            _registerMessage.text = message;
            _registerMessage.color = Color.green;
        }

        public void WriteRegisterMessageRed(string message)
        {
            _registerMessage.text = message;
            _registerMessage.color = Color.red;
        }


        public void ClearLogInMessageField()
        {
            _logInMessage.text = "";
        }

        public void WriteLogInMessageRed(string message)
        {
            _logInMessage.text = message;
            _logInMessage.color = Color.red;
        }
    }
}