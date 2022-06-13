using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Ravager : BaseEnemy 
{ 
    //public override void Awake()
    //{
    //    base.Awake();
    //}

    //private void Start()
    //{

    //}
    //public override void Update()
    //{
    //    base.Update();
    //}

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        //Gizmos.DrawWireSphere(meleeAttackPosition.position, enemyMeleeAttackData.attackRadius);
    }
}
