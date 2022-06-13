using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char0HeavyAttackState : HeavyAttackState
{
    public Char0HeavyAttackState(Player player, string animBoolName, D_HeavyAttacks HeavyAttackData) : base(player, animBoolName, HeavyAttackData)
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
        if (player.AttackCounter >= 4 || player.AttackCounter < 3)
        {
            player.AttackCounter = 3;
        }
        else
        {
            player.AttackCounter++;
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
    }
}

