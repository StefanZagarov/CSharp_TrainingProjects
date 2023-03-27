using UnityEngine;
using TMPro;
using Zenject;
using View.Interfaces;

namespace View
{
    public class LevelSelectorView : MonoBehaviour, ILevelSelectorView
    {
        [SerializeField] private TMP_InputField _inputField;

        [Inject]
        private IBrickSpawnerView _brickSpawnerView;

        public void ChangeHeight()
        {
            if (string.IsNullOrEmpty(_inputField.text)) return;

            int level = int.Parse(_inputField.text);

            if (level < 3)
            {
                _inputField.text = "Level too small";
                return;
            }

            if (level > 300)
            {
                _inputField.text = "Level too big";
                return;
            }

            _brickSpawnerView.SpawnTower(level);
        }
    }
}