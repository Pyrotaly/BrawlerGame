using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class HurtNode : ActionNode
{
    private bool KnockedUp;
    protected override void OnStart()
    {

        if (Core.Combat.CoreDamageType == 2)
        {
            KnockedUp = true;
        }
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {

        AnimatorNodes.SetInteger("damageType", Core.Combat.CoreDamageType);

        if (KnockedUp)
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

            if (Enemy.Core.CollisionSenses.Ground)
            {
                AnimatorNodes.SetBool("KnockUp", false);
                KnockedUp = false;
            }

            return State.Success;
        }

        if (Enemy.Damaged && !KnockedUp)
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

            return State.Success;
        }
        else
        {
            AnimatorNodes.SetBool("Hurt", false);
            return State.Failure;
        }
    }
}
