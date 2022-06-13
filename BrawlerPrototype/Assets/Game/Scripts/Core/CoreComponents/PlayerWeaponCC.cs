using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCC : CoreComponent, IDamageable
{
    public LayerMask damageAbles;
    public Transform tempSAPos;

    public void Damage(float damageAmount, int damageType)
    {
        Debug.Log(core.transform.parent.name + "Damaged!");
    }
}
