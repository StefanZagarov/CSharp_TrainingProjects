using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _camera;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
}
