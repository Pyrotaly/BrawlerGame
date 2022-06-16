using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackState : GroundStates
{
    public D_LightAttacks lightAttackData;
    protected float timeStamp;

    public LightAttackState(Player player, string animBoolName, D_LightAttacks lightAttackData) : base(player, animBoolName)
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
        player.CharacterSelected.NextLightAttack[0] = Time.time + player.CharacterSelected.CharacterLightCooldowns[0];
        player.AnimCombat.SetBool("Light", false);
        timeStamp = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.Core.Movement.SetVelocityX(xInput * 10);

        if (!player.Input.Attack)
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= 0.3)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
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
