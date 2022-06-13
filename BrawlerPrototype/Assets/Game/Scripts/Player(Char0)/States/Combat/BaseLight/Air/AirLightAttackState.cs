using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLightAttackState : AirStates
{
    private D_LightAttacks lightAttackData;
    public AirLightAttackState(Player player, string animBoolName, D_LightAttacks lightAttackData) : base(player, animBoolName)
    {
        this.lightAttackData = lightAttackData;
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
        stateMachine.ChangeState(player.IdleState);
    }

    public override void WeaponAnimationTrigger()
    {
        base.WeaponAnimationTrigger();
    }
}
