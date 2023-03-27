using MessageSystem.Model;
using MessageSystem.Service.Interface;
using System.Collections.Generic;

namespace MessageSystem.Service
{
    public class MessageHistoryService : IMessageHistoryService
    {
        private List<MessageInfo> _messageInfoList = new();

        private List<MessageInfo> _messagesOnScreen = new();

        public List<MessageInfo> GetMessagesOnScreenList()
        {
            return _messagesOnScreen;
        }

        public void AddToMessagesOnScreen(MessageInfo messageInfo)
        {
            _messagesOnScreen.Add(messageInfo);
        }

        public void RemoveFromMessagesOnScreen(MessageInfo messageInfo)
        {
            _messagesOnScreen.Remove(messageInfo);
        }

        public void AddMessageToList(MessageInfo messageInfo)
        {
            _messageInfoList.Add(messageInfo);
        }

        public MessageInfo GetSavedMessage(MessageInfo messageInfo)
        {
            foreach (MessageInfo message in _messageInfoList)
            {
                if (message.MessageID == messageInfo.MessageID)
                {
                    return message;
                }
            }
            return null;
        }

        public int GetListCount()
        {
            return _messageInfoList.Count;
        }

        public void DeleteMessageFromList(MessageInfo messageInfo)
        {
            foreach (MessageInfo message in _messageInfoList)
            {
                if (message.MessageID == messageInfo.MessageID)
                {
                    _messageInfoList.Remove(message);
                    return;
                }
            }
        }

        public void ClearList()
        {
            _messageInfoList.Clear();
        }
    }
}