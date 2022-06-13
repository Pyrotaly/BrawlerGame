using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockState : GroundStates
{
    public PlayerBlockState(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.Core.Combat.Blocking = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.Core.Combat.Blocking = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!player.Input.Blocking)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void WeaponAnimationTrigger()
    {
        base.WeaponAnimationTrigger();
    }
}
