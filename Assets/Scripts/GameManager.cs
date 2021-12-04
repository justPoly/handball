using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted;
    public static bool gameIsPaused;
   
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGameStarted = true;
    }
    public void PauseGame()
    {
        gameIsPaused = true;
        //if (gameIsPaused == true)

        Time.timeScale = 0f;

        /* else
         {
             Time.timeScale = 1;
         }*/
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
