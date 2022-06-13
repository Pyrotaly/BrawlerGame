using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newProjectileStats", menuName = "Data/ProjectileStats")]
public class D_ProjectileStats : ScriptableObject
{
    //public GameObject projectile;
    public float projectileDamage = 10f;
    public float projectileSpeed = 12f; 
    public float projectileTravelDistance;
}