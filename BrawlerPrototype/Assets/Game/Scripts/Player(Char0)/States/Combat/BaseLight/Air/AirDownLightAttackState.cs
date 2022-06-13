using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDownLightAttackState : AirStates
{
    private D_LightAttacks LightAttackData;
    public AirDownLightAttackState(Player player, string animBoolName, D_LightAttacks LightAttackData) : base(player, animBoolName)
    {
        this.LightAttackData = LightAttackData;
    }

    public override void Enter()
    {
        base.Enter();
        player.CanFlip = false;
        player.AnimCombat.SetBool("Light", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.AnimCombat.SetBool("Light", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.Core.Movement.SetVelocityY(6);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
        stateMachine.ChangeState(player.FallState);
    }

    public override void WeaponAnimationTrigger()
    {
        base.WeaponAnimationTrigger();
    }
}
