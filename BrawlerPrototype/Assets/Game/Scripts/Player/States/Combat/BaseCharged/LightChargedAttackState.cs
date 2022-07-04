using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChargedAttackState : GroundStates
{
    protected D_HeavyAttacks HeavyAttackData;
    public LightChargedAttackState(Player player, string animBoolName, D_HeavyAttacks HeavyAttackData) : base(player, animBoolName)
    {
        this.HeavyAttackData = HeavyAttackData;
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
        stateMachine.ChangeState(player.IdleState);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
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
        attacking = false;
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