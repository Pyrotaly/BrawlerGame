using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicGameManager : MonoBehaviour
{
    private bool gameHasEnded;
    public GameObject PlayerScreen, EnemyScreen;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
        }
    }

    public void EnemyWinsScreen()
    {
        EnemyScreen.SetActive(true);
    }

    public void PlayerWinsScreen()
    {
        PlayerScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
