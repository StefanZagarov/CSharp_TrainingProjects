using UnityEngine;
using View.Interfaces;
using Zenject;

public class GameSceneViewInstaller : MonoInstaller
{
    [SerializeField] private GameObject _brick;

    public override void InstallBindings()
    {
        Container.Bind<IBrickHighlighterView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IBrickMoverView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IBrickSpawnerView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ICameraMoverView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ICollisionDetectorView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IGameOverScreenView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ILevelSelectorView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IPanelTogglerView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ISaveSlotsTextView>().FromComponentInHierarchy().AsSingle();

        Container.Bind<ILoadButtonView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ILoadFromButtonView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ISaveButtonView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ISaveToButtonView>().FromComponentInHierarchy().AsSingle();
    }
}