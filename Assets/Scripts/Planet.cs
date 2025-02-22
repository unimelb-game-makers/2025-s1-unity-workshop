using System;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    private int _health;

    private void Start()
    {
        _health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            // On collision with an asteroid, we want to reduce our health and destroy the asteroid
            ReduceHealth();
            Destroy(asteroid.gameObject);
        }
    }

    private void ReduceHealth()
    {
        // Reduce Health by 1
        _health -= 1;
        
        // Die if our health reaches 0
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
