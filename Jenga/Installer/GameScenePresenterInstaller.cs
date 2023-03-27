using Presenter;
using Presenter.Interfaces;
using Zenject;

public class GameScenePresenterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBrickSpawnerPresenter>().To<BrickSpawnerPresenter>().AsSingle();
        Container.Bind<ICameraMoverPresenter>().To<CameraMoverPresenter>().AsSingle();
        Container.Bind<ICollisionDetectorPresenter>().To<CollisionDetectorPresenter>().AsSingle();
        Container.Bind<ILoadButtonPresenter>().To<LoadButtonPresenter>().AsSingle();
        Container.Bind<ILoadFromButtonPresenter>().To<LoadFromButtonPresenter>().AsSingle();
        Container.Bind<ISaveButtonPresenter>().To<SaveButtonPresenter>().AsSingle();
        Container.Bind<ISaveSlotsTextPresenter>().To<SaveSlotsTextPresenter>().AsSingle();
        Container.Bind<ISaveToButtonPresenter>().To<SaveToButtonPresenter>().AsSingle();
    }
}