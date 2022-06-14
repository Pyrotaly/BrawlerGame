using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFodder : BaseEnemy
{
    private int direction;
    public override void AttackAnimationTrigger()
    {
        base.AttackAnimationTrigger();

        if (transform.position.x < PlayerPosition.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(meleeAttackPosition.position, EnemyLightAttackData.LightAttackDetails[0].DamageRadius, BaseData.WhatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(EnemyLightAttackData.LightAttackDetails[0].DamageAmount, EnemyLightAttackData.LightAttackDetails[0].BasicDamageType);
            }

            IKnockable knockbackable = collider.GetComponent<IKnockable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(EnemyLightAttackData.LightAttackDetails[0].knockbackStrength, EnemyLightAttackData.LightAttackDetails[0].knockbackAngle, direction);
            }
        }

        EnemyNextLightAttack[0] = Time.time + EnemyLightCooldowns[0];
    }
}
