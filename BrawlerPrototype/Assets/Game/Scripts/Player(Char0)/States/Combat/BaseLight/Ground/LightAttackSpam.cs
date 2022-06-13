using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackSpam : GroundStates
{
    public LightAttackSpam(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
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
    }
}
