using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private BaseEnemy enemy;
    [SerializeField] private Transform borderLeftPosition;
    [SerializeField] private Transform borderRightPosition;
    [SerializeField] private Transform returnPosition1;
    [SerializeField] private Transform returnPosition2;

    void Update()
    {
        if (player.transform.position.x < borderLeftPosition.position.x)
        {
            Debug.Log("sAVEME");
            player.transform.position = returnPosition1.position;
        }

        if (player.transform.position.x > borderRightPosition.position.x)
        {
            Debug.Log("sAVEME");
            player.transform.position = returnPosition2.position;
        }

        if (enemy.transform.position.x < borderLeftPosition.position.x)
        {
            Debug.Log("sAVEME");
            player.transform.position = returnPosition1.position;
        }

        if (enemy.transform.position.x > borderRightPosition.position.x)
        {
            Debug.Log("sAVEME");
            player.transform.position = returnPosition2.position;
        }
    }
}
