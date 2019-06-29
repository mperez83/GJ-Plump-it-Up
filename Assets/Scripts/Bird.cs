using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    bool facingLeft;

    public float minSpeed;
    public float maxSpeed;
    Vector2 moveAmount;

    void Start()
    {
        facingLeft = (Random.Range(0, 2) == 0) ? true : false;
        if (facingLeft)
        {
            transform.position = new Vector2(GameMaster.instance.screenRightEdge, Random.Range(GameMaster.instance.screenBottomEdge, GameMaster.instance.screenTopEdge));
            moveAmount = new Vector2(-Random.Range(minSpeed, maxSpeed), 0);
        }
        else
        {
            transform.position = new Vector2(GameMaster.instance.screenLeftEdge, Random.Range(GameMaster.instance.screenBottomEdge, GameMaster.instance.screenTopEdge));
            moveAmount = new Vector2(Random.Range(minSpeed, maxSpeed), 0); 
        }

        if (Random.Range(0, 4200) == 69) moveAmount *= 100;
    }

    void Update()
    {
        transform.Translate(moveAmount * Time.deltaTime);
        if (facingLeft)
        {
            if (transform.position.x < GameMaster.instance.screenLeftEdge)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.x > GameMaster.instance.screenRightEdge)
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