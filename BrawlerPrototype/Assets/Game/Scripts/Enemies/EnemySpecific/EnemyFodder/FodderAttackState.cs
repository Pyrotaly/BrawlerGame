using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodderAttackState : EnemyAttackState
{
    public FodderAttackState(BaseMook entity, EnemyStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName, attackPosition)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        stateMachine.ChangeState(entity.FleeState);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position,
            entity.EnemyLightData.LightAttackDetails[0].DamageRadius, entity.BaseData.WhatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(entity.EnemyLightData.LightAttackDetails[0].DamageAmount,
                    entity.EnemyLightData.LightAttackDetails[0].DamageType);
            }

            IKnockable knockbackable = collider.GetComponent<IKnockable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(entity.EnemyLightData.LightAttackDetails[0].KnockbackStrength,
                    entity.EnemyLightData.LightAttackDetails[0].KnockbackAngle, core.Movement.FacingDirection);
            }
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {

        base.TriggerAttack();
    }
}
