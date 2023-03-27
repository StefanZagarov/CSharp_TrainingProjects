using MessageSystem.Model;
using MessageSystem.Presenter.Interface;
using MessageSystem.Service.Interface;
using Zenject;

namespace MessageSystem.Presenter
{
    public class MessageWindowHandlerPresenter : IMessageWindowHandlerPresenter
    {
        [Inject] IMessageHistoryService _messageHistoryService;

        public void AddToMessagesOnScreenList(MessageInfo messageInfo)
        {
            _messageHistoryService.AddToMessagesOnScreen(messageInfo);
        }

        public void RemoveFromMessageOnScreenList(MessageInfo messageInfo)
        {
            _messageHistoryService.RemoveFromMessagesOnScreen(messageInfo);
        }
    }
}