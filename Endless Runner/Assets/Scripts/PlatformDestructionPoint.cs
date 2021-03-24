using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestructionPoint : MonoBehaviour
{

    // Variables
    private Transform thisObjectsTransform;
    private Transform playersTransform;

    public float xAxisOffset;

    void Start()
    {
        thisObjectsTransform = gameObject.transform;
        playersTransform = GameObject.Find("Player").transform;
    }


    void Update()
    {
        // Move this object along in line with the player, minus an offset in the x axis
        thisObjectsTransform.position = new Vector3(playersTransform.position.x + xAxisOffset, 
            thisObjectsTransform.position.y, playersTransform.position.z);

        //// Do not rotate object
        //thisObjectsTransform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
