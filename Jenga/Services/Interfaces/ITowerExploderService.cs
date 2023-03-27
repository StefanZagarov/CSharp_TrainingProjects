using System.Collections.Generic;
using UnityEngine;

namespace Services.Interfaces
{
    public interface ITowerExploderService
    {
        bool ExplodeTower(List<GameObject> brickList, float force);
        void IncreaseCounter();
        void ResetConditions();
        bool GetIsGameOver();
        void SetIsGameOver(bool set);
    }
}