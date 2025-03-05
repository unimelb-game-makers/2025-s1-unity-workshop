using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rb;

    private int health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 speed, int maxHealth)
    {
        health = maxHealth;
        rb.linearVelocity = speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            Destroy(gameObject);
        }
        else
        {
            TakeDamage(1);
        }
        Debug.Log("Collided with " + collision.gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
