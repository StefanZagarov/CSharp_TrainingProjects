using Presenter.Interfaces;
using System;
using UnityEngine;
using View.Interfaces;
using Zenject;

namespace View
{
    public class LoadButtonView : MonoBehaviour, ILoadButtonView
    {
        [Inject]
        ILoadButtonPresenter _loadButtonPresenter;

        public void LoadGame()
        {
            try
            {
                _loadButtonPresenter.LoadState(transform.parent.parent.name);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                Debug.LogWarning("No Save File!");
            }
        }
    }
}