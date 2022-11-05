using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public static int score;
    private void Update()
    {
        currentScoreText.text = "Score" + '\n' + score.ToString();
        highScoreText.text = "High Score" + '\n' + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
