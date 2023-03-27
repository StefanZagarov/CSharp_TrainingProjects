using MessageSystem.Model;
using MessageSystem.Presenter.Interface;
using MessageSystem.Service.Interface;
using MessageSystem.View.Interface;
using Zenject;

namespace MessageSystem.Presenter
{
    public class LogMessagePresenter : ILogMessagePresenter
    {
        [Inject] private IMessageHistoryService _messageHistoryService;
        [Inject] private ILogPanelView _logPanelView;

        public bool WindowIsOnScreen(MessageInfo messageInfo)
        {
            foreach (MessageInfo instantiatedMessage in _messageHistoryService.GetMessagesOnScreenList())
            {
                if (instantiatedMessage.MessageID == messageInfo.MessageID)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteLog(MessageInfo messageInfo)
        {
            _messageHistoryService.DeleteMessageFromList(messageInfo);
            _logPanelView.UpdateLogCounter();
        }
    }
}