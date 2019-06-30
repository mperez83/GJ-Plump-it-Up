using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    bool facingLeft;
    float birdWidth;

    public float minSpeed;
    public float maxSpeed;
    Vector2 moveAmount;

    public float minScale;
    public float maxScale;

    Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();

        float scaleValue = Random.Range(minScale, maxScale);
        transform.localScale = new Vector2(scaleValue, scaleValue);
        birdWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        facingLeft = (Random.Range(0, 2) == 0) ? true : false;
        if (facingLeft)
        {
            transform.position = new Vector2(GameMaster.instance.screenRightEdge + (birdWidth / 2), Random.Range(GameMaster.instance.screenBottomEdge, GameMaster.instance.screenTopEdge));
            moveAmount = new Vector2(-Random.Range(minSpeed, maxSpeed), 0);
        }
        else
        {
            transform.position = new Vector2(GameMaster.instance.screenLeftEdge - (birdWidth / 2), Random.Range(GameMaster.instance.screenBottomEdge, GameMaster.instance.screenTopEdge));
            moveAmount = new Vector2(Random.Range(minSpeed, maxSpeed), 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Random.Range(0, 8192) == 69)
        {
            anim.Play("Shiny_Bird_Flap");
        }
    }

    void Update()
    {
        transform.Translate(moveAmount * Time.deltaTime);
        if (facingLeft)
        {
            if (transform.position.x < (GameMaster.instance.screenLeftEdge - (birdWidth / 2)))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.x > (GameMaster.instance.screenRightEdge + (birdWidth / 2)))
            {
                Destroy(gameObject);
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.transform.parent.gameObject;
            player.GetComponent<Player>().EndGame();
        }
    }
}