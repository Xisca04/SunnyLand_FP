using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public static class Score
{
    // Score of the player

    private static int score;
    public const string HIGH_SCORE = "highScore"; // Clave en PlayerPrefs
    // Score colectables
    public const int GEM_SCORE = 100;
    public const int CHERRY_SCORE = 50;

    // Score enemies
    public const int ENEMY_HARD_SCORE = 150;
    public const int ENEMY_MEDIUM_SCORE = 70;
    public const int ENEMY_EASY_SCORE = 50;

    public static event EventHandler OnHighScoreChange; // Event
    private static ScoreUI scoreUIScript;

    private static void Start()
    {
        score = 0;
    }

    public static void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Debug.Log($"{pointsToAdd}");
        ScoreUI.Instance.UpdateScore(score);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE, 0);
    }

    public static bool TrySetNewHighScore() // score = current puntuation
    {
        int highScore = GetHighScore();

        if (score > highScore)
        {
            // Modificamos el High Score
            PlayerPrefs.SetInt(HIGH_SCORE, score);
            PlayerPrefs.Save();

            if (OnHighScoreChange != null)
            {
                OnHighScoreChange(null, EventArgs.Empty);
            }

            return true;
        }

        return false;
    }

    public static void InitializeStaticScore()
    {
        OnHighScoreChange = null;
        score = 0;
        AddScore(0);
        ScoreUI.Instance.UpdateHighScoreText();
    }

    public static int GetScore()
    {
        return score;
    }

}
