using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected D_BaseEnemy stateData;

    protected bool isDetectingWall;
    protected bool isPlayerInMinAgroRange;
    protected bool isInMeleeAttackRange;
    public EnemyMoveState(BaseMook entity, EnemyStateMachine stateMachine, string animBoolName, D_BaseEnemy stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        //core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);
        //FMOD_Test.PlaySound("event:/Character/Enemy Footsteps");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //transition to attack state as of now, only enemy automatically enters attack state if possibles

        if (entity.transform.position.x < entity.PlayerPosition.x)
        {
            core.Movement.SetVelocityX(stateData.RunToMovementSpeed);
        }
        else
        {
            core.Movement.SetVelocityX(stateData.RunToMovementSpeed * -1);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
