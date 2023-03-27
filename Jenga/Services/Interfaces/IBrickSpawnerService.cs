using Model.State;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Interfaces
{
    public interface IBrickSpawnerService
    {
        List<GameObject> BricksList { get; }
        void SpawnTower(GameObject brickLevelPrefab, int height, float rotationAmmount,
            float yPosOffset);
        void LoadTower(GameObject brickPrefab, List<BrickState> brickList);
        void DestroyTower();
    }
}