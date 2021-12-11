using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static bool gameIsPaused= false;
    public Button pauseButton;
    public Button playButton;
    // Start is called before the first frame update

    private void Start()
    {
       // gameIsPaused = false;
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
    void FixedUpdate()
    {
    }

    public void PauseGame()
    {
        pauseButton.gameObject.SetActive(false);
       
        playButton.interactable = true;
        playButton.gameObject.SetActive(true);
        gameIsPaused = true;

        Time.timeScale = 0f;
     



    }
    public void ResumeGame()
    {
        playButton.gameObject.SetActive(false);
       
        pauseButton.gameObject.SetActive(true);
        pauseButton.enabled = true;
        gameIsPaused = false;
        Time.timeScale = 1;
  
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Level 1");

    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    
}
