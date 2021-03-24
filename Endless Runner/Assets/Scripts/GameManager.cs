using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Variables
    public Transform platformGenerator;
    private Vector3 platformSpawnPoint;

    public PlayerController thePlayer;
    private Vector3 playerSpawnPoint;

    private ObjectDestroyer[] platformList;

    public ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

    public GameObject thePauseButton;

    public bool powerupReset;

    void Start()
    {
        // Set spawn points
        platformSpawnPoint = platformGenerator.position;
        playerSpawnPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        theScoreManager.scoreIncreasing = true;
    }


    public void RestartGame()
    {
        // Use a coroutine to enable a restart delay after death
        //StartCoroutine("RestartGameCo");

        // Disable the pause button
        thePauseButton.SetActive(false);

        // Stop score increasing
        theScoreManager.scoreIncreasing = false;

        // Remove the camera from the player before setting the player inactive
        Camera.main.transform.parent = null;

        // Death anim etc.
        thePlayer.gameObject.SetActive(false);

        // Enable the Death Menu canvas
        theDeathScreen.gameObject.SetActive(true);
    }


    public void Reset()
    {
        // Add the camera back to the player 
        Camera.main.transform.parent = thePlayer.transform;

        // Enable the Death Menu canvas
        theDeathScreen.gameObject.SetActive(false);

        // Enable the pause button
        thePauseButton.SetActive(true);

        //Delete platforms
        platformList = FindObjectsOfType<ObjectDestroyer>();
        foreach (ObjectDestroyer destroyer in platformList)
        {
            destroyer.gameObject.SetActive(false);
        }

        // Reset spawn points
        thePlayer.transform.position = playerSpawnPoint;
        platformGenerator.position = platformSpawnPoint;
        thePlayer.gameObject.SetActive(true);

        // Resume score increasing and reset to 0
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

        // Reset powerup effects
        powerupReset = true;
    }




    // Coroutine used to restart the game
    /* public IEnumerator RestartGameCo()
    {
        // Stop score increasing
        theScoreManager.scoreIncreasing = false;

        // Death anim etc.
        thePlayer.gameObject.SetActive(false);

        // Delay
        yield return new WaitForSeconds(2);

        //Delete platforms
        platformList = FindObjectsOfType<ObjectDestroyer>();
        foreach (ObjectDestroyer destroyer in platformList)
        {
            destroyer.gameObject.SetActive(false);
        }

        // Reset spawn points
        thePlayer.transform.position = playerSpawnPoint;
        platformGenerator.position = platformSpawnPoint;
        thePlayer.gameObject.SetActive(true);

        // Resume score increasing and reset to 0
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    } */





}
