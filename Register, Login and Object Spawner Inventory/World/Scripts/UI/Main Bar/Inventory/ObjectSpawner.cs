using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSpawner : MonoBehaviour
{
    //To fix: WASD highlights buttons when the panel is open, Space triggers the button
    [SerializeField] private float _rotationAmmount = 0f;
    [SerializeField] private float _snapRotationAmmount = 45f;

    private GameObject _objectPreview;
    private static bool _isPreview = false;

    private LayerMask _mask;

    private void Awake()
    {
        _mask = 1 << LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        if (_objectPreview is null) return;

        MovePreview();
        MouseControls(_objectPreview);

        if (!_isPreview)
        {
            _objectPreview = null;
        }
    }

    public void InstantiateObject(GameObject objectToSpawn)
    {
        _objectPreview = Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
        _isPreview = true;
    }

    //Mouse methods
    private void MouseControls(GameObject gameObject)
    {
        RotatePreview();

        //If the mouse is over an UI left click wont place the object
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            _isPreview = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            _isPreview = false;
        }
    }

    private bool IsMouseOverUI() //checks if cursor is over an UI element
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void MovePreview()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit mouseHitPosition, Mathf.Infinity, _mask))
        {
            _objectPreview.transform.position = mouseHitPosition.point;
        }
    }

    private void RotatePreview()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            _objectPreview.transform.Rotate(0, _snapRotationAmmount, 0);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _objectPreview.transform.Rotate(0, -_snapRotationAmmount, 0);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            _objectPreview.transform.Rotate(0, _rotationAmmount, 0);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _objectPreview.transform.Rotate(0, -_rotationAmmount, 0);
        }
    }
}