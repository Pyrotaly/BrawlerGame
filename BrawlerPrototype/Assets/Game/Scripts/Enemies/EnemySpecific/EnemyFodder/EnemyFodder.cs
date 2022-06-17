using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFodder : BaseMook
{
    private int direction;
    public override void AttackAnimationTrigger()
    {
        base.AttackAnimationTrigger();

        if (transform.position.x < PlayerPosition.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    protected override void Update()
    {
        base.Update();

        //Checks if enemy can attack and then move to player to hit or hit player if already there
        if (Time.time >= NextAttackTime && EnemyAttackTokenManagement.AttackTokens != 0)
        {
            EnemyAttackTokenManagement.AttackTokens--;

            StateMachine.ChangeState(MoveState);
            
            if (CheckPlayerInMeleeRange())
            {
                StateMachine.ChangeState(AttackState);
            }
        }
    }
}
