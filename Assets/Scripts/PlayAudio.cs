using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource[] audioZone;
    public static int Index;
    private int currentIndex;
    private void Awake()
    {
        Index = 0;
        currentIndex = Index;
    }
    private void Update()
    {
        if(currentIndex != Index)
        {
            for (int i = 0; i < audioZone.Length; i++)
            {
                audioZone[i].mute = true;
            }
            audioZone[Index].mute = false;
            currentIndex = Index;
        }
    }
}
