using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class HurtNode : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        AnimatorNodes.SetInteger("damageType", Core.Combat.CoreDamageType);

        if (Core.Combat.CoreDamageType == 2)
        {
            return State.Success;
        }
        else if (Enemy.Core.CollisionSenses.Ground)
        {
            return State.Failure;
        }

        if (Enemy.Damaged)
        {

            if (Enemy.Core.CollisionSenses.Ground)
            {
                Core.Movement.SetVelocityX(0);

                foreach (AnimatorControllerParameter parameter in AnimatorNodes.parameters)
                {
                    if (parameter.name == "Hurt")
                    {
                        AnimatorNodes.SetBool(parameter.name, true);
                    }
                    else
                    {
                        AnimatorNodes.SetBool(parameter.name, false);
                    }
                }
            }

            return State.Success;
        }
        else
        {
            AnimatorNodes.SetBool("Hurt", false);
            return State.Failure;
        }
    }
}
