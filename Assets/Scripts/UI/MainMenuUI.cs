using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
