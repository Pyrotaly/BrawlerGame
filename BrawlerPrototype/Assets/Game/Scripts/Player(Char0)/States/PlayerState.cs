using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected int xInput;
    protected int yInput;
    protected int direction;

    protected Core core;

    protected Player player;
    protected PlayerStateMachine stateMachine;              

    protected bool isAnimationFinished = true;
    protected bool isExitingState;

    protected string animBoolName;

    protected bool isGrounded;
    protected bool isJumping;
    protected bool touchingWall;
    protected bool touchingLedge;

    protected double timer;
    protected float tempTime;
    
    protected bool startTimer;

    protected bool isClimbing;
    //protected bool isDashing; 

    public PlayerState(Player player, string animBoolName)  
    {
        this.player = player; 
        this.animBoolName = animBoolName;
        core = player.Core;
    }

    public virtual void Enter()
    {
        stateMachine = player.StateMachine;
        player.AnimCombat.SetBool(animBoolName, true);
        isAnimationFinished = false;
        isExitingState = false;
        direction = player.Input.direction;
    }

    public virtual void Exit()
    {
        player.AnimCombat.SetBool(animBoolName, false);
        isExitingState = true;
        startTimer = false;
        player.CanFlip = true;
    }

    public virtual void LogicUpdate()
    {
        //Debug.Log(animBoolName);

        xInput = player.Input.NormInputX;
        yInput = player.Input.NormInputY;
        isJumping = player.Input.Jumping;

        if (player.Input.Dashing && Time.time >= player.NextDash)   //Player data
        {
            stateMachine.ChangeState(player.DashState);
            player.NextDash = Time.time + player.DashRate;
        }

        if (player.PlayerHealth <= 0)
        {
            Debug.Log("dIE");
            stateMachine.ChangeState(player.DieState);
        }
    }

    public virtual void PhysicsUpdate() 
    {
        DoChecks();
    }

    public virtual void DoChecks() 
    {
        isGrounded = player.isGrounded;
    }

    #region AnimationEvents
    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishedTrigger()
    {
        isAnimationFinished = true;
    }

    public virtual void WeaponAnimationTrigger()
    {

    }
    #endregion

    public virtual void Timer()
    {
        if (startTimer == true)
        {
            tempTime += Time.deltaTime;
            timer = System.Math.Round(tempTime, 2);
            //Debug.Log(timer);
            //Debug.Log("tempTime" + tempTime);
        }
        else
        {
            tempTime = 0;
            timer = 0;
        }
    }
}