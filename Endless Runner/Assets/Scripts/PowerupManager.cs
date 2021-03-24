using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    // Variables 
    private bool doublePoints;
    private bool obstacleRemover;
    private bool powerupActive;

    private float powerupDurationCounter;

    private ScoreManager theScoreManager;
    private PlatformSpawner thePlatformSpawner;
    private GameManager theGameManager;

    private float normalPointsPerSecond;
    private float obstacleRate;

    private ObjectDestroyer[] obstacleList;

     


    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformSpawner = FindObjectOfType<PlatformSpawner>();
        theGameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (powerupActive)
        {
            // Start counting down
            powerupDurationCounter -= Time.deltaTime;

            // Remove all currect powerups when the player dies
            if (theGameManager.powerupReset)
            {
                powerupDurationCounter = 0;
                theGameManager.powerupReset = false;
            }

            // Powerup effects
            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2.5f;
                theScoreManager.pointsDouble = true;
            }

            if (obstacleRemover)
            {
                thePlatformSpawner.randomObstacleThreshold = 0f;
            }

            // End powerup
            if (powerupDurationCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                thePlatformSpawner.randomObstacleThreshold = obstacleRate;

                powerupActive = false;
                theScoreManager.pointsDouble = false;
            }
        }
    }

    // Take in the type of powerup and duration 
    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        obstacleRemover = safe;
        powerupDurationCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        obstacleRate = thePlatformSpawner.randomObstacleThreshold;


        // If obstacleRemover has been picked up, delete current obstacles
        if (obstacleRemover)
        {
            obstacleList = FindObjectsOfType<ObjectDestroyer>();
            foreach (ObjectDestroyer destroyer in obstacleList)
            {
                if (destroyer.gameObject.name.Contains("Obstacle"))
                {
                    destroyer.gameObject.SetActive(false);
                }
            }
        }
        

        powerupActive = true;
    }





}
