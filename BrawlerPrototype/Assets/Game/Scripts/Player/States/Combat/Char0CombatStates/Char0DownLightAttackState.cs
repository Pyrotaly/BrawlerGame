using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char0DownLightAttackState : DownLightAttackState
{
    private GameObject projectile;
    public Char0DownLightAttackState(Player player, string animBoolName, D_LightAttacks lightAttackData) : base(player, animBoolName, lightAttackData)
    {
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        player.Core.Movement.SetVelocityX(10 * player.Input.direction);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void WeaponAnimationTrigger()
    {
        base.WeaponAnimationTrigger();

        GameObject[] projectiles = player.CharacterSelected.Projectiles;
        projectile = GameObject.Instantiate(projectiles[0], player.CharacterSelected.RangeAttackStartingPosition[0].position, player.CharacterSelected.RangeAttackStartingPosition[0].rotation);
    }
}
