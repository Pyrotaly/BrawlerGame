using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class BaseBoss : BaseEnemy
{
    [SerializeField] private BehaviourTree EnemyTree;

    [HideInInspector] public float[] EnemyNextLightAttack = new float[10];
    [HideInInspector] public float[] EnemyNextHeavyAttack = new float[10];

    [HideInInspector] public float[] EnemyLightCooldowns = new float[10];           //Currently, array is set to 10 but might need to change in the future
    [HideInInspector] public float[] EnemyChargedLightCooldowns = new float[10];

    protected override void Awake()
    {
        base.Awake();

        EnemyTree.Bind(Core, this, Anim);                            //Gets access to the data script
        EnemyTree = EnemyTree.Clone();                               //Duplicates behavior tree if another script has the exact same MovementTree
    }

    protected override void Start()
    {
        base.Start();

        for (int i = 0; i < EnemyLightData.LightAttackDetails.Length; i++) //These should be the same length for all data types
        {
            EnemyLightCooldowns[i] = EnemyLightData.LightAttackDetails[i].BasicCooldown;
            EnemyChargedLightCooldowns[i] = EnemyLightData.LightAttackDetails[i].ChargedCooldown;
        }
    }

    public override void Update()
    {
        base.Update();

        if (EnemyTree)
        {
            EnemyTree.Update();
        }
    }

    //Checks where the player is, used in BehaviorTree movement nodes
    public void CheckPositions()
    {
        PlayerPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
