using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ConditionalLongRange : ActionNode
{
    [SerializeField]
    private int rangeCondition;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        if (!Enemy.CheckPlayerInCloseRange() && !Enemy.CheckPlayerInMediumRange() && Enemy.CheckPlayerInLongRange())
        {
            Debug.Log("Long");
            return State.Success;
        }
        else
        {
            return State.Failure;
        }   
    }
}