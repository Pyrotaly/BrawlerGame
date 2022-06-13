using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackState : GroundStates
{
    public D_LightAttacks lightAttackData;

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
        Debug.Log("HOLA");
        if (!player.Input.Attack) 
        {
            Debug.Log("HELLO");
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
        stateMachine.ChangeState(player.IdleState);
    }

    public override void WeaponAnimationTrigger()
    {
        base.WeaponAnimationTrigger();
        player.CheckMeleeAttack(400, 3, 3, new Vector2(3,5));
    }
}
