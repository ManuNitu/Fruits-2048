using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RedLine : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject countdownPanel;
    public TextMeshProUGUI countdown;
    private Animator anim;
    private float countdownDelay = 0.75f;
    private float currentCountDownDelay;
    private float time = 4;
    private float currentTime;
    private int colliding;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentTime = time;
        currentCountDownDelay = countdownDelay;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            colliding++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            colliding--;
        }
    }
    private void Update()
    {
        if (colliding > 0)
        {
            if (currentCountDownDelay <= 0)
            {
                anim.SetBool("flash", true);
                currentTime -= Time.deltaTime;
            }
            else
                currentCountDownDelay -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("flash", false);
            currentCountDownDelay = countdownDelay;
            currentTime = time;
        }

        if ((int)currentTime < time)
        {
            if (currentTime < 1)
            {
                countdownPanel.SetActive(false);
                gameOverPanel.SetActive(true);
                UserInterface.paused = true;
                Time.timeScale = 0f;
            }
            else
            {
                if (!countdownPanel.activeSelf)
                    countdownPanel.SetActive(true);
                countdown.text = ((int)currentTime).ToString();
            }
        }
        else
        {
            if (countdownPanel.activeSelf)
                countdownPanel.SetActive(false);
        }
    }
}
