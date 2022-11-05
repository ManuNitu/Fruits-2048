using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Drag_n_Drop : MonoBehaviour
{
    public List<GameObject> Fruits;
    public Image nextFruit;
    public float dropCooldown;
    private float maxDistance;
    private bool dragging;
    Vector2 mousePos;
    Vector2 startPos;
    private SpriteRenderer sprite;
    private int fruitIndex;
    private int nextFruitIndex;
    private bool onCooldown;
    private void Awake()
    {
        nextFruitIndex = Random.Range(0, Fruits.Count);
        sprite = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        StartCoroutine(GetRandomFruit(0f));
    }
    private void Update()
    {
        if (UserInterface.paused || !sprite.enabled)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            dragging = true;
        }
        else if (Input.GetMouseButtonUp(0) && dragging)
        {
            dragging = false;
            DropFruit();
        }

        if (dragging && !onCooldown && !UserInterface.paused)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = Mathf.Clamp(mousePos.x, -maxDistance, maxDistance);
            Vector2 dirr = mousePos - (Vector2)transform.position;
            dirr.y = 0f;
            if (dirr.x > 0 && transform.position.x >= maxDistance || dirr.x < 0 && transform.position.x <= -maxDistance)
            {
                if (transform.position.x > 0)
                    transform.position = new Vector2(maxDistance,transform.position.y);
                if(transform.position.x < 0)
                    transform.position = new Vector2(-maxDistance, transform.position.y);
                return; 
            }
            transform.Translate(dirr);
        }
    }
    void DropFruit()
    {
        Instantiate(Fruits[fruitIndex], transform.position, Quaternion.identity);
        StartCoroutine(GetRandomFruit(dropCooldown));
    }
    IEnumerator GetRandomFruit(float cooldown)
    {
        onCooldown = true;
        sprite.enabled = false;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
        sprite.enabled = true;

        //current fruit
        fruitIndex = nextFruitIndex;
        transform.localScale = Fruits[fruitIndex].transform.localScale;
        sprite.sprite = Fruits[fruitIndex].GetComponent<SpriteRenderer>().sprite;
        maxDistance = 2.3f - 0.1f * (transform.localScale.x / 0.2f);
        transform.position = startPos;

        //next fruit
        nextFruitIndex = Random.Range(0, Fruits.Count);
        nextFruit.sprite = Fruits[nextFruitIndex].GetComponent<SpriteRenderer>().sprite;
    }
}
