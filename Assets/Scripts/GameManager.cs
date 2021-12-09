using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
   
    // Start is called before the first frame update

    public void PauseGame()
    {
      
        Time.timeScale = 0f;

      
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");

    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
