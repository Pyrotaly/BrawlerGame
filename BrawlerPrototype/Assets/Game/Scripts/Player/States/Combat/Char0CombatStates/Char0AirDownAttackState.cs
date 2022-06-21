using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char0AirDownAttackState : AirDownLightAttackState
{
    public Char0AirDownAttackState(Player player, string animBoolName, D_LightAttacks LightAttackData) : base(player, animBoolName, LightAttackData)
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
        player.Core.Movement.SetVelocityY(6);
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
