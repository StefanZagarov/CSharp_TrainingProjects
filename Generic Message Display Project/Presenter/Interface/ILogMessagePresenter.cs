using MessageSystem.Model;

namespace MessageSystem.Presenter.Interface
{
    public interface ILogMessagePresenter
    {
        void DeleteLog(MessageInfo messageInfo);
        bool WindowIsOnScreen(MessageInfo messageInfo);
    }
}