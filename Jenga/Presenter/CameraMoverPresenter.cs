using Presenter.Interfaces;
using Services.Interfaces;
using Zenject;

namespace Presenter
{
    public class CameraMoverPresenter : ICameraMoverPresenter
    {
        [Inject] private ICameraMoverService _cameraMoverService;

        public void MouseOrbit(float mouseAxisX, float orbitSpeed)
        {
            _cameraMoverService.MouseOrbit(mouseAxisX, orbitSpeed);
        }

        public void Zoom(float mouseScrollWheel, float zoomSpeed, float zoomInDistanceLimit, float zoomOutDistanceLimit)
        {
            _cameraMoverService.Zoom(mouseScrollWheel, zoomSpeed, zoomInDistanceLimit, zoomOutDistanceLimit);
        }

        public void Pan(float mouseAxisY)
        {
            _cameraMoverService.Pan(mouseAxisY);
        }
    }
}