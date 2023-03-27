using MessageSystem.Model;

namespace MessageSystem.Service.Interface
{
    public interface IMessageDisplayerService
    {
        MessageInfo SpawnMessageWindow(string message);

        MessageInfo SpawnExceptionWindow(string exceptionMessage, string stackTrace);
    }
}