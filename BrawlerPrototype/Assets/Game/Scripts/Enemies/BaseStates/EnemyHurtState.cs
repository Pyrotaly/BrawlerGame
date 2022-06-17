using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyState
{
    private D_BaseEnemy baseData;
    private float timeStamp;
    public EnemyHurtState(BaseMook entity, EnemyStateMachine stateMachine, string animBoolName, D_BaseEnemy baseData) : base(entity, stateMachine, animBoolName)
    {
        this.baseData = baseData;
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
        stateMachine.ChangeState(entity.IdleState);
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

        timeStamp += Time.deltaTime;

        if (timeStamp == baseData.KnockUpVulnerabilityTime)
        {
            core.Movement.SetVelocityY(baseData.FallVelocity);
        }

        if (entity.DamagedType == 2)
        {
            if (core.CollisionSenses.Ground)
            {
                // recover
                Debug.Log("Recovery State");
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

