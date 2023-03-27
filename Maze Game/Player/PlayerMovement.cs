using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;

    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _rotationSpeed = 0f;    

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementInputHandler();
    }

    private void MovementInputHandler()
    {
        float horizonalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizonalInput, 0, verticalInput).normalized; //normalize works by making sure that when we press two keys and go diagonally we wont move faster than intended

        _controller.Move(movementDirection * _speed * Time.deltaTime);

        if (movementDirection != Vector3.zero /*.magnitude >= 0.1f*/)
        {
            _animator.SetBool("isMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }
}
