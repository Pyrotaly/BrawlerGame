using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleeState : EnemyState
{
    protected D_BaseEnemy stateData;

    public EnemyFleeState(BaseMook entity, EnemyStateMachine stateMachine, string animBoolName, D_BaseEnemy stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //core.Movement.SetVelocityX(stateData.RunFromMovementSpeed);

        if (entity.transform.position.x > entity.PlayerPosition.x)
        {
            core.Movement.SetVelocityX(stateData.RunFromMovementSpeed);
        }
        else
        {
            core.Movement.SetVelocityX(stateData.RunFromMovementSpeed * -1);
        }

        if (!entity.CheckPlayerInMediumRange())
        {
            stateMachine.ChangeState(entity.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
