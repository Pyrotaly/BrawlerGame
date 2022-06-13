using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class HeavyAttackNode : ActionNode
{
    public string AnimParameter;
    public int ArrayCooldownInt; //Which array value from cooldown array should this node be concerend with 
    public int TempUtilValue;
    public float NodeXMVS; //NodeXMVS
    public override void CalculateUtils()
    {
        if (Time.time >= Enemy.EnemyNextHeavyAttack[ArrayCooldownInt]) //player.CharacterSelected.nextLightAttackTime
        {
            TestInt = TempUtilValue;
        }
        else
        {
            AnimatorNodes.SetBool(AnimParameter, false);
            TestInt = 0;
        }
    }

    protected override void OnStart(){
        AnimatorNodes.SetBool("Move", false);
        AnimatorNodes.SetBool("Flee", false);
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {

        Core.Movement.SetVelocityX(NodeXMVS);

        if (Time.time >= Enemy.EnemyNextHeavyAttack[ArrayCooldownInt]) //player.CharacterSelected.nextLightAttackTime
        {
            foreach (AnimatorControllerParameter parameter in AnimatorNodes.parameters)
            {
                if (parameter.name == AnimParameter)
                {
                    AnimatorNodes.SetBool(parameter.name, true);
                }
                else
                {
                    AnimatorNodes.SetBool(parameter.name, false);
                }
            }
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
