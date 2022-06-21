using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float MaxHealth = 100f;

    [Header("Move State")]
    public float MovementVelocity = 10f;
    public float AirVelocity = 0f;

    [Header("Jump State")]                  //Remove some values later
    public float JumpVelocity = 29f;
    public int AmountOfJumps = 1;
    public float JumpTime = 3.00f; //?
    //public float JumpResistance = 3.5f;

    [Header("Fall Force")]
    public float FallVelocity = 10f;
}
