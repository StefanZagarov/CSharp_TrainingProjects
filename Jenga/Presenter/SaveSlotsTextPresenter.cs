using App.LogIn.LogInInterface;
using Model;
using Presenter.Interfaces;
using SaveSystem.Interfaces;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class SaveSlotsTextPresenter : ISaveSlotsTextPresenter
{
    private const string SAVE_FOLDER = "SaveFolder";
    private const string SLOT_TEXT = "SlotText";

    [Inject] private ILoader _loader;
    [Inject] private IAccountGetter _accountGetter;

    public List<SaveSlotText> GetSaveSlotsText()
    {
        List<SaveSlotText> saveSlots = new();
        string loggedAccount = _accountGetter.GetLoggedAccount().Username;
        string folderPath = Path.Combine(Application.dataPath, SAVE_FOLDER, loggedAccount, SLOT_TEXT);

        saveSlots = _loader.LoadAll<SaveSlotText>(folderPath);

        return saveSlots;
    }
}