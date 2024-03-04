using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreUI : MonoBehaviour
{
    // UI Score
    public static ScoreUI Instance { get; private set; }  // Singleton

    // UI
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance Score UI");
        }

        Instance = this;
    }

    // Updates the text visually
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}