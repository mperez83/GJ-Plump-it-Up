using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlayer : MonoBehaviour
{
    public Sprite idleKid;
    public Sprite readyKid;

    public GameObject actualPlayer;
    public SkyTween skyTween;

    public GameObject arrow;
    Vector2 arrowAnchorPos;
    float arrowMainDeg;
    float arrowSinVal;

    SpriteRenderer sr;



    void Awake()
    {
        Time.timeScale = 0;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = idleKid;
        arrowAnchorPos = arrow.transform.position;
    }

    void Update()
    {
        //Arrow sway
        arrowSinVal = 0.3f * Mathf.Sin(arrowMainDeg * Mathf.Deg2Rad);
        arrowMainDeg += (360 * (1 / 5f)) * 0.01f;
        if (arrowMainDeg > 360) arrowMainDeg = arrowMainDeg - 360;
        arrow.transform.position = new Vector2(arrowAnchorPos.x, arrowAnchorPos.y + arrowSinVal);
    }

    private void OnMouseEnter()
    {
        sr.sprite = readyKid;
    }

    private void OnMouseExit()
    {
        sr.sprite = idleKid;
    }

    void OnMouseDown()
    {
        Time.timeScale = 1;
        actualPlayer.SetActive(true);
        skyTween.Init();
        Destroy(gameObject);
    }
}