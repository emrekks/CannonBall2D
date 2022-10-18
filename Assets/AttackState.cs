using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : State
{
    public override State RunCurrentState()
    {
        EnemyAI.instance.transform.position =
            Vector2.MoveTowards(EnemyAI.instance.transform.position, Cannon.instance.transform.position, EnemyAI.instance.speed * Time.deltaTime);
        return this;
    }
}
