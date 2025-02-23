using System;
using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    private int _health;

    public static Action<int> OnHealthChanged;
    public static Action OnDead;

    private void Start()
    {
        _health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // On collision with an asteroid, we want to reduce our health and destroy the asteroid
            ReduceHealth();
            Destroy(collision.gameObject);
        }
    }

    private void ReduceHealth()
    {
        // Reduce Health by 1
        _health -= 1;
        
        OnHealthChanged?.Invoke(_health);
        // Die if our health reaches 0
        if (_health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
