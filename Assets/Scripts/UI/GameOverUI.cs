using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private void Awake()
    {
        Earth.OnDead += OnDead;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDead()
    {
        gameObject.SetActive(true);
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void TitleButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
