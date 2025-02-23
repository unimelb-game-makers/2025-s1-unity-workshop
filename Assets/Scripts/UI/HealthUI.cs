using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;

    private void Awake()
    {
        Earth.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        healthText.SetText($"HEALTH: {health}");
    }
}
