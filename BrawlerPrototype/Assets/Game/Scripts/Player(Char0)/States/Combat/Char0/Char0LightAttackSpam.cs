using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char0LightAttackSpam : LightAttackSpam
{
    public D_LightAttacks lightAttackData;
    public Char0LightAttackSpam(Player player, string animBoolName, D_LightAttacks lightAttackData) : base(player, animBoolName)
    {
        this.lightAttackData = lightAttackData;
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

        if (isAnimationFinished)
        {
            if (attacking)
            {
                Debug.Log("HAHA");
                stateMachine.ChangeState(player.CharacterSelected.Light);
            }
            else
            {
                stateMachine.ChangeState(player.IdleState);
            }
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
