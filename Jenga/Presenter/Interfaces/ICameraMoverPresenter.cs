namespace Presenter.Interfaces
{
    public interface ICameraMoverPresenter
    {
        void MouseOrbit(float mouseAxisX, float orbitSpeed);
        void Zoom(float mouseScrollWheel, float zoomSpeed, float zoomInDistanceLimit, float zoomOutDistanceLimit);
        void Pan(float mouseAxisY);
    }
}