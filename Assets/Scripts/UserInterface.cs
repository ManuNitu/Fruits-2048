using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UserInterface : MonoBehaviour
{
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI highScore;
    public GameObject NewHighScoreIndicator;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public static bool paused;
    private void Awake()
    {
        Time.timeScale = 1f;
        Score.score = 0;
        paused = false;
    }
    public void Pause()
    {
        if (!paused)
        {
            paused = true;
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
            Resume();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        paused = false;
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Update()
    {
        if (!GameOverPanel.activeSelf)
            return;

        if(Score.score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score.score);
            NewHighScoreIndicator.SetActive(true);
        }
        yourScore.text = Score.score.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();

    }
}
