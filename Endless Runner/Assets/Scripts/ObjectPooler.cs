using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    // Variables
    #region
    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;
    #endregion

    void Start()
    {
        // Create empty list
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            // cast into a GameObject so it can be put into the list
            // Rotation etc. will be set seperately from here
            GameObject obj = (GameObject)Instantiate(pooledObject);
            // Spawn it as inactive
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // cast into a GameObject so it can be put into the list
        // Rotation etc. will be set seperately from here
        GameObject obj = (GameObject)Instantiate(pooledObject);
        // Spawn it as inactive
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }



}
