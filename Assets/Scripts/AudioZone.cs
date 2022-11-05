using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
    public int index;
    private AudioSource audioSource;
    private float countdownDelay = 0.75f;
    private float currentCountDownDelay;
    private int colliding;
    private void Awake()
    {
        currentCountDownDelay = countdownDelay;
        audioSource = GetComponent<AudioSource>();
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
                if (index > PlayAudio.Index)
                    PlayAudio.Index = index;
                currentCountDownDelay = countdownDelay;
            }
            else
                currentCountDownDelay -= Time.deltaTime;
        }
        else
        {
            if (index == PlayAudio.Index)
                PlayAudio.Index = index - 1;
            currentCountDownDelay = countdownDelay;
        }
    }
}
