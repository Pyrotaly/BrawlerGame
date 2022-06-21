using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttackState : EnemyAttackState
{
    //protected D_EnemyRangeAttack stateData;
    public EnemyRangeAttackState(BaseMook entity, EnemyStateMachine stateMachine, string animBoolName, 
        Transform attackPosition) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.attackPosition = attackPosition;
        //this.stateData = stateData; D_EnemyRangeAttack stateData
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    //public override void FinishAttack()
    //{
    //    base.FinishAttack();
    //}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
