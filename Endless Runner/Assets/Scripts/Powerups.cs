using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    // Variables 
    public bool doublePoints;
    public bool obstacleRemover;

    public float powerupDuration;

    private PowerupManager thePowerupManager;
    private SpriteRenderer theSpriteRenderer;

    public GameObject powerupParticles;

    //public Sprite[] powerupSprites;

    


    void Start()
    {
        thePowerupManager = FindObjectOfType<PowerupManager>();
    }


    void Awake()
    {
        int powerupSelector = Random.Range(0, 2);

        // Decide which powerup to spawn
        switch (powerupSelector)
        {
            case 0: doublePoints = true;
                break;

            case 1: obstacleRemover = true;
                break;
        }

        // Select correct sprite from array
        //GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thePowerupManager.ActivatePowerup(doublePoints, obstacleRemover, powerupDuration);
            Instantiate(powerupParticles, transform.position, Quaternion.Euler(90, 0, 0));

        }
        gameObject.SetActive(false);
    }





}
