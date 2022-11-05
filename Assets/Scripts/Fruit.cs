using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int value;
    public GameObject nextFruit;
    [HideInInspector] public bool started;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (started)
            return;
        if (collision.CompareTag("Fruit"))
        {
            GameObject thisFruit = transform.parent.gameObject;
            GameObject thatFruit = collision.transform.parent.gameObject;

            if (thisFruit.name == thatFruit.name)
            {
                collision.GetComponent<Fruit>().started = true;
                started = true;
                Score.score += value;
                Vector2 diff = (collision.transform.position + transform.position)/2;
                if(nextFruit != null)
                    Instantiate(nextFruit, diff, Quaternion.identity);
                if (thatFruit != null)
                    Destroy(thatFruit);
                Destroy(thisFruit);
            }
        }
    }
}
