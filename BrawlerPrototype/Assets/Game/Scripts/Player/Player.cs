using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public BaseCharacter CharacterSelected;
    public HealthBar HealthBar;
    [HideInInspector] public float PlayerHealth;

    public float DashRate { get; private set; }
    [HideInInspector] public float NextDash;  

    [Header("GroundCheck")]
    public Transform feetPos;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isTouchingWall;

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerBlockState BlockState { get; private set; }
    public PlayerDieState DieState { get; private set; }
    public PlayerFallLandState FallLandState { get; private set; }
   
    public Core Core { get; private set; }
    public Animator AnimCombat { get; private set; }
    public PlayerInputController Input { get; private set; }
    public Rigidbody2D RB2D { get; private set; }
    public GameObject HitBox { get; private set; }

    [Header("Data")]
    [SerializeField] private PlayerData playerData;

    [HideInInspector]  public int AttackCounter;
    [HideInInspector]  public bool IsDashing;
    [HideInInspector]  public bool CanFlip;
    [HideInInspector]  public int CharacterNumber;

    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        
        if (GameObject.Find("PlayerCC") != null)
        {
            HitBox = GameObject.Find("PlayerCC");
        }

        StateMachine = new PlayerStateMachine();
        RB2D = GetComponent<Rigidbody2D>();
        Input = GetComponent<PlayerInputController>();
        AnimCombat = GameObject.Find("Sprites").GetComponent<Animator>();

        IdleState = new PlayerIdleState(this, "Idle");
        MoveState = new PlayerMoveState(this, "Move", playerData);
        JumpState = new PlayerJumpState(this, "Jump", playerData);
        FallState = new PlayerFallState(this, "Fall", playerData);
        DashState = new PlayerDashState(this, "Dash");
        BlockState = new PlayerBlockState(this, "Block");
        DieState = new PlayerDieState(this, "Die");
        FallLandState = new PlayerFallLandState(this, "FallLand");

        if(gameObject.GetComponent("PlayerCharacter0") != null)
        {
            CharacterSelected = GetComponent<PlayerCharacter0>();
            CharacterNumber = 0;
        }
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
        DashRate = 1.5f;
        NextDash = 0f;

        AttackCounter = 0;

        Core.Combat.CoreHealth = playerData.MaxHealth;
        HealthBar.SetMaxHealth(playerData.MaxHealth);
        //FMOD_Test.PlaySound("event:/Character/Door Close");          SoundManagerTesting
    }

    private void Update()   
    {
        //AnimCombat.SetInteger("attackCounter", AttackCounter);



        PlayerHealth = Core.Combat.CoreHealth;

        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundCheckRadius, whatIsGround);

        if (PlayerHealth <= 0)
        {
            FindObjectOfType<BasicGameManager>().EndGame();
            FindObjectOfType<BasicGameManager>().EnemyWinsScreen();
        }
        #region IFrame Management
        if (IsDashing)
        {
            HitBox.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            HitBox.GetComponent<BoxCollider2D>().enabled = true;
        }
        #endregion
    }

    private void FixedUpdate() 
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #region AnimationEvents
    public void AnimationTrigger()
    {
        StateMachine.CurrentState.AnimationTrigger();
    }

    public void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishedTrigger();
    }

    public void WeaponAnimationTrigger()
    {
        StateMachine.CurrentState.WeaponAnimationTrigger();
    }
    #endregion

    #region Damage/KnockBack
    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    private List<IKnockable> detectedKnockable = new List<IKnockable>();

    public void AddToDetected(Collider2D collision)
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

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        IKnockable knockable = collision.GetComponent<IKnockable>();

        if (damageable != null)
        {
            detectedDamageable.Remove(damageable);
        }

        if (knockable != null)
        {
            detectedKnockable.Remove(knockable);
        }
    }

    //Certain Frames will call this function and deal damage to all items in list
    public void CheckMeleeAttack(float weaponDamage, int damageType, float xDistance, Vector2 angle)  
    {
        foreach (IDamageable item in detectedDamageable.ToList())
        {
            item.Damage(weaponDamage, damageType);    //damage
        }

        foreach (IKnockable item in detectedKnockable.ToList())
        {
            item.Knockback(xDistance, angle, Input.direction); 
        }
    }
    #endregion


    //These trigger functions below detect whether or not two colliders contacted or left contact
    private void OnTriggerEnter2D(Collider2D collision)  
    {
        AddToDetected(collision);
    }
                                                        
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }
}