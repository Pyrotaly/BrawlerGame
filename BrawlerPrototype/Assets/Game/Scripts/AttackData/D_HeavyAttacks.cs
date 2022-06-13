using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHeavyAttackData", menuName = "Data/Heavy Attack Data")]
public class D_HeavyAttacks : ScriptableObject
{
    [SerializeField] public S_AttackDetails[] HeavyAttackDetails;
}
