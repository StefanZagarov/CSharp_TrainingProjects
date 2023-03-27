using MessageSystem.Model;
using MessageSystem.Service.Interface;
using MessageSystem.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MessageSystem.Service
{
    public class LogPanelService : ILogPanelService, IInitializable
    {
        [Inject] private LogMessageView.Factory _logMessageFactory;
        private Transform _transform;

        public void Initialize()
        {
            _transform = Object.FindObjectOfType<LogPanelView>().
                GetComponentInChildren<VerticalLayoutGroup>(true).gameObject.transform;
        }

        public void CreateLogMessage(MessageInfo messageInfo)
        {
            LogMessageView logPanel = _logMessageFactory.Create();

            // Initialize
            logPanel.transform.SetParent(_transform, false);

            logPanel.GetComponentInChildren<TMP_Text>().text = messageInfo.Message;

            logPanel.SetMessageInfo(messageInfo);
        }


    }
}