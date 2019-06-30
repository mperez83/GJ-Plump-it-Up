using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflater : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    float moveAmountY;
    float rotateSpeed;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        float leftEdge = GameMaster.instance.screenLeftEdge + (sr.sprite.bounds.size.x / 2);
        float rightEdge = GameMaster.instance.screenRightEdge - (sr.sprite.bounds.size.x / 2);
        transform.position = new Vector2(Random.Range(leftEdge, rightEdge), GameMaster.instance.screenTopEdge + (sr.sprite.bounds.size.y / 2));

        moveAmountY = Random.Range(minSpeed, maxSpeed);
        rotateSpeed = (Random.Range(0, 2) == 0) ? Random.Range(100f, 200f) : Random.Range(-200f, -100f);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + (rotateSpeed * Time.deltaTime));
        transform.position = new Vector2(transform.position.x, transform.position.y - (moveAmountY * Time.deltaTime));
        if (transform.position.y < (GameMaster.instance.screenBottomEdge - (sr.sprite.bounds.size.y / 2)))
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