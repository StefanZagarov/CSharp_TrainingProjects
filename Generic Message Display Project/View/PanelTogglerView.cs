using UnityEngine;

namespace MessageSystem.View
{
    public class PanelTogglerView : MonoBehaviour
    {
        [SerializeField] private GameObject _logPanel;

        public void TogglePanel()
        {
            bool isActive = _logPanel.activeSelf;

            _logPanel.SetActive(!isActive);
        }
    }
}