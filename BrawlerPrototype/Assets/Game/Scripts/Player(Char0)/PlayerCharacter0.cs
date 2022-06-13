using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter0 : BaseCharacter
{
    //public float TestTime;

    public override void Awake()
    {
        base.Awake();

        Light = new LightAttackState(playerX, "Attack", LightAttackData);

        DownLight = new Char0DownLightAttackState(playerX, "DownAttack", LightAttackData);
        UpLight = new UpLightAttackState(playerX, "UpAttack", LightAttackData);
        DashLight = new DashLightAttackState(playerX, "DashAttack", LightAttackData);

        AirLight = new AirLightAttackState(playerX, "AirAttack", LightAttackData);
        AirDownLight = new AirDownLightAttackState(playerX, "AirDownAttack", LightAttackData);


        //Temporarily light charged attack versions
        Heavy = new Char0HeavyAttackState(playerX, "AttackCharged", HeavyAttackData);
        DownHeavy = new Char0DownHeavyAttackState(playerX, "DownCharged", HeavyAttackData);  //animBool is DownAttack before
        UpHeavy = new UpHeavyAttackState(playerX, "UpAttack", HeavyAttackData);
        DashHeavy = new DashHeavyAttackState(playerX, "DashAttack", HeavyAttackData);
    }

    //private void Start()   //Need to override?
    //{

    //}
}
