using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject AboutDeveloper;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
    public void AboutDev()
    {
        AboutDeveloper.SetActive(true);
    }
    public void ExitAboutDev()
    {
        AboutDeveloper.SetActive(false);
    }
}
