using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The sprites are on different gameobject from the gameobject with the scripts, this script lets the sprites to call functions from the scripts
public class PlayerAnimationEventTransfer : MonoBehaviour 
{
    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
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
    }
}
