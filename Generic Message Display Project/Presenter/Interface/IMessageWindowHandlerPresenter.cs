using MessageSystem.Model;

namespace MessageSystem.Presenter.Interface
{
    public interface IMessageWindowHandlerPresenter
    {
        void AddToMessagesOnScreenList(MessageInfo messageID);
        void RemoveFromMessageOnScreenList(MessageInfo messageID);
    }
}