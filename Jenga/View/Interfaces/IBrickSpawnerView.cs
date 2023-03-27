using UnityEngine;

namespace View.Interfaces
{
    public interface IBrickSpawnerView
    {
        void SpawnTower(int height);
        GameObject GetBrickPrefab();
    }
}