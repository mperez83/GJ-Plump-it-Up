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

    void OnEnable()
    {
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

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}