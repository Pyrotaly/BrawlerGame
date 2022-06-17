using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMook : BaseEnemy
{
    [Header("Combat")]
    [SerializeField] public Transform meleeAttackPosition;

    public EnemyStateMachine StateMachine;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
    }
}
