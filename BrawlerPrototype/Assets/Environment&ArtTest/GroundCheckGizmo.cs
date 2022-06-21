using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckGizmo : MonoBehaviour
{
    [SerializeField]
    private Transform groundPosition;
    [SerializeField]
    private float boxLength;
    [SerializeField]
    private float boxHeight;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundPosition.position, new Vector2(boxLength, boxHeight));
    }
}
