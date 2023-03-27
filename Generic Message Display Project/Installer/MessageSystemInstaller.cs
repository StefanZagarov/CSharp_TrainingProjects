using MessageSystem.Presenter;
using MessageSystem.Presenter.Interface;
using MessageSystem.Service;
using MessageSystem.Service.Interface;
using MessageSystem.View;
using MessageSystem.View.Interface;
using UnityEngine;
using Zenject;

namespace MessageSystem.Installer
{
    public class MessageSystemInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _messageSystemCanvas;
        [SerializeField] private GameObject _messageWindow;
        [SerializeField] private GameObject _logMessage;

        public override void InstallBindings()
        {
            // View
            Container.Bind<ILogPanelView>().FromComponentInNewPrefab(_messageSystemCanvas).AsSingle().NonLazy();
            Container.Bind<IMessageDisplayerView>().To<MessageDisplayerView>().AsSingle();

            Container.BindFactory<LogMessageView, LogMessageView.Factory>().FromComponentInNewPrefab(_logMessage).AsSingle();
            Container.BindFactory<MessageWindowHandlerView, MessageWindowHandlerView.Factory>().FromComponentInNewPrefab(_messageWindow).AsSingle();

            // Presenter
            Container.Bind<ILogMessagePresenter>().To<LogMessagePresenter>().AsSingle();
            Container.Bind<ILogPanelPresenter>().To<LogPanelPresenter>().AsSingle();
            Container.Bind<IMessageDisplayerPresenter>().To<MessageDisplayerPresenter>().AsSingle();
            Container.Bind<IMessageWindowHandlerPresenter>().To<MessageWindowHandlerPresenter>().AsSingle();

            // Service
            Container.BindInterfacesTo<LogPanelService>().AsSingle();
            Container.Bind<IMessageDisplayerService>().To<MessageDisplayerService>().AsSingle();
            Container.Bind<IMessageHistoryService>().To<MessageHistoryService>().AsSingle();
        }
    }
}