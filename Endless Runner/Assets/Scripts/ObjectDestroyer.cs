using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Although designed for platforms, this class can be used on any asset within the game, such as collectables
public class ObjectDestroyer : MonoBehaviour
{

    //Variables 
    #region
    public GameObject platformDestructionPoint;
    #endregion


    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    void Update()
    {
        // If the platform has gone behind destruction point
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //// Destroy this object
            //Destroy(gameObject);

            // Set object to inactive
            gameObject.SetActive(false);
        }
    }




}
