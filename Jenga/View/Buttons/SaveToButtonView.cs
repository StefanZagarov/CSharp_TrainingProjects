using UnityEngine;
using Zenject;
using Presenter.Interfaces;
using View.Interfaces;
using System;
using MessageSystem.View.Interface;

namespace View
{
    public class SaveToButtonView : MonoBehaviour, ISaveToButtonView
    {
        [Inject] private ISaveToButtonPresenter _saveToButtonPresenter;
        [Inject] private IMessageDisplayerView _messageDisplayerView;

        public void SaveGameTo()
        {
            try
            {
                _saveToButtonPresenter.SaveStateTo();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                _messageDisplayerView.DisplayExceptionMessage("Could not save!", ex.Message);
            }
        }
    }
}