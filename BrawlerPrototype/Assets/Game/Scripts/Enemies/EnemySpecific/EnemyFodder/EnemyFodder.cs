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

    protected override void Awake()
    {
        base.Awake();
        AttackState = new FodderAttackState(this, StateMachine, "Attack", AttackPosition);  //In future, make class more specific for enemies
    }


    protected override void Update()
    {
        base.Update();

        //Debug.Log("MeleeRange" + CheckPlayerInMeleeRange());
        //Debug.Log("AttackToken" + EnemyAttackTokenManagement.AttackTokens);

        if (Time.time >= NextAttackTime)
        {
            Debug.Log("Attack");
        }

        //Checks if enemy can attack and then move to player to hit or hit player if already there
        if (Time.time >= NextAttackTime && EnemyAttackTokenManagement.AttackTokens != 0)
        {
            StateMachine.ChangeState(MoveState);

            if (CheckPlayerInMeleeRange())
            {
                StateMachine.ChangeState(AttackState);
            }
        }

    }
}
