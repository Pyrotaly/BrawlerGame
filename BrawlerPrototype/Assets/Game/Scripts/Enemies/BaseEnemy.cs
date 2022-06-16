using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class BaseEnemy : MonoBehaviour
{

    [HideInInspector] private Transform target;                     //COULD BE AN ERROR OF NOT GETTING PLAYER IN FUTURE
    [HideInInspector] public Vector3 PlayerPosition;
    [SerializeField] private Transform playerDistanceRayPosition;   //Where the ray that checks player is located on enemy
    private readonly float positionUpdateFrequency = 0.1f;          //Checks player position every given interval instead of every update

    [SerializeField] public D_BaseEnemy BaseData;
    [SerializeField] private BehaviourTree EnemyTree;

    public Animator Anim { get; private set; }
    public Core Core { get; private set; }
    public bool Damaged { get; private set; }                       //Used in Core

    private float timeStamp;

    private float dirNum;                                           //It is used in Update
    public int TestDirection;
    public bool CanFlip;

    [Header("Combat")]
    [SerializeField] public Transform meleeAttackPosition;
    [HideInInspector] public int DamagedType;                       //When enemy is damaged, this int determines what damage type the damage dealt was
    [HideInInspector] public float EnemyHealth;
    public GameObject[] EnemyProjectiles;
    public Transform[] EnemyRangeAttackStartingPosition;
    public bool Flying;                                             //Planning on flying enemies in the future

    [Header("Data")]
    public D_LightAttacks EnemyLightAttackData;

    [HideInInspector] public float[] EnemyNextLightAttack = new float[10];
    [HideInInspector] public float[] EnemyNextHeavyAttack = new float[10];

    [HideInInspector] public float[] EnemyLightCooldowns = new float[10];           //Currently, array is set to 10 but might need to change in the future
    [HideInInspector] public float[] EnemyChargedLightCooldowns = new float[10];    


    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        Anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        EnemyTree.Bind(Core, this, Anim);                            //Gets access to the data script
        EnemyTree = EnemyTree.Clone();                               //Duplicates behavior tree if another script has the exact same MovementTree
    }

    public virtual void Start()
    {
        Core.Combat.CoreHealth = BaseData.MaxHealth;
        Core.Movement.canKnockUp = true;

        for (int i = 0; i < EnemyLightAttackData.LightAttackDetails.Length; i++) //These should be the same length for all data types
        {
            EnemyLightCooldowns[i] = EnemyLightAttackData.LightAttackDetails[i].BasicCooldown;
            EnemyChargedLightCooldowns[i] = EnemyLightAttackData.LightAttackDetails[i].ChargedCooldown;
        }
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        EnemyHealth = Core.Combat.CoreHealth;

        InvokeRepeating("CheckPositions", 0f, positionUpdateFrequency); //This is used in movement nodes

        if (EnemyTree)
        {
            EnemyTree.Update();
        }

        #region DamageManagement
        if (Core.Combat.Damaged == true) //Struck by a non-knockup attack
        {

            if (Core.Combat.CoreDamageType != 2)
            {
                Damaged = true;
                DamagedType = Core.Combat.CoreDamageType;
            }
            else                //Struck by knockup
            {
                Damaged = true;
                Core.Movement.canKnockUp = false;
                timeStamp += Time.deltaTime;

                if (timeStamp >= BaseData.KnockUpVulnerabilityTime)
                {
                    Core.Movement.SetVelocityY(BaseData.FallVelocity);
                }

                if (Core.CollisionSenses.Ground)
                {
                    timeStamp = 0;
                    Damaged = false;
                    Core.Movement.canKnockUp = true;
                }
            }

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
            TestDirection = 1;
            return -1f;
        }
        else
        {
            Core.Movement.RB2D.transform.Rotate(0.0f, 0.0f, 0.0f);
            TestDirection = -1;
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

    //Checks where the player is, used in BehaviorTree movement nodes
    public void CheckPositions()
    {
        PlayerPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

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

            Gizmos.DrawWireSphere(meleeAttackPosition.position, EnemyLightAttackData.LightAttackDetails[0].DamageRadius);
        }
    }
}