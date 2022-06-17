using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Transform attackPosition;
    public EnemyAttackState(BaseEnemy entity, EnemyStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }


    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //These functions below will be called in animation events
    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        //    isAnimationFinished = true;
    }


}
