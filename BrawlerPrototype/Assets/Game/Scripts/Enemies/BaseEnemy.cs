using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class BaseEnemy : MonoBehaviour
{
    public BehaviourTree Tree;
    private readonly float positionUpdateFrequency = 0.1f;
    [HideInInspector] private Transform target;                     //COULD BE AN ERROR OF NOT GETTING PLAYER IN FUTURE
    [HideInInspector] public Vector3 PlayerPosition;
    [SerializeField] private Transform playerDistanceRayPosition;   //Where the ray that checks player is located on enemy
    [SerializeField] private Transform playerMediumDistanceRayPosition;
    [SerializeField] public D_BaseEnemy BaseData;

    [Header("Combat")]
    [SerializeField] public Transform meleeAttackPosition;
    [HideInInspector] public int EnemyDamageType;
    [HideInInspector] public int DamagedType;                       //When enemy is damaged, this int determines what damage type the damage dealt was
    [HideInInspector] public float EnemyHealth;
    [HideInInspector] public bool AnimationDone;                    //USED IN NODES BUT COULD BE REMOVED LATER
    public bool Flying;

    public HealthBar EnemyHealthBar;
    //public AnimatorControllerParameter[] parameters;              This is to set animators to be false by brute force
    public Animator Anim { get; private set; }
    public Core Core { get; private set; }
    public bool Damaged { get; private set; }                       //Used in Core

    private float dirNum;                                           //It is used in Update
    public int TestDirection;
    protected bool canFlip;

    [Header("Combat")]
    public GameObject[] EnemyProjectiles;
    public Transform[] EnemyRangeAttackStartingPosition;

    [Header("Data")]
    public D_LightAttacks EnemyLightAttackData;
    public D_HeavyAttacks EnemyHeavyAttackData;

    [HideInInspector] public float[] EnemyNextLightAttack = new float[10];
    [HideInInspector] public float[] EnemyNextHeavyAttack = new float[10];

    [HideInInspector] public float[] EnemyLightCooldowns = new float[10];           //Currently, array is set to 10 but might need to change in the future
    [HideInInspector] public float[] EnemyChargedLightCooldowns = new float[10];
    [HideInInspector] public float[] EnemyHeavyCooldowns = new float[10];
    [HideInInspector] public float[] EnemyChargedHeavyCooldowns = new float[10];

    [HideInInspector] public bool[] EnemyCanLightAttack = new bool[10];
    [HideInInspector] public bool[] EnemyCanHeavyAttack = new bool[10];
    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        Anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Tree.Bind(Core, this, Anim);                                //Gets access to the data script
        Tree = Tree.Clone();                                        //Duplicates behavior tree if another script has the exact same MovementTree
    }

    public virtual void Start()
    {
        TestDirection = 1;
        Core.Combat.CoreHealth = BaseData.MaxHealth;
        EnemyHealthBar.SetMaxHealth(BaseData.MaxHealth);

        for (int i = 0; i < EnemyLightAttackData.LightAttackDetails.Length; i++) //These should be the same length for all data types
        {
            EnemyLightCooldowns[i] = EnemyLightAttackData.LightAttackDetails[i].BasicCooldown;
            EnemyChargedLightCooldowns[i] = EnemyLightAttackData.LightAttackDetails[i].ChargedCooldown;

            EnemyHeavyCooldowns[i] = EnemyHeavyAttackData.HeavyAttackDetails[i].BasicCooldown;
            EnemyChargedHeavyCooldowns[i] = EnemyHeavyAttackData.HeavyAttackDetails[i].ChargedCooldown;
        }
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        EnemyHealth = Core.Combat.CoreHealth;

        InvokeRepeating("CheckPositions", 0f, positionUpdateFrequency); //This is used in movement nodes

        if (Tree)
        {
            Tree.Update();
        }

        //Debug.Log("Close" + CheckPlayerInCloseRange());
        //Debug.Log("Medium" + CheckPlayerInMediumRange());

        //DyingManagement
        //if (EnemyHealth <= 0)
        //{
        //    foreach (AnimatorControllerParameter parameter in Anim.parameters)
        //    {
        //        if (parameter.name == "Die")
        //        {
        //            Anim.SetBool(parameter.name, true);
        //            Debug.Log("DeadOK");
        //        }
        //        else
        //        {
        //            Anim.SetBool(parameter.name, false);
        //        }
        //    }
        //}

        #region DamageManagement
        if (Core.Combat.Damaged == true)
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
            canFlip = false;
        }
        else
        {
            canFlip = true;
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
        if (dir > 0f && canFlip)
        {
            Core.Movement.RB2D.transform.Rotate(0.0f, 0.0f, 0.0f);
            return 1f;
        }
        else if (dir < 0f && canFlip)
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
        return Physics2D.Raycast(playerDistanceRayPosition.position, transform.right, BaseData.CheckTouchingBorderRange, BaseData.WhatIsBorder);
    }

    public virtual bool CheckPlayerInCloseRange()         
    {
        return Physics2D.Raycast(playerDistanceRayPosition.position, transform.right, BaseData.CheckPlayerInCloseRange, BaseData.WhatIsPlayer);
    }

    public virtual bool CheckPlayerInMediumRange()
    {
        return Physics2D.Raycast(playerMediumDistanceRayPosition.position, transform.right, BaseData.CheckPlayerInMediumRange, BaseData.WhatIsPlayer);
    }

    public virtual bool CheckPlayerInLongRange()
    {
        return Physics2D.Raycast(playerMediumDistanceRayPosition.position, transform.right, BaseData.CheckPlayerInLongRange, BaseData.WhatIsPlayer);
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
        AnimationDone = true;
        canFlip = true;
    }

    #region HeavyAttacks
    public virtual void HeavyAttackDamageTrigger()
    {

    }

    public virtual void HeavyAttackAnimationTrigger()
    {

    }

    public virtual void DownHeavyAttackDamageTrigger()
    {

    }

    public virtual void DownHeavyAttackAnimationTrigger()
    {

    }
    public virtual void UpHeavyAttackDamageTrigger()
    {

    }

    public virtual void UpHeavyAttackAnimationTrigger()
    {

    }

    public virtual void DashHeavyAttackDamageTrigger()
    {

    }

    public virtual void DashHeavyAttackAnimationTrigger()
    {

    }

    public virtual void AirHeavyAttackDamageTrigger()
    {

    }

    public virtual void AirHeavyAttackAnimationTrigger()
    {

    }

    public virtual void AirDownHeavyAttackDamageTrigger()
    {

    }

    public virtual void AirDownHeavyAttackAnimationTrigger()
    {

    }

    public virtual void AirUpHeavyAttackDamageTrigger()
    {

    }

    public virtual void AirUpHeavyAttackAnimationTrigger()
    {

    }

    public virtual void AirDashHeavyAttackDamageTrigger()
    {

    }

    public virtual void AirDashHeavyAttackAnimationTrigger()
    {

    }
    #endregion

    #region LightAttacks
    public virtual void LightAttackDamageTrigger()
    {

    }

    public virtual void LightAttackAnimationTrigger()
    {

    }

    public virtual void DownLightAttackDamageTrigger()
    {

    }

    public virtual void DownLightAttackAnimationTrigger()
    {

    }
    public virtual void UpLightAttackDamageTrigger()
    {

    }

    public virtual void UpLightAttackAnimationTrigger()
    {

    }

    public virtual void DashLightAttackDamageTrigger()
    {

    }

    public virtual void DashLightAttackAnimationTrigger()
    {

    }

    public virtual void AirLightAttackDamageTrigger()
    {

    }

    public virtual void AirLightAttackAnimationTrigger()
    {

    }

    public virtual void AirDownLightAttackDamageTrigger()
    {

    }

    public virtual void AirDownLightAttackAnimationTrigger()
    {

    }

    public virtual void AirUpLightAttackDamageTrigger()
    {

    }

    public virtual void AirUpLightAttackAnimationTrigger()
    {

    }

    public virtual void AirDashLightAttackDamageTrigger()
    {

    }

    public virtual void AirDashLightAttackAnimationTrigger()
    {

    }
    #endregion
    #endregion

    //Checks where the player is, used in BehaviorTree moving
    public void CheckPositions()
    {
        PlayerPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
    public void TurnOffAnimationDone()
    {
        AnimationDone = false;
    }
    public void Die()
    {
        Destroy(this);
    }

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
            Gizmos.DrawWireSphere(playerMediumDistanceRayPosition.position + (Vector3)(Vector2.right * BaseData.CheckPlayerInMediumRange), 0.2f); //8
            Gizmos.color = Color.white; // long Range
            Gizmos.DrawWireSphere(playerDistanceRayPosition.position + (Vector3)(Vector2.right * BaseData.CheckPlayerInLongRange), 0.2f); // 7

            Gizmos.color = Color.cyan; // melee range
            Gizmos.DrawLine(playerDistanceRayPosition.position, playerDistanceRayPosition.position +
                (Vector3)(Vector2.right * BaseData.CheckPlayerInMeleeRange));

            Gizmos.color = Color.black; // BorderTouchingRange
            Gizmos.DrawLine(playerDistanceRayPosition.position, playerDistanceRayPosition.position +
                (Vector3)(Vector2.right * BaseData.CheckTouchingBorderRange)); 

            Gizmos.color = Color.red; //ground check
            Gizmos.DrawWireSphere(Core.CollisionSenses.GroundCheck.position, (4)); //baseData.groundCheckRadius
        }
    }
}