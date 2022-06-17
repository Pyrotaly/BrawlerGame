using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class BaseEnemy : MonoBehaviour
{
    [Header("Player Targeting")]
    private readonly float positionUpdateFrequency = 0.1f;          //Checks player position every given interval instead of every update
    [HideInInspector] protected Transform target;                     //COULD BE AN ERROR OF NOT GETTING PLAYER IN FUTURE
    [HideInInspector] public Vector3 PlayerPosition;
    [SerializeField] private Transform playerDistanceRayPosition;   //Where the ray that checks player is located on enemy

    [Header("Combat")]
    public GameObject[] EnemyProjectiles;
    public Transform[] EnemyRangeAttackStartingPosition;
    [HideInInspector] public int DamagedType;                       //When enemy is damaged, this int determines what damage type the damage dealt was
    [HideInInspector] public float EnemyHealth;

    [Header("Data")]
    [SerializeField] public D_BaseEnemy BaseData;
    [SerializeField] public D_LightAttacks EnemyLightData;

    public Animator Anim { get; private set; }
    public Core Core { get; private set; }
    public bool Damaged { get; private set; }                       //Used in Core

    private float timeStamp;
    private float dirNum;                                           //It is used in Update
    [HideInInspector] public bool CanFlip;

    protected virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        Anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected virtual void Start()
    {
        Core.Combat.CoreHealth = BaseData.MaxHealth;
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        EnemyHealth = Core.Combat.CoreHealth;

        InvokeRepeating("CheckPositions", 0f, positionUpdateFrequency); //This is used in movement nodes

        #region DamageManagement
        if (Core.Combat.Damaged == true) //Struck by a non-knockup attack
        {
            Damaged = true;
            DamagedType = Core.Combat.CoreDamageType;
        }
        else
        {
            Damaged = false;
        }
        #endregion

        #region FlippingSpriteManager#1
        Vector3 heading = target.position - transform.position;
        dirNum = AngleDir(transform.forward, heading, transform.up);

        if (!Core.CollisionSenses.Ground)
        {
            CanFlip = false;
        }
        else
        {
            CanFlip = true;
        }
        #endregion
    }

    protected void FixedUpdate()
    {

    } 

    #region FlippingSpriteManager#2
    private float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {                                                           //The Vector3 fwd is from transform.forward
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);                      //1.The Dot product will determine float direction       
                                                                //2. The second variable "up" is vector where it casts a line and then it will be compared. 
                                                                //3. "up" is like a line above enemy, if player is on left side of line, a negative value.  If right side, positive value
        if (dir > 0f && CanFlip)
        {
            Core.Movement.RB2D.transform.Rotate(0.0f, 0.0f, 0.0f);
            return 1f;
        }
        else if (dir < 0f && CanFlip)
        {
            Core.Movement.RB2D.transform.Rotate(0.0f, 180.0f, 0.0f);
            return -1f;
        }
        else
        {
            Core.Movement.RB2D.transform.Rotate(0.0f, 0.0f, 0.0f);
            return 0f;
        }
    }
    #endregion

    #region DistanceChecks 
    public bool CheckPlayerAbove()
    {
        if (PlayerPosition.y > transform.position.y)
        {
            Debug.Log("Above me");
            return true;
        }
        else
        {
            return false;
        }
    } 
    public virtual bool CheckPlayerInMeleeRange()
    {
        return Physics2D.Raycast(playerDistanceRayPosition.position, transform.right, BaseData.CheckPlayerInMeleeRange, BaseData.WhatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRange()         
    {
        return Physics2D.Raycast(playerDistanceRayPosition.position, transform.right, BaseData.CheckPlayerInCloseRange, BaseData.WhatIsPlayer);
    }

    public virtual bool CheckPlayerInMediumRange()
    {
        return Physics2D.Raycast(playerDistanceRayPosition.position, transform.right, BaseData.CheckPlayerInMediumRange, BaseData.WhatIsPlayer);
    }

    public virtual bool CheckPlayerInLongRange()
    {
        return Physics2D.Raycast(playerDistanceRayPosition.position, transform.right, BaseData.CheckPlayerInLongRange, BaseData.WhatIsPlayer);
    }

    public virtual bool CheckTouchingBorder()
    {
        return Physics2D.Raycast(playerDistanceRayPosition.position, transform.right, BaseData.CheckTouchingBorderRange, BaseData.WhatIsBorder);
    }
    #endregion

    #region AnimationEvents
    public void AnimationTrigger()
    {
    }

    public void AnimationFinishTrigger()
    {
        CanFlip = true;
    }

    public virtual void AttackAnimationTrigger()
    {

    }
    #endregion


    public void Die()
    {
        Destroy(this);
    }

    //Allows checks to be visible 
    public virtual void OnDrawGizmos()
    {
        if (Core != null)
        {
            Gizmos.color = Color.red; //wall check
            Gizmos.DrawLine(Core.CollisionSenses.WallCheck.position, Core.CollisionSenses.WallCheck.position + 
                (Vector3)(Vector2.right * Core.Movement.FacingDirection * Core.CollisionSenses.WallCheckDistance));

            Gizmos.color = Color.blue; //min agro
            Gizmos.DrawWireSphere(playerDistanceRayPosition.position + (Vector3)(Vector2.right * BaseData.CheckPlayerInCloseRange), 0.2f); //6
            Gizmos.color = Color.yellow; //medium agro
            Gizmos.DrawWireSphere(playerDistanceRayPosition.position + (Vector3)(Vector2.right * BaseData.CheckPlayerInMediumRange), 0.2f); //8
            Gizmos.color = Color.white; // long Range
            Gizmos.DrawWireSphere(playerDistanceRayPosition.position + (Vector3)(Vector2.right * BaseData.CheckPlayerInLongRange), 0.2f); // 7

            Gizmos.color = Color.cyan; // melee range
            Gizmos.DrawLine(playerDistanceRayPosition.position, playerDistanceRayPosition.position +
                (Vector3)(Vector2.right * BaseData.CheckPlayerInMeleeRange));

            Gizmos.color = Color.black; // BorderTouchingRange
            Gizmos.DrawLine(playerDistanceRayPosition.position, playerDistanceRayPosition.position +
                (Vector3)(Vector2.right * BaseData.CheckTouchingBorderRange)); 

            Gizmos.color = Color.red; //ground check
            Gizmos.DrawWireSphere(Core.CollisionSenses.GroundCheck.position, (BaseData.GroundCheckRadius)); //baseData.groundCheckRadius

            //Attack Radius
            //Gizmos.DrawWireSphere(meleeAttackPosition.position, EnemyLightAttackData.LightAttackDetails[0].DamageRadius);
        }
    }
}