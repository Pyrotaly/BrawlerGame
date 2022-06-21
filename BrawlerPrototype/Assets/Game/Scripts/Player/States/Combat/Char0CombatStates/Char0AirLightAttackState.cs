using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char0AirLightAttackState : AirLightAttackState
{
    public Char0AirLightAttackState(Player player, string animBoolName, D_LightAttacks lightAttackData) : base(player, animBoolName, lightAttackData)
    {
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        player.CheckMeleeAttack(80, 1, 3, new Vector2(3, 5));
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void WeaponAnimationTrigger()
    {
        base.WeaponAnimationTrigger();
        player.CheckMeleeAttack(80, 0, 3, new Vector2(3, 5));
    }
}
