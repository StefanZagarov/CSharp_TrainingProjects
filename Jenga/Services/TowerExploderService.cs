using Services.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class TowerExploderService : ITowerExploderService
    {
        private int _counter = 0;
        private bool _isGameOver = false;
        public bool ExplodeTower(List<GameObject> brickList, float force)
        {
            if (_counter > 3 && !_isGameOver)
            {
                foreach (var brick in brickList)
                {
                    brick.GetComponentInChildren<Rigidbody>().AddForce(Random.Range(-force, force), Random.Range(-force, force), Random.Range(-force, force), ForceMode.VelocityChange);
                }
                _isGameOver = true;
                return true;
            }
            return false;
        }

        public bool GetIsGameOver()
        {
            return _isGameOver;
        }

        public void SetIsGameOver(bool set)
        {
            _isGameOver = set;
        }

        public void IncreaseCounter()
        {
            _counter++;
        }

        public void ResetConditions()
        {
            _counter = 0;
            _isGameOver = false;
        }
    }
}