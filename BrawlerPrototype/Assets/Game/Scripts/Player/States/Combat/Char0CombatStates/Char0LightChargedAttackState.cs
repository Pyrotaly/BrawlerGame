using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char0LightChargedAttackState : LightChargedAttackState
{
    public Char0LightChargedAttackState(Player player, string animBoolName, D_HeavyAttacks HeavyAttackData) : base(player, animBoolName, HeavyAttackData)
    {
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        player.Core.Movement.SetVelocityX(16 * player.Input.direction);
    }

    public override void Enter()
    {
        base.Enter();
        if (player.AttackCounter >= 1)
        {
            player.AttackCounter = 0;
            player.AnimCombat.SetInteger("attackCounter", 0);
        }
        else
        {
            player.AttackCounter++;
            player.AnimCombat.SetInteger("attackCounter", 1);
        }
    }

    public override void Exit()
    {
        base.Exit();
        attacking = true;
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
        player.CheckMeleeAttack(HeavyAttackData.HeavyAttackDetails[0].DamageAmount, HeavyAttackData.HeavyAttackDetails[0].DamageType,
            HeavyAttackData.HeavyAttackDetails[0].KnockbackStrength, HeavyAttackData.HeavyAttackDetails[0].KnockbackAngle);
    }
}

