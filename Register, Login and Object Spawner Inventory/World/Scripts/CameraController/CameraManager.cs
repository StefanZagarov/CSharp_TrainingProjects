using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0f;
    [SerializeField] private float _scrollSpeed = 0f;
    [SerializeField] private float _panSpeed = 0f;
    [SerializeField] private float _yAxisSpeed = 0f;
    [SerializeField] private float _cameraRotationSpeed = 0f;
    [SerializeField] private float _speedMultiplier = 0f;
    [SerializeField] private float _zoomSpeedMultiplier = 0f;
    [Space(5)]
    [SerializeField] private float _movementSmoothing = 0f;
    [SerializeField] private bool _invertRotation;

    private Vector3 _move;
    private Vector3 _yAxisTransform;

    private void Update()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 totalInput = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (totalInput != Vector3.zero)
        {
            _move = totalInput;
        }
        else
        {
            _move = Vector3.Lerp(_move, totalInput, _movementSmoothing * Time.deltaTime);
        }
        transform.Translate(_moveSpeed * Time.deltaTime * _move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(_speedMultiplier * Time.deltaTime * _move);
        }

        ZoomMove();
        YAxisMove();
        CameraRotationAndPanning();
    }

    private void ZoomMove()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Move(Vector3.forward, _zoomSpeedMultiplier);
            }
            else
            {
                Move(Vector3.forward, _scrollSpeed);
            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Move(Vector3.back, _zoomSpeedMultiplier);
            }
            else
            {
                Move(Vector3.back, _scrollSpeed);
            }
        }
    }

    private void YAxisMove()
    {
        float yAxisInput = Input.GetAxisRaw("Jump");
        Vector3 yAxisMove = new Vector3(0, yAxisInput, 0);

        if (yAxisMove != Vector3.zero)
        {
            _yAxisTransform = yAxisMove;
        }
        else
        {
            _yAxisTransform = Vector3.Lerp(_yAxisTransform, yAxisMove, _movementSmoothing * Time.deltaTime);
        }
        transform.position += _yAxisSpeed * Time.deltaTime * _yAxisTransform;
    }

    private void CameraRotationAndPanning()
    {
        float mouseAxisY = Input.GetAxisRaw("Mouse Y");
        float mouseAxisX = Input.GetAxisRaw("Mouse X");

        Vector3 mouseRotation = new Vector3(mouseAxisY, -mouseAxisX, 0f);

        if (!_invertRotation && Input.GetMouseButton(1))
        {
            transform.eulerAngles += mouseRotation * _cameraRotationSpeed;
        }
        else if (_invertRotation && Input.GetMouseButton(1))
        {
            transform.eulerAngles += -mouseRotation * _cameraRotationSpeed;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 forward = transform.forward;
            forward.y = 0; //ignore Y axis to stay on same height

            Vector3 moveForward = forward * -mouseAxisY * _panSpeed;
            Vector3 moveRight = transform.right * -mouseAxisX * _panSpeed;

            transform.position += moveForward + moveRight;
        }
    }

    private void Move(Vector3 transformPos, float speed)
    {
        transform.Translate(transformPos * speed * Time.deltaTime);
    }
}