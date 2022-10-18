using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoolling : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    #region singleton
    
    public static BallPoolling instance;

    void Awake() {
        instance = this;
    }

    #endregion

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetBallFromPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].gameObject.activeSelf)
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

}
