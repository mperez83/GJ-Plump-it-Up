using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, mousePos.y);

        if (transform.position.y > GameMaster.instance.screenTopEdge) transform.position = new Vector2(transform.position.x, GameMaster.instance.screenTopEdge);
        if (transform.position.y < GameMaster.instance.screenBottomEdge) transform.position = new Vector2(transform.position.x, GameMaster.instance.screenBottomEdge);
        if (transform.position.x < GameMaster.instance.screenLeftEdge) transform.position = new Vector2(GameMaster.instance.screenLeftEdge, transform.position.y);
        if (transform.position.x > GameMaster.instance.screenRightEdge) transform.position = new Vector2(GameMaster.instance.screenRightEdge, transform.position.y);
    }
}