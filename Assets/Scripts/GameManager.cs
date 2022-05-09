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
    public Button Reload;
    public Button Quit;

    public AudioClip gameOver;
    public AudioSource endGame;
   // public Kicking kicking;

    
    // Start is called before the first frame update

    private void Start()
    {
       // kicking = FindObjectOfType<Kicking>().GetComponent<Kicking>();
       // gameIsPaused = false;
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Reload.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
    }

    public void PauseGame()
    {
        pauseButton.gameObject.SetActive(false);
        Reload.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        playButton.interactable = true;
        playButton.gameObject.SetActive(true);
        gameIsPaused = true;

        Time.timeScale = 0f;
     



    }
    public void ResumeGame()
    {
        playButton.gameObject.SetActive(false);
        Reload.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
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
        endGame.PlayOneShot(gameOver, 0.2f);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("quit!");
        Application.Quit();
    }

}
