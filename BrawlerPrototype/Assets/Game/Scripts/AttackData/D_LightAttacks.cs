using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLightAttackData", menuName = "Data/Light Attack Data")]
public class D_LightAttacks : ScriptableObject
{
    [SerializeField] public S_AttackDetails[] LightAttackDetails;
}
