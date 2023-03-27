using Presenter.Interfaces;
using UnityEngine;
using View.Interfaces;
using Zenject;

public class CameraMoverView : MonoBehaviour, ICameraMoverView
{
    [SerializeField] private float _orbitSpeed;
    [SerializeField] private float _zoomSpeed;

    [SerializeField] private float _zoomInDistanceLimit;
    [SerializeField] private float _zoomOutDistanceLimit;

    [Inject] private ICameraMoverPresenter _cameraMoverPresenter;

    public bool IsMouseDown { get; set; } = false;

    private void Update()
    {
        CamControls();
    }

    private void CamControls()
    {
        MouseOrbit();
        Zoom();
        Pan();
    }

    public void MouseOrbit()
    {
        _cameraMoverPresenter.MouseOrbit(Input.GetAxisRaw("Mouse X"), _orbitSpeed);
    }

    public void Zoom()
    {
        if (IsMouseDown) return;

        _cameraMoverPresenter.Zoom(Input.GetAxisRaw("Mouse ScrollWheel"), _zoomSpeed, _zoomInDistanceLimit, _zoomOutDistanceLimit);
    }

    public void Pan()
    {
        _cameraMoverPresenter.Pan(Input.GetAxisRaw("Mouse Y"));
    }
}