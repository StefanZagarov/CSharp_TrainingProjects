using App.LogIn.LogInInterface;
using Model.State;
using ModelClasses;
using Presenter.Interfaces;
using SaveSystem.Interfaces;
using Services.Interfaces;
using System.IO;
using UnityEngine;
using View.Interfaces;
using Zenject;

namespace Presenter
{
    public class LoadButtonPresenter : ILoadButtonPresenter
    {
        private const string SAVE_FOLDER = "SaveFolder";

        [Inject] private ILoader _loader;
        [Inject] private IBrickSpawnerService _brickSpawnerService;
        [Inject] private IAccountGetter _accountGetter;
        [Inject] private IBrickSpawnerView _brickSpawnerView;
        [Inject] private ICameraMoverService _cameraMoverService;
        [Inject] private ITowerExploderService _towerExploderService;
        [Inject] private IGameOverScreenView _gameOverScreenView;        

        public void LoadState(string saveSlot)
        {
            User account = _accountGetter.GetLoggedAccount();
            string filePath = Path.Combine(Application.dataPath, SAVE_FOLDER, account.Username, saveSlot);

            GameState loadedState = _loader.Load<GameState>(filePath, ".txt");

            _towerExploderService.ResetConditions();

            _towerExploderService.SetIsGameOver(loadedState.IsGameOver);
            _gameOverScreenView.DisplayGameOver(loadedState.IsGameOver);

            _brickSpawnerService.LoadTower(_brickSpawnerView.GetBrickPrefab(), loadedState.BrickStates);
            _cameraMoverService.SetLoadedCamPosValues(_brickSpawnerService.BricksList.Count, loadedState.CameraPosition);
        }
    }
}