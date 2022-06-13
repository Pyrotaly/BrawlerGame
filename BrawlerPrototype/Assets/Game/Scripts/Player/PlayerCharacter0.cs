using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter0 : BaseCharacter
{
    protected override void Awake()
    {
        base.Awake();

        Light = new LightAttackState(playerX, "Attack", LightAttackData);
        LightCharged = new Char0LightChargedAttackState(playerX, "AttackCharged", HeavyAttackData);
        DownLight = new Char0DownLightAttackState(playerX, "DownAttack", LightAttackData);
        DownCharged = new Char0DownChargedAttackState(playerX, "DownCharged", HeavyAttackData);

        UpLight = new UpLightAttackState(playerX, "UpAttack", LightAttackData);

        AirLight = new AirLightAttackState(playerX, "AirAttack", LightAttackData);
        AirDownLight = new Char0AirDownAttackState(playerX, "AirDownAttack", LightAttackData);
        //AirLightCharged = new AirLightChargedAttackState
        //AirDownCharged

        DashAttack = new DashAttackState(playerX, "DashAttack", LightAttackData);
    }
}
