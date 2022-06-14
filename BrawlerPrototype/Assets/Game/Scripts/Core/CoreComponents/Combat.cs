using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockable
{
    //float stamina           For bosses 
    public float CoreHealth;
    //public HealthBar CoreHealthBar;

    public bool Blocking;
    public bool Damaged;
    public int CoreDamageType;

    public void Damage(float damageAmount, int damageType)
    {
        //Debug.Log(core.transform.parent.name + "Damaged!");
        Damaged = true;
        CoreDamageType = damageType;
        Invoke("DamageFalse", 0.1f);    //This might lead to future problems, this could be the resistant timer?
        if (Blocking)
        {
            CoreHealth -= damageAmount * 0.5f; //reduces damage by 50%
        }
        else
        {
            CoreHealth -= damageAmount;
        }
        
        //CoreHealthBar.SetHealth(CoreHealth);
    }

    public void Knockback(float strength, Vector2 angle, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
    }

    private void DamageFalse()
    {
        Damaged = false;
    }
}
