using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : AirStates
{
    private readonly PlayerData playerData;
    public PlayerJumpState(Player player, string animBoolName, PlayerData playerData) : base(player, animBoolName)
    {
        this.playerData = playerData;
    }
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
        startTimer = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
            
        player.Core.Movement.SetVelocityX(playerData.MovementVelocity * 0.9f * xInput);  //playerData.MovementVelocity * xInput)

        if (isJumping == false)
        {
            stateMachine.ChangeState(player.FallState);
        }

        player.Core.Movement.SetVelocityY(playerData.JumpVelocity);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
