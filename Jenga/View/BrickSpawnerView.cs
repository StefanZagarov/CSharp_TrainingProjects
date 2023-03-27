using Presenter.Interfaces;
using UnityEngine;
using View.Interfaces;
using Zenject;

namespace View
{
    public class BrickSpawnerView : MonoBehaviour, IBrickSpawnerView
    {
        [SerializeField] private GameObject _brickLevelPrefab;
        [SerializeField] private GameObject _brickPrefab;

        [SerializeField] private float _spawnRotationAmmount = 0;

        [SerializeField] private float _yPositionSpawnOffset = 0;

        [SerializeField] private float _cameraXRotation = 0;

        [Inject]
        private IBrickSpawnerPresenter _brickSpawnerPresenter;

        private void Awake()
        {
            int randomHeight = Random.Range(3, 300);

            SpawnTower(randomHeight);

            Debug.Log(randomHeight);
        }

        public void SpawnTower(int height)
        {
            _brickSpawnerPresenter.SpawnTower(_brickLevelPrefab, height, _spawnRotationAmmount,
                _yPositionSpawnOffset, _cameraXRotation);
        }

        public GameObject GetBrickPrefab()
        {
            return _brickPrefab;
        }
    }
}