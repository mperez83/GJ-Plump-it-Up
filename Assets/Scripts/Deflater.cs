using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflater : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    float moveAmountY;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        float leftEdge = GameMaster.instance.screenLeftEdge + (sr.sprite.bounds.size.x / 2);
        float rightEdge = GameMaster.instance.screenRightEdge - (sr.sprite.bounds.size.x / 2);
        transform.position = new Vector2(Random.Range(leftEdge, rightEdge), GameMaster.instance.screenTopEdge);

        moveAmountY = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(new Vector2(0, -moveAmountY) * Time.deltaTime);
        if (transform.position.y < (GameMaster.instance.screenBottomEdge - sr.sprite.bounds.size.y))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.transform.parent.gameObject;
            player.GetComponent<Player>().Deflate(0.25f);
            Destroy(gameObject);
        }
    }
}