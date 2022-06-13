using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockable 
{
    void Knockback(float strength, Vector2 angle, int direction);
}

