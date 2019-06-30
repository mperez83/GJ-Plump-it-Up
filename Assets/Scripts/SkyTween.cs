using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTween : MonoBehaviour
{
    public float tweenLengthSeconds;
    public GameObject groundKids;

    public void Init()
    {
        LeanTween.moveY(groundKids, -10, 1).setOnComplete(() =>
        {
            Destroy(groundKids);
        });
        LeanTween.moveY(gameObject, -15, tweenLengthSeconds);
    }
}