using UnityEngine;

public class PanelCloser : MonoBehaviour
{
    //X button
    [SerializeField] private GameObject _menuPanel;

    private CameraManager _cameraControls;

    private void Awake()
    {
        _cameraControls = FindObjectOfType<CameraManager>();
    }

    public void Close()
    {
        _menuPanel.SetActive(false);
        _cameraControls.enabled = true;
    }
}