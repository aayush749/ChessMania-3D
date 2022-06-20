using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScreenLoader : MonoBehaviour
{
    /**
     * Loads the main game screen. Uses "MainGame" string name to load the screen. Update this name if scene name is changed. 
     */
    public void LoadMainGameScreen()
    {
        Debug.Log("Loading Screen: MainScreen");
        SceneManager.LoadScene("MainGame");
    }

    /**
     * Quit the game
     */
    public void QuitGame()
    {
        Debug.Log("Quitting the game!");
        Application.Quit();
    }
}
