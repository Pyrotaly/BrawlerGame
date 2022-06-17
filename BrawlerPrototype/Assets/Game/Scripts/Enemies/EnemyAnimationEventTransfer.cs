using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventTransfer : MonoBehaviour
{
    private BaseMook mook;
    void Start()
    {
        mook = GetComponentInParent<BaseMook>();
    }
    private void AnimationTrigger()
    {
        mook.StateMachine.CurrentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        mook.StateMachine.CurrentState.AnimationFinishedTrigger();
    }
}
