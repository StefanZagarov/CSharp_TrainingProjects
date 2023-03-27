using MessageSystem.Model;
using MessageSystem.Presenter.Interface;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace MessageSystem.View
{
    public class LogMessageView : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<LogMessageView> { }

        [SerializeField] private GameObject _messageWindow;
        private MessageInfo _messageInfo;

        [Inject] private MessageWindowHandlerView.Factory _messageWindowFactory;
        [Inject] private ILogMessagePresenter _logMessagePresenter;

        public void SetMessageInfo(MessageInfo messageInfo)
        {
            _messageInfo = messageInfo;
        }

        // Buttons
        public void ShowMessagePanel()
        {
            if (_logMessagePresenter.WindowIsOnScreen(_messageInfo)) return;

            MessageWindowHandlerView messageWindow = _messageWindowFactory.Create();
            messageWindow.transform.parent.parent.SetParent(GameObject.FindObjectOfType<LogPanelView>().transform.parent, false);

            var messageWindowHandler = messageWindow.GetComponentInChildren<MessageWindowHandlerView>();
            messageWindowHandler.header.GetComponent<TMP_Text>().text = _messageInfo.Header;
            messageWindowHandler.messageBody.GetComponent<TMP_Text>().text = _messageInfo.Message;
            messageWindowHandler.messageInfo = _messageInfo;

            if (!string.IsNullOrEmpty(_messageInfo.StackTrace))
            {
                messageWindowHandler.exceptionButton.SetActive(true);
                messageWindowHandler.stackTraceBody.GetComponent<TMP_Text>().text = _messageInfo.StackTrace;
            }
        }

        public void DeleteLog()
        {
            _logMessagePresenter.DeleteLog(_messageInfo);

            Destroy(gameObject);
        }
    }
}