using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    // Countdown for the Final Level

    public static CountdownTimer Instance { get; private set; }  // Singleton

    // Timer
    public float timeLeft = 10f;
    private bool timerOn = false;
    public float timeToAdd = 5f;

    // UI
    [SerializeField] private TextMeshProUGUI timerText;

    // Reference
    [SerializeField] private GameOver _gameOver;


    private void Awake() // Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance Countdown Timer");
        }

        Instance = this;
    }

    private void Start()
    {
        timerOn = true;
    }

    private void Update()
    {
        CountDown();
    }

    private void CountDown() // Timer
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerText.text = "" + timeLeft.ToString("f0");
            }

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timerOn = false;
                _gameOver.GameOverLevels();
            }

            if (timeLeft < 5) // Turn to red the timer text
            {
                timerText.color = Color.red;
            }
        }
    }
}
