using UnityEngine;
using Zenject;
using System;
using MessageSystem.Service.Interface;
using MessageSystem.Model;
using TMPro;
using MessageSystem.View;

namespace MessageSystem.Service
{
    public class MessageDisplayerService : IMessageDisplayerService
    {
        [Inject] private MessageWindowHandlerView.Factory _messageWindowFactory;

        public MessageInfo SpawnMessageWindow(string messageContent)
        {
            MessageWindowHandlerView messageWindow = _messageWindowFactory.Create();
            messageWindow.transform.parent.parent.SetParent(GameObject.FindObjectOfType<LogPanelView>().transform.parent, false);

            var panelFields = messageWindow.GetComponentInChildren<MessageWindowHandlerView>();

            string headerText = panelFields.header.GetComponent<TMP_Text>().text = "Message";
            string messageBodyText = panelFields.messageBody.GetComponent<TMP_Text>().text = messageContent;
            Guid messageGuid = Guid.NewGuid();

            MessageInfo messageInfo = new(headerText, messageBodyText, messageGuid);
            panelFields.messageInfo = messageInfo;

            return messageInfo;
        }

        public MessageInfo SpawnExceptionWindow(string exceptionMessage, string stackTrace)
        {
            MessageWindowHandlerView messageWindow = _messageWindowFactory.Create();
            messageWindow.transform.parent.parent.SetParent(GameObject.FindObjectOfType<LogPanelView>().transform.parent, false);

            var panelFields = messageWindow.GetComponentInChildren<MessageWindowHandlerView>();
            panelFields.exceptionButton.SetActive(true);

            string headerText = panelFields.header.GetComponent<TMP_Text>().text = "Error";
            string messageBodyText = panelFields.messageBody.GetComponent<TMP_Text>().text = exceptionMessage;
            string stackTraceBodyText = panelFields.stackTraceBody.GetComponent<TMP_Text>().text = stackTrace;
            Guid messageGuid = Guid.NewGuid();

            MessageInfo messageInfo = new(headerText, messageBodyText, messageGuid, stackTraceBodyText);
            panelFields.messageInfo = messageInfo;

            return messageInfo;
        }
    }
}