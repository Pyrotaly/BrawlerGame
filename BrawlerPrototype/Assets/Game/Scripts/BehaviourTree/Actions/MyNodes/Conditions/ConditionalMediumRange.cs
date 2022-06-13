using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ConditionalMediumRange : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() 
    {
        if (Enemy.CheckPlayerInMediumRange())
        {
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
