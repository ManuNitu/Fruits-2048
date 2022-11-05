using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    private void Awake()
    {
        Time.timeScale = 1f;

        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    private void Update()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
