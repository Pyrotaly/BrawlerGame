using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter0 : BaseCharacter
{
    public override void Awake()
    {
        base.Awake();

        Light = new LightAttackState(playerX, "Attack", LightAttackData);
        DownLight = new Char0DownLightAttackState(playerX, "DownAttack", LightAttackData);
        UpLight = new UpLightAttackState(playerX, "UpAttack", LightAttackData);

        AirLight = new AirLightAttackState(playerX, "AirAttack", LightAttackData);
        AirDownLight = new AirDownLightAttackState(playerX, "AirDownAttack", LightAttackData);

        LightCharged = new Char0HeavyAttackState(playerX, "AttackCharged", HeavyAttackData);
        DownCharged = new Char0DownHeavyAttackState(playerX, "DownCharged", HeavyAttackData);  

        DashLight = new DashLightAttackState(playerX, "DashAttack", LightAttackData);
    }
}
