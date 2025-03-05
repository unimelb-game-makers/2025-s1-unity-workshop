using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static int Score;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private int astroidScoreValue = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        Asteroid.Destroyed += IncrementScore;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void IncrementScore()
    {
        Score += astroidScoreValue;
        scoreText.text = Score.ToString("0000");
        Debug.Log($"Score {Score}");
    }
}
