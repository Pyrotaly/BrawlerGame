using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class DieNode : ActionNode
{

    protected override void OnStart() {

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        Core.Movement.SetVelocityX(0);



        if (Enemy.EnemyHealth <= 0) 
        {
            foreach (AnimatorControllerParameter parameter in AnimatorNodes.parameters)
            {
                if (parameter.name == "Die")
                {
                    AnimatorNodes.SetBool(parameter.name, true);
                    Debug.Log("Die");
                }
                else
                {
                    AnimatorNodes.SetBool(parameter.name, false);
                }
            }
            //FindObjectOfType<BasicGameManager>().EndGame();
            //FindObjectOfType<BasicGameManager>().PlayerWinsScreen();
            return State.Success;
        }
        else
        {
            AnimatorNodes.SetBool("Die", false);
            return State.Failure;
        }

    }
}
