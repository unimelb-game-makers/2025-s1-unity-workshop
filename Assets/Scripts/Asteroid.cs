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

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
        Debug.Log("Collided with " + collision.gameObject);
    }
}
