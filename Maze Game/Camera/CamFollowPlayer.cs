using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    private Transform _player;

    [SerializeField] private Vector3 _posOffset;
    [SerializeField] private float _lerpAmount = 4f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {              
        transform.position = Vector3.Lerp(transform.position, _player.position + _posOffset, _lerpAmount * Time.deltaTime);
    }    
}
