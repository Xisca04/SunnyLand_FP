using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score: MonoBehaviour
{
    // Score of the player

    private  int score;
    // Score colectables
    public const int GEM_SCORE = 100;
    public const int CHERRY_SCORE = 50;

    // Score enemies
    public const int ENEMY_HARD_SCORE = 150;
    public const int ENEMY_MEDIUM_SCORE = 70;
    public const int ENEMY_EASY_SCORE = 50;


    private void Start()
    {
        score = 0;
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Debug.Log($"{pointsToAdd}");
        ScoreUI.Instance.UpdateScore(score);
    }

    
}
