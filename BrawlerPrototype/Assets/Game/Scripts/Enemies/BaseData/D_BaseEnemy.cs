using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBaseEnemyData", menuName = "Data/Enemy Base Data")]
public class D_BaseEnemy : ScriptableObject
{
    [Header("Combat")]
    public float MaxHealth = 30f;

    [Header("CheckDistances")]
    public float WallCheckDistance = 0.2f;
    public float LedgeCheckDistance = 0.4f;
    public float GroundCheckRadius = 0.3f;

    public float CheckPlayerInMeleeRange = 2f;
    public float CheckPlayerInCloseRange = 3f;
    public float CheckPlayerInMediumRange = 4f;
    public float CheckPlayerInLongRange = 4f;
    public float CheckTouchingBorderRange = 3f;
    public float CloseRangeActionDistance = 1f;

    [Header("LayerMask")]
    public LayerMask WhatIsGround;
    public LayerMask WhatIsPlayer;
    public LayerMask WhatIsBorder;

    [Header("HurtState")]
    public float FallVelocity;
    public float KnockUpVulnerabilityTime;

    [Header("MoveSpeed")]
    public float RunToMovementSpeed;
    public float RunFromMovementSpeed;
}
