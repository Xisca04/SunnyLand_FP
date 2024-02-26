using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreUI : MonoBehaviour
{
    // UI Score
    public static ScoreUI Instance { get; private set; }  // Singleton

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance Score UI");
        }

        Instance = this;
        
        // We subscribe a method to the event that we've created
        Score.OnHighScoreChange += Score_OnHighScoreChange;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScoreText()
    {
        int highScore = Score.GetHighScore();
        highScoreText.text = highScore.ToString();
    }

    private void OnDisable()  // Unsuscribe a method to the event
    {
        Score.OnHighScoreChange += Score_OnHighScoreChange;
    }

    private void Score_OnHighScoreChange(object sender, EventArgs e)
    {
        // When we call the event the high score will be updated
        UpdateHighScoreText();
    }

}
