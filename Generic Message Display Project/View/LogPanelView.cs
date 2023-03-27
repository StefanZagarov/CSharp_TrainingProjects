using MessageSystem.Presenter.Interface;
using MessageSystem.View.Interface;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace MessageSystem.View
{
    public class LogPanelView : MonoBehaviour, ILogPanelView
    {
        [SerializeField] private TMP_Text _notificationCounter;

        [Inject] private ILogPanelPresenter _logCounterPresenter;

        public void UpdateLogCounter()
        {
            _notificationCounter.GetComponent<TMP_Text>().text = _logCounterPresenter.GetListCount().ToString();
        }

        // Button
        public void ClearAllLogs()
        {
            try
            {
                _logCounterPresenter.ClearAllLogs();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }

            foreach (var log in FindObjectsOfType<LogMessageView>())
            {
                Destroy(log.gameObject);
            }

            UpdateLogCounter();
        }
    }
}