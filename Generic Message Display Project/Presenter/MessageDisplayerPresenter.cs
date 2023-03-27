using MessageSystem.Model;
using MessageSystem.Presenter.Interface;
using MessageSystem.Service.Interface;
using MessageSystem.View.Interface;
using Zenject;

namespace MessageSystem.Presenter
{
    public class MessageDisplayerPresenter : IMessageDisplayerPresenter
    {
        [Inject] private IMessageHistoryService _messageHistoryService;
        [Inject] private IMessageDisplayerService _messageDisplayerService;
        [Inject] private ILogPanelService _logPanelService;
        [Inject] private ILogPanelView _logPanelView;

        public void DisplayMessage(string message)
        {
            MessageInfo messageInfo = _messageDisplayerService.SpawnMessageWindow(message);

            SaveMessageInfo(messageInfo);
        }

        public void DisplayMessageException(string exceptionMessage, string stackTrace)
        {
            MessageInfo messageInfo = _messageDisplayerService.SpawnExceptionWindow(exceptionMessage, stackTrace);

            SaveMessageInfo(messageInfo);
        }

        private void SaveMessageInfo(MessageInfo messageInfo)
        {
            _messageHistoryService.AddMessageToList(messageInfo);

            _logPanelService.CreateLogMessage(messageInfo);
            _logPanelView.UpdateLogCounter();
        }
    }
}