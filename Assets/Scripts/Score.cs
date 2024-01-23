using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Score of the player

     private int score;

    // Score colectables
    public  const int GEM_SCORE = 100;
    public const int CHERRY_SCORE = 50;

    // Score enemies
    public const int EAGLE_SCORE = 150;
    public const int BAT_SCORE = 100;
    public const int VULTURE_SCORE = 100;
    public const int OPOSSUM_SCORE = 70;
    public const int PIG_SCORE = 70;
    public const int FROG_SCORE = 50;

    private void Start()
    {
        score = 0;
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        ScoreUI.Instance.UpdateScore(score);
    }
}
