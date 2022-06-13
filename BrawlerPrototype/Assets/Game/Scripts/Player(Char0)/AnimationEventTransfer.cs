using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTransfer : MonoBehaviour
{
    private Player player;
    //private CombatStates combatState;
    //Vector2 TopCorner, Vector2 DiagonolOpposite, LayerMask LayerMask

    private void Start()
    {
        player = GetComponentInParent<Player>();
        //combatState = GetComponentInParent<CombatStates>();
    }
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        player.AnimationFinishTrigger();
    }

    private void WeaponAnimationTrigger()
    {
        player.StateMachine.CurrentState.WeaponAnimationTrigger();
        //Debug.Log("BIGBIGBIG");
    }
}
