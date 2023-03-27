using UnityEngine;
using View.Interfaces;

namespace View
{
    public class PanelTogglerView : MonoBehaviour, IPanelTogglerView
    {
        [SerializeField] private GameObject _panel;

        public void TogglePanel()
        {
            bool isActive = _panel.activeSelf;

            _panel.SetActive(!isActive);
        }
    }
}