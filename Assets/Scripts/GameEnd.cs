using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int finalScore = PlayerPrefs.GetInt("finalScore");
        scoreText.text = "FINAL SCORE:\n " + finalScore;
        int highscore = PlayerPrefs.GetInt("highscore");
        if (finalScore > highscore)
            PlayerPrefs.SetInt("highscore", finalScore);
        highscoreText.text = "HIGH SCORE:\n " + highscore;
    }
}
