using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {   
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); //The string is name of scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
