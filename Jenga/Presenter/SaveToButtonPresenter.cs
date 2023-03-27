using App.LogIn.LogInInterface;
using Model.State;
using ModelClasses;
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
    public class SaveToButtonPresenter : ISaveToButtonPresenter
    {
        private const string SAVE_FOLDER = "SaveFolder";

        [Inject] private ISaver _saver;
        [Inject] private ILoader _loader;
        [Inject] private IAccountGetter _accountGetter;
        [Inject] private IGameStateService _gameStateService;
        [Inject] private ITowerExploderService _towerExploderService;



        public void SaveStateTo()
        {
            User loggedAccount = _accountGetter.GetLoggedAccount();
            string directory = Path.Combine(Application.dataPath, SAVE_FOLDER, loggedAccount.Username);

            string savePath = StandaloneFileBrowser.SaveFilePanel("", directory, $"{loggedAccount.Username}'s save", "txt");

            if (string.IsNullOrEmpty(savePath)) return;

            GameState gameState = _gameStateService.CreateGameState(loggedAccount, _towerExploderService.GetIsGameOver());

            if (!File.Exists(savePath))
            {
                _saver.SaveTo(savePath, gameState);
            }

            GameState loadedState = _loader.Load<GameState>(savePath, "");

            if (loadedState.AccountName == loggedAccount.Username)
            {
                _saver.SaveTo(savePath, gameState);

            }
            else
            {
                Debug.LogError("Cannot overwrite a save belonging to a different account!");
            }
        }
    }
}