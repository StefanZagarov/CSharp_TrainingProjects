using App.LogIn.LogInInterface;
using Model.State;
using Presenter.Interfaces;
using SaveSystem.Interfaces;
using Services.Interfaces;
using SFB;
using System.IO;
using UnityEngine;
using View.Interfaces;
using Zenject;

namespace Presenter
{
    public class LoadFromButtonPresenter : ILoadFromButtonPresenter
    {
        private const string SAVE_FOLDER = "SaveFolder";

        [Inject]
        private IAccountGetter _accountGetter;
        [Inject]
        private ILoader _loader;
        [Inject]
        private IBrickSpawnerService _brickSpawnerService;
        [Inject]
        private IBrickSpawnerView _brickSpawnerView;
        [Inject]
        private ICameraMoverService _cameraMoverService;
        [Inject]
        private ITowerExploderService _towerExploderService;
        [Inject]
        private IGameOverScreenView _gameOverScreenView;

        public void LoadStateFrom()
        {
            _towerExploderService.ResetConditions();
            _gameOverScreenView.DisplayGameOver(false);

            string accountName = _accountGetter.GetLoggedAccount().Username;
            string directory = Path.Combine(Application.dataPath, SAVE_FOLDER, accountName);

            var loadedPath = StandaloneFileBrowser.OpenFilePanel("", directory, "txt", false);

            // Still throws out of bout exception
            if (string.IsNullOrEmpty(loadedPath[0])) return;            

            GameState loadedState = _loader.Load<GameState>(loadedPath[0]);

            if (loadedState.AccountName == accountName)
            {
                _towerExploderService.SetIsGameOver(loadedState.IsGameOver);
                _gameOverScreenView.DisplayGameOver(loadedState.IsGameOver);

                _brickSpawnerService.LoadTower(_brickSpawnerView.GetBrickPrefab(), loadedState.BrickStates);
                _cameraMoverService.SetLoadedCamPosValues(_brickSpawnerService.BricksList.Count, loadedState.CameraPosition);
            }
            else
            {
                Debug.LogError("Cannot load save from different account!");
            }
        }
    }
}