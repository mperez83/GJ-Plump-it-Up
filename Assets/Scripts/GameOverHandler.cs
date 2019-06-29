using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public Scoreboard scoreboard;
    public TextMeshProUGUI finalHeightText;

    void OnEnable()
    {
        scoreboard.heightGainRate = 0;
        finalHeightText.text = "Final Height: " + scoreboard.GetHeight().ToString("F1") + "ft";
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