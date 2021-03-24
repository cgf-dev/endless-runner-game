using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    // Variables
    #region
    public GameObject platform;
    public Transform spawnPoint;
    private float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float platformWidth;

    private int platformSelector;
    //public GameObject[] platforms;
    public float[] platformWidths;

    public ObjectPooler[] theObjectPools;
    

    public GameObject player;

    // Y position variables
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    // Collectables
    public CoinSpawner theCoinSpawner;

    // Obstacles
    public float randomObstacleThreshold;
    public ObjectPooler obstaclePool;
    
    // Powerups
    public float powerupHeight;
    public float randomPowerupThreshold;
    public ObjectPooler powerupPool;


    #endregion


    void Start()
    {
        theCoinSpawner = FindObjectOfType<CoinSpawner>();

        // Get width of platform
        platformWidths = new float[theObjectPools.Length];

        // Declare widths of each platform:
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

 
    void Update()
    {
        // If we have not passed the spawn point
        if(transform.position.x < spawnPoint.position.x)
        
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            // Pick a platform at random to instantiate 
            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            // Decide if powerup is created
            if(Random.Range(0f, 100f) < randomPowerupThreshold)
            {
                // Create powerup
                GameObject newPowerup = powerupPool.GetPooledObject();

                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2, Random.Range(1f, powerupHeight), 0);

                newPowerup.SetActive(true);
            }


            // Move the spawner's position ahead
            // Move by platformWidth to ensure no overlapping occurs
            transform.position = new Vector3(transform.position.x + 
                (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);


            //// Create new platform
            //Instantiate(/*platform*/ theObjectPools[platformSelector], transform.position, theObjectPools[platformSelector].transform.rotation);

            // Get an object from the pool of objects
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            // Set the new platforms position and rotation
            // Set the platform to active
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = theObjectPools[platformSelector].transform.rotation;
            newPlatform.SetActive(true);

            // Spawn coins on flat platforms
            if(platformSelector == 0 || platformSelector == 1)
            {
                theCoinSpawner.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z));

                // Decide if an obstacle will be spawned
                if (Random.Range(0f, 100f) < randomObstacleThreshold)
                {
                    // Spawn it
                    GameObject newObstacle = obstaclePool.GetPooledObject();

                    // Move the obstacle horizontally along the platform, randomly
                    //float obstacleXPosition = Random.Range(-platformWidths[platformSelector] / 2, platformWidths[platformSelector] / 2);
                    float obstacleXPosition = Random.Range(-3, 3);
                    // Offset the obstacles position to above the platform
                    Vector3 obstaclePosition = new Vector3(obstacleXPosition, 0.9f, 0f);

                    // Set the new obstacles position and rotation
                    // Set the obstacle to active
                    newObstacle.transform.position = transform.position + obstaclePosition;
                    newObstacle.transform.rotation = theObjectPools[platformSelector].transform.rotation;
                    newObstacle.SetActive(true);
                }
            }

            // Move by platformWidth to ensure no overlapping occurs
            transform.position = new Vector3(transform.position.x +
                (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }

        
    }
