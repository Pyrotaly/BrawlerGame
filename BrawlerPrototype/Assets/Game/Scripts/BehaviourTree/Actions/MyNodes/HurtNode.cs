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
        Core.Movement.SetVelocityX(0);
        AnimatorNodes.SetBool("Move", false);
        AnimatorNodes.SetBool("Flee", false);


        AnimatorNodes.SetInteger("damageType", Core.Combat.CoreDamageType);

        if (Enemy.Damaged)
        {
            //AnimatorNodes.SetBool("Hurt", true);   Use this if enemy attacks should not be interrupted

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
