using System;
using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField] 
    private int maxHealth = 5;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // On collision with an asteroid, we want to reduce our health and destroy the asteroid
            ReduceHealth();
        }
    }

    private void ReduceHealth()
    {
        // Reduce Health by 1
        health -= 1;
        
        // Die if our health reaches 0
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
