using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct S_AttackDetails 
{
    public string AttackName;
    [Header("Basic")]
    public float DamageAmount;
    public float MovementSpeed;
    public float ProjectileSpeed;
    public float BasicCooldown;
    public int BasicDamageType;
    public float DamageRadius;

    public float knockbackStrength;
    public Vector2 knockbackAngle;

    [Header("Charged")]
    public float TimeTillCharged;
    //public float ChargedDamageAmount;
    //public float ChargedMovementSpeed;
    //public float ChargedProjectileSpeed;
    public float ChargedCooldown;
    //public int ChargedDamageType;

    //public float ChargeKnockBackStrength;  The knockback stuff
    //public Vector2 ChargeKnockBackAngle;
}
