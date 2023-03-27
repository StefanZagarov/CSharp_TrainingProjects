using Services;
using Services.Interfaces;
using Zenject;

public class GameSceneServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBrickSpawnerService>().To<BrickSpawnerService>().AsSingle();
        Container.Bind<ICameraMoverService>().To<CameraMoverService>().AsSingle();
        Container.Bind<IGameStateService>().To<GameStateService>().AsSingle();
        Container.Bind<ITowerExploderService>().To<TowerExploderService>().AsSingle();
    }
}