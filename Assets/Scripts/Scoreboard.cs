using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    float height;
    public float heightGainRate;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        highscoreText.text = "Highscore: " + GameMaster.instance.highScore.ToString("F1") + "ft";
        LeanTween.value(heightGainRate, heightGainRate * 2, 60).setOnUpdate((value) =>
        {
            heightGainRate = value;
        });
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