using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool dead = false;
    bool shrinking = false;
    public float pumpUpSpeed;

    Vector2 velocity;
    float movementDrag;

    public AudioClip deflateSound;
    public AudioClip popSound;
    public AudioClip fallSound;

    public AudioSource bubbleAS;
    public AudioSource kidAS;

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
            if (!shrinking) bubbleObject.transform.localScale += new Vector3(pumpUpSpeed, pumpUpSpeed, pumpUpSpeed) * Time.deltaTime;

            //Move player unit to mouse cursor
            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, movementDrag);

            //Determine the max distance the cursor can be
            float maxTopEdge = GameMaster.instance.screenTopEdge - (bubbleObject.GetComponent<SpriteRenderer>().bounds.size.y);
            float maxBottomEdge = GameMaster.instance.screenBottomEdge;
            float maxLeftEdge = GameMaster.instance.screenLeftEdge + (bubbleObject.GetComponent<SpriteRenderer>().bounds.size.x / 2);
            float maxRightEdge = GameMaster.instance.screenRightEdge - (bubbleObject.GetComponent<SpriteRenderer>().bounds.size.x / 2);

            //Constrain player unit to within the window
            if (transform.position.y > maxTopEdge) transform.position = new Vector2(transform.position.x, maxTopEdge);
            if (transform.position.y < maxBottomEdge) transform.position = new Vector2(transform.position.x, maxBottomEdge);
            if (transform.position.x < maxLeftEdge) transform.position = new Vector2(maxLeftEdge, transform.position.y);
            if (transform.position.x > maxRightEdge) transform.position = new Vector2(maxRightEdge, transform.position.y);

        }
    }



    public void EndGame()
    {
        dead = true;

        bubbleAS.clip = popSound;
        bubbleAS.Play();

        kidAS.clip = fallSound;
        kidAS.Play();

        bubbleObject.GetComponent<SpriteRenderer>().enabled = false;
        kidObject.GetComponent<SpriteRenderer>().sprite = poppedSprite;
        LeanTween.moveY(gameObject, GameMaster.instance.screenBottomEdge - 2f, 1f);
        gameOverScreen.SetActive(true);
    }

    public void Deflate(float amount)
    {
        shrinking = true;

        LeanTween.value(bubbleObject.transform.localScale.x, bubbleObject.transform.localScale.x - amount, 1)
        .setOnUpdate((float value) =>
        {
            bubbleObject.transform.localScale = new Vector2(value, value);
        })
        .setEase(LeanTweenType.easeOutCubic)
        .setOnComplete(() =>
        {
            shrinking = false;
        });

        bubbleAS.clip = deflateSound;
        bubbleAS.Play();
    }
}