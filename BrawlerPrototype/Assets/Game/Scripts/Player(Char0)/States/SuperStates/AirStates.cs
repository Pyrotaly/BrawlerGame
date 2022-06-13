using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStates : PlayerState
{
    protected bool attacking;
    protected bool airDownAttacking;
    protected bool upAttacking;
    public AirStates(Player player, string animBoolName) : base(player, animBoolName)
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
            if (timer >= player.CharacterSelected.LightAttackData.LightAttackDetails[4].TimeTillCharged)
            {
                stateMachine.ChangeState(player.CharacterSelected.AirLight);
                player.Input.Attack = false;
                startTimer = false;
                attacking = false;
            }
        }

        //Light
        if (attacking && !player.Input.Attack)
        {
            if (Time.time >= player.CharacterSelected.NextLightAttack[4]) //player.CharacterSelected.nextLightAttackTime
            {
                player.CharacterSelected.NextLightAttack[4] = Time.time + player.CharacterSelected.CharacterLightCooldowns[4];
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
            airDownAttacking = true;

            if (Time.time >= player.CharacterSelected.NextLightAttack[5])
            {
                Debug.Log("dOWNlIGHT");
                player.CharacterSelected.NextLightAttack[5] = Time.time + player.CharacterSelected.CharacterLightCooldowns[5];
                startTimer = false;
                airDownAttacking = false;
                Debug.Log(player.CharacterSelected.NextLightAttack[5]);
                stateMachine.ChangeState(player.CharacterSelected.AirDownLight);
            }
            else
            {
                airDownAttacking = false;
            }

            ////DownLightCharged
            //if (timer >= player.CharacterSelected.LightAttackData.LightAttackDetails[5].TimeTillCharged)
            //{
            //    stateMachine.ChangeState(player.CharacterSelected.DownHeavy);
            //    player.Input.DownAttack = false;
            //    startTimer = false;
            //    airDownAttacking = false;
            //}
        }

        //AirDownLight
        //if (airDownAttacking && !player.Input.DownAttack)
        //{
        //    if (Time.time >= player.CharacterSelected.NextLightAttack[5])
        //    {
        //        Debug.Log("dOWNlIGHT");
        //        player.CharacterSelected.NextLightAttack[5] = Time.time + player.CharacterSelected.CharacterLightCooldowns[5];
        //        startTimer = false;
        //        airDownAttacking = false;
        //        Debug.Log(player.CharacterSelected.NextLightAttack[5]);
        //        stateMachine.ChangeState(player.CharacterSelected.AirDownLight);
        //    }
        //    else
        //    {
        //        airDownAttacking = false;
        //    }
        //}
        #endregion

        #region UpAttacks
        if (player.Input.UpAttack == true)
        {
            startTimer = true;
            upAttacking = true;

            //UpLightCharged
            if (timer >= player.CharacterSelected.LightAttackData.LightAttackDetails[6].TimeTillCharged)
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
            if (Time.time >= player.CharacterSelected.NextLightAttack[6])
            {
                player.CharacterSelected.NextLightAttack[6] = Time.time + player.CharacterSelected.CharacterLightCooldowns[6];
                stateMachine.ChangeState(player.CharacterSelected.UpLight);
                Debug.Log("PLS");
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
