using Model.State;
using Services.Interfaces;
using UnityEngine;

namespace Services
{
    public class CameraMoverService : ICameraMoverService
    {
        private float _clampYMin;
        private float _clampYMax;        

        public void MouseOrbit(float mouseAxisX, float orbitSpeed)
        {
            float mouseInput = mouseAxisX;

            if (Input.GetMouseButton(1))
            {
                Camera.main.transform.transform.RotateAround(Vector3.zero, Vector3.up, mouseInput * orbitSpeed * Time.deltaTime);
            }
        }

        public void Zoom(float mouseScrollWheel, float zoomSpeed, float zoomInDistanceLimit, float zoomOutDistanceLimit)
        {           
            float zoomInput = mouseScrollWheel;

            Camera.main.transform.Translate(new Vector3(0, 0, zoomInput * zoomSpeed * Time.deltaTime));

            bool raycastHit = Physics.Raycast(Camera.main.transform.transform.position,
                Camera.main.transform.transform.forward, out RaycastHit hit, 1000f,
                1 << LayerMask.NameToLayer("Raycast"));

            if (raycastHit)
            {
                if (hit.distance < zoomInDistanceLimit)
                {
                    Camera.main.transform.transform.Translate(new Vector3(0, 0, -2f));
                }
                else if (hit.distance > zoomOutDistanceLimit)
                {
                    Camera.main.transform.transform.Translate(new Vector3(0, 0, 10f));
                }
            }
            else if (!raycastHit)
            {
                Camera.main.transform.transform.Translate(new Vector3(0, 0, -10f));
            }
        }

        public void Pan(float mouseAxisY)
        {
            float panInput = mouseAxisY;

            if (Input.GetMouseButton(1))
            {
                Camera.main.transform.transform.position += new Vector3(0, -panInput, 0);
            }

            if (Camera.main.transform.transform.position.y < _clampYMin)
            {
                Camera.main.transform.transform.position = new Vector3(Camera.main.transform.transform.position.x,
                    _clampYMin, Camera.main.transform.transform.position.z);
            }
            else if (Camera.main.transform.transform.position.y > _clampYMax)
            {
                Camera.main.transform.transform.position = new Vector3(Camera.main.transform.transform.position.x,
                    _clampYMax, Camera.main.transform.transform.position.z);
            }
        }


        private void SetPosition(Vector3 camPos, Quaternion camRot, float clampY)
        {
            Camera.main.transform.transform.SetPositionAndRotation(camPos, camRot);

            _clampYMin = 1f;
            _clampYMax = clampY;
        }

        public void SetCamPosValues(int bricksCount, float cameraXRotation)
        {
            float zOffset = -3.5f;

            if (bricksCount <= 5)
            {
                zOffset = -1f;
            }
            else if (bricksCount <= 10)
            {
                zOffset = -2.2f;
            }
            else if (bricksCount < 25)
            {
                zOffset = -3f;
            }

            float clampY = bricksCount / 2.3f;
            Vector3 camPos = new(0, bricksCount / 2f, bricksCount / zOffset);
            Quaternion camRot = Quaternion.Euler(new Vector3(cameraXRotation, 0, 0));
            SetPosition(camPos, camRot, clampY);
        }

        public void SetLoadedCamPosValues(int bricksCount, CameraState cameraState)
        {
            float clampY = (bricksCount / 3) / 2.3f;
            Vector3 camPos = new(cameraState.XPos, cameraState.YPos, cameraState.ZPos);
            Quaternion camRot = Quaternion.Euler(new Vector3(cameraState.XRot, cameraState.YRot, 0));
            SetPosition(camPos, camRot, clampY);
        }
    }
}