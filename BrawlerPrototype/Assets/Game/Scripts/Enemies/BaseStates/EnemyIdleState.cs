using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected bool isPlayerInMinAgroRange;

    public EnemyIdleState(BaseEnemy entity, EnemyStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
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
        //isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
