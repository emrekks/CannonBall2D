using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public DodgeState dodgeState;
    public AttackState attackState;
    public override State RunCurrentState()
    {
        if (EnemyAI.instance.left || EnemyAI.instance.right)
        {
            return dodgeState;
        }
        else if (Cannon.instance.bulletCount <= 0)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
