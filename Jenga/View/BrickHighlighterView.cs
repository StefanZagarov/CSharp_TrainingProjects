using UnityEngine;
using UnityEngine.EventSystems;
using View.Interfaces;

namespace View
{
    public class BrickHighlighterView : MonoBehaviour, IBrickHighlighterView
    {
        private Color _highlightColor;
        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _highlightColor = _renderer.material.color;
        }

        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            _renderer.material.color = Color.yellow;
        }

        private void OnMouseExit()
        {
            _renderer.material.color = _highlightColor;
        }
    }
}