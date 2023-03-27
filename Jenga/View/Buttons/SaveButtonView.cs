using UnityEngine;
using View.Interfaces;
using TMPro;
using Zenject;
using Presenter.Interfaces;
using System;

namespace View
{
    public class SaveButtonView : MonoBehaviour, ISaveButtonView
    {
        [Inject]
        private ISaveButtonPresenter _saveButtonPresenter;

        // Button
        public void SaveGame()
        {
            try
            {
                _saveButtonPresenter.SaveGameState(transform.parent.parent.name);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }
    }
}