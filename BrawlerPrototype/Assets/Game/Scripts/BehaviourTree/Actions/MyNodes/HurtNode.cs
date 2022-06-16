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

        AnimatorNodes.SetBool("Move", false);
        AnimatorNodes.SetBool("Flee", false);

        AnimatorNodes.SetInteger("damageType", Core.Combat.CoreDamageType);

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
            else
            {
                foreach (AnimatorControllerParameter parameter in AnimatorNodes.parameters)
                {
                    if (parameter.name == "KnockUp")
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
