using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject thePauseButton;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        // Disable the pause button
        thePauseButton.SetActive(false);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        // Enable the pause button
        thePauseButton.SetActive(true);
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
    }


    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
