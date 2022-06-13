using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCooldown : CoreComponent
{
    [SerializeField] private float BasicMeleeRate;
    private float NextBasicMeleeTime;

    [SerializeField] private float BasicRangeRate;
    private float NextBasicRangeTime;

    [SerializeField] private float OHKORate;
    private float NextOHKOTime;

    [SerializeField] private float HealRate;
    private float NextHealTime;

    [SerializeField] private float DodgeRate;
    private float NextDodgeTime;

    [SerializeField] private float FleeRate;
    private float NextFleeTime;

    #region CanBools
    public bool CanMeleeAttack()        //This is for nodes to see if on cooldown or not
    {
        if (Time.time >= NextBasicMeleeTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanRangeAttack()
    {
        if (Time.time >= NextBasicRangeTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanOHKO()
    {
        if (Time.time >= NextOHKOTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanFlee()
    {
        if (Time.time >= NextFleeTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region CooldownSetters
    public void MeleeAttackCooldownSet()       //This activates the cooldown
    {
        NextBasicMeleeTime = Time.time + BasicMeleeRate;
        //Debug.Log("EnemyCooldownSet");
    }

    public void RangeAttackCooldownSet()
    {
        NextBasicRangeTime = Time.time + BasicRangeRate;
    }

    public void OHKOAttackCooldownSet()
    {
        NextOHKOTime = Time.time + OHKORate;
    }

    public void FleeCooldownSet()
    {
        NextFleeTime = Time.time + FleeRate;
    }
    #endregion
}
