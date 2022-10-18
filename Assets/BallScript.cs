using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void Start()
    {
        Invoke("SetFalse", 3.5f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Left Top"))
        {
            EnemyAI.instance.left = true;

        }
        
        if (col.gameObject.CompareTag("Left Bottom"))
        {
            EnemyAI.instance.right = true;

        }
        
        if (col.gameObject.CompareTag("Top"))
        {
            EnemyAI.instance.left = true;

        }
    }
    
    void SetFalse()
    {
        this.gameObject.SetActive(false);
    }

}
