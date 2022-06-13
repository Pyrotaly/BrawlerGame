using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newProjectileStats", menuName = "Data/ZoneDamageStats")]
public class D_ZoneDamageStats : ScriptableObject
{
    public float Damage;
    public int DamageType;
    public float XDistance; //How far to push back
    public Vector2 Angle;
}
