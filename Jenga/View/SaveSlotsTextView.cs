using Model;
using Presenter.Interfaces;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using View.Interfaces;
using Zenject;

namespace View
{
    public class SaveSlotsTextView : MonoBehaviour, ISaveSlotsTextView
    {
        [SerializeField] private List<GameObject> _saveSlots = new List<GameObject>();

        [Inject] private ISaveSlotsTextPresenter _saveSlotsTextPresenter;

        private List<SaveSlotText> _saveSlotTextList = new();

        private void Start()
        {
            _saveSlotTextList = _saveSlotsTextPresenter.GetSaveSlotsText();

            try
            {
                LoadSaveSlotText();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        private void LoadSaveSlotText()
        {
            foreach (GameObject slot in _saveSlots)
            {
                foreach (SaveSlotText saveSlot in _saveSlotTextList)
                {
                    if (slot.name == saveSlot.SlotName)
                    {
                        slot.GetComponentInChildren<TMP_Text>().text = saveSlot.SlotText.ToString();
                    }
                }
            }
        }

        public List<GameObject> GetSlots()
        {
            return _saveSlots;
        }

        public void WriteSlotText(GameObject slot, string timeOfSave)
        {
            slot.GetComponentInChildren<TMP_Text>().text = timeOfSave.ToString();
        }
    }
}