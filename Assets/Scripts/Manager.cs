using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    private bool isPaused = false;
    public GameObject player;
    public GameObject generator;
    public GameObject bush;

    private Manager() { }

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        if (instance)
            Destroy(gameObject);
        else 
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //use esc to pause/unpause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
                isPaused = false;
            }
        }
    }

    //pause game and load pause menu
    void PauseGame()
    {
        Debug.Log("pause");
        Time.timeScale = 0;
        isPaused = true;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
    //unpause and return to game
    public void UnpauseGame()
    {
        Debug.Log("unpause");
        SceneManager.UnloadSceneAsync("PauseMenu");
        isPaused = false;
        Time.timeScale = 1;
    }
    //end the game
    public void EndGame(int finalScore)
    {
        PlayerPrefs.SetInt("finalScore", finalScore);
        int highscore = PlayerPrefs.GetInt("highscore");
        if (finalScore > highscore)
            PlayerPrefs.SetInt("highscore", finalScore);
        SceneManager.LoadScene("GameOver");
    }
}
