using Model.State;
using Services.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class BrickSpawnerService : IBrickSpawnerService
    {
        private Vector3 _placePosition = Vector3.zero;

        private Quaternion _rotation = Quaternion.Euler(0, 0, 0);
        private Quaternion _rotationModifier;

        public List<GameObject> BricksList { get; private set; } = new();

        public void SpawnTower(GameObject brickLevelPrefab, int height, float rotationAmmount,
            float yPosOffset)
        {
            DestroyTower();

            _rotationModifier = Quaternion.Euler(0, rotationAmmount, 0);

            for (int i = 1; i <= height; i++)
            {
                GameObject bricksLevel = Object.Instantiate(brickLevelPrefab, _placePosition, _rotation);

                if (i % 2 == 0)
                {
                    foreach (var brick in bricksLevel.GetComponentsInChildren<Renderer>())
                    {
                        brick.material.color = Color.gray;
                    }
                }

                _placePosition.y += yPosOffset;
                _rotation *= _rotationModifier;

                bricksLevel.transform.parent = GameObject.Find("Tower").transform;
                BricksList.Add(bricksLevel);
            }
        }

        public void LoadTower(GameObject brickPrefab, List<BrickState> brickList)
        {
            DestroyTower();

            foreach (BrickState brick in brickList)
            {
                Vector3 brickPos = new(brick.XPos, brick.YPos, brick.ZPos);
                Quaternion brickRot = new(brick.XRot, brick.YRot, brick.ZRot, brick.WRot);

                GameObject loadedBrick = Object.Instantiate(brickPrefab, brickPos, brickRot);

                Color color = new(brick.BrickColor[0], brick.BrickColor[1], brick.BrickColor[2]);
                loadedBrick.GetComponent<Renderer>().material.color = color;

                loadedBrick.transform.parent = GameObject.Find("Tower").transform;
                BricksList.Add(loadedBrick);
            }
        }

        public void DestroyTower()
        {
            if (BricksList != null)
            {
                foreach (var brick in BricksList)
                {
                    Object.Destroy(brick);
                }

                _placePosition = Vector3.zero;
                BricksList.Clear();
            }
        }
    }
}