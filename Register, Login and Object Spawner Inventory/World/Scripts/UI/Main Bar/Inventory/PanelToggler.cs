using UnityEngine;

public class PanelToggler : MonoBehaviour
{
    //Panel open and close

    [SerializeField] private GameObject _barButton;
    [SerializeField] private GameObject _menuPanel;

    //disable controls when panel is open, also in PanelCloser
    private CameraManager _cameraControls;

    private void Awake()
    {
        _cameraControls = FindObjectOfType<CameraManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menuPanel.SetActive(false);
        }
    }

    public void TogglePanel()
    {
        if (!_menuPanel.activeSelf)
        {
            FindObjectOfType<MenuCanvas>().ClosePreviousPanel();
        }

        bool isActive = _menuPanel.activeSelf;
        _menuPanel.SetActive(!isActive);

        if (!isActive)
        {
            _cameraControls.enabled = false;
        }
        else
        {
            _cameraControls.enabled = true;
        }
    }
}