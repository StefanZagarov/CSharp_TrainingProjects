using MessageSystem.Presenter.Interface;
using MessageSystem.Service.Interface;
using Zenject;

namespace MessageSystem.Presenter
{
    public class LogPanelPresenter : ILogPanelPresenter
    {
        [Inject] private IMessageHistoryService _messageHistoryService;

        public int GetListCount()
        {
            return _messageHistoryService.GetListCount();
        }

        public void ClearAllLogs()
        {
            _messageHistoryService.ClearList();
        }
    }
}