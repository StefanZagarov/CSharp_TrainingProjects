using Model.State;

namespace Services.Interfaces
{
    public interface ICameraMoverService
    {      
        void MouseOrbit(float mouseAxisX, float orbitSpeed);
        void Zoom(float mouseScrollWheel, float zoomSpeed, float zoomInDistanceLimit, float zoomOutDistanceLimit);
        void Pan(float mouseAxisY);
        void SetCamPosValues(int bricksCount, float cameraXRotation);
        void SetLoadedCamPosValues(int bricksCount, CameraState cameraState);
    }
}