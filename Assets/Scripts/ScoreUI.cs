using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    // UI Score
    public static ScoreUI Instance { get; private set; }  // Singleton

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance Score UI");
        }

        Instance = this;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
