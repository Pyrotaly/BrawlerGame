using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : GroundStates
{
    private readonly PlayerData playerData;

    public PlayerMoveState(Player player, string animBoolName, PlayerData playerData) : base(player, animBoolName)
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(playerData.MovementVelocity * xInput);

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
