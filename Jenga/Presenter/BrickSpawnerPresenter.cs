using Model.State;
using Presenter.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using View.Interfaces;
using Zenject;

namespace Presenter
{
    public class BrickSpawnerPresenter : IBrickSpawnerPresenter
    {
        [Inject]
        private IBrickSpawnerService _brickSpawnerService;
        [Inject]
        private ICameraMoverService _cameraMoverService;
        [Inject]
        private IGameOverScreenView _gameOverScreenView;
        [Inject]
        ITowerExploderService _towerExploderService;

        public void SpawnTower(GameObject brickLevelPrefab, int height, float rotationAmmount, float yPosOffset,
             float cameraXRotation)
        {
            _towerExploderService.ResetConditions();
            _gameOverScreenView.DisplayGameOver(false);

            _brickSpawnerService.SpawnTower(brickLevelPrefab, height, rotationAmmount, yPosOffset);

            _cameraMoverService.SetCamPosValues(_brickSpawnerService.BricksList.Count, cameraXRotation);
        }                
    }
}