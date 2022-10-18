using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 2;
    public bool left; 
    public bool right;
    
    #region singleton
    
    public static EnemyAI instance;

    void Awake() {
        instance = this;
    }

    #endregion



    /*public void Dodge()
    {
        if (left)
        {
            rb2d.velocity = new Vector2(-1f, 0f) * speed;
            StartCoroutine(ResetMoveBool());
        }

        if (right)
        {
            rb2d.velocity = new Vector2(1f, 0f) * speed;
            StartCoroutine(ResetMoveBool());
        }
    }*/
    
    IEnumerator ResetMoveBool()
    {
        yield return new WaitForSeconds(0.5f);
        left = false;
        right = false;
        rb2d.velocity = new Vector2(0, 0f) * speed;
    }
    
}
