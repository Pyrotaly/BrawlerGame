using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ConditionalMeleeRange : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if (Enemy.CheckPlayerInMeleeRange())
        {
            Debug.Log("MELEE");
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
