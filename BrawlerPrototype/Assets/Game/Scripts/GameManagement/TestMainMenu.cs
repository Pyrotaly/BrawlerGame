using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game"); //The string is name of scene
    }

    public void QuitGame()
    {
        //Debug.Log("QUIT REMOVE ME LATER");
        Application.Quit();
    }
}