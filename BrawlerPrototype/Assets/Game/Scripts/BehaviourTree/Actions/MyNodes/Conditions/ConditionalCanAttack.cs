using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ConditionalCanAttack : ActionNode
{
    public int ArrayCooldownInt; //Which array value from cooldown array should this node be concerend with 
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if (Time.time >= Enemy.EnemyNextLightAttack[ArrayCooldownInt]) //player.CharacterSelected.nextLightAttackTime
        {
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
