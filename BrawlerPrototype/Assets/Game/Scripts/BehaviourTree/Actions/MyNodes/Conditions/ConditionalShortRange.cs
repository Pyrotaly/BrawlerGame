using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ConditionalShortRange : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (Enemy.CheckPlayerInCloseRange())
        {
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
