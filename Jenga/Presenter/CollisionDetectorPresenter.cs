using MessageSystem.View.Interface;
using Presenter.Interfaces;
using Services.Interfaces;
using View.Interfaces;
using Zenject;

namespace Presenter
{
    public class CollisionDetectorPresenter : ICollisionDetectorPresenter
    {
        [Inject] private ITowerExploderService _towerExploderService;
        [Inject] private IGameOverScreenView _gameOverScreenView;
        [Inject] private IBrickSpawnerService _brickSpawnerService;
        [Inject] private IMessageDisplayerView _messageDisplayerView;

        public void TriggerGameOver(float force)
        {
            _towerExploderService.IncreaseCounter();
            if (_towerExploderService.ExplodeTower(_brickSpawnerService.BricksList, force))
            {
                _gameOverScreenView.DisplayGameOver(true);
                _messageDisplayerView.DisplayMessage("Game Over");
            }
        }
    }
}