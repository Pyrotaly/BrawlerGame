using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : BaseEnemy
{
    private int direction; 
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }

    #region AnimationEvents

    #region AirDash
    public override void AirDashHeavyAttackAnimationTrigger()
    {
        base.AirDashHeavyAttackAnimationTrigger();
    }

    public override void AirDashHeavyAttackDamageTrigger()
    {
        base.AirDashHeavyAttackDamageTrigger();
    }

    public override void AirDashLightAttackAnimationTrigger()
    {
        base.AirDashLightAttackAnimationTrigger();
    }
    
    public override void AirDashLightAttackDamageTrigger()
    {
        base.AirDashLightAttackDamageTrigger();
    }
    #endregion

    #region AirDown
    public override void AirDownHeavyAttackAnimationTrigger()
    {
        base.AirDownHeavyAttackAnimationTrigger();
    }

    public override void AirDownHeavyAttackDamageTrigger()
    {
        base.AirDownHeavyAttackDamageTrigger();
    }

    public override void AirDownLightAttackAnimationTrigger()
    {
        base.AirDownLightAttackAnimationTrigger();
    }

    public override void AirDownLightAttackDamageTrigger()
    {
        base.AirDownLightAttackDamageTrigger();
    }
    #endregion

    #region AirAttack
    public override void AirHeavyAttackAnimationTrigger()
    {
        base.AirHeavyAttackAnimationTrigger();
    }

    public override void AirHeavyAttackDamageTrigger()
    {
        base.AirHeavyAttackDamageTrigger();
    }

    public override void AirLightAttackAnimationTrigger()
    {
        base.AirLightAttackAnimationTrigger();
    }

    public override void AirLightAttackDamageTrigger()
    {
        base.AirLightAttackDamageTrigger();
    }
    #endregion

    #region AirUp
    public override void AirUpHeavyAttackAnimationTrigger()
    {
        base.AirUpHeavyAttackAnimationTrigger();
    }

    public override void AirUpHeavyAttackDamageTrigger()
    {
        base.AirUpHeavyAttackDamageTrigger();
    }

    public override void AirUpLightAttackAnimationTrigger()
    {
        base.AirUpLightAttackAnimationTrigger();
    }

    public override void AirUpLightAttackDamageTrigger()
    {
        base.AirUpLightAttackDamageTrigger();
    }
    #endregion

    #region DashAttack
    public override void DashHeavyAttackAnimationTrigger()
    {
        base.DashHeavyAttackAnimationTrigger();
    }

    public override void DashHeavyAttackDamageTrigger()
    {
        base.DashHeavyAttackDamageTrigger();
    }

    public override void DashLightAttackAnimationTrigger()
    {
        base.DashLightAttackAnimationTrigger();
    }

    public override void DashLightAttackDamageTrigger()
    {
        base.DashLightAttackDamageTrigger();
    }
    #endregion

    #region DownAttack
    public override void DownHeavyAttackAnimationTrigger()
    {
        base.DownHeavyAttackAnimationTrigger();
    }

    public override void DownHeavyAttackDamageTrigger()
    {
        base.DownHeavyAttackDamageTrigger();

        if (transform.position.x < PlayerPosition.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        EnemyNextHeavyAttack[1] = Time.time + EnemyHeavyCooldowns[1];
        transform.position = new Vector3(transform.position.x + (35 * direction), transform.position.y, transform.position.z);
    }

    public override void DownLightAttackAnimationTrigger()
    {
        base.DownLightAttackAnimationTrigger();
    }

    public override void DownLightAttackDamageTrigger()
    {
        base.DownLightAttackDamageTrigger();
        Instantiate(EnemyProjectiles[3], PlayerPosition, EnemyRangeAttackStartingPosition[1].rotation);
        EnemyNextLightAttack[1] = Time.time + EnemyLightCooldowns[1];
    }
    #endregion

    #region Attack
    public override void HeavyAttackAnimationTrigger()
    {
        base.HeavyAttackAnimationTrigger();
    }

    public override void HeavyAttackDamageTrigger()
    {
        base.HeavyAttackDamageTrigger();
        canFlip = false; 
        Instantiate(EnemyProjectiles[1], EnemyRangeAttackStartingPosition[1].position, EnemyRangeAttackStartingPosition[1].rotation);
        EnemyNextHeavyAttack[0] = Time.time + EnemyHeavyCooldowns[0];
    }

    public override void LightAttackAnimationTrigger()
    {
        base.LightAttackAnimationTrigger();
    }

    public override void LightAttackDamageTrigger()
    {
        base.LightAttackDamageTrigger();

        Instantiate(EnemyProjectiles[0], EnemyRangeAttackStartingPosition[0].position, EnemyRangeAttackStartingPosition[0].rotation);
        EnemyNextLightAttack[0] = Time.time + EnemyLightCooldowns[0];

    }
    #endregion

    #region UpAttack
    public override void UpHeavyAttackAnimationTrigger()
    {
        base.UpHeavyAttackAnimationTrigger();
    }

    public override void UpHeavyAttackDamageTrigger()
    {
        base.UpHeavyAttackDamageTrigger();
    }

    public override void UpLightAttackAnimationTrigger()
    {
        base.UpLightAttackAnimationTrigger();
    }

    public override void UpLightAttackDamageTrigger()
    {
        base.UpLightAttackDamageTrigger();

        Instantiate(EnemyProjectiles[2], PlayerPosition, EnemyRangeAttackStartingPosition[0].rotation);
        EnemyNextLightAttack[2] = Time.time + EnemyLightCooldowns[2];
    }
    #endregion

    #endregion

    public override bool CheckTouchingBorder()
    {
        return base.CheckTouchingBorder();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
