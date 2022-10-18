using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public Vector3 direction;
    public bool doOnce = false;

    
    #region singleton
    
    public static EnemyAI instance;

    void Awake() {
        instance = this;
    }

    #endregion

    private void Update()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, 2.5f);

            if (coll.tag == "Ball" && !doOnce)
            {
                direction = (coll.transform.position - transform.position).normalized;
                StartCoroutine(ResetDoOnce());
                doOnce = true;
            }
    }
    
    IEnumerator ResetDoOnce()
    {
        yield return new WaitForSeconds(2f);
        doOnce = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, 0), 2.5f);
    }
}
