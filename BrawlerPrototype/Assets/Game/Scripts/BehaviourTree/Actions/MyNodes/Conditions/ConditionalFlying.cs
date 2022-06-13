using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ConditionalFlying : ActionNode
{
    protected override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnStop()
    {
        throw new System.NotImplementedException();
    }

    protected override State OnUpdate()
    {
        if (Enemy.Flying)
        {
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
