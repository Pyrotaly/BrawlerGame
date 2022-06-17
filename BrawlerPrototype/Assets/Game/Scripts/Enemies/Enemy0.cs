using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : BaseEnemy
{
    private int direction; 
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }


    public override bool CheckTouchingBorder()
    {
        return base.CheckTouchingBorder();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
