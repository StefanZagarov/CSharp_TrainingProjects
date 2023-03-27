using UnityEngine;
using View.Interfaces;

namespace View
{
    public class GameOverScreenView : MonoBehaviour, IGameOverScreenView
    {
        public GameObject _canvas;

        public void DisplayGameOver(bool toggle)
        {
            _canvas.SetActive(toggle);
        }
    }
}