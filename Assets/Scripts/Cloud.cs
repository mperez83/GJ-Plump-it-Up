using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public enum Distance { Close, Mid, Far };

    public float closeMinSpeed;
    public float closeMaxSpeed;

    public float midMinSpeed;
    public float midMaxSpeed;

    public float farMinSpeed;
    public float farMaxSpeed;

    float speed;



    public void Init(Distance cloudDist)
    {
        switch (cloudDist)
        {
            case Distance.Close:
                transform.localScale = new Vector2(2, 2);
                GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
                GetComponent<SpriteRenderer>().sortingOrder = 1;
                speed = Random.Range(closeMinSpeed, closeMaxSpeed);
                break;

            case Distance.Mid:
                GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                GetComponent<SpriteRenderer>().sortingOrder = 1;
                speed = Random.Range(midMinSpeed, midMaxSpeed);
                break;

            case Distance.Far:
                transform.localScale = new Vector2(0.5f, 0.5f);
                GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                GetComponent<SpriteRenderer>().sortingOrder = 1;
                speed = Random.Range(farMinSpeed, farMaxSpeed);
                break;
        }

        transform.position = new Vector2(Random.Range(GameMaster.instance.screenLeftEdge, GameMaster.instance.screenRightEdge), GameMaster.instance.screenTopEdge + (GetComponent<SpriteRenderer>().bounds.size.y / 2f));
    }

    void Update()
    {
        transform.Translate(new Vector2(0, -speed) * Time.deltaTime);
        if (transform.position.y < (GameMaster.instance.screenBottomEdge - (GetComponent<SpriteRenderer>().bounds.size.y / 2f)))
        {
            Destroy(gameObject);
        }
    }
}