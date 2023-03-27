using UnityEngine;
using Zenject;
using View.Interfaces;
using Presenter.Interfaces;
using System;
using MessageSystem.View.Interface;

namespace View
{
    public class LoadFromButtonView : MonoBehaviour, ILoadFromButtonView
    {
        [Inject] private ILoadFromButtonPresenter _loadFromButtonPresenter;
        [Inject] private IMessageDisplayerView _messageDisplayerView;

        public void LoadFrom()
        {
            try
            {
                _loadFromButtonPresenter.LoadStateFrom();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                _messageDisplayerView.DisplayExceptionMessage("Could not load!", ex.Message);
            }
        }
    }
}