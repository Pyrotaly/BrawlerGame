using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveFromPlayer : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        //AnimatorNodes.SetBool("Flee", true);
        foreach (AnimatorControllerParameter parameter in AnimatorNodes.parameters)
        {
            if (parameter.name == "Flee")   
            {
                AnimatorNodes.SetBool(parameter.name, true);
            }
            else
            {
                AnimatorNodes.SetBool(parameter.name, false);
            }
        }

        if (Enemy.CheckTouchingBorder())
        {
            return State.Failure;
        }

        if (Enemy.transform.position.x > Enemy.PlayerPosition.x)  
        {
            //Debug.Log("MovingFROM1");
            Core.Movement.SetVelocityX(Enemy.BaseData.RunFromMovementSpeed);  
            return State.Success;
        }
        else
        {
            //ebug.Log("MovingFROM2");
            Core.Movement.SetVelocityX(Enemy.BaseData.RunFromMovementSpeed * -1);
            return State.Success;
        }
    }
}
