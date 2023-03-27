using UnityEngine;
using UnityEngine.EventSystems;
using View.Interfaces;

namespace View
{
    public class BrickMoverView : MonoBehaviour, IBrickMoverView
    {
        private Vector3 _offset;
        private float _mouseZCoord;

        void OnMouseDown()
        {
            _mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            _offset = gameObject.transform.position - GetMouseAsWorldPoint();
        }

        void OnMouseDrag()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            transform.position = GetMouseAsWorldPoint() + _offset;
        }

        public Vector3 GetMouseAsWorldPoint()
        {
            Vector3 mousePoint = Input.mousePosition;

            mousePoint.z = _mouseZCoord;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
    }
}