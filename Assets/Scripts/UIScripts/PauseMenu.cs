using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public TimeManagerScript timeManager;

    void Update()
    {
        if (GameIsPaused)
            Pause();
        else
            Resume();
    }

    public void PauseGame() //Button func
    {
        GameIsPaused = true;
        pauseButton.SetActive(false);
    }

    public void ResumeGame() //Button func
    {
        GameIsPaused = false;
        pauseButton.SetActive(true);
    }

    public void MainMenu() //Button func
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;

        Time.timeScale = timeManager.currentTimeScale;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
