using MessageSystem.Model;

namespace MessageSystem.Service.Interface
{
    public interface ILogPanelService
    {
        void CreateLogMessage(MessageInfo messageInfo);
    }
}