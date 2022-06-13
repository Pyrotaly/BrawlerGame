using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class DieNode : ActionNode
{
    public string AnimParameter;
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
                if (parameter.name == AnimParameter)
                {
                    AnimatorNodes.SetBool(parameter.name, true);
                    Debug.Log(AnimParameter);
                }
                else
                {
                    AnimatorNodes.SetBool(parameter.name, false);
                }
            }
            FindObjectOfType<BasicGameManager>().EndGame();
            FindObjectOfType<BasicGameManager>().PlayerWinsScreen();
            //AnimatorNodes.SetBool(AnimParameter, true);
            return State.Success;
        }
        else
        {
            AnimatorNodes.SetBool(AnimParameter, false);
            return State.Failure;
        }

    }
}
