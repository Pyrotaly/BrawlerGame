using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMook : BaseEnemy
{
    [Header("Combat")]
    [SerializeField] public Transform AttackPosition;

    public EnemyStateMachine StateMachine;

    public EnemyIdleState IdleState { get; private set; }
    public EnemyClimbState ClimbState { get; private set; } //Will implement in the future
    public EnemyMoveState MoveState { get; private set; }
    public EnemyDieState DieState { get; private set; }
    public EnemyHurtState HurtState { get; private set; }
    public EnemyAttackState AttackState; // { get; private set; }
    public EnemyFleeState FleeState { get; private set; }

    public float AttackCooldown;
    public float NextAttackTime;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine, "Idle");
        MoveState = new EnemyMoveState(this, StateMachine, "Move", BaseData);
        DieState = new EnemyDieState(this, StateMachine, "Die");
        HurtState = new EnemyHurtState(this, StateMachine, "Hurt", BaseData);
        FleeState = new EnemyFleeState(this, StateMachine, "Flee", BaseData);
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);

        AttackCooldown = EnemyLightData.LightAttackDetails[0].BasicCooldown;
    }

    protected override void Update()
    {
        base.Update();
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();

        if (EnemyHealth <= 0)
        {
            StateMachine.Initialize(DieState);
        }


        if (Damaged)  // && !UnStoppable     UnStoppable is when certain moves cannot transition to hurt state 
        {
            Debug.Log("AGH");
            StateMachine.ChangeState(HurtState);
        }    
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        StateMachine.CurrentState.PhysicsUpdate();
    }
}
