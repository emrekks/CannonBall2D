using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    public IdleState idleState;
    public AttackState attackState;
    public override State RunCurrentState()
    {
        if (!EnemyAI.instance.doOnce && !EnemyAI.instance.doOnce && Cannon.instance.bulletCount > 0)
        {
            return idleState;
        }
        
        else if (Cannon.instance.bulletCount <= 0)
        {
            return attackState;
        }
        
        else
        {
            if (EnemyAI.instance.doOnce)
            {
                if (0.75f < EnemyAI.instance.direction.y && 0f > EnemyAI.instance.direction.x)
                {
                    EnemyAI.instance.rb2d.velocity = Vector2.right * EnemyAI.instance.speed;
                }
                else if (0.75f < EnemyAI.instance.direction.y && 0f < EnemyAI.instance.direction.x)
                {
                    EnemyAI.instance.rb2d.velocity = Vector2.left * EnemyAI.instance.speed;
                }
                else if (0.75f > EnemyAI.instance.direction.y && 0f > EnemyAI.instance.direction.x && 0.25f < EnemyAI.instance.direction.y)
                {
                    EnemyAI.instance.rb2d.velocity = new Vector2(1, 1) * EnemyAI.instance.speed / 2;
                }
                else if (0.25f > EnemyAI.instance.direction.y && 0f > EnemyAI.instance.direction.x && -1f < EnemyAI.instance.direction.y )
                {
                    EnemyAI.instance.rb2d.velocity = new Vector2(0, 0.5f) * EnemyAI.instance.speed;
                }
                StartCoroutine(ResetMoveBool());
                EnemyAI.instance.doOnce = false;
            }
            
            return this;
        }
    }
    
    IEnumerator ResetMoveBool()
    {
        yield return new WaitForSeconds(0.5f);
        EnemyAI.instance.rb2d.velocity = new Vector2(0, 0);
    }
}
