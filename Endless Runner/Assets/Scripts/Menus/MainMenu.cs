using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject theMainMenu;
    public GameObject theHowToPlayMenu;


    public void PlayGame()
    {
        SceneManager.LoadScene("Endless Runner");
    }


    public void HowToPlay()
    {
        theHowToPlayMenu.SetActive(true);
        theMainMenu.SetActive(false);
    }


    public void BackButton()
    {
        theMainMenu.SetActive(true);
        theHowToPlayMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
