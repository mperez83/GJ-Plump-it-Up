using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public Scoreboard scoreboard;
    public TextMeshProUGUI finalHeightText;
    public TextMeshProUGUI newHighscoreText;

    public RectTransform restartButton;
    Vector2 rbHomePos;
    float rbMainDeg;
    float rbSinVal;
    float rbCosVal;

    public RectTransform menuButton;
    Vector2 mbHomePos;
    float mbMainDeg;
    float mbSinVal;
    float mbCosVal;



    void OnEnable()
    {
        rbHomePos = restartButton.position;
        mbHomePos = menuButton.position;

        LeanTween.cancel(scoreboard.gameObject);
        scoreboard.heightGainRate = 0;

        float finalScore = scoreboard.GetHeight();

        finalHeightText.text = "Final Height: " + finalScore.ToString("F1") + "ft";
        if (finalScore > GameMaster.instance.highScore)
        {
            GameMaster.instance.highScore = finalScore;
            newHighscoreText.text = "New Highscore!";
        }
    }

    private void Update()
    {
        //Restart button sway
        rbSinVal = 2 * Mathf.Sin(rbMainDeg * Mathf.Deg2Rad);
        rbCosVal = 2 * Mathf.Sin((rbMainDeg * 2) * Mathf.Deg2Rad);
        rbMainDeg += (360 * (1 / 6f)) * Time.deltaTime;
        if (rbMainDeg > 360) rbMainDeg = rbMainDeg - 360;
        restartButton.position = new Vector2(rbHomePos.x + rbCosVal, rbHomePos.y + rbSinVal);

        //Menu button sway
        mbSinVal = 2 * Mathf.Sin(mbMainDeg * Mathf.Deg2Rad);
        mbCosVal = 2 * Mathf.Sin((mbMainDeg * 2) * Mathf.Deg2Rad);
        mbMainDeg += (360 * (1 / 10f)) * Time.deltaTime;
        if (mbMainDeg > 360) mbMainDeg = mbMainDeg - 360;
        menuButton.position = new Vector2(mbHomePos.x + mbCosVal, mbHomePos.y + mbSinVal);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {
        GameMaster.instance.musicMaster.PlayMenuMusic();
        SceneManager.LoadScene("MainMenu");
    }
}