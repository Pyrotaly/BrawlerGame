using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ZoneDamage : MonoBehaviour
{
    public D_ZoneDamageStats DamageData;
    #region Damage/KnockBack
    private List<IDamageable> detectedDamageable = new List<IDamageable>(); //should this be private or public
    private List<IKnockable> detectedKnockable = new List<IKnockable>();

    private void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        IKnockable knockable = collision.GetComponent<IKnockable>();

        if (damageable != null)
        {
            detectedDamageable.Add(damageable);
        }

        if (knockable != null)
        {
            detectedKnockable.Add(knockable);
        }
    }

    private void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        IKnockable knockable = collision.GetComponent<IKnockable>();

        if (damageable != null)
        {
            //Debug.Log("RemovedFromList");
            detectedDamageable.Remove(damageable);
        }

        if (knockable != null)
        {
            detectedKnockable.Remove(knockable);    
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)  //if collider of this object collides with another collider    
    {
        AddToDetected(collision);
    }
    //These trigger functions bsasically add and remove stuff from the list
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }

    public void DealDamage()
    {
        foreach (IDamageable item in detectedDamageable.ToList())
        {
            item.Damage(DamageData.Damage, DamageData.DamageType);
        }

        foreach (IKnockable item in detectedKnockable.ToList())
        {
            item.Knockback(DamageData.XDistance, DamageData.Angle, 0);
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
