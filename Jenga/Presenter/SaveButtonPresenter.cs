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
using TMPro;
using Model;
using System;

namespace Presenter
{
    public class SaveButtonPresenter : ISaveButtonPresenter
    {
        private const string SAVE_FOLDER = "SaveFolder";
        private const string SLOT_TEXT_SAVE = "SlotText";

        [Inject]
        private ISaver _saver;
        [Inject]
        private IGameStateService _gameStateService;
        [Inject]
        private IAccountGetter _accountGetter;
        [Inject]
        private ITowerExploderService _towerExploderService;
        [Inject]
        private ISaveSlotsTextView _saveSlotsTextView;

        public void SaveGameState(string saveSlot)
        {
            User loggedAccount = _accountGetter.GetLoggedAccount();
            GameState gameState = _gameStateService.CreateGameState(loggedAccount, _towerExploderService.GetIsGameOver());

            string savePath = Path.Combine(Application.dataPath, SAVE_FOLDER, loggedAccount.Username);
            string slotTextSavePath = Path.Combine(savePath, SLOT_TEXT_SAVE);

            _saver.Save(savePath, saveSlot, ".txt", gameState);

            string timeOfSave = gameState.TimeOfSave;

            foreach (GameObject slot in _saveSlotsTextView.GetSlots())
            {
                if (slot.name.Equals(saveSlot))
                {
                    _saveSlotsTextView.WriteSlotText(slot, timeOfSave);

                    SaveSlotText saveSlotText = new(slot.name, timeOfSave);
                    _saver.Save(slotTextSavePath, saveSlot, ".txt", saveSlotText);
                }
            }
        }
    }
}