using MessageSystem.Model;
using System.Collections.Generic;

namespace MessageSystem.Service.Interface
{
    public interface IMessageHistoryService
    {
        List<MessageInfo> GetMessagesOnScreenList();
        void AddToMessagesOnScreen(MessageInfo messageInfo);
        void RemoveFromMessagesOnScreen(MessageInfo messageInfo);
        int GetListCount();
        void AddMessageToList(MessageInfo messageInfo);
        MessageInfo GetSavedMessage(MessageInfo messageInfo);
        void DeleteMessageFromList(MessageInfo messageInfo);
        void ClearList();
    }
}