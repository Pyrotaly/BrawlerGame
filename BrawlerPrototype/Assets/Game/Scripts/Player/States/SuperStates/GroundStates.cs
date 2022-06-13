using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStates : PlayerState
{
    protected bool attacking;
    protected bool downAttacking;
    protected bool upAttacking;
    public GroundStates(Player player, string animBoolName) : base(player, animBoolName)
    {

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

        Timer();

        if (player.Input.Blocking)
        {
            stateMachine.ChangeState(player.BlockState);
        }

        #region Jump/Fall
        if (isJumping && player.isGrounded == true)
        {
            stateMachine.ChangeState(player.JumpState); 
        }

        if (!isGrounded && player.RB2D.velocity.y < -0.5)
        {
            stateMachine.ChangeState(player.FallState);
        }
        #endregion

        if (!player.Input.Attack || !player.Input.DownAttack || !player.Input.UpAttack)
        {
            startTimer = false;
        }

        #region Attacks
        if (player.Input.Attack)  
        {
            startTimer = true;
            attacking = true;

            //LightCharged
            if (timer >= player.CharacterSelected.LightAttackData.LightAttackDetails[0].TimeTillCharged)
            {
                startTimer = false;
                attacking = false;
                stateMachine.ChangeState(player.CharacterSelected.LightCharged); 
            }
        }

        //Light
        if (attacking && !player.Input.Attack)
        {
            if (Time.time >= player.CharacterSelected.NextLightAttack[0]) 
            {

                stateMachine.ChangeState(player.CharacterSelected.Light);
                startTimer = false;
                attacking = false;
            }
            else
            {
                attacking = false;
            }
        }
        #endregion

        #region DownAttacks
        if (player.Input.DownAttack == true)
        {
            startTimer = true;
            downAttacking = true;

            //DownCharged
            if (timer >= player.CharacterSelected.LightAttackData.LightAttackDetails[1].TimeTillCharged)
            {
                stateMachine.ChangeState(player.CharacterSelected.DownCharged); 
                player.Input.DownAttack = false;
                startTimer = false;
                downAttacking = false;
            }
        }

        //DownLight
        if (downAttacking && !player.Input.DownAttack)
        {
            if (Time.time >= player.CharacterSelected.NextLightAttack[1])
            {
                player.CharacterSelected.NextLightAttack[1] = Time.time + player.CharacterSelected.CharacterLightCooldowns[1];
                stateMachine.ChangeState(player.CharacterSelected.DownLight);
                startTimer = false;
                downAttacking = false;
            }
            else
            {
                downAttacking = false;
            }
        }
        #endregion

        #region UpAttacks
        if (player.Input.UpAttack == true)
        {
            startTimer = true;
            upAttacking = true;

            //UpLightCharged
            if (timer >= player.CharacterSelected.LightAttackData.LightAttackDetails[2].TimeTillCharged)
            {
                stateMachine.ChangeState(player.CharacterSelected.UpCharged);
                player.Input.UpAttack = false;
                startTimer = false;
                upAttacking = false;
            }
        }

        //UpLight
        if (upAttacking && !player.Input.UpAttack)
        {
            if (Time.time >= player.CharacterSelected.NextLightAttack[2])
            {
                player.CharacterSelected.NextLightAttack[2] = Time.time + player.CharacterSelected.CharacterLightCooldowns[2];
                stateMachine.ChangeState(player.CharacterSelected.UpLight);
                startTimer = false;
                upAttacking = false;
            }
            else
            {
                upAttacking = false;
            }
        }

        #endregion
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}