using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockable
{
    //float stamina           For bosses 
    public float CoreHealth;
    //public HealthBar CoreHealthBar;
    public DamageFlash DamageFlash;

    public bool Blocking;
    public bool Damaged;
    public int CoreDamageType;

    public void Start()
    {
        if (transform.parent.parent.GetComponent<DamageFlash>() != null)
        {

            DamageFlash = transform.parent.parent.GetComponent<DamageFlash>();
        }
    }
    public void Damage(float damageAmount, int damageType)
    {
        if (CoreHealth > 0)
        {
            if (transform.parent.parent.GetComponent<DamageFlash>() != null)
            {
                DamageFlash.Flash();
            }
        }

        //Debug.Log(core.transform.parent.name + "Damaged!");
        //Debug.Log(damageType);
        Damaged = true;
        CoreDamageType = damageType;

        Invoke("DamageFalse", 0.3f);    //This might lead to future problems, this could be the resistant timer?
        if (Blocking)
        {
            CoreHealth -= damageAmount * 0.5f; //reduces damage by 50%
        }
        else
        {
            CoreHealth -= damageAmount;
        }
        
        //CoreHealthBar.SetHealth(CoreHealth);      //If there is a health bar, make the health bar visibly reduce
    }

    public void Knockback(float strength, Vector2 angle, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
    }

    private void DamageFalse()
    {
        Damaged = false;
        Debug.Log("hey");
    }
}
