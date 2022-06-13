using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHeavyAttackState : AirStates
{
    private D_HeavyAttacks HeavyAttackData;
    public DashHeavyAttackState(Player player, string animBoolName, D_HeavyAttacks HeavyAttackData) : base(player, animBoolName)
    {
        this.HeavyAttackData = HeavyAttackData;
    }

    public override void Enter()
    {
        base.Enter();
        player.CanFlip = false;
        player.AnimCombat.SetBool("Heavy", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.AnimCombat.SetBool("Heavy", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
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
        player.StateMachine.ChangeState(player.IdleState);
    }

    public override void WeaponAnimationTrigger()
    {
        base.WeaponAnimationTrigger();
    }
}