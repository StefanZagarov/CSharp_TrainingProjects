using UnityEngine;

public class OldPlayerMovement : MonoBehaviour
{
    private Rigidbody _player;
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    void HandlePlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _player.AddForce(0, 0, speed * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _player.AddForce(0, 0, -speed * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _player.AddForce(-speed * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _player.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
    }
}
