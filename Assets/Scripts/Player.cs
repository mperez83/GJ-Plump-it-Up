using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool dead = false;
    public float pumpUpSpeed;

    Vector2 velocity;
    float movementDrag;

    public GameObject gameOverScreen;
    public GameObject bubbleObject;
    public GameObject kidObject;
    public Sprite poppedSprite;



    void Start()
    {
        LeanTween.value(0.1f, 0.8f, 30f).setOnUpdate((float value) =>
        {
            movementDrag = value;
        });
    }

    void Update()
    {
        if (!dead)
        {
            //Increase bubble size slightly
            bubbleObject.transform.localScale += new Vector3(pumpUpSpeed, pumpUpSpeed, pumpUpSpeed) * Time.deltaTime;

            //Move player unit to mouse cursor
            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, movementDrag);

            //Get the bubble positions
            float bubbleTop = bubbleObject.transform.position.y + (bubbleObject.GetComponent<SpriteRenderer>().bounds.size.y);
            float bubbleBottom = bubbleObject.transform.position.y - (bubbleObject.GetComponent<SpriteRenderer>().bounds.size.y);
            float bubbleLeft = bubbleObject.transform.position.x - (bubbleObject.GetComponent<SpriteRenderer>().bounds.size.x / 2f);
            float bubbleRight = bubbleObject.transform.position.x + (bubbleObject.GetComponent<SpriteRenderer>().bounds.size.x / 2f);

            //Constrain player unit to within the window
            //if (bubbleTop > GameMaster.instance.screenTopEdge) transform.position = new Vector2(transform.position.x, bubbleTop);
            //if (bubbleBottom < GameMaster.instance.screenBottomEdge) transform.position = new Vector2(transform.position.x, GameMaster.instance.screenBottomEdge);
            //if (bubbleLeft < GameMaster.instance.screenLeftEdge) transform.position = new Vector2(GameMaster.instance.screenLeftEdge, transform.position.y);
            //if (bubbleRight > GameMaster.instance.screenRightEdge) transform.position = new Vector2(GameMaster.instance.screenRightEdge, transform.position.y);
        }
    }

    public void EndGame()
    {
        dead = true;
        bubbleObject.GetComponent<SpriteRenderer>().enabled = false;
        kidObject.GetComponent<SpriteRenderer>().sprite = poppedSprite;
        LeanTween.moveY(gameObject, GameMaster.instance.screenBottomEdge - 2f, 1f);
        gameOverScreen.SetActive(true);
    }
}