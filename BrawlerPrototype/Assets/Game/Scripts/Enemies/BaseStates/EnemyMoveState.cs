using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected D_BaseEnemy stateData;

    protected bool isDetectingWall;
    protected bool isPlayerInMinAgroRange;
    protected bool isInMeleeAttackRange;
    public EnemyMoveState(BaseEnemy entity, EnemyStateMachine stateMachine, string animBoolName, D_BaseEnemy stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        //core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);
        FMOD_Test.PlaySound("event:/Character/Enemy Footsteps");
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

        //isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();

        //isInMeleeAttackRange = entity.CheckPlayerInAttackRange();


        //core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);

        //if player still infront continue walking, if the player is not there, look for player
        //Add a flip function here perhaps
    }
}
