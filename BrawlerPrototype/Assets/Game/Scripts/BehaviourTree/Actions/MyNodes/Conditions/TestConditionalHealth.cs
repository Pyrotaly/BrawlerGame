using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class TestConditionalHealth : ActionNode
{
    [SerializeField]
    private float healthCondition;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        Debug.Log(Enemy.EnemyHealth);
        Debug.Log(healthCondition);
        if(healthCondition >= Enemy.EnemyHealth)
        {
            Debug.Log("HealthLmao");
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
