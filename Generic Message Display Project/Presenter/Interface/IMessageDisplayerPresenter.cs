using MessageSystem.Model;

namespace MessageSystem.Presenter.Interface
{
    public interface IMessageDisplayerPresenter
    {
        void DisplayMessage(string message);
        void DisplayMessageException(string exceptionMessage, string stackTrace);
    }
}