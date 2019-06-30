using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    public RectTransform titleLogo;
    Vector2 titleLogoHomePos;
    float titleMainDeg;
    float titleSinVal;

    public RectTransform startButton;
    Vector2 sbHomePos;
    float sbMainDeg;
    float sbSinVal;
    float sbCosVal;

    public RectTransform exitButton;
    Vector2 ebHomePos;
    float ebMainDeg;
    float ebSinVal;
    float ebCosVal;

    public RectTransform kidBubble;
    float kbHomeScale;
    float kbMainDeg;
    float kbSinVal;

    public RectTransform kid;
    Vector2 kidHomePos;

    public TextMeshProUGUI highscoreText;



    void Start()
    {
        titleLogoHomePos = titleLogo.position;
        sbHomePos = startButton.position;
        ebHomePos = exitButton.position;
        kbHomeScale = kidBubble.localScale.x;
        kidHomePos = kid.position;

        highscoreText.text = "Highscore: " + GameMaster.instance.highScore.ToString("F1") + "ft";
    }

    void Update()
    {
        //Title logo sway
        titleSinVal = 6 * Mathf.Sin(titleMainDeg * Mathf.Deg2Rad);
        titleMainDeg += (360 * (1 / 5f)) * Time.deltaTime;
        if (titleMainDeg > 360) titleMainDeg = titleMainDeg - 360;
        titleLogo.position = new Vector2(titleLogoHomePos.x, titleLogoHomePos.y + titleSinVal);

        //Start button sway
        sbSinVal = 2 * Mathf.Sin(sbMainDeg * Mathf.Deg2Rad);
        sbCosVal = 2 * Mathf.Sin((sbMainDeg * 2) * Mathf.Deg2Rad);
        sbMainDeg += (360 * (1 / 6f)) * Time.deltaTime;
        if (sbMainDeg > 360) sbMainDeg = sbMainDeg - 360;
        startButton.position = new Vector2(sbHomePos.x + sbCosVal, sbHomePos.y + sbSinVal);

        //Exit button sway
        ebSinVal = 2 * Mathf.Sin(ebMainDeg * Mathf.Deg2Rad);
        ebCosVal = 2 * Mathf.Sin((ebMainDeg * 2) * Mathf.Deg2Rad);
        ebMainDeg += (360 * (1 / 10f)) * Time.deltaTime;
        if (ebMainDeg > 360) ebMainDeg = ebMainDeg - 360;
        exitButton.position = new Vector2(ebHomePos.x + ebCosVal, ebHomePos.y + ebSinVal);

        //Bubble undulate
        kbSinVal = 0.02f * Mathf.Sin(kbMainDeg * Mathf.Deg2Rad);
        kbMainDeg += (360 * (1 / 6f)) * Time.deltaTime;
        if (kbMainDeg > 360) kbMainDeg = kbMainDeg - 360;
        kidBubble.localScale = new Vector2(kbHomeScale + kbSinVal, kbHomeScale + kbSinVal);

        //Kid sway
        kid.position = new Vector2(kidHomePos.x, kidHomePos.y + (titleSinVal / 3));
    }



    public void StartButton()
    {
        LeanTween.cancelAll();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        GameMaster.instance.musicMaster.PlayGameMusic();
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}