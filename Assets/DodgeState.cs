using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    public IdleState idleState;
    public AttackState attackState;
    public override State RunCurrentState()
    {
        if (!EnemyAI.instance.left && !EnemyAI.instance.right && Cannon.instance.bulletCount > 0)
        {
            return idleState;
        }
        
        else if (Cannon.instance.bulletCount <= 0)
        {
            return attackState;
        }
        
        else
        {
            if (EnemyAI.instance.left)
            {
                EnemyAI.instance.rb2d.velocity = new Vector2(-1f, 0f) * EnemyAI.instance.speed;
                StartCoroutine(ResetMoveBool());
            }

            if (EnemyAI.instance.right)
            {
                EnemyAI.instance.rb2d.velocity = new Vector2(1f, 0f) * EnemyAI.instance.speed;
                StartCoroutine(ResetMoveBool());
            }
            return this;
        }
    }
    
    IEnumerator ResetMoveBool()
    {
        yield return new WaitForSeconds(0.5f);
        EnemyAI.instance.left = false;
        EnemyAI.instance.right = false;
        EnemyAI.instance.rb2d.velocity = new Vector2(0, 0f) * EnemyAI.instance.speed;
    }
}
