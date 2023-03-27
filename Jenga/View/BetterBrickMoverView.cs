using UnityEngine;
using View.Interfaces;

public class BetterBrickMoverView : MonoBehaviour, IBrickMoverView
{
    private Vector3 _objectFromCamera;
    private Vector3 _offset;

    private Quaternion _lockRotation;

    private ICameraMoverView _cameraMoverView;

    // Instantiated objects cant use zenject injection as they appear after the injection, their injected fields return null
    private void Start()
    {
        _cameraMoverView = FindObjectOfType<CameraMoverView>();
    }

    void OnMouseDown()
    {
        _lockRotation = transform.rotation;

        _objectFromCamera = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _objectFromCamera.z));

        Cursor.visible = false;

        _cameraMoverView.IsMouseDown = true;
    }

    void OnMouseDrag()
    {
        float mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");

        Vector3 cursorScreenPoint = new(Input.mousePosition.x, Input.mousePosition.y, _objectFromCamera.z);

        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + _offset;

        if (mouseScroll > 0f)
        {
            _objectFromCamera += Vector3.forward;
        }
        else if (mouseScroll < 0f)
        {
            _objectFromCamera += Vector3.back;
        }

        transform.SetPositionAndRotation(currentPosition, _lockRotation);
    }

    private void OnMouseUp()
    {
        Cursor.visible = true;
        _cameraMoverView.IsMouseDown = false;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}