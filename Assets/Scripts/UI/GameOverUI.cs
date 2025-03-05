using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject overlay;

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneChanged;
        Earth.OnDead += OnDead;
    }

    void SceneChanged(Scene scene, LoadSceneMode sceneMode)
    {
        overlay = GameObject.Find("Game Over Overlay");
        overlay.SetActive(false);
        Debug.Assert(overlay != null);
        Debug.Log("Found GameObject!");
    }

    private void OnDead()
    {
        overlay.SetActive(true); 
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
