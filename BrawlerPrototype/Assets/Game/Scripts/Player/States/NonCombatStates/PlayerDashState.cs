using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : AirStates
{
    private bool dAttacking;
    public PlayerDashState(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.IsDashing = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.IsDashing = false;
        player.Input.JumpStop();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityY(1.1f);
        core.Movement.SetVelocityX(55 * direction);

        #region Attacks
        if (player.Input.Attack)  
        {
            //Light Dash Attack
            if (Time.time >= player.CharacterSelected.NextLightAttack[3])
            {
                player.CharacterSelected.NextLightAttack[3] = Time.time + player.CharacterSelected.CharacterLightCooldowns[3];
                stateMachine.ChangeState(player.CharacterSelected.DashAttack); 
                startTimer = false;
                dAttacking = false;
                Debug.Log("DashAttack");
            }
        }
        #endregion

        if (player.Input == isJumping)
        {
            isJumping = false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
        stateMachine.ChangeState(player.FallState);
    }
}
