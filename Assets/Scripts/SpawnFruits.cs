using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    public GameObject[] Fruits;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            int rand = Random.Range(0, Fruits.Length);
            Instantiate(Fruits[rand], mousePos, Quaternion.identity);
        }
    }
}
