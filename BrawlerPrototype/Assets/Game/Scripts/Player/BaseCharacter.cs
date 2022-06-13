using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public Player playerX { get; private set; }

    public LightAttackState Light;

    public DownLightAttackState DownLight;
    public UpLightAttackState UpLight;
    public DashAttackState DashAttack;

    public AirLightAttackState AirLight;
    public AirDownLightAttackState AirDownLight;

    public HeavyAttackState LightCharged;
    public DownHeavyAttackState DownCharged;
    public UpHeavyAttackState UpCharged;

    [Header("Data")]
    public D_LightAttacks LightAttackData;
    public D_HeavyAttacks HeavyAttackData;

    public GameObject[] Projectiles;

    public Transform[] RangeAttackStartingPosition;

    [HideInInspector] public float[] NextLightAttack = new float[10];
    [HideInInspector] public float[] NextHeavyAttack = new float[10];

    [HideInInspector] public float[] CharacterLightCooldowns = new float[10]; //Currently, array is set to 10 but might need to change in the future
    [HideInInspector] public float[] CharacterChargedLightCooldowns = new float[10];
    [HideInInspector] public float[] CharacterHeavyCooldowns = new float[10];
    [HideInInspector] public float[] CharacterChargedHeavyCooldowns = new float[10];

    protected virtual void Awake()
    {
        playerX = GetComponent<Player>();
    }

    private void Start() 
    {
        for (int i = 0; i < LightAttackData.LightAttackDetails.Length; i++) //There should be the same length for all data types
        {
            CharacterLightCooldowns[i] = LightAttackData.LightAttackDetails[i].BasicCooldown;
            CharacterChargedLightCooldowns[i] = LightAttackData.LightAttackDetails[i].ChargedCooldown;

            CharacterHeavyCooldowns[i] = HeavyAttackData.HeavyAttackDetails[i].BasicCooldown;
            CharacterChargedHeavyCooldowns[i] = HeavyAttackData.HeavyAttackDetails[i].ChargedCooldown;
        }
    }
}
