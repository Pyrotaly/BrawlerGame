using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
     }

    public CollisionSenses CollisionSenses
    {
        get => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }
    public Combat Combat
    {
        get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    public EnemyCooldown EnemyCooldown { get; private set; }

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Combat combat;
    //private EnemyCooldown enemyCooldown;

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Combat = GetComponentInChildren<Combat>();
        if (transform.parent.name != "Player")
        {
            EnemyCooldown = GetComponentInChildren<EnemyCooldown>();
        }
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}
