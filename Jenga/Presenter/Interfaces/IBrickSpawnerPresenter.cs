using Model.State;
using System.Collections.Generic;
using UnityEngine;

namespace Presenter.Interfaces
{
    public interface IBrickSpawnerPresenter
    {
        void SpawnTower(GameObject brickLevelPrefab, int height, float rotationAmmount, float yPosOffset,
             float cameraXRotation);

        //void LoadTower(GameObject brickPrefab, List<BrickState> brickList, CameraState cameraState);
    }
}