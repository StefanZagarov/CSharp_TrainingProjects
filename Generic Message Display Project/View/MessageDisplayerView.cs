using MessageSystem.Presenter.Interface;
using MessageSystem.View.Interface;
using Zenject;

namespace MessageSystem.View
{
    public class MessageDisplayerView : IMessageDisplayerView
    {
        [Inject] private IMessageDisplayerPresenter _messageDisplayerPresenter;

        public void DisplayMessage(string message)
        {
            _messageDisplayerPresenter.DisplayMessage(message);
        }

        public void DisplayExceptionMessage(string exceptionMessage, string stackTrace)
        {
            _messageDisplayerPresenter.DisplayMessageException(exceptionMessage, stackTrace);
        }
    }
}