using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject overlay;
    private void OnLevelWasLoaded()
    {
        Earth.OnDead += OnDead;
        overlay.gameObject.SetActive(false);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        overlay.gameObject.SetActive(false);
    }


    private void OnDead()
    {
        overlay.gameObject.SetActive(true); 
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void TitleButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
