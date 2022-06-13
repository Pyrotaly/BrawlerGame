using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    #region Check Transforms
    public Transform GroundCheck { get => groundCheck; private set => GroundCheck = value; }
    public Transform WallCheck { get => wallCheck; private set => WallCheck = value; }
    public Transform LedgeCheck { get => ledgeCheck; private set => LedgeCheck = value; }
    #endregion

    public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }                  //In bardent, vertical is enemy check
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField]
    private Transform groundCheck, wallCheck, ledgeCheck;

    public bool ledgeTouch;
    public bool wallTouch;

    public bool LedgeFront()
    {
        RaycastHit2D ledgeHit = Physics2D.Raycast(ledgeCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
        if (ledgeHit.collider != null)
        {
            ledgeTouch = true;
        }
        else
        {
            ledgeTouch = false;
        }
        return ledgeTouch;
    }

    public bool WallFront()
    {
        RaycastHit2D wallHit = Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
        if (wallHit.collider != null)
        {
            wallTouch = true;
        }
        else
        {
            wallTouch = false;
        }
        return wallTouch;
    }

    public bool Ground
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    //public bool LedgeFront
    //{
    //    get => Physics2D.Raycast(ledgeCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    //}

    //public bool WallFront
    //{
    //    get => Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround); //Walls and terrain will be on ground Layer
    //}
}
