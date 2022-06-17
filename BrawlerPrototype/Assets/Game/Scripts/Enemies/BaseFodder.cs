using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFodder : MonoBehaviour
{
    [Header("Player Targeting")]
    [SerializeField] private Transform target;
    [SerializeField] private float PositionUpdateFrequency;
    protected Vector3 playerPosition;

    //[SerializeField]
    //public D_EnemyMeleeAttack enemyMeleeAttackData;
}
