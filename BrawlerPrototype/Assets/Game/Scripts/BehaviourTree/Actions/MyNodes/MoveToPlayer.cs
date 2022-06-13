using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveToPlayer : ActionNode
{
    protected override void OnStart() {
        AnimatorNodes.SetBool("Flee", false);
        
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        //AnimatorNodes.SetBool("Move", true);
        //animatorNodes.SetInteger("pp", 3);

        foreach (AnimatorControllerParameter parameter in AnimatorNodes.parameters)
        {
            if (parameter.name == "Move")
            {
                AnimatorNodes.SetBool(parameter.name, true);
            }
            else
            {
                AnimatorNodes.SetBool(parameter.name, false);
            }
        }

        if (Enemy.transform.position.x < Enemy.PlayerPosition.x)
        {
            Core.Movement.SetVelocityX(Enemy.BaseData.RunToMovementSpeed);  //Should be data for speed
            AnimatorNodes.SetBool("Move", true);
        }
        else
        {
            Core.Movement.SetVelocityX(Enemy.BaseData.RunToMovementSpeed * -1);
            AnimatorNodes.SetBool("Move", true);
        }

        return State.Success;
    }
}
