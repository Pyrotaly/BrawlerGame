using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : AirStates
{
    private readonly PlayerData playerData;
    public PlayerFallState(Player player, string animBoolName, PlayerData playerData) : base(player, animBoolName)
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
        startTimer = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(playerData.MovementVelocity * xInput);

        if (isGrounded && core.Movement.CurrentVelocity.y < 0.01f)
        {
            if (xInput == 0)
            {
                stateMachine.ChangeState(player.FallLandState);
            }
            else
            {
                stateMachine.ChangeState(player.MoveState);
            }
        }

        if (player.RB2D.velocity.y > 0)
        {
            core.Movement.SetVelocityY(playerData.FallVelocity);
        }

        //if (player.RB2D.velocity.y == 0) //This is for being stuck on a ledge
        //{
        //    core.Movement.SetVelocityY(-60); 
        //}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
