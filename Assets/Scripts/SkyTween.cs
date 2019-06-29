using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTween : MonoBehaviour
{
    public float tweenLengthSeconds;

    void Start()
    {
        LeanTween.moveY(gameObject, -15, tweenLengthSeconds);
    }
}