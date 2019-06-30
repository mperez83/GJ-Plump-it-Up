using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    [HideInInspector]
    public float highScore = 0;

    [HideInInspector]
    public float screenTopEdge;
    [HideInInspector]
    public float screenBottomEdge;
    [HideInInspector]
    public float screenLeftEdge;
    [HideInInspector]
    public float screenRightEdge;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this);

        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        //Constantly update the screen bounds (could be performance taxing?)
        screenTopEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -(Camera.main.transform.position.z))).y;
        screenBottomEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -(Camera.main.transform.position.z))).y;
        screenLeftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -(Camera.main.transform.position.z))).x;
        screenRightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -(Camera.main.transform.position.z))).x;
    }
}