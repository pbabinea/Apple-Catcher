using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //begin game for main menu button
    public void BeginGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //return to main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //unpause from pause menu
    public void Unpause()
    {
        Manager.instance.UnpauseGame();
    }
}
