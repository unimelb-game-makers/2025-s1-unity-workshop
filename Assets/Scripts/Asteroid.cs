using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 speed)
    {
        _rb.linearVelocity = speed;
    }
}
