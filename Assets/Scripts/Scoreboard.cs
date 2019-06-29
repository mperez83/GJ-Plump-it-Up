using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    float height;
    public float heightGainRate;

    public TextMeshProUGUI scoreText;

    void Start()
    {

    }

    void Update()
    {
        height += (heightGainRate * Time.deltaTime);
        scoreText.text = "Height: " + Mathf.Floor(height).ToString() + "ft";
    }

    public float GetHeight()
    {
        return height;
    }
}