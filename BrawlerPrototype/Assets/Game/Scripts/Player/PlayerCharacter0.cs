using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter0 : BaseCharacter
{
    protected override void Awake()
    {
        base.Awake();

        Light = new LightAttackState(playerX, "Attack", LightAttackData);
        DownLight = new Char0DownLightAttackState(playerX, "DownAttack", LightAttackData);
        UpLight = new UpLightAttackState(playerX, "UpAttack", LightAttackData);

        AirLight = new AirLightAttackState(playerX, "AirAttack", LightAttackData);
        AirDownLight = new Char0AirDownLightAttackState(playerX, "AirDownAttack", LightAttackData);

        LightCharged = new Char0LightChargedAttackState(playerX, "AttackCharged", HeavyAttackData);
        DownCharged = new Char0DownChargedAttackState(playerX, "DownCharged", HeavyAttackData);  

        DashAttack = new DashAttackState(playerX, "DashAttack", LightAttackData);
    }
}
