using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject endMenu;

    private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused == false)
            {
                PauseGame();
            }
        }
    }

    public void StartGame()
    {
        UnPauseGame();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    #region Pause & UnPause functions

    private void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        pauseMenu.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseMenu.SetActive(false);
    }
    #endregion

    #region EndGame

    public void EndGame()
    {
        Time.timeScale = 0;
        endMenu.SetActive(true);
    }
    #endregion
}
